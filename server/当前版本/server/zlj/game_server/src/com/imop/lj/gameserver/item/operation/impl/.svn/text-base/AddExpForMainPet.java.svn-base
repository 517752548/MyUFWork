package com.imop.lj.gameserver.item.operation.impl;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.PetExpLogReason;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.ConsumableFunc;
import com.imop.lj.gameserver.item.template.ConsumeItemTemplate;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.role.Role;

/**
 * 主武将加经验
 * 
 * @author xiaowei.liu
 * 
 */
public class AddExpForMainPet extends AbstractConsumeOperation {

	@Override
	public ConsumableFunc getConsumableFunc() {
		return ConsumableFunc.MAIN_PET_EXP_CARD;
	}
	
	

	@Override
	public <T extends Role> boolean isSuitable(Human user, Item item, int count, T role) {
		if(role == null){
			return false;
		}
		
		if(!(role instanceof Pet)){
			return false;
		}
		
		if(!super.isSuitable(user, item, count, role)){
			return false;
		}

		Pet pet = (Pet)role;
		
		return pet.isLeader();
	}



	@Override
	protected <T extends Role> boolean useImpl(Human user, Item item, int count, T role) {
		if(count <= 0){
			return false;
		}
		
		if(Item.isEmpty(item)){
			return false;
		}
		
		if(role == null){
			return false;
		}
		
		if(!(role instanceof Pet)){
			return false;
		}
		
		Pet pet = (Pet)role;
		
		// 只有主将能用
		if(!pet.isLeader()){
			return false;
		}
		
		ConsumeItemTemplate temp = (ConsumeItemTemplate) item.getTemplate();
		long diffExp = Globals.getTemplateCacheService().getPetTemplateCache().getDiffExp(pet, 0);
		int currNum = item.getOverlap();
		int maxNum = (int)Math.ceil((double)diffExp / temp.getArgA());
		int finalNum = currNum >= maxNum ? maxNum : currNum;
		
		if (count > finalNum) {
			// 请求数量大于可用数量
			return false;
		}
		
		// 扣除物品
		if(!user.getInventory().removeItemByIndex(item.getBagType(), item.getIndex(), count, ItemLogReason.OTHER_PET_EXP_CARD_COST, ItemLogReason.OTHER_PET_EXP_CARD_COST.getReasonText())){
			return false;
		}
		
		Globals.getPetService().addExp(user, pet.getUUID(), temp.getArgA() * (long)count, PetExpLogReason.MAIN_PET_EXP_CARD_ADD, PetExpLogReason.MAIN_PET_EXP_CARD_ADD.getReasonText(), true);
		return true;
	}
}
