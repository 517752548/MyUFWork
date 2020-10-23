package com.imop.lj.gameserver.item;

import java.util.Collection;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.container.AbstractItemBag;

/**
 * 临时背包物品过期处理
 * 
 * @author xiaowei.liu
 * 
 */
public class ItemInTempBagDelProcesser implements HeartbeatTask {
	/** 检查道具是否过期的时间间隔，1分钟 */
	private static final long CHECK_DELETE_SPAN = 1 * TimeUtils.MIN;
	private boolean isCanceled;
	private Inventory inventory;
	private Human owner;
	
	public ItemInTempBagDelProcesser(Inventory inventory){
		isCanceled = false;
		this.inventory = inventory;
		this.owner = inventory.getOwner();
	}
	
	@Override
	public void run() {
		if(isCanceled){
			return;
		}
		
		AbstractItemBag bag = this.inventory.getTempBag();
		
		Collection<Item> items = bag.getAll();
		boolean change = false;
		for (Item item : items) {
			if (!item.canDeleteInTemp()) {
				continue;
			}
			
			// 删除道具
			// String name = item.getName();
			item.delete(ItemLogReason.EXPIRED_IN_TEMP_BAG, ItemLogReason.EXPIRED_IN_TEMP_BAG.getReasonText());
			change = true;
//			owner.sendMessage(item.getUpdateMsgAndResetModify());
			item.updateItemWithCache();
			// owner.sendSystemMessage(LangConstants.ITEM_DELETE_SINCE_EXPIRED, name);
		}
		
		if(change){
			bag.onChanged();
		}
	}

	@Override
	public long getRunTimeSpan() {
		return CHECK_DELETE_SPAN;
	}

	@Override
	public void cancel() {
		isCanceled = true;
	}

}
