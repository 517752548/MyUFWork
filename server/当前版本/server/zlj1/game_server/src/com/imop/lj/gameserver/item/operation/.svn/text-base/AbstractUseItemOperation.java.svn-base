package com.imop.lj.gameserver.item.operation;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.UseTarget;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.role.Role;

/**
 * UseItemOperation的骨架实现
 * 
 * 
 */
public abstract class AbstractUseItemOperation implements UseItemOperation {

	@Override
	public abstract <T extends Role> boolean isSuitable(Human user, Item item,int count, T role);

	/**
	 * 是否可以执行使用道具的操作，即是否满足所有使用此道具的条件，此方法返回true时调用use方法应该使用成功
	 * 首先判断是否为空，在调用isSuitable 方法，再调用canUseImpl 方法
	 * 
	 * @param user
	 *            使用者
	 * @param item
	 *            使用的道具
	 * @param target
	 *            使用目标
	 * @return
	 */
	@Override
	public final <T extends Role> boolean canUse(Human user, Item item,int count, T role) {
		// 空道具不能使用
		if (Item.isEmpty(item)) {
			return false;
		}

		// 本Operation处理不了的使用请求一定返回false
		if (!isSuitable(user, item,count, role)) {
			return false;
		}
		return canUseImpl(user, item,count, role);
	}

	@Override
	public final <T extends Role> boolean use(Human user,Item item,int count , T role) {
		// 这里不再检查一遍使用条件了，调用者需要在调用前用canUse检查条件
		return useImpl(user, item,count, role);
	}

	
	
	@Override
	public <T extends Role> boolean cost(Human user, Item item, int count, T pet) {
		// 默认不需要扣除道具
		return true;
	}

	/**
	 * 子类实现使用条件的判断，等级、职业、性别、锁定、过期等道具使用的一般条件不需要在这里检查，这里只判断使用此类功能道具的特殊条件
	 * 
	 * 
	 * @return
	 */
	protected abstract <T extends Role> boolean canUseImpl(Human user, Item item,int count, T role);

	/**
	 * 子类实现具体的使用操作
	 * 
	 * @param user
	 *            使用者
	 * @param item
	 *            被使用的item的引用，但调用此方法时已经执行完扣减，因此item可能为空，其关键属性可能已经清楚掉了
	 * @param itemInfo
	 *            在扣减前收集的道具信息，道具的使用效果等信息需要在这个参数中获得
	 * @param target
	 *            目标
	 * @return 如果使用成功返回true，否则返回false
	 */
	protected abstract <T extends Role> boolean useImpl(Human user, Item item,int count, T role);

