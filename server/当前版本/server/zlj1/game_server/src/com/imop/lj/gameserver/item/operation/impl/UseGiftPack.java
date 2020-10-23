package com.imop.lj.gameserver.item.operation.impl;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.ConsumableFunc;
import com.imop.lj.gameserver.item.template.ConsumeItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.role.Role;

/**
 * 礼盒(固定礼盒，随机礼盒)
 * 
 * @author xiaowei.liu
 * 
 */
public class UseGiftPack extends AbstractConsumeOperation {

	@Override
	public ConsumableFunc getConsumableFunc() {
		return ConsumableFunc.GIFE_PECK;
	}
	
	@Override
	protected <T extends Role> boolean useImpl(Human user, Item item, int count, T role) {
		if(count < 1 || item.getOverlap() < count){
			return false;
		}
		
		ItemTemplate it = item.getTemplate();
		if(it == null || !(it instanceof ConsumeItemTemplate)){
			return false;
		}
		
		ConsumeItemTemplate temp = (ConsumeItemTemplate)it;
		
		// 生成奖励
		List<Reward> list = new ArrayList<Reward>();
		for(int i=0; i<count; i++){
			Reward reward = Globals.getRewardService().createReward(user.getUUID(), temp.getArgA(), " use gift peck ");
			
			if(reward.isNull() || reward.getReasonType() != RewardReasonType.GIFT_PACK){
				Loggers.itemLogger.error("#UseGiftPack.useImpl reward id = " + reward.getUuid() + ", reason type = " + reward.getReasonType() + " is error");
				continue;
			}
			
			list.add(reward);
		}
		
		// 扣除礼盒
		if(!user.getInventory().removeItemByIndex(item.getBagType(), item.getIndex(), count, ItemLogReason.GIFT_PECK_COST, ItemLogReason.GIFT_PECK_COST.getReasonText())){
			return false;
		}
		
		Reward reward = Globals.getRewardService().mergeReward(list);
		Globals.getRewardService().giveReward(user, reward, true);
		
		// 有面板类型的等级礼包，使用后需要弹出一个专门的面板 TODO FIXME
//		if (it.getItemType() == ItemType.CONSUMABLE_GIVE_GIFT_LEVEL_PANEL) {
//			ItemTemplate popPanelItemTpl = Globals.getTemplateCacheService().get(temp.getArgB(), ItemTemplate.class);
//			GCGetLevelItemPanel gcGetLevelItemPanel = ItemMessageBuilder.buildGCGetLevelItemPanel(user, 0, 0, false, popPanelItemTpl);
//			if (null != gcGetLevelItemPanel) {
//				user.sendMessage(gcGetLevelItemPanel);
//			}
//		}
		return true;
	}

}
