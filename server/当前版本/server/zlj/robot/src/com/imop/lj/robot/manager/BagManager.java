package com.imop.lj.robot.manager;

import java.util.Iterator;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.model.item.CommonItem;
import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.item.msg.GCBagUpdate;
import com.imop.lj.gameserver.item.msg.GCRemoveItem;
import com.imop.lj.robot.Robot;

public class BagManager extends AbstractManager{

	private short bagCapacity = 0;

	public Map<String,CommonItem> primBag ;

	public BagManager(Robot owner) {
		super(owner);
		primBag = Maps.newHashMap();
	}

	public void init(GCBagUpdate gcBagUpdate)
	{
		System.out.println(gcBagUpdate);
//		bagCapacity = gcBagUpdate.getCapacity();
//		int bagType = gcBagUpdate.getBagId();
//		if(BagType.PRIM.index == bagType)
//		{
//			this.primBag.clear();
//			CommonItem[] commonItems = gcBagUpdate.getItem();
//
//			if (commonItems != null) {
//				for(CommonItem commonitem : commonItems)
//				{
//					primBag.put(commonitem.getUuid(), commonitem);
//				}
//			}
//		}
	}

	public void removeItem(GCRemoveItem gcRemoveItem)
	{
		if(gcRemoveItem.getBagId() == BagType.PRIM.index)
		{
			CommonItem commonItem = getItemByIndex(gcRemoveItem.getIndex());

			if (commonItem != null) {
				primBag.remove(commonItem.getUuid());
			}
		}
	}

	public short getBagCapacity() {
		return bagCapacity;
	}

	public CommonItem getItemByUuid(String uuid)
	{
		return primBag.get(uuid);
	}

	public CommonItem getFirstNotEmptyItem()
	{
		CommonItem result = null;
		Iterator<Map.Entry<String,CommonItem>> it = primBag.entrySet().iterator();
		while(it.hasNext())
		{
			result = it.next().getValue();
			break;
		}
		return result;
	}

	public CommonItem getItemByIndex(int index)
	{
		CommonItem result = null;
		Iterator<Map.Entry<String,CommonItem>> it = primBag.entrySet().iterator();
		while(it.hasNext())
		{
			CommonItem item = it.next().getValue();
			if(item.getIndex() == index)
			{
				result = item;
				break;
			}
		}
		return result;
	}

	public int getItemCount() {
		return primBag.size();
	}

	public void updateItem(CommonItem item)
	{
		if(item == null)
		{
			return;
		}
		primBag.put(item.getUuid(), item);
	}
}
