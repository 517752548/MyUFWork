package com.imop.lj.gameserver.item.operation.impl;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.container.AbstractItemBag;
import com.imop.lj.gameserver.item.container.PetEquipBag;
import com.imop.lj.gameserver.item.operation.AbstractMoveItemOperation;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.role.Role;

/**
 * 将装备从主背包移动到身上，即穿上或替换装备
 * 
 */
public class MovePrimBag2Body extends AbstractMoveItemOperation {

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
		Pet pet = (Pet) role;
		if (from.getPosition() == Position.NULL) {
			return false;
		}
		// 检查要穿装备武将的所有者是否一致
		if (pet.getOwner() != user) {
			return false;
		}
		//战斗中，不能进行此操作
		if (user.isInAnyBattle()) {
			user.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return false;
		}
		// 检查是否能穿上
		if (!canPutOn(pet, from)) {
			return false;
		}
		AbstractItemBag fromBag = user.getInventory().getBagByType(from.getBagType(), pet.getCharId());
		PetEquipBag petBag = user.getInventory().getBagByPet(pet.getUUID());

		if (to.getPosition() != from.getPosition()) {
			// 目标位置不对，自动得找到正确的位置放上去
			to = petBag.getByPosition(from.getPosition());
		}
		if (swapItem(from, to, fromBag, petBag)) {
			from.setWearerId(pet.getUUID());
			to.setWearerId(0l);
			// 这里可能有绑定状态的变化，因此不能发GCSwapItem
//			user.sendMessage(from.getUpdateMsgAndResetModify());
//			user.sendMessage(to.getUpdateMsgAndResetModify());
			from.updateItemWithCache();
			to.updateItemWithCache();
			// 换装
			if (!Item.isEmpty(to)) {
				petBag.takeOff(to, false);
			}
			petBag.putOn(from);
			return true;
		}
		
		return false;
	}

	@Override
	protected boolean isSuiltable(BagType fromBag, BagType toBag) {
		// 从主背包到身上
		if (fromBag == BagType.PRIM && toBag == BagType.PET_EQUIP) {
			return true;
		} else {
			return false;
		}
	}

	/**
	 * 装备穿上条件检查，并给予提示
	 * 
	 * @param equip
	 * @return
	 */
	private boolean canPutOn(Pet pet, Item equip) {
		return equip.getFeature().canPuton(pet, true);
	}
}
