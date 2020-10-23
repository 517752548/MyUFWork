package com.imop.lj.gameserver.item;

import java.util.ArrayList;
import java.util.BitSet;
import java.util.Collection;
import java.util.Collections;
import java.util.EnumMap;
import java.util.List;
import java.util.Map;

import org.slf4j.Logger;

import com.google.common.collect.Maps;
import com.imop.lj.common.HeartBeatListener;
import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.ReasonDesc;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.RoleConstants;
import com.imop.lj.common.model.item.CommonItem;
import com.imop.lj.core.annotation.SyncIoOper;
import com.imop.lj.core.orm.DataAccessException;
import com.imop.lj.core.util.Assert;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.db.model.ItemEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.common.db.RoleDataHolder;
import com.imop.lj.gameserver.common.event.MainBagGetItemEvent;
import com.imop.lj.gameserver.common.event.MainBagRemoveItemEvent;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTaskExecutor;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTaskExecutorImpl;
import com.imop.lj.gameserver.common.msg.GCMessage;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.container.AbstractItemBag;
import com.imop.lj.gameserver.item.container.CommonBag;
import com.imop.lj.gameserver.item.container.PetEquipBag;
import com.imop.lj.gameserver.item.container.PetGemBag;
import com.imop.lj.gameserver.item.container.ShoulderBag;
import com.imop.lj.gameserver.item.container.SkillEffectItemBag;
import com.imop.lj.gameserver.item.container.StoreBag;
import com.imop.lj.gameserver.item.msg.GCBagUpdate;
import com.imop.lj.gameserver.item.msg.GCItemUpdateList;
import com.imop.lj.gameserver.item.msg.GCResetCapacity;
import com.imop.lj.gameserver.item.msg.ItemMessageBuilder;
import com.imop.lj.gameserver.item.operation.MoveItemOperation;
import com.imop.lj.gameserver.item.operation.MoveItemServicePool;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.mail.MailDef.MailType;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardParam;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;
import com.imop.lj.gameserver.trade.ITradable;

public class Inventory implements RoleDataHolder, HeartBeatListener {

	private static final Logger logger = Loggers.itemLogger;
	public static final int ITEM_INFO_TEMP_BAG = 1;
	public static final int TEMP_BAG_IS_ENOUGH = 2;

	/** 道具所属的玩家 */
	private final Human owner;

	/** 所有玩家包的表 */
	private EnumMap<BagType, CommonBag> bags;

	/** 所属玩家的所有武将背包的表 */
	private Map<Long, PetEquipBag> petBags;
	
	/** 所属玩家的所有宝石背包的表 */
	private Map<Long, PetGemBag> petGemBags;
	
	/** 加载后未通过校验的道具 */
	private List<Item> badItems;

	private BitSet noticeBitSet = new BitSet();
	
	/** 心跳任务处理器 */
	private HeartbeatTaskExecutor hbTaskExecutor;
	
	/** 打造装备检测器 */
	private CraftEquipNoticeChecker craftChecker;
	
	/**
	 * 缓存的道具更新的消息
	 */
	private List<CommonItem> cachedMsgList = new ArrayList<CommonItem>();

	public Inventory(Human owner) {
		this.owner = owner;
		bags = new EnumMap<BagType, CommonBag>(BagType.class);
		
		//主背包
		int primBagNum = getPrimBagNum();
		bags.put(BagType.PRIM, new ShoulderBag(owner, BagType.PRIM, primBagNum));
		this.owner.setPrimBagNum(primBagNum);
		
		//仓库
		int storeBagNum = getStoreBagNum();
		bags.put(BagType.STORE, new StoreBag(owner, BagType.STORE, storeBagNum));

		//XXX 仙符背包，看做主背包的一部分，和主背包同样处理
		int skillEffectBagNum = getSkillEffectBagNum();
		bags.put(BagType.SKILL_EFFECT_BAG, new SkillEffectItemBag(owner, BagType.SKILL_EFFECT_BAG, skillEffectBagNum));
		
		petBags = Maps.newHashMap();
		petGemBags = Maps.newHashMap();

		craftChecker = new CraftEquipNoticeChecker(this.owner);
		hbTaskExecutor = new HeartbeatTaskExecutorImpl();
		hbTaskExecutor.submit(new ItemExpireProcesser(this));
	}
	
	public int getPrimBagNum() {
		return RoleConstants.PRIM_BAG_CAPACITY_INI_NUM + owner.getHadOpenPrimBagNum();
	}
	
	public int getStoreBagNum() {
		return RoleConstants.STORE_BAG_CAPACITY_INI_NUM + owner.getStoreOpenNum() * RoleConstants.STORE_BAG_PAGE_NUM;
	}
	
	public int getSkillEffectBagNum() {
		return RoleConstants.SKILL_EFFECT_BAG_CAPACITY_INI_NUM;
	}

	/**
	 * 加载完宠物后初始化宠物装备包
	 * 
	 */
	public void initPetBags() {
		// TODO 武将要从petmanager获得
		for (Pet pet : this.owner.getPetManager().getAllPet()) {
			PetEquipBag secbag = new PetEquipBag(this.owner, pet);
			petBags.put(pet.getUUID(), secbag);
		}
	}
	
	/**
	 * 加载完宠物后初始化宠物装备包
	 * 
	 */
	public void initGemBags() {
		// TODO 武将要从petmanager获得
		for (Pet pet : this.owner.getPetManager().getAllPet()) {
			PetGemBag secbag = new PetGemBag(this.owner, pet);
			petGemBags.put(pet.getUUID(), secbag);
		}
	}
	
	/**
	 * 增加宠物装备包
	 * 
	 * @param owerPet
	 */
	public void addPetBag(Pet owerPet) {
		PetEquipBag petEquipBag = new PetEquipBag(this.owner, owerPet);
		petBags.put(owerPet.getUUID(), petEquipBag);
	}
	
	/**
	 * 增加宠物宝石包
	 * 
	 * @param owerPet
	 */
	public void addPetGemBag(Pet owerPet) {
		PetGemBag petGemBag = new PetGemBag(this.owner, owerPet);
		petGemBags.put(owerPet.getUUID(), petGemBag);
	}

	/**
	 * 删除宠物装备包
	 * 
	 * @param petUuid
	 */
	public void removePetBag(long petUuid) {
		petBags.remove(petUuid);
	}
	
	/**
	 * 删除宠物宝石包
	 * 
	 * @param petUuid
	 */
	public void removePetGemBag(long petUuid) {
		petGemBags.remove(petUuid);
	}

