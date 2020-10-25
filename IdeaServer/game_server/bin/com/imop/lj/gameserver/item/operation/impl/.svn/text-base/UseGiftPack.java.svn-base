package com.imop.lj.gameserver.item.operation.impl;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.BindType;
import com.imop.lj.gameserver.item.ItemDef.ConsumableFunc;
import com.imop.lj.gameserver.item.ItemDef.ItemType;
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
	protected <T extends Role> boolean canUseImpl(Human user, Item item, int count, T role) {
		boolean flag = super.canUseImpl(user, item, count, role);
		if (!flag) {
			return flag;
		}
		
		//灵犀仙葫使用限制
		if (item.getTemplate().getItemType() == ItemType.XIANHU_LINGXI) {
			if (!Globals.getXianhuService().canPlayByTime()) {
				user.sendErrorMessage(LangConstants.XIANHU_FAIL7);
				return false;
			}
		}
		
		return true;
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
		
		boolean isBind = item.isBind();
		
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
		
		//如果礼包是绑定的，则开出的东西也是绑定的
		if (isBind) {
			reward.setBindType(BindType.BIND);
		}
		
		boolean flag = Globals.getRewardService().giveReward(user, reward, true);
		if (!flag) {
			Loggers.itemLogger.error("#UseGiftPack.useImpl giveReward return false!roleId=" + reward.getUuid() + ", reason type = " + reward.getReasonType() + " is error");
		}

		//灵犀仙葫特殊处理，使用后需要计数
		if (it.getItemType() == ItemType.XIANHU_LINGXI) {
			Globals.getXianhuService().onPlayLingxi(user.getUUID(), count);
		}
		
		return true;
	}

}
