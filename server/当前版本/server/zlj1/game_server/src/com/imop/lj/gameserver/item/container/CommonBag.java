package com.imop.lj.gameserver.item.container;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.template.ItemTemplate;

/**
 * 通用的道具容器实现
 * <p>
 * 提供了调整容量、整理、丢弃道具、找空位的通用实现。背包和仓库租赁箱都可以在此基础上实现。
 * 
 */
public abstract class CommonBag extends AbstractItemBag {

	protected CommonBag(Human owner, BagType bagType, int capacity) {
		super(owner, bagType, capacity);
	}

	abstract public int getMaxCanAdd(ItemTemplate itemTemplate);
	
	abstract public void setResetBagNum(int newCapacity);

	abstract public Collection<Item> add(ItemTemplate template, int count, ItemGenLogReason reason, String detailReason);

	public boolean resetCapacity(int newCapacity) {
		int oldCapacity = getCapacity();
		if (newCapacity == oldCapacity) {
			// 不增不减，不需要动
			return true;
		} else if (newCapacity > oldCapacity) {
			// 扩容
			Item[] newItems = new Item[newCapacity];
			for (int i = 0; i < newCapacity; i++) {
				if (i < oldCapacity) {
					// 原来部分拷贝过来
					newItems[i] = items[i];
				} else {
					// 新的部分填满空道具
					newItems[i] = Item.newEmptyOwneredInstance(owner, getBagType(), i);
				}
			}
			items = newItems;
		} else {
			// 减少了，看看要干掉的最后几个格子里面有没有东西
			for (int i = oldCapacity - 1; i >= newCapacity; i--) {
				if (!items[i].isEmpty()) {
					// 有东西就不能重设容量
					return false;
				}
			}
			// 没有东西可以重设了
			Item[] newItems = new Item[newCapacity];
			for (int i = 0; i < newCapacity; i++) {
				// 原来部分拷贝过来就行
				newItems[i] = items[i];
			}
			items = newItems;
		}
		// 通知客户端
		this.setResetBagNum(newCapacity);
		this.owner.snapChangedProperty(true);
		return true;
	}

	/**
	 * 整理包裹
	 */
	public void tidyUp() {
		// 合并可叠加的道具，进可能叠加
		List<Item> mergedList = mergeSameItems();
		// 按照排序规则排序
		Collections.sort(mergedList, tidyUpComp);
		// 重设所有道具的索引，并放回背包中
		Iterator<Item> itr = mergedList.iterator();
		int cap = getCapacity();
		for (int i = 0; i < cap; i++) {
			Item curItem = null;
			// 如果还有没放下的，放置这个，否则放置空的
			if (itr.hasNext()) {
				curItem = itr.next();
				curItem.setIndex(i);
			} else {
				curItem = Item.newEmptyOwneredInstance(owner, getBagType(), i);
			}
			items[i] = curItem;
		}
	}

	/**
	 * 将包中所有非空的item进行合并，尽可能叠加，区分绑定状态
	 * 
	 * @return
	 */
	private List<Item> mergeSameItems() {
		// 先按模板Id与绑定状态分类
		Map<Integer, List<Item>> classifyMap = classifyByTmplId();
		List<Item> mergedList = new ArrayList<Item>();
		for (List<Item> list : classifyMap.values()) {
			mergedList.addAll(mergeSameItem(list));
		}
		return mergedList;
	}

	/**
	 * 按模板Id与绑定状态分类
	 * 
	 * @see Item#genKeyByTmplIdAnd(int)
	 * @return
	 */
	private Map<Integer, List<Item>> classifyByTmplId() {
		Map<Integer, List<Item>> classifyMap = new HashMap<Integer, List<Item>>();
		for (Item item : items) {
			if (Item.isEmpty(item)) {
				continue;
			}
			int key = item.getTemplateId();
			List<Item> list = classifyMap.get(key);
			if (list == null) {
				list = new ArrayList<Item>();
				classifyMap.put(key, list);
			}
			list.add(item);
		}
		return classifyMap;
	}

	/**
	 * 将相同templateId和绑定状态的一组道具按尽量叠加的规则合并
	 * 
	 * @param sameList
	 * @return
	 */
	private Collection<Item> mergeSameItem(List<Item> sameList) {
		// 统计一共有多少个
		int total = 0;
		for (Item item : sameList) {
			total += item.getOverlap();
		}
		// 取最大叠加数
		int maxOverlap = sameList.get(0).getMaxOverlap();
		// 需要占得槽位数，合并后就会有这么多个Item对象，此值不会超过sameList.size()
		int needSlot = (total + maxOverlap - 1) / maxOverlap;
		// 合并后肯定至多只有一个槽位是没达到最大叠加上限的，计算此叠加数
		int leftOverlap = total % maxOverlap;
		List<Item> resultList = new ArrayList<Item>();
		ItemLogReason reason = ItemLogReason.TIDY_UP;
		if (leftOverlap == 0) {
			// 刚好没有零头，needSlot个Item全是maxoverlap叠加的，其余sameList.size()-needSlot删掉
			int i = 0;
			for (Item item : sameList) {
				if (i < needSlot) {
					// 置为满叠加
					item.changeOverlap(maxOverlap, reason, "", "", true);
					resultList.add(item);
				} else {
					// 剩下的就没有用了
					item.delete(reason, "");
				}
				i++;
			}
		} else {
			// 有零头，needSlot-1个Item为最大叠加的，1个为leftOverlap叠加的，其余sameList.size()-needSlot删掉
			int i = 0;
			for (Item item : sameList) {
				if (i < needSlot - 1) {
					// needSlot-1个 置为满叠加
					item.changeOverlap(maxOverlap, reason, "", "", true);
					resultList.add(item);
				} else if (i == needSlot - 1) {
					// 这个是零头，置为leftOverlap
					item.changeOverlap(leftOverlap, reason, "", "", true);
					resultList.add(item);
				} else {
					// 剩下的就没有用了
					item.changeOverlap(0, reason, "", "", true);
				}
				i++;
			}
		}
		return resultList;
	}

