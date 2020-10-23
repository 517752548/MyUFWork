package com.imop.lj.gameserver.item.operation.impl;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef;
import com.imop.lj.gameserver.item.ItemDef.ConsumableFunc;
//import com.imop.lj.gameserver.item.ItemDef.CostType;
import com.imop.lj.gameserver.item.ItemDef.IdentityType;
import com.imop.lj.gameserver.item.operation.AbstractUseItemOperation;
import com.imop.lj.gameserver.item.template.ConsumeItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.role.Role;

public abstract class AbstractConsumeOperation extends AbstractUseItemOperation {

	@Override
	public <T extends Role> boolean isSuitable(Human user, Item item, int count, T pet) {
		if (Item.isEmpty(item)) {
			return false;
		}
		return hasConsumableFunc(item, getConsumableFunc());
	}
	
	@Override
	protected <T extends Role> boolean canUseImpl(Human user, Item item, int count, T role) {
		if (item.getBagType() != BagType.PRIM) {
			return false;
		}
		
		if (item.getOwner() != user) {
			return false;
		}
		
		// 需求级别大于玩家级别
		if (item.getTemplate().getLevel() > user.getLevel()) {
			user.sendErrorMessage(LangConstants.USE_ITEM_FAIL_NOT_ENOUGH_LEVEL, item.getTemplate().getLevel());
			return false;
		}
		
		return user.getInventory().hasItemByTmplId(item.getTemplateId(), count);
	}
	
	
	/**
	 * 检查一个道具是否具有指定的消耗品功能
	 * 
	 * @param item
	 * @param func
	 * @return
	 */
	protected boolean hasConsumableFunc(Item item, ItemDef.ConsumableFunc func) {
		if (item.getBagType() != BagType.PRIM) {
			return false;
		}
		
		ItemTemplate itemTmpl = item.getTemplate();
		if (itemTmpl.getIdendityType() != ItemDef.IdentityType.CONSUMABLE) {
			return false;
		}
		if (itemTmpl.getIdendityType() == IdentityType.CONSUMABLE) {
			ConsumeItemTemplate template = (ConsumeItemTemplate) itemTmpl;
			if (template.getFunction() == func) {
				return true;
			}
		}
		return false;
	}
	
	public abstract ConsumableFunc getConsumableFunc();
}
