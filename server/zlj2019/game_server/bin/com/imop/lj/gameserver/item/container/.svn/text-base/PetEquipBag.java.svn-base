package com.imop.lj.gameserver.item.container;


import java.util.Arrays;

import com.imop.lj.common.constants.RoleConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.BindType;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.feature.EquipFeature;
import com.imop.lj.gameserver.pet.Pet;


/**
 * 武将身上的装备包
 *
 */
public class PetEquipBag extends AbstractEquipBag {

	/**
	 * 检测装备是否有效，即穿上之后装备的各种属性是否能够对装备者起作用
	 *
	 * @param equip
	 * @return
	 */
	public boolean isEffective(Item equip) {
		return true;
	}

	public PetEquipBag(Human owner,Pet pet) {
		super(owner, pet,BagType.PET_EQUIP, RoleConstants.PET_EQUIP_BAG_CAPACITY);
	}

	/**
	 * 穿上装备部件
	 *
	 * @param user
	 * @param equip
	 */
	public void putOn(Item equip) {
		// 换装
//		putOnAvatar(equip);
//		//更新套装
//		Globals.getEquipService().onSuitChange((Pet)this.wearer, equip);

		//修改装备的绑定状态
		if (!equip.isBind() &&
				equip.getTemplate().getBindType() == BindType.EQUIP_BIND) {
			//装备状态改变
			equip.setBind(true);
		}
		
		//装备任务监听
		Human human = wearer.getOwner();
		EquipFeature feature = (EquipFeature) equip.getFeature();
		human.getTaskListener().onEquipUpdate(human, 
				feature.getColor().getIndex(), feature.getGrade().getIndex());
		
		//宝石任务监听
		human.getTaskListener().onEquipGemUpdate(human, Globals.getGameConstants().getGemMaxLevel());
		
		//时装和武器需要换avatar
		Position pos = equip.getTemplate().getPosition();
		if (pos == Position.FASHION || pos == Position.WEAPON) {
			Globals.getMapService().noticeNearMapInfoChanged(wearer.getOwner());
			Globals.getTeamService().onTeamMemberInfoChanged(wearer.getOwner());
		}
	}

	/**
	 * 脱下装备
	 *
	 * @param user
	 * @param pos
	 *            脱下的位置
	 * @param needTakeoffAvatar
	 *            是否需要换下装备
	 */
	public void takeOff(Item equip, boolean needTakeoffAvatar) {
		Position pos = equip.getPosition();
		// 换装
		if (needTakeoffAvatar) {
			takeOffAvatar(pos);
		}
		
		//TODO
//		//更新套装
//		Globals.getEquipService().onSuitChange((Pet)this.wearer, equip);
//		// 脱战甲
//		Globals.getArmourService().onPutOnOrOffArmour(wearer.getOwner(), equip.getTemplate());
		
		//时装和武器需要换avatar
		if (pos == Position.FASHION || pos == Position.WEAPON) {
			Globals.getMapService().noticeNearMapInfoChanged(wearer.getOwner());
			Globals.getTeamService().onTeamMemberInfoChanged(wearer.getOwner());
		}
	}
	
	@Override
	public String toString() {
		return "PetEquipBag [INDEX2POS=" + Arrays.toString(INDEX2POS) + ", avatarPosMap=" + avatarPosMap + ", wearer="
				+ wearer + ", equipCapacity=" + equipCapacity + ", items=" + Arrays.toString(items) + ", owner=" + owner
				+ ", bagType=" + bagType + "]";
	}

	@Override
	public void init() {
		Position[] _INDEX2POS = {
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
				/** 翅膀 */
				Position.WING,
				/** 时装 */
				Position.FASHION
				
				};
		this.INDEX2POS = _INDEX2POS;
		
		for (int i = 0; i < INDEX2POS.length; i++) {
			if (INDEX2POS[i].isNeedSwitchAvatar()) {
				avatarPosMap.put(INDEX2POS[i], i);
			}
		}		
	}
}