	/**
	 * 初始化玩家的背包,并加载玩家的道具
	 */
	@SyncIoOper
	public void load() {
		// 从数据库加载玩家道具,同步io操作
		loadAllItemsFromDB(this);
	}

	/**
	 * 从数据库中加载玩家的所有物品
	 * 
	 * @param taskInfo
	 */
	@SyncIoOper
	public void loadAllItemsFromDB(Inventory inventory) {
		Assert.notNull(inventory);
		long _charId = inventory.getOwner().getUUID();
		List<ItemEntity> items = null;
		try {
			items = Globals.getDaoService().getItemDao().getItemsByCharId(_charId);
			for (ItemEntity entity : items) {
				Item item = Item.buildFromItemEntity(entity, inventory.getOwner());
				if (item != null) {
					item.setInDb(true); // 从db中读出来的都在db中
					item.getLifeCycle().deactivate();
					if (item.validateOnLoaded(entity)) {
						inventory.putItem(item);
					} else {
						inventory.putBadItem(item);
					}
				}
			}
		} catch (DataAccessException e) {
			if (Loggers.itemLogger.isErrorEnabled()) {
				Loggers.itemLogger.error(LogUtils.buildLogInfoStr(inventory.getOwner().getUUID() + "", "从数据库中加载物品信息出错"), e);
			}
			return;
		}
	}

	public Human getOwner() {
		return owner;
	}

	@Override
	public void checkAfterRoleLoad() {
		// 将所有包裹里的道具设为active
		activeAllItems();
	}

	private void activeAllItems() {
		for (AbstractItemBag bag : bags.values()) {
			bag.activeAll();
		}
		for (PetEquipBag bag : petBags.values()) {
			bag.activeAll();
		}
		for (PetGemBag bag : petGemBags.values()) {
			bag.activeAll();
		}
		
	}

	@Override
	public void checkBeforeRoleEnter() {
	}

	@Override
	public void onHeartBeat() {
		this.hbTaskExecutor.onHeartBeat();
		//最后发道具更新的消息
		checkSendCachedMsg();
	}

	/**
	 * 获得背包,包含搜索宠物背包
	 * 
	 * @param bagType
	 * @param petId
	 * @return
	 */
	public AbstractItemBag getBagByType(BagType bagType, long wearerId) {
		AbstractItemBag bag = null;
		if (bagType == BagType.PET_EQUIP) {
			bag = this.petBags.get(wearerId);
		}else if (bagType == BagType.PET_GEM) {
			bag = this.petGemBags.get(wearerId);
		}else {
			bag = bags.get(bagType);
		}
		return bag;
	}
	
	public CommonBag getCommonBagByType(BagType bagType) {
		return bags.get(bagType);
	}

	/**
	 * 增加一个道具实例，一般用于在数据加载时相背包中添加数据
	 * 
	 * @param item
	 */
	public void putItem(Item item) {
		BagType bagType = item.getBagType();
		if (bags.containsKey(bagType)) {
			bags.get(bagType).putItem(item);
		} else if (bagType == BagType.PET_EQUIP) {
			PetEquipBag petBag = petBags.get(item.getWearerId());
			if (petBag != null) {
				petBag.putItem(item);
			} else {
				logger.error("武将背包没有找到wearerId:" + item.getWearerId() + " bag:" + item.getBagType() + " item:" + item.getTemplateId());
			}
		} else if (bagType == BagType.PET_GEM) {
			PetGemBag petGemBag = petGemBags.get(item.getWearerId());
			if (petGemBag != null) {
				petGemBag.putItem(item);
			} else {
				logger.error("宝石背包没有找到wearerId:" + item.getWearerId() + " bag:" + item.getBagType() + " item:" + item.getTemplateId());
			}
		}else {
			logger.error("不可以直接往此包中添加道具 bag:" + item.getBagType() + " item:" + item.getTemplateId());
		}
	}

	/**
	 * 在加载数据时，将未通过校验的item，使用此方法加入inventory
	 * 
	 * @param item
	 */
	public void putBadItem(Item item) {
		if (this.badItems == null) {
			badItems = new ArrayList<Item>();
		}
		badItems.add(item);
	}

	/**
	 * 获取所有主背包中的非空道具，其他背包的对应操作可以先得到背包再取得其中的物品
	 * 
	 * @return
	 */
	public Collection<Item> getAllPrimBagItems() {
		return this.bags.get(BagType.PRIM).getAll();
	}

	/**
	 * 向背包中增加指定的数量的道具,该方法给予道具空间不够则全部不给<br/>
	 * 
	 * 此方法是需要在已经计算好绑定状态后调用，此处不再计算绑定状态<br/>
	 * 
	 * 该接口是游戏中生成新道具的唯一接口，所有道具产生相关操作只能调用该接口进行处理
	 * 
	 * @param templateId
	 *            添加的道具模板ID
	 * @param count
	 *            添加的道具数
	 * @param reason
	 *            添加的原因
	 * @param detailReason
	 *            添加原因的详细说明（用于扩展reason，可无）
	 * @param needNotify
	 *            是否通知客户端"您或得了x个x"
	 * @param needRefeshBag
	 *            是否需要刷新整个背包
	 * @return 操作后需要跟新的Item列表
	 */
	public Collection<Item> addItem(int templateId, int count, ItemGenLogReason reason, String detailReason, boolean needNotify) {
		Collection<Item> updateList = this.addItem(templateId, count, reason, detailReason, needNotify, true, Currency.NULL, 0, 0);
		return updateList;
	}
	
//	/**
//	 * 添加物品,不向前端发送物品更新消息，由其它地方处理
//	 * 
//	 * @param templateId
//	 * @param count
//	 * @param reason
//	 * @param detailReason
//	 * @param needNotify
//	 * @return
//	 */
//	public Collection<Item> addItemNoSendMsg(int templateId, int count, ItemGenLogReason reason, String detailReason, boolean needNotify){
//		Collection<Item> updateList = this.addItem(templateId, count, reason, detailReason, needNotify, false);
//		this.sendTempBagNotice(needNotify);
//		return updateList;
//	}

