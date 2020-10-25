package com.imop.lj.gameserver.item.operation.impl;

import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.UseTarget;
import com.imop.lj.gameserver.item.operation.AbstractUseItemOperation;
import com.imop.lj.gameserver.item.operation.MoveItemOperation;
import com.imop.lj.gameserver.item.operation.MoveItemServicePool;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.role.Role;

/**
 * 
 * 使用即移动的情况，使用武器、防具、行囊、格箱等都在这处理，转交给移动服务实现功能
 * 
 * 
 */
public class UseAsMove extends AbstractUseItemOperation {

	// 移动物品实现，判断装备，或者是临时背包物品
	@Override
	protected <T extends Role> boolean canUseImpl(Human user, Item item,int count, T role) {
		return true;
	}

	@Override
	public <T extends Role> boolean isSuitable(Human user, Item item,int count, T role) {
		if (item.getBagType() == BagType.TEMP) {
			return true;
		}
		
		if(role == null){
			return false;
		}

		if(role instanceof Pet){
			Pet pet = (Pet) role;
			if ((item.getBagType() == BagType.PRIM || item.getBagType() == BagType.PET_EQUIP) && (item.isEquipment() )) {
				return checkEquipConditions(user, pet, item, UseTarget.ALL_PET);
			} else if((item.getBagType() == BagType.PRIM || item.getBagType() == BagType.PET_EQUIP) ) {
				return checkEquipConditions(user, pet, item, UseTarget.LEADER_ONLY);
			}
		}
		
//		if(role instanceof Horse){
//			Horse horse = (Horse) role;
//			if ((item.getBagType() == BagType.PRIM || item.getBagType() == BagType.HORSE_EQUIP) && (item.isHorseEquipment())) {
//				return checkHorseEquipConditions(user, horse, item);
//			}
//		}
		return false;
	}

	@Override
	protected <T extends Role> boolean useImpl(Human user, Item item,int count, T role) {
		if(role == null){
			return false;
		}
		
		if (!canUse(user, item,count, role)) {
			return false;
		}
		
		if(role instanceof Pet){
			Pet pet = (Pet) role;
			if ((item.getBagType() == BagType.PRIM || item.getBagType() == BagType.PET_EQUIP) && (item.isEquipment())) {
				return useEquip(user, item, pet);
			}
		}
		
//		if(role instanceof Horse){
//			Horse horse = (Horse) role;
//			if ((item.getBagType() == BagType.PRIM || item.getBagType() == BagType.HORSE_EQUIP) && (item.isHorseEquipment())) {
//				return useHorseEquip(user,item,horse);
//			}
//		}
		
		
		// 穿装备
		
		if (item.getBagType() == BagType.TEMP) {
			return pickUpItemInTemp(user, item);
		}

		return false;
	}

	/**
	 * 从临时背包到主背包移动
	 * 
	 * @param user
	 * @param item
	 * @return
	 */
	protected boolean pickUpItemInTemp(Human user, Item item) {
		BagType fromBag = item.getBagType();
		if (fromBag != BagType.TEMP) {
			return false;
		}
		BagType toBag = BagType.PRIM;
		// 创建一个空Item,只是为了指定目标包
		Item toItem = user.getInventory().getItemByIndex(toBag, 0, 0);

		MoveItemOperation service = MoveItemServicePool.instance.get(fromBag, toBag);
		return service.move(user, item, toItem);
	}
	
//	/**
//	 * 坐骑穿戴物品
//	 * 
//	 * @param user
//	 * @param item
//	 * @param horse
//	 * @return
//	 */
//	protected boolean useHorseEquip(Human user, Item item, Horse horse) {
//		if (horse == null) {
//			return false;
//		}
//		BagType fromBag = item.getBagType();
//		BagType toBag = BagType.NULL;
//		// 根据fromBag决定toBag
//		switch (fromBag) {
//		case PRIM:
//			// 从包里使用装备，就是移动到武将身上
//			toBag = BagType.HORSE_EQUIP;
//			break;
//		case HORSE_EQUIP:
//			// 从武将身上装备栏使用装备，就是移动到主背包
//			toBag = BagType.PRIM;
//			break;
//		default:
//			// 只允许使用身上或者主背包中的装备
//			return false;
//		}
//		// 创建一个空Item,只是为了指定目标包
//		Item toItem = user.getInventory().getItemByIndex(toBag, horse.getUUID(), 0);
//
//		MoveItemOperation service = MoveItemServicePool.instance.get(fromBag, toBag);
//		return service.move(user, horse, item, toItem);
//	}

	/**
	 * 武将穿戴物品
	 * 
	 * @param user
	 * @param item
	 * @param pet
	 * @return
	 */
	protected boolean useEquip(Human user, Item item, Pet pet) {
		if (pet == null) {
			return false;
		}
		BagType fromBag = item.getBagType();
		BagType toBag = BagType.NULL;
		// 根据fromBag决定toBag
		switch (fromBag) {
		case PRIM:
			// 从包里使用装备，就是移动到武将身上
			toBag = BagType.PET_EQUIP;
			break;
		case PET_EQUIP:
			// 从武将身上装备栏使用装备，就是移动到主背包
			toBag = BagType.PRIM;
			break;
		default:
			// 只允许使用身上或者主背包中的装备
			return false;
		}
		
		// 创建一个空Item,只是为了指定目标包
		Item toItem = user.getInventory().getItemByIndex(toBag, pet.getUUID(), 0);

		MoveItemOperation service = MoveItemServicePool.instance.get(fromBag, toBag);
		return service.move(user, pet, item, toItem);
	}
}
