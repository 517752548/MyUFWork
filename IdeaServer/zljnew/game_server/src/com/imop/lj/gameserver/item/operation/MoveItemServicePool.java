package com.imop.lj.gameserver.item.operation;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.item.operation.impl.MoveBody2PrimBag;
import com.imop.lj.gameserver.item.operation.impl.MoveGem2PrimBag;
import com.imop.lj.gameserver.item.operation.impl.MovePrimBag2Body;
import com.imop.lj.gameserver.item.operation.impl.MovePrimBag2Gem;
import com.imop.lj.gameserver.item.operation.impl.MovePrimBag2Store;
import com.imop.lj.gameserver.item.operation.impl.MoveShoulderBag2Itself;
import com.imop.lj.gameserver.item.operation.impl.MoveStore2PrimBag;

/**
 * MoveItemService的对象池，用于根据源、目的包的id查询取得相应的MoveItemService，这些service对象都是公用的对象，单实例
 * 
 */
public enum MoveItemServicePool {

	instance;

	private final Map<BagPair, MoveItemOperation> serviceMap;

	private MoveItemServicePool() {
		serviceMap = new HashMap<BagPair, MoveItemOperation>();
		// 把每一个MoveItemService的实现new一个放到serviceMap中
		// 主包，材料，任务，仓库自己往自己里面移动，都用这个service
		serviceMap.put(new BagPair(BagType.PRIM, BagType.PRIM), new MoveShoulderBag2Itself());
		serviceMap.put(new BagPair(BagType.PET_EQUIP, BagType.PRIM), new MoveBody2PrimBag());
		serviceMap.put(new BagPair(BagType.PRIM, BagType.PET_EQUIP), new MovePrimBag2Body());
//		serviceMap.put(new BagPair(BagType.TEMP, BagType.PRIM), new MoveTemp2PrimBag());
//		serviceMap.put(new BagPair(BagType.PET_GEM, BagType.PRIM), new MoveGem2PrimBag());
//		serviceMap.put(new BagPair(BagType.PRIM, BagType.PET_GEM), new MovePrimBag2Gem());
		
		serviceMap.put(new BagPair(BagType.STORE, BagType.PRIM), new MoveStore2PrimBag());
		serviceMap.put(new BagPair(BagType.PRIM, BagType.STORE), new MovePrimBag2Store());
		
	}

	/**
	 * 取得一个MoveItemService对象
	 * 
	 * @param fromBag
	 *            来源包id
	 * @param toBag
	 *            目的包id
	 * @return 如果从fromBagId到toBagId]不可以移动，返回null
	 */
	public MoveItemOperation get(BagType fromBag, BagType toBag) {
		BagPair keyBagPair = new BagPair(fromBag, toBag);
		MoveItemOperation service = serviceMap.get(keyBagPair);
		return service;
	}

	private static class BagPair {

		public BagType fromBag;
		public BagType toBag;

		private BagPair(BagType fromBag, BagType toBag) {
			super();
			this.fromBag = fromBag;
			this.toBag = toBag;
		}

		@Override
		public int hashCode() {
			return (fromBag.index << Short.SIZE) | toBag.index;
		}

		@Override
		public boolean equals(Object obj) {
			if (this == obj)
				return true;
			if (obj == null)
				return false;
			if (getClass() != obj.getClass())
				return false;
			BagPair other = (BagPair) obj;
			if (fromBag == null) {
				if (other.fromBag != null)
					return false;
			} else if (!fromBag.equals(other.fromBag))
				return false;
			if (toBag == null) {
				if (other.toBag != null)
					return false;
			} else if (!toBag.equals(other.toBag))
				return false;
			return true;
		}
	}
}
