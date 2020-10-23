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
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.role.Role;

/**
 * 武将招募卡
 * 
 * @author xiaowei.liu
 * 
 */
public class UseHirePet extends AbstractConsumeOperation {

	@Override
	public ConsumableFunc getConsumableFunc() {
		return ConsumableFunc.PET_HIRE_CARD;
	}

	@Override
	protected <T extends Role> boolean useImpl(Human user, Item item, int count, T role) {
		// 每次只能增加一个武将
		if(count != 1){
			return false;
		}
		
		ItemTemplate it = item.getTemplate();
		if(it == null || !(it instanceof ConsumeItemTemplate)){
			return false;
		}
		
		ConsumeItemTemplate consume = (ConsumeItemTemplate) it;
		PetTemplate petTemp = Globals.getTemplateCacheService().get(consume.getArgA(), PetTemplate.class);
		
		// 能否招募武将
		if (!Globals.getPetService().canCatchPet(user,petTemp)) {
			return false;
		}
		
		// 扣除武将卡成功
		Collection<Item> coll = user.getInventory().removeItem(it.getId(), 1, ItemLogReason.PET_HIRE_CARD_COST, ItemLogReason.PET_HIRE_CARD_COST.getReasonText());
		if(coll.isEmpty()){
			return false;
		}
		
		// 添加武将
		Globals.getPetService().onCatchPet(user, petTemp.getId(), PetLogReason.PET_HIRE_CARD);
		return true;
	}

}
