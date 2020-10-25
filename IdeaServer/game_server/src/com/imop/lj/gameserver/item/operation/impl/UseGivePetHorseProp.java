package com.imop.lj.gameserver.item.operation.impl;

import java.util.Collection;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef;
import com.imop.lj.gameserver.item.ItemDef.ConsumableFunc;
import com.imop.lj.gameserver.item.template.ConsumeItemTemplate;
import com.imop.lj.gameserver.offlinedata.UserOfflineData;
import com.imop.lj.gameserver.offlinedata.UserPetHorseData;
import com.imop.lj.gameserver.pet.PetHorse;
import com.imop.lj.gameserver.pet.PetMessageBuilder;
import com.imop.lj.gameserver.pet.PetHorseDef.HorsePropType;
import com.imop.lj.gameserver.role.Role;

/**
 * 增加骑宠属性
 */
public class UseGivePetHorseProp extends AbstractConsumeOperation {

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
		return ItemDef.ConsumableFunc.PET_HORSE_PROP;
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
		int propType = template.getArgA();
		long propAmount = template.getArgB();
		HorsePropType type = HorsePropType.valueOf(propType);
		if(type == null){
			return false;
		}		
		
		if(role == null || !(role instanceof PetHorse)){
			return false;
		}
		
		
		UserPetHorseData petHorseData = offlineData.getPetHorseData(role.getUUID());
		if(petHorseData == null){
			return false;
		}
		if (petHorseData.getTemplate() == null) {
			return false;
		}
		
		switch (type) {
		case LOY:
			if(petHorseData.getLoy() >= Globals.getGameConstants().getPetHorseMaxLoy()){
				user.sendErrorMessage(LangConstants.LOY_PET_HORSE_FULL);
				return false;
			}
			petHorseData.setLoy(petHorseData.getLoy() + propAmount);
			if(petHorseData.getLoy() >= Globals.getGameConstants().getPetHorseMaxLoy()){
				petHorseData.setLoy(Globals.getGameConstants().getPetHorseMaxLoy());
			}
			user.sendErrorMessage(LangConstants.LOY_PET_HORSE_ADD, propAmount);
			break;
		case CLO:
			if(petHorseData.getClo() >= Globals.getGameConstants().getPetHorseMaxClo()){
				user.sendErrorMessage(LangConstants.CLO_PET_HORSE_FULL);
				return false;
			}
			petHorseData.setClo(petHorseData.getClo() + propAmount);
			if(petHorseData.getClo() >= Globals.getGameConstants().getPetHorseMaxClo()){
				petHorseData.setClo(Globals.getGameConstants().getPetHorseMaxClo());
			}
			user.sendErrorMessage(LangConstants.CLO_PET_HORSE_ADD, propAmount);
			break;
		case LEASE_HOLD:
			if(!petHorseData.isExperience()){
				user.sendErrorMessage(LangConstants.EXPER_PET_HORSE_NOT_OK);
				return false;
			}
			//是否小于1小时
			if(petHorseData.getDeadline() - Globals.getTimeService().now() > Globals.getGameConstants().getPetHorseReletTime()){
				user.sendErrorMessage(LangConstants.RELET_EXPER_PET_HORSE_NOT_OK, Globals.getGameConstants().getPetHorseReletTime() / TimeUtils.HOUR);
				return false;
			}
			petHorseData.setDeadline(Globals.getTimeService().now() + propAmount * TimeUtils.HOUR);
			user.sendErrorMessage(LangConstants.EXPER_PET_HORSE_ADD, propAmount);
			break;

		default:
			break;
		}
		
		
		// 扣道具
		Collection<Item> coll = user.getInventory().removeItem(template.getId(), 1, ItemLogReason.PET_HORSE_PROP_COST, ItemLogReason.PET_HORSE_PROP_COST.getReasonText(), true);
		if(coll.isEmpty()){
			return false;
		}
		
		offlineData.setModified();
		
		//更新信息
		user.sendMessage(PetMessageBuilder.buildGCPetHorseCurPropUpdate(user.getCharId(), petHorseData.getUuid()));
		
		return true;
	}

}
