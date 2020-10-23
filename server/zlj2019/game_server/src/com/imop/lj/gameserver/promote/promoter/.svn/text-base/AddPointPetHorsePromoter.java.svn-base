package com.imop.lj.gameserver.promote.promoter;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.promote.AbstractPromoter;
import com.imop.lj.gameserver.promote.PromoteDef.PromoteID;

public class AddPointPetHorsePromoter extends AbstractPromoter {

	public AddPointPetHorsePromoter() {
		super(PromoteID.ADD_POINT_PET_HORSE);
	}
	
	@Override
	public boolean canPromote(Human human) {
		return Globals.getPetService().isNeedAddPointPetHorse(human)
				 && Globals.getFuncService().hasOpenedFunc(human, FuncTypeEnum.HORSE);
	}

}