	/**
	 * 发送临时背包相关提示
	 */
	public void sendTempBagNotice(boolean notice){
		if(notice){
			if(this.noticeBitSet.get(ITEM_INFO_TEMP_BAG)){
				this.owner.sendErrorMessage(LangConstants.ITEM_INOT_TEMP_BAG);
			}
			
			if(this.noticeBitSet.get(TEMP_BAG_IS_ENOUGH)){
				this.owner.sendErrorMessage(LangConstants.TEMP_BAG_IS_ENOUGH);
			}
		}
		
		this.noticeBitSet.clear();
	}
	/**
	 * 向背包中增加指定的数量的道具,该方法给予道具空间不够则全部不给<br/>
	 * 
	 * 此方法是需要在已经计算好绑定状态后调用，此处不再计算绑定状态<br/>
	 * 
	 * 该接口是游戏中生成新道具的唯一接口，所有道具产生相关操作只能调用该接口进行处理
	 * 
	 * @param templateId
	 *            添加的道具模板ID
	 * @param count
	 *            添加的道具数
	 * @param reason
	 *            添加的原因
	 * @param detailReason
	 *            添加原因的详细说明（用于扩展reason，可无）
	 * @param needNotify
	 *            是否通知客户端"您或得了x个x"
	 * @param sendMsg
	 *            是否向前端发送消息
	 * @return 操作后需要跟新的Item列表
	 */
	public Collection<Item> addItem(int templateId, int count, ItemGenLogReason reason, String detailReason, boolean needNotify, boolean sendMsg,
			Currency costedCurrency, long totalCost, long actualCost) {
		if (count <= 0) {
			return Collections.emptyList();
		}
		ItemTemplate tmpl = Globals.getItemService().getItemTempByTempId(templateId);
		if (tmpl == null) {
			Loggers.itemLogger.error(String.format("找不到道具 id=%d, roleId=%d", templateId, owner.getUUID()));
			return Collections.emptyList();
		}

		int originalNum = getItemCountByTmplId(templateId);
		int reportDelNum = 0;
		
		BagType bgType = tmpl.getBagType();
		Collection<Item> updatedItems = new ArrayList<Item>();
		
		//主背包、仙符包，同样处理
		if (bgType == BagType.PRIM || bgType == BagType.SKILL_EFFECT_BAG) {
			// 找到应该放入的包
			CommonBag bag = bags.get(bgType);

			// 检查是否有足够的空间存放，不做提示，提示需要请求者在调用此方法前作
			int primCanAdd = bag.getMaxCanAdd(tmpl);
			int primLeft = count - primCanAdd;
			reportDelNum = primLeft;
			if(primLeft <= 0){
				//如果主背包能放下物品则放进此物品
				updatedItems = bag.add(tmpl, count, reason, detailReason);
				Loggers.itemLogger.info("玩家放入 " + bgType + " 背包中=" + owner.getUUID() + ":" + owner.getName() + ":" + tmpl.getId() + ":" + count);
			}else{
				updatedItems = bag.add(tmpl, primCanAdd, reason, detailReason);
				Loggers.itemLogger.info("玩家放入 " + bgType + " 背包中=" + owner.getUUID() + ":" + owner.getName() + ":" + tmpl.getId() + ":" + primCanAdd);
				
				//记录丢弃物品日志
				Loggers.itemLogger.warn(bgType + " 背包已满，玩家物品转发邮件=" + owner.getUUID() + ":" + owner.getName() + ":" + tmpl.getId() + ":" + primLeft);
				
				//构建reward参数
				List<RewardParam> paramList = new ArrayList<RewardParam>();
				RewardParam rp = new RewardParam(RewardType.REWARD_ITEM, templateId, primLeft);
				paramList.add(rp);
				Reward reward = Globals.getRewardService().createRewardByFixedContent(getOwner().getCharId(),
						RewardReasonType.BAG_FULL_SEND_MAIL, paramList, "bagfull");
				//发带附件的邮件
				Globals.getMailService().sendSysMail(getOwner().getCharId(), MailType.SYSTEM, 
						Globals.getLangService().readSysLang(LangConstants.BAG_FULL_ITEM_SEND_MAIL_TITLE), 
						Globals.getLangService().readSysLang(LangConstants.BAG_FULL_ITEM_SEND_MAIL_CONTENT), 
						reward);
				
				//背包放不下的道具已经发邮件了，所以删除道具数量就为0了
				reportDelNum = 0;
			}
		} else {
			// 找到应该放入的包
			CommonBag bag = (CommonBag) bags.get(bgType);

			// 检查是否有足够的空间存放，不做提示，提示需要请求者在调用此方法前作
			if (bag.getMaxCanAdd(tmpl) < count) {
				return Collections.emptyList();
			}
			// 执行添加
			updatedItems = bag.add(tmpl, count, reason, detailReason);
		}
		
		// 更新客户端背包
		for (Item item : updatedItems) {
			if (sendMsg) {
//				GCMessage message = item.getUpdateMsgAndResetModify();
//				this.owner.sendMessage(message);
				item.updateItemWithCache();
			}
		}
		if (needNotify) {
			// 提示：您或得了x个x
			//XXX 先都注掉，客户端自己冒
//					owner.sendSystemMessage(LangConstants.GET_SOMETHING, count, TipsUtil.getItemNameByTemp(tmpl));
		}
		
		// 财务汇报
		Globals.getMoneyReportService().onAddItem(this.getOwner(), reason, templateId, count, originalNum, costedCurrency, totalCost, actualCost);
		// 进入临时背包或扔掉的道具算 删除道具
		if (reportDelNum > 0) {
			Globals.getEventService().fireEvent(new MainBagRemoveItemEvent(owner, tmpl, count));
			Globals.getMoneyReportService().onRemoveItem(this.getOwner(), ItemLogReason.PLAYER_DROP, templateId, reportDelNum);
			//记录丢弃日志
			Globals.getLogService().sendItemLog(getOwner(), ItemLogReason.PLAYER_DROP, "onAddNoSpaceDelete", 
					bgType.getIndex(), 0, templateId, "", 0, reportDelNum, "", new byte[0]);
		}
		
		//仿照之前的财务汇报，汇报热云，dataEye
		Globals.getReyunService().reportAddItem(getOwner().getPlayer(), templateId, count, reason.getReasonText());
		Globals.getDataEyeService().addItemLog(getOwner().getPlayer(), templateId, count, reason.getReasonText());
		if (reportDelNum > 0) {
			Globals.getReyunService().reportRemoveItem(getOwner().getPlayer(), templateId, reportDelNum, ItemLogReason.PLAYER_DROP.getReasonText());
			Globals.getDataEyeService().removeItemLog(getOwner().getPlayer(), templateId, count, ItemLogReason.PLAYER_DROP.getReasonText());
		}
		
		// 玩家主背包或卡牌包获得道具的事件触发
		if (bgType == BagType.PRIM || bgType == BagType.SKILL_EFFECT_BAG) {
			Globals.getEventService().fireEvent(new MainBagGetItemEvent(owner, tmpl, count));
		}
		
		return updatedItems;
	}

