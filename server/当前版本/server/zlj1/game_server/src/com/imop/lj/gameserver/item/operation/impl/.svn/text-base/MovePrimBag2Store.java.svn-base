package com.imop.lj.gameserver.item.operation.impl;

import java.util.Collection;

import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Inventory;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.container.CommonBag;
import com.imop.lj.gameserver.item.operation.AbstractMoveItemOperation;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.role.Role;

/**
 * 主背包道具入仓库
 * @author yuanbo.gao
 *
 */
public class MovePrimBag2Store extends AbstractMoveItemOperation {

	@Override
	protected boolean moveImpl(Human user, Item from, Item to) {
		//有时效道具不能存到仓库
		if (from.isTimeLimitItem()) {
			user.sendSystemMessage(LangConstants.PRIM_BAG_2_STORE_BAG_FAIL_NO_TIMELIMIT_ITEM);
			return false;
		}
		
		// 不可叠加物品特殊处理
		if (!from.getTemplate().canOverlap()) {
			return this.handleCanNotOverlap(user, from);
		}
		
		//之前已经对item进行校验，所以此处不做校验
		CommonBag storeBag = user.getInventory().getStoreBag();
		ItemTemplate fromItemTemplate = from.getTemplate();
		// 不能全放下，一个也不放
		if (storeBag.getMaxCanAdd(fromItemTemplate) < from.getOverlap()) {
			//放不下
			user.sendSystemMessage(LangConstants.PRIM_BAG_2_STORE_BAG_FAIL);
			return false;
		}
		
		String reasonDetail = from.toJsonObject().toString();
		int dropItemOoverlap = from.getOverlap();
		int fromBagIndex = from.getIndex();
		ItemTemplate tmpl = from.getTemplate();
		
		if (tmpl == null) {
			Loggers.itemLogger.warn("MovePrimBag2Store.moveImpl the template is null");
			return false;
		}
		
		Inventory inventory = user.getInventory();
		boolean flag = inventory.dropItem(from.getBagType(), fromBagIndex, ItemLogReason.PRIM2STORE, reasonDetail);
		if (!flag) {
			//临时背包如果更新为空肯定有问题
			Loggers.itemLogger.warn("MovePrimBag2Store.moveImpl drop item is failed");
			return false;
		}
		
		Collection<Item> updatedPrimBagItems = storeBag.add(tmpl, dropItemOoverlap, ItemGenLogReason.PRIM2STORE, reasonDetail);
		if (updatedPrimBagItems.isEmpty()) {
			//主背包如果更新为空肯定有问题
			Loggers.itemLogger.warn("MovePrimBag2Store.moveImpl add item is failed");
			return false;
		}
		
		// 更新客户端背包
		for (Item item : updatedPrimBagItems) {
//			GCMessage message = item.getUpdateMsgAndResetModify();
//			user.sendMessage(message);
			item.updateItemWithCache();
		}
		user.sendSystemMessage(LangConstants.PRIM_BAG_2_STORE_BAG_SUCCESS, dropItemOoverlap, tmpl.getName());
		return true;
	}

	private boolean handleCanNotOverlap(Human user, Item from) {
		CommonBag primBag = user.getInventory().getPrimBag();
		CommonBag storeBag = user.getInventory().getStoreBag();
		Item emptySlot = storeBag.getEmptySlot();
		if (emptySlot == null) {
			user.sendSystemMessage(LangConstants.PRIM_BAG_2_STORE_BAG_FAIL);
			return false;
		}
		
		BagType fromType = from.getBagType();
		int fromIndex = from.getIndex();
		
		BagType toType = emptySlot.getBagType();
		int toIndex = emptySlot.getIndex();
		
		from.setBagType(toType);
		from.setIndex(toIndex);
		
		emptySlot.setBagType(fromType);
		emptySlot.setIndex(fromIndex);
		
		storeBag.putItem(from);
		primBag.putItem(emptySlot);
		
//		user.sendMessage(from.getUpdateMsgAndResetModify());
//		user.sendMessage(emptySlot.getUpdateMsgAndResetModify());
		from.updateItemWithCache();
		emptySlot.updateItemWithCache();
		return true;
	}
	
	@Override
	protected <T extends Role> boolean moveImpl(Human user, T wearer, Item from, Item to) {
		return false;
	}

	@Override
	protected boolean isSuiltable(BagType fromBag, BagType toBag) {
		if (fromBag == BagType.PRIM && toBag == BagType.STORE) {
			return true;
		} else {
			return false;
		}
	}
}
