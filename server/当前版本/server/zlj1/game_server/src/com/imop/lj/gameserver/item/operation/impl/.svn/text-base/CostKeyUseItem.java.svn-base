package com.imop.lj.gameserver.item.operation.impl;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.ConsumableFunc;
import com.imop.lj.gameserver.item.ItemDef.CostType;
import com.imop.lj.gameserver.item.template.ConsumeItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.role.Role;

public class CostKeyUseItem extends AbstractConsumeOperation {

	@Override
	public ConsumableFunc getConsumableFunc() {
		return ConsumableFunc.COST_KEY_USE_ITEM;
	}	
	@Override
	public <T extends Role> boolean cost(Human user, Item item, int count, T pet) {
		ItemTemplate it = item.getTemplate();
		if(!it.getItemType().isNeedKey()){
			// 不需要消耗则直接返回成功
			return true;
		}
		
		if(!(it instanceof ConsumeItemTemplate)){
			return false;
		}
		
		ConsumeItemTemplate cit = (ConsumeItemTemplate)it;
		int argA = cit.getCostArgA();
		int argB = cit.getCostArgB() * count;
		
		if(cit.getCostType() == CostType.ITEM){
			String text = LogUtils.genReasonText(ItemLogReason.COST_KEY_USE_ITEM, cit.getId(), count);
			if(!user.getInventory().removeItem(argA, argB, ItemLogReason.COST_KEY_USE_ITEM, text).isEmpty()){
				return true;
			}else{
				user.sendErrorMessage(LangConstants.ITEM_NOT_ENOUGH);
				return false;
			}
		}else if(cit.getCostType() == CostType.MONEY){
			String text = LogUtils.genReasonText(MoneyLogReason.COST_KEY_USE_ITEM_COST, cit.getId(), count);
			if(user.costMoney(argB, Currency.valueOf(argA), true, 1, MoneyLogReason.COST_KEY_USE_ITEM_COST, text, -1)){
				return true;
			}else{
				user.sendErrorMessage(LangConstants.COMMON_NOT_ENOUGH, Globals.getLangService().readSysLang(Currency.valueOf(argA).getNameKey()));
				return false;
			}
		}else{
			return false;
		}
	}
	@Override
	protected <T extends Role> boolean canUseImpl(Human user, Item item,
			int count, T role) {
		
		if (count < 1 || item.getOverlap() < count) {
			return false;
		}

		ItemTemplate it = item.getTemplate();
		if (it == null || !(it instanceof ConsumeItemTemplate)) {
			return false;
		}

		ConsumeItemTemplate temp = (ConsumeItemTemplate) it;
		if (user.getLevel() < temp.getLevel()) {
			user.sendErrorMessage(LangConstants.ITEM_USEFAIL_LEVEL);
			return false;
		}
		return super.canUseImpl(user, item, count, role);
	}
	
	@Override
	protected <T extends Role> boolean useImpl(Human user, Item item,
			int count, T role) {
		if (count < 1 || item.getOverlap() < count) {
			return false;
		}

		ItemTemplate it = item.getTemplate();
		if (it == null || !(it instanceof ConsumeItemTemplate)) {
			return false;
		}

		ConsumeItemTemplate temp = (ConsumeItemTemplate) it;
		if (user.getLevel() < temp.getLevel()) {
			user.sendErrorMessage(LangConstants.ITEM_USEFAIL_LEVEL);
			return false;
		}
		
		// 生成奖励
		List<Reward> list = new ArrayList<Reward>();
		for(int i=0; i<count; i++){
			Reward reward = Globals.getRewardService().createReward(user.getUUID(), temp.getArgB(), " cost key use item ");
			
			if(reward.isNull() || reward.getReasonType() != RewardReasonType.COST_KEY_USE_ITEM){
				Loggers.itemLogger.error("#CostKeyUseItem.useImpl reward id = " + reward.getUuid() + ", reason type = " + reward.getReasonType() + " is error");
				continue;
			}
			
			list.add(reward);
		}
		
		// 扣除礼盒
		if(!user.getInventory().removeItemByIndex(item.getBagType(), item.getIndex(), count, ItemLogReason.COST_KEY_USE_ITEM_DEL, ItemLogReason.COST_KEY_USE_ITEM_DEL.getReasonText())){
			return false;
		}
		
		Reward reward = Globals.getRewardService().mergeReward(list);
		Globals.getRewardService().giveReward(user, reward, true);
		
		return true;
	}

}
