package com.imop.lj.gameserver.item.operation.impl;

import java.util.Collection;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.PetExpLogReason;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef;
import com.imop.lj.gameserver.item.ItemDef.ConsumableFunc;
import com.imop.lj.gameserver.item.template.ConsumeItemTemplate;
import com.imop.lj.gameserver.offlinedata.UserOfflineData;
import com.imop.lj.gameserver.pet.PetLeader;
import com.imop.lj.gameserver.role.Role;

/**
 * 增加经验,除主将外
 */
public class UseGiveExp extends AbstractConsumeOperation {

	@Override
	protected <T extends Role> boolean canUseImpl(Human user, Item item, int count, T role) {
		if(!super.canUseImpl(user, item, count, role)){
			return false;
		}
		//战斗中无法
		if (user.isInAnyBattle()) {
			return false;
		}
			
		return true;
	}

	@Override
	public ConsumableFunc getConsumableFunc() {
		return ItemDef.ConsumableFunc.GIVE_EXP;
	}
	
	@Override
	protected <T extends Role> boolean useImpl(Human user, Item item, int count, T role) {
		if(count != 1){
			return false;
		}
		
		ConsumeItemTemplate template = (ConsumeItemTemplate)item.getTemplate();
		
		// 增加
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(user.getCharId());
		if(offlineData == null){
			return false;
		}
		
		//主将除外
		if(role == null || (role instanceof PetLeader)){
			return false;
		}
		
		
		int expCount = template.getArgA();
		
		if(Globals.getPetService().addExp(user, role.getUUID(), expCount, PetExpLogReason.ITEM_EXP_REWARD,
				PetExpLogReason.ITEM_EXP_REWARD.reasonText, true)){
			// 扣道具
			Collection<Item> coll = user.getInventory().removeItem(template.getId(), 1, ItemLogReason.EXP_COST, ItemLogReason.EXP_COST.getReasonText(), true);
			if(coll.isEmpty()){
				return false;
			}
		}
		
		return true;
	}

}
