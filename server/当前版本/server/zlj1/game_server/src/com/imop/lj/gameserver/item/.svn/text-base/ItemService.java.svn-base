package com.imop.lj.gameserver.item;

import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.RoleConstants;
import com.imop.lj.common.model.item.CommonItem;
import com.imop.lj.common.model.item.SellItemInfo;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
//import com.imop.lj.gameserver.item.ItemDef.CostType;
import com.imop.lj.gameserver.item.container.AbstractItemBag;
import com.imop.lj.gameserver.item.container.CommonBag;
import com.imop.lj.gameserver.item.feature.AbstractEquipFeature;
import com.imop.lj.gameserver.item.feature.ItemFeature;
import com.imop.lj.gameserver.item.generate.EquipGenerator;
import com.imop.lj.gameserver.item.msg.GCResetCapacity;
import com.imop.lj.gameserver.item.msg.ItemMessageBuilder;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.item.template.StoreOpenTemplate;

public class ItemService implements InitializeRequired {

	/** 装备生成器 */
	protected EquipGenerator equipGenerator;

	/** 强化的时候是否自动清除CD */
	protected int leveUpType = 0;

//	/**
//	 * 根据{@link EquipItemAttribute}生成对应的{@link AmendTriple}
//	 * 
//	 * @param attrs
//	 * @return
//	 */
//	public List<AmendTriple> convertAmendTuples(List<EquipItemAttribute> attrs) {
//		if (attrs == null) {
//			return Collections.emptyList();
//		}
//		ArrayList<AmendTriple> tuples = new ArrayList<AmendTriple>();
//		for (EquipItemAttribute attr : attrs) {
//			if (attr == null || attr.getPropKey() <= 0) {
//				continue;
//			}
//
//			AmendTriple tuple = Globals.getAmendService().createAmendTriple(attr.getPropKey(), attr.getPropValue());
//			tuples.add(tuple);
//		}
//		return tuples;
//	}

	/**
	 * 将装备的实例属性构建成json串
	 * 
	 * @param feature
	 * @return
	 */
	public String buildPropJsonString(ItemFeature feature) {
		if (feature == null) {
			return "";
		}

		// TODO 根据不同feature类型返回props
		// if (feature instanceof AbstractEquipmentFeature && !(feature
		// instanceof HuntItemFeature)) {
		// AbstractEquipmentFeature equipFeature = (AbstractEquipmentFeature)
		// feature;
		// JSONObject jsonObj = new JSONObject();
		// //收集强化属性
		// ItemService.accumulateEnhanceLevel(equipFeature, jsonObj);
		// //收集物品的绑定状态
		// ItemService.accumulateActiveState(equipFeature, jsonObj);
		// //收集物品的取消绑定的时间
		// ItemService.accumulateCancelTime(equipFeature, jsonObj);
		// //收集宝石包裹信息
		// ItemService.accumulateDiamondPackage(equipFeature, jsonObj);
		//
		// return jsonObj.toString();
		// }
		// if (feature instanceof HuntItemFeature) {
		// HuntItemFeature huntItemFeature = (HuntItemFeature) feature;
		// JSONObject jsonObj = new JSONObject();
		// //命格等级
		// ItemService.accumulateHuntLevel(huntItemFeature, jsonObj);
		// //命格经验
		// ItemService.accumulateHuntExp(huntItemFeature, jsonObj);
		// //命格最大经验
		// ItemService.accumulateHuntMaxExp(huntItemFeature, jsonObj);
		//
		// //天命命格属性激活状态
		// ItemService.accumulateHuntDistiny(huntItemFeature, jsonObj);
		// return jsonObj.toString();
		//
		// }
		// if(feature instanceof GemItemFeature) {
		// GemItemFeature diamondItemFeature = (GemItemFeature) feature;
		// JSONObject jsonObj = new JSONObject();
		// //收集宝石属性信息
		// ItemService.accumalteDiamondProerties(diamondItemFeature, jsonObj);
		// System.out.println("diamond json ="+jsonObj.toString());
		// return jsonObj.toString();
		// }

		return "";
	}

