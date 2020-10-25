package com.imop.lj.gameserver.item.container;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.constants.RoleConstants;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.role.Role;

public class AbstractGemBag extends AbstractItemBag implements InitializeRequired {
	
	/** 佩戴者 */
	protected final Role wearer;
	
	/** key=position  value=itemIndex */
	protected static HashMap<Position,ArrayList<Integer>> POS2INDEXMAP = Maps.newHashMap();
	
	/** 位置列表 */
	protected static Position[] INDEX2POS = {
		/** 武器 */
		Position.WEAPON,
		/** 头盔 */
		Position.HEAD,
		/** 护肩 */
		Position.SHOULDER,
		/** 披风 */
		Position.CLOAK,
		/** 胸甲 */
		Position.BREAST,
		/** 护腕 */
		Position.WRISTER,
		/** 戒指 */
		Position.RING,
		/** 项链 */
		Position.NECKLACE,
		/** 腰带 */
		Position.BELT,
		/** 裤子 */
		Position.PANTS,
		/** 靴子 */
		Position.BOOT,
		};
	
	protected static Integer subCapacity = RoleConstants.PET_GEM_BAG_SUB_CAPACITY;
	
	protected AbstractGemBag(Human owner,Role wearer,BagType bagType,int gemCapacity) {
		super(owner, bagType, gemCapacity);
		this.wearer = wearer;
		this.init();
	}


	@Override
	public Item drop(int index, ItemLogReason reason, String detailReason) {
		// TODO 自动生成的方法存根
		return null;
	}


	@Override
	public void init() {
	}
	
	public static boolean containedPositionIndex(int index){
		for(Position p : INDEX2POS){
			if(p == Position.valueOf(index)){
				return true;
			}
		}
		return false;
	}
	
	
	public static Integer getSubCapacity(){
		return subCapacity;
	}
	
	/**
	 * 返回所有宝石列表
	 * @return
	 */
	public List<Item> getAllItems() {
		List<Item> resultItems = new ArrayList<Item>(this.getCapacity());
		for (Item gem : items) {
			if(!Item.isEmpty(gem)) {
				resultItems.add(gem);
			}
		}
		return resultItems;
	}

	public List<Item> getItemsByPosition(Position p){
		ArrayList<Item> result = new ArrayList<Item>(subCapacity);
		if(POS2INDEXMAP == null){
			return result;
		}
		if(!POS2INDEXMAP.containsKey(p) || POS2INDEXMAP.get(p) == null){
			return result;
		}
		for(Integer index : POS2INDEXMAP.get(p)){
			if(index >= 0){
				result.add(items[index]);
			}
		}
		return result;
	}

	/** 返回的是克隆*/
	public static Position[] getINDEX2POS() {
		return INDEX2POS.clone();
	}

	
}
