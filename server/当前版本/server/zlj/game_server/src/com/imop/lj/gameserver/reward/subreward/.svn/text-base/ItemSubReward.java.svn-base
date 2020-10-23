package com.imop.lj.gameserver.reward.subreward;

import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.TipsUtil;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.ItemDef.BindType;
import com.imop.lj.gameserver.item.ItemParam;
import com.imop.lj.gameserver.item.template.EquipItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.mail.MailDef.MailType;
import com.imop.lj.gameserver.reward.ISubReward;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardAddedType;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;
import com.imop.lj.gameserver.reward.RewardKeyDefine;
import com.imop.lj.gameserver.reward.RewardParam;
import com.imop.lj.gameserver.reward.template.RewardTemplate;

/**
 * 物品类型奖励
 * 
 * @author xiaowei.liu
 * 
 */
public class ItemSubReward extends AbstractSubReward {
	/** Map<道具模板Id，道具数量> */
	private Map<Integer, Integer> map = new LinkedHashMap<Integer, Integer>();
	
	public ItemSubReward(Reward reward) {
		super(reward, RewardType.REWARD_ITEM);
	}
	
	/**
	 * 创建道具类奖励参数
	 * 
	 * @param tempId
	 * @param num
	 * @return
	 */
	public static RewardParam createRewardParam(int tempId, int num){
		RewardParam param = new RewardParam();
		param.setRewardType(RewardType.REWARD_ITEM);
		param.setParam1(tempId);
		param.setParam2(num);
		return param;
	}

	@Override
	public boolean addReward(RewardParam param) {
		if(!this.checkParam(param)){
			return false;
		}
		
		Integer itemTempId = param.getParam1();
		Integer num = param.getParam2();
		
		Integer curr = map.get(itemTempId);
		if(curr == null){
			curr = 0;
		}
		
		if(curr > Integer.MAX_VALUE - num){
			curr = Integer.MAX_VALUE;
		}else{
			curr += num;
		}
		
		map.put(itemTempId, curr);
		return true;
	}

	@Override
	public List<RewardParam> toRewardParamList() {
		List<RewardParam> list = new ArrayList<RewardParam>();
		for(Entry<Integer, Integer> entry : map.entrySet()){
			RewardParam param = new RewardParam();
			param.setRewardType(this.rewardType);
			param.setParam1(entry.getKey());
			param.setParam2(entry.getValue());
			list.add(param);
		}
		return list;
	}

	@Override
	public boolean giveReward(Human human, boolean needNotify) {
		//构建检查背包空间是否足够的参数
		List<ItemParam> list = new ArrayList<ItemParam>();
		for (Entry<Integer, Integer> entry : map.entrySet()) {
			boolean isBind = true;
			//如果bindType不为null，则该值决定绑定状态
			if (this.reward.getBindType() != null) {
				isBind = this.reward.getBindType() == BindType.BIND ? true : false;
			} else {
				//道具模板决定绑定状态
				isBind = Globals.getTemplateCacheService().get(entry.getKey(), ItemTemplate.class).isBind();
			}
			
			list.add(new ItemParam(entry.getKey(), entry.getValue(), isBind));
		}
		
		//背包是否没有足够的空间
		if (human.getInventory().checkSpace(list, false)) {
			//背包空间足够，直接发道具
			for (ItemParam param : list) {
				int itemId = param.getTemplateId();
				int itemNum = param.getCount();
				boolean isBind = param.isBind();
				
				ItemTemplate tpl = Globals.getItemService().getItemTempByTempId(itemId);
				if (tpl == null) {
					continue;
				}
				if (!tpl.isEquipment()) {
					human.getInventory().addItem(itemId, itemNum, reward.getReasonType().getItemGenLogReason(), reward.getParams(), isBind, needNotify);
				} else {
					EquipItemTemplate equipTpl = (EquipItemTemplate)tpl;
					if (!equipTpl.isFixedEquip()) {
						//装备默认按照最低配方和阶数1生成
						Globals.getItemService().addItemByParams(false, ItemGenLogReason.GAME_CREATE_REWARD, null, ItemLogReason.GAME_CREATE_REWARD, human, 
								itemId, itemNum, isBind, null, null, null, null);
					} else {
						human.getInventory().addItem(itemId, itemNum, reward.getReasonType().getItemGenLogReason(), reward.getParams(), isBind, needNotify);
					}
				}
			}
		} else {
			//背包不能全部放进去，直接发邮件奖励
			Reward reward = Globals.getRewardService().createRewardByFixedContent(human.getCharId(),
					RewardReasonType.BAG_FULL_SEND_MAIL_REWARD, toRewardParamList(), "bagFullReward");
			//发带附件的邮件
			Globals.getMailService().sendSysMail(human.getCharId(), MailType.SYSTEM, 
					Globals.getLangService().readSysLang(LangConstants.BAG_FULL_ITEM_SEND_MAIL_TITLE), 
					Globals.getLangService().readSysLang(LangConstants.BAG_FULL_ITEM_SEND_MAIL_CONTENT), 
					reward);
		}
		
		return true;
	}

