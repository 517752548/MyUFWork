package com.imop.lj.gameserver.item.operation.impl;

import java.util.Collection;

import com.imop.lj.common.LogReasons;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.container.CommonBag;
import com.imop.lj.gameserver.item.operation.AbstractMoveItemOperation;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.role.Role;

/**
 * 将装备从身上移回背包，即卸下或替换装备
 * 
 * 
 */
public class MoveGem2PrimBag extends AbstractMoveItemOperation {

	@Override
	protected boolean moveImpl(Human user, Item from, Item to) {
		return false;
	}
	/**
	 * 卸下宝石
	 */
	@Override
	protected <T extends Role> boolean moveImpl(Human user, T role, Item from, Item to) {
		if(role == null){
			return false;
		}
		if(!(role instanceof Pet)){
			return false;
		}
		//战斗中，不能进行此操作
		if (user.isInAnyBattle()) {
			user.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return false;
		}
		int itemNum = 1;
		
		CommonBag primBag = user.getInventory().getPrimBag();
		// 不能全放下，一个也不放
		if (primBag.getMaxCanAdd(from.getTemplate()) < itemNum) {
			//放不下
			user.sendSystemMessage(LangConstants.PRIM_BAG_NOT_ENOUGH_SPACE);
			return false;
		}
		
		Integer tempId =  from.getTemplateId();
		//删除宝石包的物品
		//主背包中宝石对应的overlap减少
		//这个方法只能主背包用: boolean result = user.getInventory().removeItemByIndex(from.getBagType(), from.getIndex(), 1, LogReasons.ItemLogReason.COST_ITEM_FOR_SET_GEM, LogUtils.genReasonText(LogReasons.ItemLogReason.COST_ITEM_FOR_SET_GEM, from.getTemplateId()));
		from.delete(LogReasons.ItemLogReason.COST_ITEM_FOR_TAKE_OFF_GEM, LogUtils.genReasonText(LogReasons.ItemLogReason.COST_ITEM_FOR_TAKE_OFF_GEM, from.getTemplateId()));
		//像主背包里面添加一个宝石
		Collection<Item> newItems = user.getInventory().addItem(tempId, itemNum, LogReasons.ItemGenLogReason.GEM_TAKE_OFF, LogUtils.genReasonText(LogReasons.ItemGenLogReason.GEM_TAKE_OFF, tempId), false);
		
//		user.sendMessage(from.getUpdateMsgAndResetModify());
		from.updateItemWithCache();
		for(Item item : newItems){
			//user.sendMessage(item.getUpdateMsgAndResetModify());
			item.setModified();
		}
		return true;
	}

	@Override
	protected boolean isSuiltable(BagType fromBag, BagType toBag) {
		// 从主背包到身上
		if (fromBag == BagType.PET_GEM && toBag == BagType.PRIM) {
			return true;
		} else {
			return false;
		}
	}

}