	/**
	 * 批量添加道具，这些道具需要时由于相同的原因添加的，要么全成功，要么全失败<br/>
	 * 此方法是需要在已经计算好绑定状态后调用，此处不再计算绑定状态
	 * 
	 * @param params
	 *            要新增道具参数，参数中的bindStatus是被忽略的，按照道具模板的bindMode规则进行绑定
	 * @param reason
	 *            添加的原因
	 * @param detailReason
	 *            添加原因的详细说明（用于扩展reason，可无）
	 * @param needNotify
	 *            是否通知客户端"您或得了x个x"
	 * @return 操作后需要跟新的Item列表
	 */
	public Collection<Item> addAllItems(Collection<ItemParam> params, ItemGenLogReason reason, String detailReason, boolean needNotify) {
		// 合并相同的参数，考虑绑定
		Collection<ItemParam> mergedParams = ItemParam.mergeByTmplId(params);
		List<Item> updateList = new ArrayList<Item>();
		//FIXME 如果有其他主背包可能会有物品丢弃的现象，目前只关心一个主背包  能全放下才放，这里只是做最后的校验，不提示，一般情况下在调用此方法前请求者已经检查过了空间
//		if (checkSpace(mergedParams, false)) {
		for (ItemParam param : mergedParams) {
			updateList.addAll(addItem(param.getTemplateId(), param.getCount(), reason, detailReason, needNotify));
		}
//		}
		this.sendTempBagNotice(needNotify);
		return updateList;
	}

	/**
	 * 检查背包是否能够放下params指定的所有道具，注意锁定了的道具不在考虑范围内
	 * 考虑新需求，如果主背包已经满，多余的物品放到临时背包中，所以此方法只有需要的时候调用
	 * 
	 * @param params
	 *            道具参数列表
	 * @param needNotice
	 *            是否需要提示，如果为true，在空间不足时会提示背包空间不足，同时提示每个包需要几个空位
	 * @return 全都能放下返回true，否则返回fasle
	 */
	public boolean checkSpace(Collection<ItemParam> params, boolean needNotice) {
		Collection<ItemParam> merged = ItemParam.mergeByTmplId(params);
		// 计算每个包需要几个槽位 key:格子类型，value:需要的槽位
		EnumMap<BagType, Integer> needSlotCounter = countNeedSlot(merged);
		boolean isSuccess = true;
		StringBuilder msgSb = new StringBuilder();
		for (Map.Entry<BagType, Integer> entry : needSlotCounter.entrySet()) {
			BagType bagType = entry.getKey();
			int needSlot = entry.getValue();
			CommonBag bag = (CommonBag) bags.get(bagType);
			if (bag.getEmptySlotCount() < needSlot) {
				// 空槽位比需要的少，放不下了
				isSuccess = false;
				if (needNotice) {
					String bagName = Globals.getLangService().readSysLang(bagType.getNameLangId());
					// {0}中需要{1}个空位
					msgSb.append(Globals.getLangService().readSysLang(LangConstants.ITEM_MAKE_SPACE, bagName, needSlot)).append(" ");
				} else {
					// 如果不需要通知，直接返回结果，如果需要通知，需要将所有的道具都检查一遍，统计出那个包需要多少个格子
					return isSuccess;
				}
			}
		}
		// 如果不能全放下，并且需要提示，提示空间不足，并指出哪个包需要几个空格
		if (!isSuccess && needNotice) {
			// 您的背包没有足够的空间
			owner.sendSystemMessage(LangConstants.ITEM_NOT_ENOUGH_SPACE);
			// 通知每个包需要多少个空位
			owner.sendSystemMessage(msgSb.toString());
			// //增加道具log
			//
			// logItem(owner,ItemLogReason.ITEM_NOT_ENOUGH_SPACE,ItemLogReason.ITEM_NOT_ENOUGH_SPACE.getReasonText()
			// ,0,0,0,"",0,1,"",DataType.obj2byte(msgSb)
			// );
		}
		return isSuccess;
	}

	/**
	 * 移动道具
	 * 
	 * @param fromBag
	 *            源包
	 * @param fromIndex
	 *            在源包中的索引
	 * @param toBag
	 *            目标包
	 * @param toIndex
	 *            在目标包中的索引
	 */
	public boolean moveItem(BagType fromBag, int fromIndex, BagType toBag, int toIndex, Pet wearer, long wearerId) {
		// TODO 检测状态冲突
		boolean result = false;
		// 没有移动直接返回
		if (fromBag == toBag && fromIndex == toIndex) {
			return result;
		}

		Item fromItem = getItemByIndex(fromBag, wearerId, fromIndex);
		Item toItem = getItemByIndex(toBag, wearerId, toIndex);
		if (Item.isEmpty(fromItem)) {
			// 源道具不可以是空格，目标道具可以是空格
			return result;
		}
		if (toItem == null) {
			// 这种toItem,肯定是有问题的,没有找到相应的bag,或者index
			if (Loggers.itemLogger.isWarnEnabled()) {
				Loggers.itemLogger
						.error(LogUtils.buildLogInfoStr(getOwner().getCharId() + "", String.format(
								"移动道具,目标不合法,fromBag=%s,fromIndex=%s,toBag=%s,toIndex=%s,index=%s", fromBag.index, fromIndex, toBag.index, toIndex,
								wearerId)));
				// //增加道具log
				// String content =
				// String.format(ItemLogReason.GET_SOMETHING.getReasonText(),
				// fromBag.index,fromIndex,toBag.index,toIndex,wearerId);
				// logItem(owner,ItemLogReason.ITEM_MOVETOITEM_ERROR,content
				// ,fromBag.index,fromIndex,toIndex,"",0,1,"",DataType.obj2byte(toBag)
				// );
			}
			return result; 
		}

		MoveItemOperation service = MoveItemServicePool.instance.get(fromBag, toBag);
		if (service == null) {
			// 没有合适的处理器，说明不允许这样移动
			owner.sendSystemMessage(LangConstants.MOVE_ITEM_FAIL);
			// //增加道具log
			// String content =
			// String.format(ItemLogReason.MOVE_ITEM_FAIL.getReasonText(),
			// fromBag.index,fromIndex,toBag.index,toIndex,wearerId);
			// logItem(owner,ItemLogReason.MOVE_ITEM_FAIL,content
			// ,fromBag.index,fromIndex,toIndex,"",0,1,"",DataType.obj2byte(toBag)
			// );
			return result;
		}
		if (wearer == null) {
			// 不涉及武将装备移动
			result = service.move(owner, fromItem, toItem);
		} else {
			result = service.move(owner, wearer, fromItem, toItem);
		}
		return result;
	}

