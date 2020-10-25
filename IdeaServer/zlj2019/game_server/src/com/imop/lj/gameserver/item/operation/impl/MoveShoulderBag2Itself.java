package com.imop.lj.gameserver.item.operation.impl;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.container.AbstractItemBag;
import com.imop.lj.gameserver.item.msg.GCSwapItem;
import com.imop.lj.gameserver.item.operation.AbstractMoveItemOperation;
import com.imop.lj.gameserver.role.Role;

/**
 * 
 * 背包向自己里面移动中移动道具,包括<br/>
 * 主背包->主背包，<br/>
 * 材料包->材料包，<br/>
 * 任务道具包->任务道具包，<br/>
 * 仓库->仓库
 * 
 * 
 */
public class MoveShoulderBag2Itself extends AbstractMoveItemOperation {

	@Override
	protected boolean isSuiltable(BagType fromBag, BagType toBag) {
		// 只适用于主背包、材料包、任务道具包、仓库四个包往自己里面移动
		boolean fromPass = AbstractItemBag.isPrimBag(fromBag);
		boolean toPass = (toBag == fromBag);
		return fromPass && toPass;
	}

	@Override
	protected boolean moveImpl(Human user, Item from, Item to) {
		int fromOverlap = from.getOverlap();
		int toOverlap = to.getOverlap();
		int maxOverlap = to.getMaxOverlap();
		ItemLogReason reason = ItemLogReason.SHOULDERBAG2ITSELF;
		if (Item.canMerge(from, to) && toOverlap < to.getMaxOverlap()) {
			// 可以叠加，名且to还没有叠加满，处理叠加
			int total = fromOverlap + toOverlap;
			if (total > maxOverlap) {
				// to也放不下全部的，还得占两个格子，to调整为最大叠加数，from调整为剩下的
				to.changeOverlap(maxOverlap, reason, "", "", true);
				from.changeOverlap(total - maxOverlap, reason, "", "", true);
			} else {
				// to能全放下，将to的数量调整为total，将from干掉
				to.changeOverlap(total, reason, "", "", true);
				from.changeOverlap(0, reason, "", "", true);
			}
			// 两个Item已经变了，单独发消息
//			user.sendMessage(to.getUpdateMsgAndResetModify());
//			user.sendMessage(from.getUpdateMsgAndResetModify());
			to.updateItemWithCache();
			from.updateItemWithCache();
			return true;
		} else {
			// 不需要考虑叠加，可能是从移动到空格或者别的道具上，直接交换即可
			if (swapItem(from, to)) {
				// 两个道具肯定没变，只发一个swap就行
				GCSwapItem msg = new GCSwapItem(0l, (short) to.getBagType().index, (short) to.getIndex(), 0l, (short) from.getBagType().index,
						(short) from.getIndex());
				user.sendMessage(msg);
				// 重置更改状态
				from.resetModified();
				to.resetModified();
				return true;
			}
		}
		return false;
	}

	/**
	 * 主背包之间不需要走这个方法
	 */
	@Override
	protected <T extends Role> boolean moveImpl(Human user, T wearer, Item fromItem, Item toItem) {
		return false;
	}
}