	@Override
	public ISubReward createEmptySubReward(Reward reward) {
		return new ItemSubReward(reward);
	}

	@Override
	public boolean checkParam(RewardParam param) {
		int itemTemplateId = param.getParam1();
		ItemTemplate itemTemplate = Globals.getTemplateCacheService().get(itemTemplateId, ItemTemplate.class);
		if(itemTemplate == null){
			return false;
		}
		
		int amount = param.getParam2();
		
		//如果物品数量小于等于0返回非法
		if(amount <= 0){
			return false;
		}
		
		return true;
	}

	@Override
	public String checkTemplate(RewardTemplate tmpl) {
		int itemTemplateId = tmpl.getParam1();
		ItemTemplate itemTemplate = Globals.getTemplateCacheService().get(itemTemplateId, ItemTemplate.class);
		if(itemTemplate == null){
			return "物品不存在 itemId = " + itemTemplateId;
		}
		
		int amount = tmpl.getParam2();
		
		// 如果物品数量小于等于0返回非法
		if(amount <= 0){
			return "物品数量 <= 0 值 = " + amount;
		}
		
		return null;
		
	}
	
	/**
	 * 是否有指定品质的物品
	 * 
	 * @param rarityId
	 * @return
	 */
	public boolean hasRarityItem(int rarityId) {
		for (int tempId : this.map.keySet()) {
			ItemTemplate itemTpl = Globals.getTemplateCacheService().get(tempId, ItemTemplate.class);
			if (null != itemTpl) {
				if (itemTpl.getRarityId() >= rarityId) {
					return true;
				}
			}
		}
		return false;
	}
	
	/**
	 * 获取道具数据
	 * @param rarityId
	 * @return
	 */
	public Map<Integer, Integer> getItemData() {
		return this.map;
	}

	@Override
	public String getRewardString() {
		StringBuffer sb = new StringBuffer();
		int size = this.map.size();
		int i = 0;
		for(Entry<Integer, Integer> entry : map.entrySet()){
			int itemId = entry.getKey();
			int count = entry.getValue();
			ItemTemplate itemTpl = Globals.getTemplateCacheService().get(itemId, ItemTemplate.class);
			if (null == itemTpl || count <= 0) {
				sb.append("--");
			}else{
				String nameWithColor = TipsUtil.getStrByColor(itemTpl.getName(), itemTpl.getRarity().getColor());
				sb.append(nameWithColor);
				sb.append(TipsUtil.CONNECT_STR2);
				sb.append(count);
			}
			
			if(i < size - 1){
				sb.append(TipsUtil.CONNECT_STR1);
			}
			i++;
		}
		return sb.toString();
	}

	@Override
	public String getMsgString() {
		JSONArray array = new JSONArray();
		for(Entry<Integer, Integer> entry : this.map.entrySet()){
			JSONObject obj = new JSONObject();
			ItemTemplate temp = Globals.getTemplateCacheService().get(entry.getKey(), ItemTemplate.class);
			if(temp != null){
				obj.put(RewardKeyDefine.ITEM_TEMP_ID_KEY, entry.getKey());
				obj.put(RewardKeyDefine.ITEM_NUM_KEY, entry.getValue());
//				obj.put(RewardKeyDefine.ITEM_RARITY_KEY, temp.getRarityId());
//				obj.put(RewardKeyDefine.ITEM_ICON_KEY, temp.getIcon());
//				obj.put(RewardKeyDefine.ITEM_TEMP_ID_KEY, temp.getId());
//				obj.put(RewardKeyDefine.ITEM_PROPS_KEY, "");
//				obj.put(RewardKeyDefine.ITEM_CATALOG_KEY, temp.getItemType().getCatalogue().getIndex());
//				obj.put(RewardKeyDefine.ITEM_MIAOBIAN, temp.getMiaobian());
//				obj.put(RewardKeyDefine.ITEM_EFFECT_ID, temp.getEffectId());
			}
			array.add(obj.toString());
		}
		return array.toString();
	}

	@Override
	public void amend(Map<RewardAddedType, Integer> amendMap) {
		
	}

	@Override
	public boolean giveCorpsReward(Corps corps, boolean needNotify) {
		return false;
	}
}