	/**
	 * 查询某一道具在包里数量，不区分绑定状态，只在主背包、材料、任务三个包里面找，而不搜索身上的装备、仓库等
	 * 
	 * @param templateId
	 * @return
	 */
	public int getItemCountByTmplId(int templateId) {
		CommonBag bag = this.getBagByTemplateId(templateId);
		if (bag != null) {
			return bag.getCountByTmpId(templateId);
		} else {
			// 不在那三个包中视为没有
			return 0;
		}
	}

	/**
	 * 查询是否有template指定的那些道具，区别绑定状态<br/>
	 * 只在主背包、材料、任务三个包里面找，而不搜索身上的装备、 仓库等
	 * 
	 * @param templateId
	 * @param count
	 * @param bind
	 * @return
	 */
	public boolean hasItemByTmplId(int templateId, int count) {
		int gotCount = getItemCountByTmplId(templateId);
		return gotCount >= count;
	}

	/**
	 * 查询是否有params指定的那些道具，忽略绑定状态，即param中的bind属性被忽略，<br/>
	 * 只在主背包、材料、任务三个包里面找，而不搜索身上的装备、 仓库等
	 * 
	 * @param params
	 * @return
	 */
	public boolean hasItemsByParams(Collection<ItemParam> params) {
		Collection<ItemParam> merged = ItemParam.mergeByTmplId(params);
		for (ItemParam param : merged) {
			if (!hasItemByTmplId(param.getTemplateId(), param.getCount())) {
				return false;
			}
		}
		return true;
	}

//	/**
//	 * 查询在指定索引上是否有templateId指定的道具，忽略绑定状态<br/>
//	 * 只在主背包、材料、任务三个包里面找，而不搜索身上的装备、 仓库等
//	 * 
//	 * @param bag
//	 * @param index
//	 * @param templateId
//	 * @param count
//	 * @return
//	 */
//	public boolean hasItemByIndexAndTmplId(BagType bag, int index, int templateId, int count) {
//		return hasItemByIndex(bag, index, templateId, count);
//	}

//	/**
//	 * 查询在指定索引上是否有templateId指定的道具<br/>
//	 * 只在主背包、材料、任务三个包里面找，而不搜索身上的装备、 仓库等
//	 * 
//	 * @param bag
//	 * @param index
//	 * @param templateId
//	 * @param count
//	 * @param considerBind
//	 * @param bind
//	 * @return
//	 */
//	private boolean hasItemByIndex(BagType bag, int index, int templateId, int count) {
//		if (bag == null || bag == BagType.NULL) {
//			return false;
//		}
//		if (!AbstractItemBag.isPrimBag(bag)) {
//			return false;
//		}
//		// if (considerBind && bind == null) {
//		// return false;
//		// }
//		// 检测包格中物品数量是否够
//		AbstractItemBag aib = bags.get(bag);
//		Item item = aib.getByIndex(index);
//		if (Item.isEmpty(item)) {
//			return false;
//		}
//		if (item.getTemplateId() != templateId) {
//			return false;
//		}
//		// if (considerBind && item.getBindStatus() != bind) {
//		// return false;
//		// }
//		if (item.getOverlap() < count) {
//			return false;
//		}
//		return true;
//	}

	/**
	 * 移除一定数量的某种道具，要么全删，要么不删，只能移除主背包、材料包、任务道具包中的道具，区分绑定状态
	 * 
	 * @param <T>
	 * @param templateId
	 * @param count
	 * @param reason
	 * @return 移除了的Item
	 */
	public Collection<Item> removeItem(int templateId, int count, ItemLogReason reason, String detailReason) {
		return this.removeItem(templateId, count, reason, detailReason, true);
	}

	/**
	 * 移除一定数量的某种道具，要么全删，要么不删，只能移除主背包、材料包、任务道具包中的道具，区分绑定状态，是否通知客户物品刷新
	 * 
	 * @param templateId
	 * @param count
	 * @param reason
	 * @param detailReason
	 * @param nofityClient
	 * @return
	 */
	public Collection<Item> removeItem(int templateId, int count, ItemLogReason reason, String detailReason, boolean notifyClient) {
		CommonBag bag = this.getBagByTemplateId(templateId);
		if (bag == null) {
			return Collections.emptyList();
		}
		Collection<Item> updateList = bag.removeItem(templateId, count, reason, detailReason);
		if(notifyClient){
			// 通知客户端
			noticeClient(updateList);
		}
		// //增加道具log
		// String content =
		// String.format(ItemLogReason.ITEM_REMOVE_CONSIDERBIND.getReasonText(),
		// templateId,count);
		// logItem(owner,ItemLogReason.ITEM_REMOVE_CONSIDERBIND,content
		// ,bag.getEmptySlotCount(),bag.getCapacity(),templateId,"",count,1,"",DataType.obj2byte(bag)
		// );
		return updateList;
	}
	
	/**
	 * 移除params指定的所有道具，要么全删，要么不删，区分绑定状态
	 * 
	 * @return 所有移除了的Item
	 */
	public Collection<Item> removeItem(Collection<ItemParam> params, ItemLogReason reason, String detailReason) {
		Collection<ItemParam> merged = ItemParam.mergeByTmplId(params);
		// 全都有才能删
//		if (!hasItemsByParams(merged)) {
//			return Collections.emptyList();
//		}
		List<Item> deletedList = new ArrayList<Item>();
		for (ItemParam param : merged) {
			deletedList.addAll(removeItem(param.getTemplateId(), param.getCount(), reason, detailReason));
		}
		return deletedList;
	}

	/**
	 * 拆分道具
	 * 
	 * @param bagType
	 * @param index
	 * @param count
	 */
	public void splitItem(BagType bagType, int index, int count) {
		// 状态冲突检查

		// 只有主背包、材料包、任务道具包三个背包有拆分功能
		if (!AbstractItemBag.isPrimBag(bagType) && !AbstractItemBag.isStoreBag(bagType) && !AbstractItemBag.isSkillEffectBag(bagType)) {
			return;
		}
		CommonBag bag = (CommonBag) bags.get(bagType);
		// 检查道具状态是否为空，是否锁定等
		Item itemToSplit = bag.getByIndex(index);
		if (Item.isEmpty(itemToSplit)) {
			owner.sendSystemMessage(LangConstants.ITEM_CANNOT_SLIT);
			return;
		}

		Item emptyItem = bag.getEmptySlot();
		// 没有地方拆分
		if (emptyItem == null) {
			// 您的背包没有足够的空间
			owner.sendSystemMessage(LangConstants.ITEM_NOT_ENOUGH_SPACE);
			// //增加道具log
			// String content =
			// ItemLogReason.ITEM_NOT_ENOUGH_SPACE.getReasonText();
			// logItem(owner,ItemLogReason.ITEM_NOT_ENOUGH_SPACE,content
			// ,bagType.index,bagType.getIndex(),itemToSplit.getTemplateId(),"",count,LangConstants.ITEM_NOT_ENOUGH_SPACE,"",DataType.obj2byte(bag)
			// );
		}
		// 执行拆分
		List<Item> updateList = bag.split(index, count);
		// 更新客户端背包
		for (Item item : updateList) {
//			owner.sendMessage(item.getUpdateMsgAndResetModify());
			item.updateItemWithCache();
		}
	}

