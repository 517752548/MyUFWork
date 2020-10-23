package com.imop.lj.gameserver.item.msg;

import java.util.Collection;

import com.imop.lj.common.model.item.CommonItem;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.container.AbstractItemBag;

public class ItemMessageBuilder {

	public static GCItemUpdate buildGCItemInfo(Item item) {
		CommonItemBuilder builder = new CommonItemBuilder();
		GCItemUpdate msg = new GCItemUpdate();
		builder.bindItem(item);
		msg.setItem(builder.buildCommonItem());
		return msg;
	}
	
	public static CommonItem createItemInfo(Item item){
		CommonItemBuilder builder = new CommonItemBuilder();
		builder.bindItem(item);
		return builder.buildCommonItem();
	}

	public static GCBagUpdate buildGCBagUpdate(AbstractItemBag bag) {
		CommonItem[] commonItems = getCommonItem(bag);
		GCBagUpdate msg = new GCBagUpdate(bag.getBagType().index, 0L, commonItems);
		return msg;
	}

	public static CommonItem[] getCommonItem(AbstractItemBag bag) {
		CommonItemBuilder builder = new CommonItemBuilder();
		Collection<Item> items = bag.getAll();
		CommonItem[] commonItems = new CommonItem[0];
		if (!items.isEmpty()) {
			commonItems = new CommonItem[items.size()];
			int i = 0;
			for (Item item : items) {
				builder.bindItem(item);
				commonItems[i] = builder.buildCommonItem();
				i++;
			}
		}
		return commonItems;
	}

	public static CommonItem[] getCommonItem(Collection<Item> items) {
		CommonItemBuilder builder = new CommonItemBuilder();
		CommonItem[] commonItems = new CommonItem[0];
		if (items != null && items.size() > 0) {
			commonItems = new CommonItem[items.size()];
			int i = 0;
			for (Item item : items) {
				builder.bindItem(item);
				commonItems[i] = builder.buildCommonItem();
				i++;
			}
		}
		return commonItems;
	}
	
}