	/**
	 * 判断模板id为templateId的绑定状态为bind的物品是否可以叠加到baseItem上<br/>
	 * 此方法不考虑叠加上限的问题
	 * 
	 * @param baseItem
	 * @param templateId
	 * @param bind
	 * @return
	 */
	public boolean canOverlapOn(Item baseItem, int templateId) {
		// 锁定的物品不可以再往上面叠加
		return Item.isSameTemplateId(templateId, baseItem);
	}

	public ItemService() {
		this.equipGenerator = new EquipGenerator();

	}

	@Override
	public void init() {
		
	}

	public void reload() {
		init();
	}

	/**
	 * 创建一个已经激活的道具，即创建之后将直接出现在游戏世界中，初始叠加数为0
	 * 
	 * @param owner
	 *            所有者
	 * @param template
	 *            道具模板
	 * @param bagId
	 *            所在包id
	 * @param _index
	 *            在包中的索引
	 * @return
	 */
	public Item newActivatedInstance(Human owner, ItemTemplate template, BagType bagType, int bagIndex) {
		Item item = null;
//		if (template.isEquipment()) {
//			item = equipGenerator.generateActivedEquip(owner, (EquipItemTemplate) template, bagType, bagIndex);
//		} else {
			item = Item.newActivatedInstance(owner, template, bagType, bagIndex);
//		}
		return item;
	}
	
	/**
	 * 创建一个已经激活的道具，即创建之后将直接出现在游戏世界中
	 * 宝石镶嵌专用
	 * @param owner
	 *            所有者
	 * @param template
	 *            道具模板
	 * @param bagId
	 *            所在包id
	 * @param _index
	 *            在包中的索引
	 * @return
	 */
	public Item newActivatedInstance(Human owner, ItemTemplate template, BagType bagType, int bagIndex,int overlap) {
		Item item = null;
//		if (template.isEquipment()) {
//			item = equipGenerator.generateActivedEquip(owner, (EquipItemTemplate) template, bagType, bagIndex);
//		} else {
			item = Item.newActivatedInstance(owner, template, bagType, bagIndex,overlap);
//		}
		return item;
	}
	
	/**
	 * gm命令用，其他方法不要用！！
	 * @param owner
	 * @param template
	 * @param bagType
	 * @param bagIndex
	 * @return
	 */
	public Item newActivatedInstanceForGM(Human owner, ItemTemplate template, BagType bagType, int bagIndex
			, int[] attrA, int[] attrB, int...params) {
		Item item = null;
//		if (template.isEquipment()) {
//			item = equipGenerator.generateActivedEquipForGM(owner, (EquipItemTemplate) template, bagType, bagIndex, attrA, attrB, params);
//		} else {
			item = Item.newActivatedInstanceForGM(owner, template, bagType, bagIndex, attrA, attrB, params);
//		}
		return item;
	}

	/**
	 * 创建一个未激活的道具，初始叠加数为0
	 * 
	 * @param owner
	 *            所有者
	 * @param template
	 *            道具模板
	 * @param bagId
	 *            所在包id
	 * @param _index
	 *            在包中的索引
	 * @return
	 */
	public Item newDeactiveInstance(Human owner, ItemTemplate template, BagType bagType, int bagIndex) {
//		if (template.isEquipment()) {
//			Item item = equipGenerator.generateDeactivedEquip(owner, (EquipItemTemplate) template, bagType, bagIndex);
//			return item;
//		}
			return Item.newDeactivedInstance(owner, template, bagType, bagIndex);
		
	}

	/**
	 * 根据item模板id，取得该item模板
	 * 
	 * @param templateId
	 * @return item模板
	 */
	public ItemTemplate getItemTempByTempId(int templateId) {
		ItemTemplate tmpl = Globals.getTemplateCacheService().get(templateId, ItemTemplate.class);
		return tmpl;
	}

	public int getLeveUpType() {
		return leveUpType;
	}

	public void setLeveUpType(int leveUpType) {
		this.leveUpType = leveUpType;
	}

	public boolean levelUpKillCd(Human human, String uuid, boolean notify, boolean hasEnhanced) {

		return true;
	}

	public void levelUpOneKey(Human human, String uuid) {

	}

