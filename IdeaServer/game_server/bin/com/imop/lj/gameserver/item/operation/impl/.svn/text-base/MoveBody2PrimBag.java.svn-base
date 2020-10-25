package com.imop.lj.gameserver.item.operation.impl;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.container.CommonBag;
import com.imop.lj.gameserver.item.container.PetEquipBag;
import com.imop.lj.gameserver.item.msg.GCSwapItem;
import com.imop.lj.gameserver.item.operation.AbstractMoveItemOperation;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.role.Role;

/**
 * 将装备从身上移回背包，即卸下或替换装备
 * 
 * 
 */
public class MoveBody2PrimBag extends AbstractMoveItemOperation {

	@Override
	protected boolean moveImpl(Human user, Item from, Item to) {
		return false;
	}

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
		
		Pet pet = (Pet) role;
		
		CommonBag bag = user.getInventory().getPrimBag();
		PetEquipBag petBag = user.getInventory().getBagByPet(pet.getUUID());
		if (!to.isEmpty()) {
			// 目标不是空格，找一个空格，脱下时不能同时换上新的装备
			to = bag.getEmptySlot();
			if (to == null) {
				// 放不下,提示背包空间不足
				user.sendSystemMessage(LangConstants.ITEM_NOT_ENOUGH_SPACE);
				return false;
			}
		}
		if (swapItem(from, to, petBag, bag)) {
			// 由于不能脱下装备,同时换装上身,所以只维护脱下的装备
			from.setWearerId(0l);

			// 脱下装备，只发一个swap就行
			GCSwapItem msg = new GCSwapItem(pet.getUUID(), (short) to.getBagType().index, (short) to.getIndex(), 0l,
					(short) from.getBagType().index, (short) from.getIndex());
			user.sendMessage(msg);
			// 重置更改状态
			to.resetModified();
			from.resetModified();
			// 脱下avatar
			petBag.takeOff(from, true);		
			return true;
		}
		return false;
	}

	@Override
	protected boolean isSuiltable(BagType fromBag, BagType toBag) {
		// 从主背包到身上
		if (fromBag == BagType.PET_EQUIP && toBag == BagType.PRIM) {
			return true;
		} else {
			return false;
		}
	}

}
