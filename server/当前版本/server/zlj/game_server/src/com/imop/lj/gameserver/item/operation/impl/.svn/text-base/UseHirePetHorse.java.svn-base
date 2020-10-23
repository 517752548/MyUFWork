package com.imop.lj.gameserver.item.operation.impl;

import java.util.Collection;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.PetLogReason;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.ConsumableFunc;
import com.imop.lj.gameserver.item.template.ConsumeItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.pet.PetHorse;
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.role.Role;

/**
 * 骑宠招募卡
 * 
 */
public class UseHirePetHorse extends AbstractConsumeOperation {

	@Override
	public ConsumableFunc getConsumableFunc() {
		return ConsumableFunc.PET_HORSE_HIRE_CARD;
	}

	@Override
	protected <T extends Role> boolean useImpl(Human user, Item item, int count, T role) {
		// 每次只能增加一个骑宠
		if(count != 1){
			return false;
		}
		
		ItemTemplate it = item.getTemplate();
		if(it == null || !(it instanceof ConsumeItemTemplate)){
			return false;
		}
		
		ConsumeItemTemplate consume = (ConsumeItemTemplate) it;
		PetTemplate petTemp = Globals.getTemplateCacheService().get(consume.getArgA(), PetTemplate.class);
		
		// 能否招募骑宠
		if (!Globals.getPetService().canGetPetHorse(user,petTemp)) {
			return false;
		}
		
		boolean isBind = item.isBind();
		
		// 扣除骑宠卡成功
		Collection<Item> coll = user.getInventory().removeItem(it.getId(), 1, ItemLogReason.PET_HORSE_HIRE_CARD_COST, 
				ItemLogReason.PET_HORSE_HIRE_CARD_COST.getReasonText(), isBind);
		if(coll.isEmpty()){
			return false;
		}
		
		// 添加骑宠
		PetHorse petHorse = Globals.getPetService().onGetPetHorse(user, petTemp.getId(), PetLogReason.PET_HORSE_HIRE_CARD, isBind);
		if(petHorse == null){
			return false;
		}

		return true;
	}

}
