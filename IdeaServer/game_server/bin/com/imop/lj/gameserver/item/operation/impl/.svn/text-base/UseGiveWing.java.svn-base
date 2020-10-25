package com.imop.lj.gameserver.item.operation.impl;

import java.util.Collection;
import java.util.List;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.WingLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.ConsumableFunc;
import com.imop.lj.gameserver.item.template.ConsumeItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.role.Role;
import com.imop.lj.gameserver.wing.Wing;
import com.imop.lj.gameserver.wing.WingManager;
import com.imop.lj.gameserver.wing.template.WingTemplate;

/**
 * 给翅膀卡
 * 
 * 
 */
public class UseGiveWing extends AbstractConsumeOperation {

	@Override
	protected <T extends Role> boolean canUseImpl(Human user, Item item, int count, T role) {
		if(!super.canUseImpl(user, item, count, role)){
			return false;
		}
		//战斗中无法使用翅膀
		if (user.isInAnyBattle()) {
			return false;
		}
		//判断玩家是否已有翅膀卡
		ItemTemplate it = item.getTemplate();
		if(it == null || !(it instanceof ConsumeItemTemplate)){
			return false;
		}
		ConsumeItemTemplate consume = (ConsumeItemTemplate) it;
		List<Wing> wLists = user.getWingManager().getAllWingList();
		if (wLists != null) {
			for (Wing w : wLists) {
				if (w.getTemplate().getId() == consume.getArgA()) {
					user.sendErrorMessage(LangConstants.WING_REPEAT);
					return false;
				}
			}
		}
		return true;
	}
	
	@Override
	public ConsumableFunc getConsumableFunc() {
		return ConsumableFunc.GIVE_WING_CARD;
	}

	@Override
	protected <T extends Role> boolean useImpl(Human user, Item item, int count, T role) {
		// 每次只能增加一个翅膀
		if(count != 1){
			return false;
		}
		
		ItemTemplate it = item.getTemplate();
		if(it == null || !(it instanceof ConsumeItemTemplate)){
			return false;
		}
		
		ConsumeItemTemplate consume = (ConsumeItemTemplate) it;
		WingTemplate wingTemp = Globals.getTemplateCacheService().get(consume.getArgA(), WingTemplate.class);
		
		// 扣除翅膀卡成功
		Collection<Item> coll = user.getInventory().removeItem(it.getId(), 1, ItemLogReason.WING_CARD_COST, ItemLogReason.WING_CARD_COST.getReasonText(), true);
		if(coll.isEmpty()){
			return false;
		}
		
		// 添加翅膀
		Globals.getWingService().createNewWing(user, wingTemp.getId());
		
		
		//记录日志
		String genDetailReason = LogUtils.genReasonText(WingLogReason.USE_WING_CARD,it.getId());
		Globals.getLogService().sendWingLog(user, WingLogReason.USE_WING_CARD, genDetailReason, wingTemp.getId(), 0, 0, 0);
		
		WingManager wingManager = user.getWingManager();
		if(wingManager == null){
			return false;
		}
		//翅膀第一次获得的时候,直接是装备状态
		if(wingManager.getAllWingList().size() == 1){
			Globals.getWingService().useWing(user, wingTemp.getId());
		}
		return true;
	}

}