	/**
	 * 卖出物品
	 * 
	 * @param human
	 * @param bagId
	 * @param sellItems
	 */
	public void sellItem(Human human, int bagId, SellItemInfo[] sellItemInfos) {
		BagType bagType = BagType.valueOf(bagId);
		// 是否可出售物品的背包
		if (!AbstractItemBag.isPrimBag(bagType) && !AbstractItemBag.isSkillEffectBag(bagType)) {
			human.sendSystemMessage(LangConstants.INVAILD_SELL_ITEM);
			return;
		}
		JSONArray detailReasonJson = new JSONArray();
		
		int[] indexs = new int[sellItemInfos.length];
		int[] counts = new int[sellItemInfos.length];
		List<Item> sellItems = new ArrayList<Item>();
		Map<Currency, Long> priceMap = new HashMap<Currency, Long>();
		int i = 0;
		for (SellItemInfo sellItemInfo : sellItemInfos) {
			Item toSellItem = human.getInventory().getItemByIndex(bagType, 0l, sellItemInfo.getIndex());
			if (toSellItem == null) {
				human.sendSystemMessage(LangConstants.INVAILD_SELL_ITEM);
				return;
			}

			if (!toSellItem.isCanSelled()) {
				human.sendSystemMessage(LangConstants.INVAILD_SELL_ITEM);
				return;
			}
			//卖出数量超过拥有数量，不让卖！
			if (sellItemInfo.getCount() > toSellItem.getOverlap()) {
				human.sendSystemMessage(LangConstants.INVAILD_SELL_ITEM);
				return;
			}
			
			ItemTemplate itemTemplate = toSellItem.getTemplate();
			long price = toSellItem.getFeature().getPrice() * sellItemInfo.getCount();
			Currency currency = itemTemplate.getSellCurrency();
			if (priceMap.containsKey(currency)) {
				long existPrice = priceMap.get(currency);
				priceMap.put(currency, existPrice + price);
			} else {
				priceMap.put(currency, price);
			}
			sellItems.add(toSellItem);
			indexs[i] = toSellItem.getIndex();
			counts[i] = sellItemInfo.getCount();
			i++;
			
			JSONObject jo = new JSONObject();
			jo.put("tplId", itemTemplate.getId());
			jo.put("num", sellItemInfo.getCount());
			detailReasonJson.add(jo);
		}

		// 判断是否能全部给钱
		for (Entry<Currency, Long> entry : priceMap.entrySet()) {
			Currency currency = entry.getKey();
			long amount = entry.getValue();
			if (!human.canGiveMoney(amount, currency)) {
				human.sendSystemMessage(LangConstants.SELL_ITEM_FAILED);
				return;
			}
		}

		if (human.getInventory().removeItemByIndex(bagType, indexs, counts, ItemLogReason.SELL_COST, detailReasonJson.toString())) {
			for (Entry<Currency, Long> entry : priceMap.entrySet()) {
				Currency currency = entry.getKey();
				long amount = entry.getValue();
				boolean giveMoneySucc = human.giveMoney(amount, currency, true, MoneyLogReason.SELL_TO_SHOP, detailReasonJson.toString());
				if (!giveMoneySucc) {
					// 如果给予失败。正常情况不会发生
					Loggers.playerLogger
							.error(LogUtils.buildLogInfoStr(human.getUUID() + "", String.format("出售物品(id=%d)时给钱失败", detailReasonJson.toString())));
					human.sendSystemMessage(LangConstants.SHOP_SELL_FAIL);
					return;
				}
			}
		}
	}
	
