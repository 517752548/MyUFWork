package com.imop.lj.gameserver.item;

import java.util.Collection;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.container.AbstractItemBag;

/**
 * 用于扫描道具是否过期，并做相应处理
 *
 *
 */
public class ItemExpireProcesser implements HeartbeatTask {

	/** 检查道具是否过期的时间间隔，10分钟 */
	private static final long CHECK_EXPIRED_SPAN = 10 * TimeUtils.MIN;
	private boolean isCanceled;
	private Inventory inventory;
	private Human owner;

	public ItemExpireProcesser(Inventory inventory) {
		this.inventory = inventory;
		this.owner = inventory.getOwner();
		this.isCanceled = false;
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		//主将装备背包，删除后主将会有属性的变化
		scan(inventory.getBagByPet(owner.getPetManager().getLeader().getUUID()));
		
		//主背包
		scan(inventory.getPrimBag());
	}

	/**
	 * @param bag
	 */
	private void scan(AbstractItemBag bag) {
		Collection<Item> items = bag.getAll();
		for (Item item : items) {
			if (!item.isExpired()) {
				continue;
			}
			// 删除道具
			String name = item.getName();
			item.delete(ItemLogReason.EXPIRED, "");
			bag.onChanged();
			
//			owner.sendMessage(item.getUpdateMsgAndResetModify());
			item.updateItemWithCache();

			owner.sendSystemMessage(LangConstants.ITEM_DELETE_SINCE_EXPIRED, name);
		}
	}

	@Override
	public long getRunTimeSpan() {
		return CHECK_EXPIRED_SPAN;
	}

	@Override
	public void cancel() {
		isCanceled = true;
	}
}