	/**
	 * 丢弃道具
	 * 
	 * @param index
	 * @return
	 */
	public Item drop(int index,ItemLogReason reason, String detailReason) {
		Item item = getByIndex(index);
		if (Item.isEmpty(item)) {
			return null;
		}
		item.delete(ItemLogReason.PLAYER_DROP, detailReason);
		return item;
	}

	/**
	 * 找到一个可以放置该物品的位置，考虑了叠加的情况
	 * 
	 * @param template
	 *            要放置的物品的模板
	 * @param count
	 *            要放置的物品的数量
	 * @return 可以放置的该物品的位置，如果没有位置返回null
	 */
	public Item getCanPutSolt(ItemTemplate template, int count) {
		if (count <= 0) {
			return null;
		}

		Item solt = null;
		if (template.canOverlap()) {
			solt = getCanPutOverlapSlot(template.getId(), count);
		}

		if (solt == null) {
			// 不能堆叠或者没有合适的堆叠位置，就找一个空位
			solt = getEmptySlot();
		}
		return solt;
	}

	/**
	 * 找到可以堆叠该物品的位置
	 * 
	 * @param templateId
	 *            要放置的物品的模板id
	 * @param count
	 *            要放置的物品的数量
	 * @return 可以放置的该物品的位置，如果没有位置返回null
	 */
	private Item getCanPutOverlapSlot(int templateId, int count) {
		if (count <= 0) {
			return null;
		}

		for (Item item : items) {
			if (Globals.getItemService().canOverlapOn(item, templateId)) {
				int capacity = item.getMaxOverlap() - item.getOverlap();
				if (capacity >= count) {
					return item;
				}
			}
		}

		return null;
	}

	/** 整理背包用的排序器 */
	private final Comparator<Item> tidyUpComp = new Comparator<Item>() {

		@Override
		public int compare(Item itemA, Item itemB) {
			if (Item.isEmpty(itemA)) {
				return Item.isEmpty(itemB) ? 0 : 1;
			}
			if (Item.isEmpty(itemB)) {
				return Item.isEmpty(itemA) ? 0 : -1;
			}

			if (itemA.getTemplate().getIdentityTypeId() != itemB.getTemplate().getIdentityTypeId()) {
				return itemA.getTemplate().getIdentityTypeId() - itemB.getTemplate().getIdentityTypeId();
			} else if (itemA.getTemplateId() != itemB.getTemplateId()) {
				// 不是同一个模板，按模板id排序
				return itemA.getTemplateId() - itemB.getTemplateId();
			} else {
				// 同一个模板，按叠加数排序
				return itemA.getOverlap() - itemB.getOverlap();
			}
		}
	};
	

	/** 叠加数比较器，按叠加从小到大排列 */
	protected final Comparator<Item> overlapComp = new Comparator<Item>() {

		@Override
		public int compare(Item itemA, Item itemB) {
			int ovlpA = itemA.getOverlap();
			int ovlpB = itemB.getOverlap();
			if (ovlpA > ovlpB) {
				return 1;
			} else if (ovlpA < ovlpB) {
				return -1;
			} else {
				return 0;
			}
		}
	};

	/**
	 * 移除一定数量的某种道具，区分绑定状态，优先删除叠加数少的道具，尽可能使删除完成后产生更多的空槽位 如果 count 为0则抛出
	 * {@link IllegalArgumentException}
	 * 
	 * @param <T>
	 * @param templateId
	 *            模板Id
	 * @param count
	 *            要移除的数量
	 * @param reason
	 *            移除的原因
	 * @return 移除了的Item
	 */
	public abstract Collection<Item> removeItem(int templateId, int count, ItemLogReason reason, String detailReason);

	/**
	 * 检查要放下count个模板为template的道具需要多少个槽位
	 * 
	 * @param template
	 * @param count
	 * @return
	 */
	public abstract int getNeedSlot(ItemTemplate template, int count);

	/**
	 * 获取背包中的空格个数
	 * 
	 * @return
	 */
	public abstract int getEmptySlotCount();

	/**
	 * 拆分道具
	 * 
	 * @param index
	 *            索引
	 * @param count
	 *            拆出来的数量
	 * @return 需要跟新的道具
	 */
	public abstract List<Item> split(int index, final int count);
}
