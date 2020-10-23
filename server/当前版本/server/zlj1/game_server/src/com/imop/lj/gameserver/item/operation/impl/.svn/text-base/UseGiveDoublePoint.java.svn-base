package com.imop.lj.gameserver.item.operation.impl;

import java.util.Collection;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.TowerLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.ConsumableFunc;
import com.imop.lj.gameserver.item.template.ConsumeItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.offlinedata.UserOfflineData;
import com.imop.lj.gameserver.role.Role;

/**
 * 使用双倍经验丹
 * 
 * 
 */
public class UseGiveDoublePoint extends AbstractConsumeOperation {

	@Override
	protected <T extends Role> boolean canUseImpl(Human user, Item item, int count, T role) {
		if(!super.canUseImpl(user, item, count, role)){
			return false;
		}
		//战斗中无法使用双倍经验丹
		if (user.isInAnyBattle()) {
			return false;
		}
		return true;
	}
	
	@Override
	public ConsumableFunc getConsumableFunc() {
		return ConsumableFunc.GIVE_DOUBLE_POINT;
	}

	@Override
	protected <T extends Role> boolean useImpl(Human user, Item item, int count, T role) {
		// 每次只能增加一个双倍经验丹
		if(count != 1){
			return false;
		}
		
		ItemTemplate it = item.getTemplate();
		if(it == null || !(it instanceof ConsumeItemTemplate)){
			return false;
		}
		
		// 扣除双倍经验丹成功
		Collection<Item> coll = user.getInventory().removeItem(it.getId(), 1, ItemLogReason.DOUBLE_POINT_COST, ItemLogReason.DOUBLE_POINT_COST.getReasonText());
		if(coll.isEmpty()){
			return false;
		}
		
		// 增加双倍经验点数
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(user.getCharId());
		if(offlineData == null){
			return false;
		}
		
		int afterPoint = offlineData.getCurDoublePoint() + Globals.getGameConstants().getUseGiveDoublePointNum();
		if(afterPoint > Globals.getGameConstants().getSysGiveDoublePointMax()){
			user.sendErrorMessage(LangConstants.DOUBLE_POINT_IS_FULL, Globals.getGameConstants().getSysGiveDoublePointMax());
			return false;
		}
		offlineData.setCurDoublePoint(afterPoint);
		
		if(user.getTowerManager() == null){
			return false;
		}
		//发送消息
		user.sendErrorMessage(LangConstants.USE_GIVE_DOUBLE_POINT_OK,Globals.getGameConstants().getUseGiveDoublePointNum());
		//记录日志
		Globals.getLogService().sendTowerLog(user, TowerLogReason.USE_DOUBLE_POINT,  "", 
				user.getTowerManager().getCurTowerLevel(),
				offlineData.getCurDoublePoint(),
				offlineData.getIsOpenDouble());
		return true;
	}

}
