package com.imop.lj.gameserver.item.container;


import java.util.ArrayList;
import java.util.EnumMap;
import java.util.List;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.feature.EquipFeature;
import com.imop.lj.gameserver.role.Role;
import com.imop.lj.gameserver.role.properties.RolePropertyManager;


/**
 * 武将身上的装备包
 *
 */
public abstract class AbstractEquipBag extends AbstractItemBag implements InitializeRequired {

	/** 玩家身体位置与道具位置 {@link Item#getPosition()} 之间的对应关系按从界面左到右排列 */
	protected Position[] INDEX2POS;

	/** 需要换装的部位与索引的映射表 */
	protected EnumMap<Position, Integer> avatarPosMap = new EnumMap<Position, Integer>(Position.class);

	/** 佩戴者 */
	protected final Role wearer;
	
	protected final int equipCapacity;

	/**
	 * 检测装备是否有效，即穿上之后装备的各种属性是否能够对装备者起作用
	 *
	 * @param equip
	 * @return
	 */
	public boolean isEffective(Item equip) {
		return true;
	}

	public AbstractEquipBag(Human owner,Role wearer,BagType bagType,int equipCapacity) {
		super(owner, bagType, equipCapacity);
		this.wearer = wearer;
		this.equipCapacity = equipCapacity;
		this.init();
	}
	
	@Override
	public void onLoad() {
	}


	/**
	 * 玩家身体上的组件变化了,重新计算玩家身上穿的东西
	 */
	@Override
	public void onChanged() {
		updateEquipEffect();
	}

	/**
	 * 刷新装备修正效果
	 *
	 */
	private void updateEquipEffect() {
		wearer.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_EQUIP);
		
		//更新离线数据，主将装备发生变化
		if (wearer.getUUID() == getOwner().getPetManager().getLeader().getUUID()) {
			Globals.getOfflineDataService().onLeaderEquipUpdate(getOwner());
		}
	}

	public Role getWearer() {
		return wearer;
	}

	/**
	 * 根据装备的位置获取在玩家身上对应的装备
	 *
	 * @param pos
	 *            装备位置
	 * @return
	 */
	public Item getByPosition(Position pos) {
		List<Item> list = new ArrayList<Item>();
		boolean hasEmpty = false;
		int emptyIndex = 0;
		for (int i = 0; i < INDEX2POS.length; i++) {
			if (INDEX2POS[i] != pos) {
				continue;
			}
			Item item = getByIndex(i);
			if (item == null) {
				// 这种情况不应该发生
				continue;
			}
			list.add(item);
			// 看看有没有空位
			if (item.isEmpty()) {
				hasEmpty = true;
				emptyIndex = i;
				break;
			}
		}
		if (list.isEmpty()) {
			return null;
		}
		if (hasEmpty) {
			// 有空位尽量返回空位
			return items[emptyIndex];
		} else {
			return list.get(0);
		}
	}
	
	public int getTplIdByPosition(Position pos){
		Item item = getByPosition(pos);
		return item != null ? item.getTemplateId() : -1;
	}
	
	

	/**
	 * 根据装备的索引获取其对应的装备位置
	 *
	 * @param index
	 * @return
	 */
	public ItemDef.Position getPosByIndex(int index) {
		if (index >= INDEX2POS.length || index < 0) {
			return Position.NULL;
		}
		return INDEX2POS[index];
	}

	/**
	 * 返回当前身上所有生效的装备
	 *
	 * @return
	 */
	public List<Item> getEffectiveItems() {
		// 查找有效的装备
		List<Item> effectives = new ArrayList<Item>(this.equipCapacity);
		for (Item equip : items) {
			if (!Item.isEmpty(equip) && isEffective(equip)) {
				effectives.add(equip);
			}
		}
		return effectives;
	}

	/**
	 * 返回当前身上所有装备的总数量
	 * @return
	 */
	public int getAllItemsCount() {
		int count = 0;
		for (Item equip : items) {
			if(!Item.isEmpty(equip)) count++;
		}
		return count;
	}

	/**
	 * 返回所有装备列表
	 * @return
	 */
	public List<Item> getAllItems() {
		List<Item> resultItems = new ArrayList<Item>(this.equipCapacity);
		for (Item equip : items) {
			if(!Item.isEmpty(equip)) {
				resultItems.add(equip);
			}
		}
		return resultItems;
	}

	/**
	 * 获取所有装备
	 * 
	 * @return
	 */
	public List<Item> getAllEquips(){
		List<Item> resultItems = new ArrayList<Item>(this.equipCapacity);
		for (Item equip : items) {
			if (!Item.isEmpty(equip) && 
					equip.getFeature() instanceof EquipFeature) {
				resultItems.add(equip);
			}
		}
		return resultItems;
	}
	/**
	 * 判读装备位置是否有装备
	 * @param positionId
	 * @return
	 */
	public boolean hasItemByPosition(Position pos) {
		Item item = getByPosition(pos);
		if(null == item) {
			return false;
		}
		return !item.isEmpty();
	}
	public boolean hasItemByPosition(int positionId) {
		return hasItemByPosition(Position.valueOf(positionId));
	}
		
	/**
	 * 穿上装备部件
	 *
	 * @param user
	 * @param equip
	 */
	public abstract void putOn(Item equip);

	/**
	 * 脱下装备
	 *
	 * @param user
	 * @param pos
	 *            脱下的位置
	 * @param needTakeoffAvatar
	 *            是否需要换下装备
	 */
	public abstract  void takeOff(Item equip, boolean needTakeoffAvatar);


	protected void takeOffAvatar(ItemDef.Position pos) {
		if (!pos.isNeedSwitchAvatar()) {
			return;
		}
	}

//	/**
//	 * 秘书是否有装备在身上
//	 * @return
//	 */
//	public boolean hasEquipOnBody() {
//		boolean flag = false;
//		for (Item equip : items) {
//			if(!Item.isEmpty(equip)) {
//				flag = true;
//				break;
//			}
//		}
//		return flag;
//	}

	@Override
	public Item drop(int index, ItemLogReason reason, String detailReason) {
		return null;
	}
}