	/**
	 * 仓库开格子
	 * @param human
	 */
	public void openStoreBag(Human human) {
		int oldOpenNum = human.getStoreOpenNum();
		//格子是否已达上限
		int curCapacity = human.getInventory().getStoreBagNum();
		if (curCapacity >= RoleConstants.STORE_BAG_MAX_NUM) {
			human.sendErrorMessage(LangConstants.OPEN_BAG_FAIL_REACH_MAX);
			return;
		}

		//判断模板是否存在，如果没有，则表示不能开了
		StoreOpenTemplate openTpl = Globals.getTemplateCacheService().get(oldOpenNum, StoreOpenTemplate.class);
		if (openTpl == null) {
			human.sendErrorMessage(LangConstants.OPEN_BAG_FAIL_REACH_MAX);
			return;
		}
		
		int templateId = openTpl.getItemTplId();
		int needItemNum = openTpl.getItemNum();
		
		// 检查道具是否足够
		if (!human.getInventory().hasItemByTmplId(templateId, needItemNum)) {
			human.sendErrorMessage(LangConstants.NOT_ENOUGH_ITEM_CAN_OPEN_BAG);
			return;
		}

		// 扣道具
		Collection<Item> removeItem = human.getInventory().removeItem(templateId, needItemNum, ItemLogReason.OPEN_BAG,
				ItemLogReason.OPEN_BAG.reasonText);
		// 开格子
		if (!removeItem.isEmpty()) {
			int oldCapacity = human.getInventory().getStoreBag().getCapacity();
			human.setStoreOpenNum(human.getStoreOpenNum() + 1);
			human.getInventory().getStoreBag().resetCapacity(human.getInventory().getStoreBagNum());
			human.sendMessage(new GCResetCapacity(BagType.STORE.getIndex(), human.getInventory().getStoreBag().getCapacity()));
			// 提示操作成功
			human.sendErrorMessage(LangConstants.OPEN_BAG_OK, human.getInventory().getStoreBag().getCapacity() - oldCapacity);
		}
	}
	
	public void addItemInfoCache(Item item){
		Globals.getBaseModelCache().addItemInfoCache(ItemMessageBuilder.createItemInfo(item));
	}
	
	public CommonItem getItemInfoCache(String uuid){
		return Globals.getBaseModelCache().getItemInfoCache(uuid);
	}
	
	/**
	 * 背包和临时背包是否都满了，即没有空格了
	 * @param human
	 * @return
	 */
	public boolean isPrimAndTempBagBothFull(Human human) {
		boolean flag = true;
		if (human != null && human.getInventory() != null) {
			// 背包和临时背包都没有空格了
			flag = human.getInventory().getPrimBag().getEmptySlotCount() <= 0;
		}
		return flag;
	}
	
	/**
	 * 创建具有特殊属性的道具
	 * 注意：这个方法适用于有特殊属性的道具，如装备等，其他的普通道具不要调用这里！！！
	 * 
	 * @param isGM true为GM命令创建！！！
	 * @param human
	 * @param itemId
	 * @param count
	 * @param attrA
	 * @param attrB
	 * @param fixedParams
	 */
	public Item addItemByParams(boolean isGM, ItemGenLogReason genReason, String genDetailReason, 
			ItemLogReason reason, Human human, int itemId, int count, int[] attrA, int[] attrB, int...fixedParams) {
		// 物品模板
		ItemTemplate template = Globals.getTemplateCacheService().get(itemId, ItemTemplate.class);
		if (template == null) {
			return null;
		}
		
		String genKey = KeyUtil.UUIDKey();
		// 记录道具产生日志
		ItemGenLogReason itemGenLogReason = isGM ? ItemGenLogReason.GM_CREATE_REWARD : genReason;
		if (genDetailReason == null || genDetailReason.isEmpty()) {
			genDetailReason = itemGenLogReason.getReasonText();
		}
		Globals.getLogService().sendItemGenLog(human, itemGenLogReason, genDetailReason, template.getId(), template.getName()
				, count, 0, "", genKey);
		ItemLogReason itemLogReason = isGM ? ItemLogReason.GM_CREATE_REWARD : reason;
				
		// 主道具包
		CommonBag primBag = human.getInventory().getPrimBag();
		//TODO 临时背包先干掉
//		CommonBag tempBag = human.getInventory().getTempBag();
		// 添加到的背包
		CommonBag addBag = null;
		
		Item emptyItem = null;
		int left = count;
		Item newItem = null;
		for(; left > 0; ) {
			emptyItem = primBag.getEmptySlot();
			
			if (emptyItem != null) {
				addBag = primBag;
			} 
//			else if(null != tempBag.getEmptySlot()) {
//				emptyItem = tempBag.getEmptySlot();
//				addBag = tempBag;
//			}
			
			if (null != addBag && null != emptyItem) {
				if (isGM) {
					newItem = Item.newActivatedInstanceForGM(human, template, addBag.getBagType(), emptyItem.getIndex(),
							attrA, attrB, fixedParams);
				} else {
					newItem = Item.newActivatedInstanceWithParams(human, template, addBag.getBagType(), emptyItem.getIndex(),
							attrA, attrB, fixedParams);
				}
				newItem.setModified();
				primBag.putItem(newItem);
				
				if (template.getMaxOverlap() >= left) {
					// 可以全部放入
					newItem.changeOverlap(left, itemLogReason, itemLogReason.getReasonText(), genKey, true);
					left = 0;
				} else {
					// 只能放一部分
					newItem.changeOverlap(template.getMaxOverlap(), itemLogReason, itemLogReason.getReasonText(), genKey, true);
					left -= template.getMaxOverlap();
				}
				
				Globals.getBaseModelCache().addItemInfoCache(ItemMessageBuilder.createItemInfo(newItem));
				// 刷新物品
				
				// 装备
				if(ItemDef.IdentityType.EQUIP == newItem.getTemplate().getIdendityType()) {
					AbstractEquipFeature feature = (AbstractEquipFeature)newItem.getFeature();
					Globals.getEquipService().flushItemAndProp(human, feature, true);
				}
//				if(ItemDef.IdentityType.TREASURE == newItem.getTemplate().getIdendityType()) {
//					TreasureFeature feature = (TreasureFeature)newItem.getFeature();
//				}
				// 通知客户端物品变化
//				GCMessage message = newItem.getUpdateMsgAndResetModify();
//				human.sendMessage(message);
				newItem.updateItemWithCache();
			} else {
				//没有空的格子了，直接返回
				//记录丢弃日志
				String p = attrA.toString() + ";" + attrB.toString() + ";" + fixedParams.toString();
				Globals.getLogService().sendItemLog(human, ItemLogReason.PLAYER_DROP, "onAddByParamNoSpaceDelete " + p, 
						BagType.PRIM.getIndex(), 0, template.getId(), "", 0, 1, "", new byte[0]);
				return newItem;
			}
		}
		return newItem;
	}
	