	/**
	 * 整理背包
	 * 
	 * @param bagType
	 */
	public void tidyBag(BagType bagType) {
		// 状态冲突检查

		// 主背包、材料包、任务道具包三个背包有整理功能
		// 仓库也有整理功能
		if (!AbstractItemBag.isPrimBag(bagType) && !AbstractItemBag.isStoreBag(bagType) && !AbstractItemBag.isSkillEffectBag(bagType)) {
			return;
		}

		CommonBag bag = (CommonBag) bags.get(bagType);

		bag.tidyUp();
		// 刷新背包信息
		GCMessage msg = null;
		switch (bagType) {
		case PRIM:
			msg = getPrimBagInfoMsg();
			break;
		case STORE:
			msg = getStoreBagInfoMsg();
			break;
		case SKILL_EFFECT_BAG:
			msg = getSkillEffectBagInfoMsg();
			break;
		default:
			break;
		}

		owner.sendMessage(msg);
	}

	/**
	 * 当指定位置的物品被删除后,重置对应位置的ItemInstance对象
	 * 
	 * @param bagType
	 *            包的类型
	 * @param index
	 *            包的索引位置
	 */
	public void resetAfterDel(BagType bagType, long wearerId, int index) {
		final AbstractItemBag bag = getBagByType(bagType, wearerId);
		final Item item = getItemByIndex(bagType, wearerId, index);
		if (item == null) {
			logger.error(String.format("背包中出现null的Item引用 bag=%s index=%d", bagType.name(), index));
			return;
		}
		Item resetItem = Item.newEmptyOwneredInstance(owner, bagType, index);
		bag.putItem(resetItem);
	}

	/**
	 * 丢弃道具
	 * 
	 * @param bagType
	 * @param index
	 */
	public boolean dropItem(BagType bagType, int index , ItemLogReason reason, String detailReason) {
		// 状态冲突检查
		Item droped = null;
		switch (bagType) {
		case PRIM:
		case SKILL_EFFECT_BAG:
			CommonBag bag = bags.get(bagType);
			Item raw = bag.getByIndex(index);
			int tplId = raw.getTemplateId();
			int overLap = raw.getOverlap();
			droped = bag.drop(index,reason,detailReason);
			bag.onChanged();
			Globals.getEventService().fireEvent(new MainBagRemoveItemEvent(owner, 
					Globals.getTemplateCacheService().get(tplId, ItemTemplate.class), overLap));
			// 财务汇报 主背包才汇报
			Globals.getMoneyReportService().onRemoveItem(this.owner, reason, tplId, overLap);
			break;
		case TEMP:
			CommonBag tempBag = bags.get(bagType);
			droped = tempBag.drop(index,reason,detailReason);
			tempBag.onChanged();
			break;
		case STORE:
			CommonBag storeBag = bags.get(bagType);
			droped = storeBag.drop(index,reason,detailReason);
			storeBag.onChanged();
			break;
		default:
			break;
		}

		if (droped != null) {
//			owner.sendMessage(droped.getUpdateMsgAndResetModify());
			droped.updateItemWithCache();
			return true;
		}
		return false;
	}

	/**
	 * 直接拾取道具1个实例，一般是有实例属性的最大叠加数未1的
	 * 
	 * @param item
	 *            道具实例，这里提供的实例时从ItemService中生成出来的，overlap为0，并且需要激活才可以用
	 * @param reason
	 *            原因
	 * @param detailReason
	 *            详细原因（可无）
	 * @param needNotify
	 *            是否通知客户端"您或得了x个x"
	 * @return 如果道具不存在或者放不下返回false，否则返回true
	 */
	public boolean giveOneItemInstance(Item item, ItemGenLogReason reason, String detailReason,  boolean needNotify) {
		ItemTemplate template = item.getTemplate();
		BagType bagType = template.getBagType();
		// 找到应该放入的包
		CommonBag bag = (CommonBag) bags.get(bagType);
		Item emptySlot = bag.getEmptySlot();
		if (emptySlot == null) {
			if (needNotify) {
				StringBuilder msgSb = new StringBuilder();
				String bagName = Globals.getLangService().readSysLang(bagType.getNameLangId());
				// {0}中需要{1}个空位
				msgSb.append(Globals.getLangService().readSysLang(LangConstants.ITEM_MAKE_SPACE, bagName, 1));
				// 您的背包没有足够的空间
				owner.sendSystemMessage(LangConstants.ITEM_NOT_ENOUGH_SPACE);
				// 通知每个包需要多少个空位
				owner.sendSystemMessage(msgSb.toString());

				// //增加道具log
				// String content =
				// ItemLogReason.ITEM_NOT_ENOUGH_SPACE.getReasonText();
				// logItem(owner,ItemLogReason.ITEM_NOT_ENOUGH_SPACE,content
				// ,bagType.index,bagType.getIndex(),item.getTemplateId(),"",1,LangConstants.ITEM_NOT_ENOUGH_SPACE,"",DataType.obj2byte(msgSb)
				// );
			}
			return false;
		}

		item.setBagType(emptySlot.getBagType());
		item.setIndex(emptySlot.getIndex());
		item.setOwner(owner);
		// 记录道具产生日志
		String genKey = KeyUtil.UUIDKey();
		try {
			// 增加物品增加原因到reasonDetail
			String countChangeReason = " [genReason:" + reason.getClass().getField(reason.name()).getAnnotation(ReasonDesc.class).value() + "] ";
			detailReason = detailReason == null ? countChangeReason : detailReason + countChangeReason;

			Globals.getLogService().sendItemGenLog(owner, reason, detailReason, template.getId(), template.getName(), 1, 0,
					item.toEntity().getProperties(), genKey);
		} catch (Exception e) {
			Loggers.itemLogger.error(LogUtils.buildLogInfoStr(owner.getUUID() + "", "记录直接拾取道具1个实例日志时出错"), e);
		}
		item.changeOverlap(1, ItemLogReason.COUNT_ADD, detailReason, genKey, true);
		item.getLifeCycle().activate();
		item.setModified();
		bag.putItem(item);
//		owner.sendMessage(item.getUpdateMsgAndResetModify());
		item.updateItemWithCache();
		
		if (needNotify) {
			// 提示：您或得了x个x
			owner.sendSystemMessage(LangConstants.GET_SOMETHING, 1, item.getName());

			// //增加道具log
			// String content =
			// String.format(ItemLogReason.GET_SOMETHING.getReasonText(), 1,
			// item
			// .getName());
			//
			// logItem(owner,ItemLogReason.GET_SOMETHING,content
			// ,bagType.index,bagType.getIndex(),item.getTemplateId(),item.getName(),1,1,reason.getReasonText(),DataType.obj2byte(bag)
			//
			// );
		}
		return true;
	}

