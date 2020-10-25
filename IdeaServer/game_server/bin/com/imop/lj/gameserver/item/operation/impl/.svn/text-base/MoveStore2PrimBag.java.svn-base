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
 * 仓库道具入包
 * @author yuanbo.gao
 *
 */
public class MoveStore2PrimBag extends AbstractMoveItemOperation {

	@Override
	protected boolean moveImpl(Human user, Item from, Item to) {
		// 不可叠加物品特殊处理
		if (!from.getTemplate().canOverlap()) {
			return this.handleCanNotOverlap(user, from);
		}
		
		//绑定状态
		boolean isBind = from.isBind();
		
		//之前已经对item进行校验，所以此处不做校验
		CommonBag primBag = user.getInventory().getPrimBag();
		ItemTemplate fromItemTemplate = from.getTemplate();
		// 不能全放下，一个也不放
		if (primBag.getMaxCanAdd(fromItemTemplate, isBind) < from.getOverlap()) {
			//放不下
			user.sendSystemMessage(LangConstants.STORE_BAG_2_PRIM_BAG_FAIL);
			return false;
		}
		
		String reasonDetail = from.toJsonObject().toString();
		int dropItemOoverlap = from.getOverlap();
		int fromBagIndex = from.getIndex();
		ItemTemplate tmpl = from.getTemplate();
		
		if (tmpl == null) {
			Loggers.itemLogger.warn("MoveStore2PrimBag.moveImpl the template is null");
			return false;
		}
		Inventory inventory = user.getInventory();
		boolean flag = inventory.dropItem(from.getBagType(), fromBagIndex, ItemLogReason.STORE2PRIM, reasonDetail);
		if (!flag) {
			//临时背包如果更新为空肯定有问题
			Loggers.itemLogger.warn("MoveStore2PrimBag.moveImpl drop item is failed");
			return false;
		}
		
		Collection<Item> updatedPrimBagItems = primBag.add(tmpl, dropItemOoverlap, ItemGenLogReason.STORE2PRIM, reasonDetail, isBind);
		if (updatedPrimBagItems.isEmpty()) {
			//主背包如果更新为空肯定有问题
			Loggers.itemLogger.warn("MoveStore2PrimBag.moveImpl add item is failed");
			return false;
		}
		
		// 更新客户端背包
		for (Item item : updatedPrimBagItems) {
//			GCMessage message = item.getUpdateMsgAndResetModify();
//			user.sendMessage(message);
			item.updateItemWithCache();
		}
		user.sendSystemMessage(LangConstants.STORE_BAG_2_PRIM_BAG_SUCCESS, dropItemOoverlap, tmpl.getName());
		return true;
	}

	private boolean handleCanNotOverlap(Human user, Item from) {
		CommonBag primBag = user.getInventory().getPrimBag();
		CommonBag storeBag = user.getInventory().getStoreBag();
		Item emptySlot = primBag.getEmptySlot();
		if (emptySlot == null) {
			user.sendSystemMessage(LangConstants.STORE_BAG_2_PRIM_BAG_FAIL);
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
		
		primBag.putItem(from);
		storeBag.putItem(emptySlot);
		
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
		if (fromBag == BagType.STORE && toBag == BagType.PRIM) {
			return true;
		} else {
			return false;
		}
	}
}
