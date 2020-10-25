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
import com.imop.lj.gameserver.reward.template.LevelGiftPackTemplate;
import com.imop.lj.gameserver.role.Role;

/**
 * 等级礼包
 * 
 * @author xiaowei.liu
 * 
 */
public class UseLevelMaterialPack extends AbstractConsumeOperation {
	@Override
	protected <T extends Role> boolean useImpl(Human user, Item item, int count, T role) {
		if(count < 1 || item.getOverlap() < count){
			return false;
		}
		
		ItemTemplate it = item.getTemplate();
		if(it == null || !(it instanceof ConsumeItemTemplate)){
			return false;
		}
		
		ConsumeItemTemplate consume = (ConsumeItemTemplate)it;
		// 生成奖励
		List<Reward> list = new ArrayList<Reward>();
		LevelGiftPackTemplate levelGiftPack = Globals.getTemplateCacheService().getRewardTemplateCache().getLevelGiftPackTemplateByLevel(consume.getArgA(), user.getLevel());
		if(levelGiftPack == null){
			Loggers.rewardLogger.error("UserLevelGiftPack.userImpl arg = " + consume.getArgA() + ", level = " + user.getLevel() + " does not exist");
			return false;
		}
		
		for(int i=0; i<count; i++){
			Reward reward = Globals.getRewardService().createReward(user.getUUID(), levelGiftPack.getRewardId(), " level use gift peck ");
			if(reward.isNull()){
				continue;
			}
			
			list.add(reward);
		}
		
		// 扣除礼盒
		if(!user.getInventory().removeItemByIndex(item.getBagType(), item.getIndex(), count, ItemLogReason.LEVEL_GIFT_PACK_COST, ItemLogReason.LEVEL_GIFT_PACK_COST.getReasonText())){
			return false;
		}
		
		Reward reward = Globals.getRewardService().mergeReward(list);
		Globals.getRewardService().giveReward(user, reward, true);

		return true;
	}
	
	@Override
	public ConsumableFunc getConsumableFunc() {
		return ConsumableFunc.LEVEL_MATERIAL_PACK;
	}

}