	public Item addItemWithFeature(ItemGenLogReason genReason, String genDetailReason, 
			ItemLogReason reason, Human human, int itemId, ItemFeature itemFeature) {
		// 物品模板
		ItemTemplate template = Globals.getTemplateCacheService().get(itemId, ItemTemplate.class);
		if (template == null || itemFeature == null) {
			return null;
		}
		int count = 1;
		
		String genKey = KeyUtil.UUIDKey();
		
		Globals.getLogService().sendItemGenLog(human, genReason, genDetailReason, template.getId(), template.getName()
				, count, 0, "", genKey);
		
		BagType bagType = template.getBagType();
		// 主道具包
		CommonBag bag = human.getInventory().getCommonBagByType(bagType);
		if (bag == null) {
			return null;
		}
		// 添加到的背包
		CommonBag addBag = null;
		
		Item emptyItem = null;
		Item newItem = null;
		emptyItem = bag.getEmptySlot();
		//因为添加的是带feature的道具，所以肯定不能叠加，需要一个空格子
		if (emptyItem != null) {
			addBag = bag;
		} 
		
		if (null != addBag && null != emptyItem) {
			newItem = Item.newActivatedInstanceWithFeature(human, template, addBag.getBagType(), emptyItem.getIndex(), itemFeature);
			newItem.setModified();
			bag.putItem(newItem);
			
			// 可以全部放入
			newItem.changeOverlap(count, reason, reason.getReasonText(), genKey, true);
			
			Globals.getBaseModelCache().addItemInfoCache(ItemMessageBuilder.createItemInfo(newItem));
			// 刷新物品
			
			// 装备
			if(ItemDef.IdentityType.EQUIP == newItem.getTemplate().getIdendityType()) {
				AbstractEquipFeature feature = (AbstractEquipFeature)newItem.getFeature();
				Globals.getEquipService().flushItemAndProp(human, feature, true);
			}

			// 通知客户端物品变化
//			GCMessage message = newItem.getUpdateMsgAndResetModify();
//			human.sendMessage(message);
			newItem.updateItemWithCache();
		} else {
			//没有空的格子了，直接返回
			//记录丢弃日志
			String p = itemFeature.toProps(false);
			Globals.getLogService().sendItemLog(human, ItemLogReason.PLAYER_DROP, "onAddByFeatureNoSpaceDelete " + p, 
					BagType.PRIM.getIndex(), 0, template.getId(), "", 0, 1, "", new byte[0]);
			return newItem;
		}
		return newItem;
	}
}