	/**
	 * 检查穿装备道具的一般条件
	 * 
	 * @param user
	 * @param item
	 * @return
	 */
	public static boolean checkEquipConditions(Human user, Pet pet, Item item, UseTarget target) {
		if (Item.isEmpty(item)) {
			return false;
		}

//		// 判断是否是装备
//		if (!item.isEquipment()) {
//			user.sendSystemMessage(LangConstants.INVAILD_PUT_ON_ITEM);
//			return false;
//		}

		if (item.getOwner() == null || item.getOwner() != user) {
			// 没有owner或者不是自己的道具不能使用
			return false;
		}

		// 查看此道具是否处于可用状态
		if (!item.checkAvailable()) {
			// 此道具当前不可用
			user.sendSystemMessage(LangConstants.INVAILD_PUT_ON_ITEM);
			return false;
		}

		// 穿装备和脱装备pet必须非空,判断item和武将所属human是否一致
		if (pet == null || pet.getOwner() != user) {
			return false;
		}

		// 如果是从装备背包到主背包，不需要判断等级和使用对象
		if (item.getBagType() == BagType.PET_EQUIP) {
			return true;
		}

		// 判断能不能使用
		if (!item.isCanUsed()) {
			user.sendSystemMessage(LangConstants.INVAILD_PUT_ON_ITEM);
			return false;
		}

		// 判断穿得装备是否是主背包
		if (item.getBagType() != BagType.PRIM) {
			user.sendSystemMessage(LangConstants.INVAILD_PUT_ON_ITEM);
			return false;
		}
		// TODO 判断是否过期

		// 判断等级和使用对象
		switch (target) {
		// 错误
		case WITHOUT_TARGET:
			return false;
			// 只有伙伴能穿
		case PET_WITHOUT_LEADER:
			if (pet.isLeader()) {
				return false;
			}
			break;
		// 只有主将能穿
		case LEADER_ONLY:
			if (!pet.isLeader()) {
				return false;
			}
			break;
		// 所有武将能穿
		case ALL_PET:
			break;
		default:
			return false;
		}

//		// 判断等级
//		if (item.getLevel() != 0 && pet.getLevel() < item.getLevel()) {
//			user.sendSystemMessage(LangConstants.ITEM_USEFAIL_LEVEL);
//			return false;
//		} else {
//			return true;
//		}
		return true;
	}
	
//	/**
//	 * 检查穿坐骑装备道具的一般条件
//	 * 
//	 * @param user
//	 * @param item
//	 * @return
//	 */
//	public static boolean checkHorseEquipConditions(Human user, Horse horse, Item item) {
//		if (Item.isEmpty(item)) {
//			return false;
//		}
//
//		if (item.getOwner() == null || item.getOwner() != user) {
//			// 没有owner或者不是自己的道具不能使用
//			return false;
//		}
//
//		// 查看此道具是否处于可用状态
//		if (!item.checkAvailable()) {
//			// 此道具当前不可用
//			user.sendSystemMessage(LangConstants.INVAILD_PUT_ON_ITEM);
//			return false;
//		}
//
//		// 穿装备和脱装备pet必须非空,判断item和武将所属human是否一致
//		if (horse == null || horse.getOwner() != user) {
//			return false;
//		}
//
//		// 如果是从装备背包到主背包，不需要判断等级和使用对象
//		if (item.getBagType() == BagType.HORSE_EQUIP) {
//			return true;
//		}
//
//		// 判断能不能使用
//		if (!item.isCanUsed()) {
//			user.sendSystemMessage(LangConstants.INVAILD_PUT_ON_ITEM);
//			return false;
//		}
//
//		// 判断穿得装备是否是主背包
//		if (item.getBagType() != BagType.PRIM) {
//			user.sendSystemMessage(LangConstants.INVAILD_PUT_ON_ITEM);
//			return false;
//		}
//
//		// 判断等级
//		if (item.getLevel() != 0 && horse.getLevel() < item.getLevel()) {
//			user.sendSystemMessage(LangConstants.ITEM_USEFAIL_LEVEL);
//			return false;
//		} else {
//			return true;
//		}
//	}

//	/**
//	 * 检查消耗物道具的一般条件
//	 * 
//	 * @param user
//	 * @param item
//	 * @return
//	 */
//	public static boolean checkComsumeConditions(Human user, Pet pet, Item item, UseTarget target) {
//		if (Item.isEmpty(item)) {
//			return false;
//		}
//
//		// 判断是否是可消耗物
//		if (!item.isConsumable()) {
//			user.sendSystemMessage(LangConstants.ITEM_NOT_AVAILABLE);
//			return false;
//		}
//
//		if (item.getOwner() == null || item.getOwner() != user) {
//			// 没有owner或者不是自己的道具不能使用
//			return false;
//		}
//
//		// 查看此道具是否处于可用状态
//		if (!item.checkAvailable()) {
//			// 此道具当前不可用
//			user.sendSystemMessage(LangConstants.ITEM_NOT_AVAILABLE);
//			return false;
//		}
//
//		// 判断能不能使用
//		if (!item.isCanUsed()) {
//			return false;
//		}
//
//		// 如果此道具不是主背包装备非法
//		BagType bagType = item.getBagType();
//		if (!AbstractItemBag.isPrimBag(bagType)) {
//			user.sendSystemMessage(LangConstants.INVAILD_USE_ITEM);
//			return false;
//		}
//
//		// TODO 判断过期物品
//
//		// 判断消耗物的使用等级和使用对象
//		switch (target) {
//		// 与武将无关根据角色等级判断等级条件
//		case WITHOUT_TARGET:
//			if (item.getLevel() != 0 && user.getLevel() < item.getLevel()) {
//				user.sendSystemMessage(LangConstants.ITEM_USEFAIL_LEVEL);
//				return false;
//			} else {
//				return true;
//			}
//			// 只能伙伴使用
//		case PET_WITHOUT_LEADER:
//			if (pet == null || pet.getOwner() != user) {
//				return false;
//			}
//			if (pet.isLeader()) {
//				return false;
//			}
//			break;
//		// 只有主将能使用
//		case LEADER_ONLY:
//			if (pet == null || pet.getOwner() != user) {
//				return false;
//			}
//			if (!pet.isLeader()) {
//				return false;
//			}
//
//			break;
//		// 武将都能使用
//		case ALL_PET:
//			if (pet == null || pet.getOwner() != user) {
//				return false;
//			}
//			break;
//		default:
//			return false;
//		}
//
//		// 判断武将的等级条件
//		if (item.getLevel() != 0 && pet.getLevel() < item.getLevel()) {
//			user.sendSystemMessage(LangConstants.ITEM_USEFAIL_LEVEL);
//			return false;
//		} else {
//			return true;
//		}
//	}
//
//	/**
//	 * 扣减一个的默认操作，一般情况下使用消耗品都是这种形式
//	 * 
//	 * @param item
//	 * @return
//	 */
//	protected static boolean consumeOne(Human user, Item item) {
//		if (Item.isEmpty(item)) {
//			return false;
//		}
//		int left = item.getOverlap() - 1;
//		if (left < 0) {
//			left = 0;
//		}
//		// 执行扣减
//		item.changeOverlap(left, ItemLogReason.USED, "", "", true);
//		// 发送消息
//		user.sendMessage(item.getUpdateMsgAndResetModify());
//		return true;
//	}
}
