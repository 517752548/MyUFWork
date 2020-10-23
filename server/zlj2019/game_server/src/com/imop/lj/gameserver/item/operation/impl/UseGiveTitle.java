package com.imop.lj.gameserver.item.operation.impl;

import java.util.Collection;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.ConsumableFunc;
import com.imop.lj.gameserver.item.template.ConsumeItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.role.Role;

/**
 * 给称号
 */
public class UseGiveTitle extends AbstractConsumeOperation {

	@Override
	protected <T extends Role> boolean canUseImpl(Human user, Item item, int count, T role) {
		if (!super.canUseImpl(user, item, count, role)) {
			return false;
		}
		//战斗中无法使用
		if (user.isInAnyBattle()) {
			return false;
		}
		
		ItemTemplate it = item.getTemplate();
		if(it == null || !(it instanceof ConsumeItemTemplate)){
			return false;
		}
		
		return true;
	}
	
	@Override
	public ConsumableFunc getConsumableFunc() {
		return ConsumableFunc.TITLE_CARD;
	}

	@Override
	protected <T extends Role> boolean useImpl(Human user, Item item, int count, T role) {
		//每次只能增加一个
		if (count != 1) {
			return false;
		}
		
		ItemTemplate it = item.getTemplate();
		if (it == null || !(it instanceof ConsumeItemTemplate)) {
			return false;
		}
		
		ConsumeItemTemplate consume = (ConsumeItemTemplate) it;
		int titleId = consume.getArgA();
		String detail = LogUtils.genReasonText(ItemLogReason.TITLE_CARD_COST, titleId);
		//扣除道具
		Collection<Item> coll = user.getInventory().removeItem(it.getId(), 1, 
				ItemLogReason.TITLE_CARD_COST, detail, true);
		if (coll.isEmpty()) {
			return false;
		}
		
		//添加称号
		Globals.getTitleService().addTitleInfo(user.getCharId(), titleId);
		
		return true;
	}

}
