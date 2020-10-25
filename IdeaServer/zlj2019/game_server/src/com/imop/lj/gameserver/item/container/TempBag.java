package com.imop.lj.gameserver.item.container;

import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.List;

import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.ReasonDesc;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.template.ItemTemplate;

/**
 * 临时背包
 * 
 * @author yuanbo.gao
 * 
 */
public class TempBag extends CommonBag {

	public TempBag(Human owner, BagType bagType, int capacity) {
		super(owner, bagType, capacity);
	}

	/**
	 * 临时背包只叠加空的背包，不叠加物品
	 */
	@Override
	public int getMaxCanAdd(ItemTemplate itemTemplate, boolean isBind) {
		int count = 0;
		final int overlap = itemTemplate.getMaxOverlap();
		for (Item item : items) {
			if (Item.isEmpty(item)) {
				count += overlap;
			}
		}
		return count;
	}

	@Override
	public Collection<Item> add(ItemTemplate template, int count, ItemGenLogReason reason, String detailReason, boolean isBind) {
		if (count == 0) {
			return Collections.emptyList();
		}
		// 不能全放下，一个也不放
		if (getMaxCanAdd(template, isBind) < count) {
			return Collections.emptyList();
		}

		boolean needSendLog = true;
		String genKey = "";
		try {
			do {
				// 记录道具产生日志
				genKey = KeyUtil.UUIDKey();
				Globals.getLogService().sendItemGenLog(owner, reason, detailReason, template.getId(), template.getName(), count, 0, "", genKey);
				// 增加物品增加原因到reasonDetail
				String countChangeReason = " [genReason:" + reason.getClass().getField(reason.name()).getAnnotation(ReasonDesc.class).value() + "] ";
				detailReason = detailReason == null ? countChangeReason : detailReason + countChangeReason;
			} while (false);
		} catch (Exception e) {
			Loggers.itemLogger.error(LogUtils.buildLogInfoStr(owner.getUUID() + "", "记录向包中添加一定数量物品日志时出错"), e);
		}
		List<Item> updateList = new ArrayList<Item>();
		int left = count;
		// 还没全放下,就添加到空格中
		if (left > 0) {
			left = addToEmptySlot(template, left, ItemLogReason.COUNT_ADD, detailReason, genKey, updateList, needSendLog, isBind);
		}
		// 还没全放下，肯定出错了
		if (left != 0) {
			Loggers.itemLogger.error(LogUtils.buildLogInfoStr(owner.getUUID() + "",
					String.format("出现添加道具不完全的异常， itemId=%d count=%d left=%d", template.getId(), count, left)));
		}

		return updateList;
	}

	/**
	 * 向空格中增加道具，不叠加，考虑道具的绑定状态，尽力放置，如果放不下返回剩下的个数
	 * 
	 * @param updateList
	 *            需要跟新的Item的list
	 * @return 放不下剩下的个数
	 */
	private int addToEmptySlot(ItemTemplate template, int count, ItemLogReason reason, String reasonDetail, String genKey, List<Item> updateList,
			boolean needSendLog, boolean isBind) {
		int left = count;
		if (count == 0) {
			return 0;
		}
		for (Item item : items) {
			if (left == 0) {
				break;
			}
			if (item.isEmpty()) { // 只检查空的格子
				// 产生一个新的激活的物品实例
				Item newItem = Globals.getItemService().newActivatedInstance(owner, template, getBagType(), item.getIndex(), isBind);
				newItem.setDeadline(new Timestamp(TimeUtils.getDeadLine(Globals.getTimeService().now(), Globals.getGameConstants().getTempBagItemValidPeriod(), TimeUtils.MILLI_SECOND)));
				newItem.setModified();
				this.items[newItem.getIndex()] = newItem;
				if (template.getMaxOverlap() >= left) {
					// 可以全部放入
					newItem.changeOverlap(left, reason, reasonDetail, genKey, needSendLog);
					left = 0;
					updateList.add(newItem);
					break;
				} else {
					// 只能放一部分
					newItem.changeOverlap(template.getMaxOverlap(), reason, reasonDetail, genKey, needSendLog);
					left -= template.getMaxOverlap();
					updateList.add(newItem);
				}
			}
		}
		return left;
	}

	
	
	/**
	 * 检查要放下count个模板为template的道具需要多少个槽位
	 * 
	 * @param template
	 * @param count
	 * @return
	 */
	@Override
	public int getNeedSlot(ItemTemplate template, int count, boolean isBind) {
		int maxovlp = template.getMaxOverlap();
		return (count + maxovlp - 1) / maxovlp;
	}

	@Override
	public int getEmptySlotCount() {
		int count = 0;
		for (Item item : items) {
			if (item.isEmpty()) {
				count++;
			}
		}
		return count;
	}
	
	@Override
	public void activeAll() {
		for (Item item : items) {
			item.getLifeCycle().activate();
			
			if(item.canDeleteInTemp()){
				// 临时背包中的物品失效
				item.delete(ItemLogReason.EXPIRED_IN_TEMP_BAG, ItemLogReason.EXPIRED_IN_TEMP_BAG.getReasonText());
			}
		}
	}

//	@Override
//	public List<Item> split(int index, int count) {
//		throw new UnsupportedOperationException();
//	}

	@Override
	public void tidyUp() {
		throw new UnsupportedOperationException();
	}
	
	@Override
	public Collection<Item> removeItem(int templateId, int count, ItemLogReason reason, String detailReason, boolean bindFirst) {
		throw new UnsupportedOperationException();
	}
	
	@Override
	public void setResetBagNum(int newCapacity) {
		this.owner.setTempBagNum(newCapacity);
	}
}