	/**
	 * 物品数量变化时通知监听器 此处调用是较频繁的
	 * 
	 * @param templateId
	 */
	public void onItemCountChanged(final int templateId) {
		// 通知对包中道具数量变化感兴趣的监听器 TODO
//		try{
//			this.owner.getEquipUpgradeManager().onItemNumChange(templateId);
//		}catch(Exception ex){
//			Loggers.itemLogger.warn("Inventory,onItemCountChanged error", ex);
//		}
		
	}
	
	public Item getItemByUUIDForShow(String uuid) {
		Item result = null;
		//主背包
		for (CommonBag bag: this.bags.values()) {
			result = bag.getByUUID(uuid);
			if(result != null){
				return result;
			}
		}
		
		//主将身上
		if (getOwner().getPetManager() != null && getOwner().getPetManager().getLeader() != null) {
			PetEquipBag leaderBag = petBags.get(getOwner().getPetManager().getLeader().getUUID());
			result = leaderBag.getByUUID(uuid);
			if (result != null) {
				return result;
			}
		}
		
		return result;
	}

	/**
	 * 通过UUID查找一个道具，查找范围按顺序：主背包、身上、仓库、材料、任务。 此方法开销比较大，慎用
	 * 
	 * @param bag
	 * @param UUID
	 * @return
	 */
	public Item getItemByUUID(String UUID) {
		Item result = null;
		for(CommonBag bag: this.bags.values()){
			result = bag.getByUUID(UUID);
			if(result != null){
				return result;
			}
		}
		for (PetEquipBag petBag : petBags.values()) {
			result = petBag.getByUUID(UUID);
			if (result != null) {
				return result;
			}
		}
		
		for (PetGemBag petGemBag : petGemBags.values()) {
			result = petGemBag.getByUUID(UUID);
			if (result != null) {
				return result;
			}
		}
		return result;
	}

	/**
	 * 通过UUID查找一个道具，查找范围按顺序：主背包
	 * 
	 * @param bag
	 * @param UUID
	 * @return
	 */
	public ITradable<?> getItemByUUIDForTrade(String UUID) {
		Item result = null;
		for(CommonBag bag: this.bags.values()) {
			//只能卖主背包和仙符包的道具
			if (bag.getBagType() == BagType.PRIM || bag.getBagType() == BagType.SKILL_EFFECT_BAG) {
				result = bag.getByUUID(UUID);
				if(result != null){
					return result;
				}
			}
		}
		return result;
	}
	
	/**
	 * 通过索引取道具对象
	 * 
	 * @param bag
	 *            包id
	 * @param index
	 *            在包中的索引
	 * @return 如果包id或index不存在，返回null
	 */
	public Item getItemByIndex(BagType bagType, long wearerId, int index) {
		AbstractItemBag bag = getBagByType(bagType, wearerId);
		if (bag != null) {
			return bag.getByIndex(index);
		} else {
			return null;
		}
	}

	/**
	 * 按索引移除物品
	 * 
	 * @param bag
	 * @param index
	 * @param count
	 * @param reason
	 * @param detailReason
	 * @return
	 */
	public boolean removeItemByIndex(BagType bag, int index, int count, ItemLogReason reason, String detailReason) {
		return removeItemByIndex(bag, new int[] { index }, new int[] { count }, reason, detailReason);
	}

	/**
	 * 按指定索引数组移除所有的物品。 使用该方法时要注意：物品的堆叠数若小于要移除的物品数，则最多扣除堆叠的个数。
	 * <ul>
	 * <li>注：此处只能移除主背包、材料包和任务包的物品</li>
	 * </ul>
	 * 
	 * @param bag
	 * @param index
	 * @param count
	 * @param reason
	 * @param detailReason
	 * @return
	 */
	public boolean removeItemByIndex(BagType bag, int index[], int[] count, ItemLogReason reason, String detailReason) {
		if (bag == null || bag == BagType.NULL) {
			return false;
		}
		
		// 非卖出操作，检查是否主背包
		if (!AbstractItemBag.isPrimBag(bag) && !AbstractItemBag.isSkillEffectBag(bag)) {
			return false;
		}

		// 检测各个索引对应的包格中物品数量是否够
		AbstractItemBag aib = bags.get(bag);
		for (int i = 0; i < index.length; i++) {
			Item item = aib.getByIndex(index[i]);
			if (Item.isEmpty(item)) {
				if (Loggers.itemLogger.isWarnEnabled()) {
					Loggers.itemLogger.warn(String.format("Can't remove %d item,item is empty!", count[i]));
				}
				continue;
			}

			if (item.getOverlap() < count[i]) {
				count[i] = item.getOverlap();
				if (Loggers.itemLogger.isWarnEnabled()) {
					Loggers.itemLogger.warn(String.format("Can't remove %d item(%d),there are only %d items!", count[i], item.getTemplateId(),
							item.getOverlap()));
				}
			}
		}

		// 扣除物品
		for (int i = 0; i < index.length; i++) {
			Item item = aib.getByIndex(index[i]);
			if (!Item.isEmpty(item)) {
				int tplId = item.getTemplateId();
				item.changeOverlap(item.getOverlap() - count[i], reason, detailReason, item.getDbId(), true);
				
				//发消息通知前台
//				owner.sendMessage(item.getUpdateMsgAndResetModify());
				item.updateItemWithCache();
				
				Globals.getEventService().fireEvent(new MainBagRemoveItemEvent(owner, 
						Globals.getTemplateCacheService().get(tplId, ItemTemplate.class), count[i]));
				// 财务汇报
				Globals.getMoneyReportService().onRemoveItem(this.owner, reason, tplId, count[i]);
			}
		}
		return true;
	}
	
//	/**
//	 * 将所有需要存库的包裹中的item全都转成ItemEntity
//	 * 
//	 * @return
//	 */
//	public List<ItemEntity> toItemEntities() {
//		List<ItemEntity> entities = new ArrayList<ItemEntity>();
//		entities.addAll(primBag.toItemEntitys());
//		return entities;
//	}

