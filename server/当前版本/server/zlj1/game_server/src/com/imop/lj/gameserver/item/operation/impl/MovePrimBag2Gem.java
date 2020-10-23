package com.imop.lj.gameserver.item.operation.impl;

import com.imop.lj.common.LogReasons;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.container.PetGemBag;
import com.imop.lj.gameserver.item.operation.AbstractMoveItemOperation;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.role.Role;

/**
 * 将装备从主背包移动到身上的宝石背包，即镶嵌或者替换宝石
 * 
 */
public class MovePrimBag2Gem extends AbstractMoveItemOperation {

	@Override
	protected boolean moveImpl(Human user, Item from, Item to) {
		return false;
	}
	
	/***
	 * 镶嵌宝石
	 * from 主背包
	 * to 宝石包，to实际上是空的，不考虑交换
	 */
	@Override
	protected <T extends Role> boolean moveImpl(Human user, T role, Item from, Item to) {
		if(role == null){
			return false;
		}
		if(!(role instanceof Pet)){
			return false;
		}
		Pet pet = (Pet) role;
		// 检查要穿装备武将的所有者是否一致
		if (pet.getOwner() != user) {
			return false;
		}
		//战斗中，不能进行此操作
		if (user.isInAnyBattle()) {
			user.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return false;
		}
//		// 检查是否能穿上 TODO 这里的判断写在equipService里面
//		if (!canPutOn(pet, from)) {
//			return false;
//		}
		ItemTemplate temp =  from.getTemplate();
		//主背包中宝石对应的overlap减少
		boolean result = user.getInventory().removeItemByIndex(from.getBagType(), from.getIndex(), 1, LogReasons.ItemLogReason.COST_ITEM_FOR_SET_GEM, LogUtils.genReasonText(LogReasons.ItemLogReason.COST_ITEM_FOR_SET_GEM, from.getTemplateId()));
		if(!result){
			//未知原因失败
			return false;
		}
		if(!from.getLifeCycle().isDestroyed()){
			from.setModified();
			//user.sendMessage(from.getUpdateMsgAndResetModify());
		}
		PetGemBag gemBag = user.getInventory().getGemBagByPet(pet.getUUID());
		gemBag.addGem(to, temp,LogReasons.ItemGenLogReason.GEM_SET, LogUtils.genReasonText(LogReasons.ItemGenLogReason.GEM_SET, from.getTemplateId()));
		return true;
	}


	@Override
	protected boolean isSuiltable(BagType fromBag, BagType toBag) {
		// 从主背包到身上
		if (fromBag == BagType.PRIM && toBag == BagType.PET_GEM) {
			return true;
		} else {
			return false;
		}
	}

//	/**
//	 * 装备穿上条件检查，并给予提示
//	 * 
//	 * @param equip
//	 * @return
//	 */
//	private boolean canPutOn(Pet pet, Item equip) {
//		return equip.getFeature().canPuton(pet, true);
//	}
}
