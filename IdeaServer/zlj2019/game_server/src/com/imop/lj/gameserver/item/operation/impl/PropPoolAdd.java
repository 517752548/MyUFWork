package com.imop.lj.gameserver.item.operation.impl;

import java.util.Collection;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.ResultTypes;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.ConsumableFunc;
import com.imop.lj.gameserver.item.ItemDef.PoolAddType;
import com.imop.lj.gameserver.item.msg.GCUsePoolAddResult;
import com.imop.lj.gameserver.item.template.ConsumeItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.role.Role;

/**
 * 池子增加数值
 * 
 */
public class PropPoolAdd extends AbstractConsumeOperation {

	@Override
	public ConsumableFunc getConsumableFunc() {
		return ConsumableFunc.PROP_POOL_ADD;
	}

	@Override
	protected <T extends Role> boolean useImpl(Human human, Item item, int count, T role) {
		ItemTemplate it = item.getTemplate();
		if(it == null || !(it instanceof ConsumeItemTemplate)){
			return false;
		}
		
		ConsumeItemTemplate tpl = (ConsumeItemTemplate) it;
		PoolAddType type = tpl.getPoolAddType();
		long addValue = tpl.getArgB() * count;
		
		//扣道具
		Collection<Item> ret = human.getInventory().removeItem(it.getId(), count, 
				ItemLogReason.PROP_POOL_ADD, ItemLogReason.PROP_POOL_ADD.getReasonText(), true);
		if (ret == null || ret.isEmpty()) {
			return false;
		}
		
		//池子数值更新
		boolean flag = Globals.getBattleService().onUseItemPoolAdd(human, type, addValue);
		if (flag) {
			human.sendErrorMessage(LangConstants.ITEM_POOL_ADD_USE_OK, Globals.getLangService().readSysLang(type.getNameKey()), addValue+"");
		} else {
			human.sendErrorMessage(LangConstants.ITEM_USE_FAILED);
		}
		
		//通知前台使用成功
		human.sendMessage(new GCUsePoolAddResult(tpl.getId(), ResultTypes.SUCCESS.getIndex()));
		return true;
	}

}