	public List<Item> getBadItems() {
		return badItems;
	}

	public CommonBag getPrimBag() {
		return this.bags.get(BagType.PRIM);
	}
	
	public CommonBag getTempBag() {
		return this.bags.get(BagType.TEMP);
	}
	
	public CommonBag getStoreBag() {
		return this.bags.get(BagType.STORE);
	}
	
	public CommonBag getSkillEffectBag() {
		return this.bags.get(BagType.SKILL_EFFECT_BAG);
	}
	
	/**
	 * 生成主背包消息对象
	 * 
	 * @return
	 */
	public GCBagUpdate getPrimBagInfoMsg() {
		return ItemMessageBuilder.buildGCBagUpdate(this.bags.get(BagType.PRIM));
	}
	
//	public GCBagUpdate getTempBagInfoMsg() {
//		return ItemMessageBuilder.buildGCBagUpdate(this.bags.get(BagType.TEMP));
//	}
	
	public GCBagUpdate getStoreBagInfoMsg() {
		return ItemMessageBuilder.buildGCBagUpdate(this.bags.get(BagType.STORE));
	}
	
	public GCBagUpdate getSkillEffectBagInfoMsg() {
		return ItemMessageBuilder.buildGCBagUpdate(this.bags.get(BagType.SKILL_EFFECT_BAG));
	}
	
	public void sendBagCapacity() {
		getOwner().sendMessage(new GCResetCapacity(BagType.PRIM.getIndex(), getPrimBagNum()));
		getOwner().sendMessage(new GCResetCapacity(BagType.STORE.getIndex(), getStoreBagNum()));
		getOwner().sendMessage(new GCResetCapacity(BagType.SKILL_EFFECT_BAG.getIndex(), getSkillEffectBagNum()));
	}
	
	private EnumMap<BagType, Integer> countNeedSlot(Collection<ItemParam> params) {
		EnumMap<BagType, Integer> needSlotCounter = new EnumMap<BagType, Integer>(BagType.class);
		// 遍历所有请求，统计每个包需要多少个空位才能放下
		for (ItemParam param : params) {
			int templateId = param.getTemplateId();
			ItemTemplate template = Globals.getItemService().getItemTempByTempId(templateId);
			// 找到此道具应该放入的包
			CommonBag bag = this.getBagByTemplateId(templateId);
			int count = param.getCount();
			// 此包需要的空位
			int needSlot = bag.getNeedSlot(template, count);
			BagType bagType = bag.getBagType();
			if (needSlotCounter.containsKey(bagType)) {
				needSlotCounter.put(bagType, needSlotCounter.get(bagType) + needSlot);
			} else {
				needSlotCounter.put(bagType, needSlot);
			}
		}
		return needSlotCounter;
	}

	/**
	 * 根据模板id得到所属的背包，得到的包为主背包、材料包、任务道具包之一
	 * 
	 * @param templateId
	 * @return 如果所属背包不是三个包之一返回null
	 */
	private CommonBag getBagByTemplateId(int templateId) {
		ItemTemplate tmpl = Globals.getItemService().getItemTempByTempId(templateId);
		if (tmpl == null) {
			return null;
		}
		AbstractItemBag bag = bags.get(tmpl.getBagType());
		// XXX 这里的判断改为是否commonBag而不是primBag
		if (!AbstractItemBag.isCommonBag(bag.getBagType())) {
			// 走到这里很有可能是填表填错了
			return null;
		}
		// 三个背包都是这种类型
		return (CommonBag) bag;
	}

	/**
	 * 通知客户端更新物品信息
	 * 
	 * @param updateList
	 */
	private void noticeClient(Collection<Item> updateList) {
		if (!updateList.isEmpty()) {
			// 通知客户端更新背包
			for (Item item : updateList) {
//				owner.sendMessage(item.getUpdateMsgAndResetModify());
				item.updateItemWithCache();
			}
		}
	}

	public GCMessage getPetBagInfoMsg(long petId) {
		PetEquipBag secBag = this.getBagByPet(petId);
		GCBagUpdate gcBagUpdate = ItemMessageBuilder.buildGCBagUpdate(secBag);
		gcBagUpdate.setWearerId(petId);
		return gcBagUpdate;
	}
	
	public GCMessage getPetGemBagInfoMsg(long petId) {
		PetGemBag secBag = this.getGemBagByPet(petId);
		GCBagUpdate gcBagUpdate = ItemMessageBuilder.buildGCBagUpdate(secBag);
		gcBagUpdate.setWearerId(petId);
		return gcBagUpdate;
	}

	/**
	 * 根据PetId取bag
	 * 
	 * @param petUuid
	 * @return
	 */
	public PetEquipBag getBagByPet(long petUuid) {
		return petBags.get(petUuid);
	}
	
	/**
	 * 根据PetId取GemBag
	 * 
	 * @param petUuid
	 * @return
	 */
	public PetGemBag getGemBagByPet(long petUuid) {
		return petGemBags.get(petUuid);
	}

	/**
	 * 获取打造装备检测器
	 * @return
	 */
	public CraftEquipNoticeChecker getCraftChecker() {
		return craftChecker;
	}
	
	/**
	 * 是否有可打造的装备
	 * @return
	 */
	public boolean canCraft() {
		return craftChecker.isCanCraft();
	}
	
	/**
	 * 打造材料变化时
	 * @param isAdd
	 */
	public void onCraftMaterialChanged(boolean isAdd) {
		if (isAdd && !canCraft()) {
			getCraftChecker().checkCanCraft();
		} else if (!isAdd && canCraft()) {
			getCraftChecker().checkCanCraft();
		}
	}

	public List<CommonItem> getCachedMsgList() {
		return cachedMsgList;
	}
	
	public void addCacheMsg(CommonItem commonItem) {
		if (commonItem != null) {
			cachedMsgList.add(commonItem);
		}
	}
	
	public void checkSendCachedMsg() {
		if (!cachedMsgList.isEmpty()) {
			getOwner().sendMessage(new GCItemUpdateList(cachedMsgList.toArray(new CommonItem[0])));
			cachedMsgList.clear();
		}
	}
}
