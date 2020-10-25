package com.imop.lj.gameserver.promote.promoter;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.promote.AbstractPromoter;
import com.imop.lj.gameserver.promote.PromoteDef.PromoteID;

public class AddPointPetPromoter extends AbstractPromoter {

	public AddPointPetPromoter() {
		super(PromoteID.ADD_POINT_PET);
	}
	
	@Override
	public boolean canPromote(Human human) {
		return Globals.getPetService().isNeedAddPointPet(human);
	}

}
