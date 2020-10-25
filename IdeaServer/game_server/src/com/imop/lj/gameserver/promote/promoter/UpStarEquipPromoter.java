package com.imop.lj.gameserver.promote.promoter;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.promote.AbstractPromoter;
import com.imop.lj.gameserver.promote.PromoteDef.PromoteID;

public class UpStarEquipPromoter extends AbstractPromoter {

	public UpStarEquipPromoter() {
		super(PromoteID.UP_STAR);
	}
	
	@Override
	public boolean canPromote(Human human) {
		return Globals.getEquipService().isNeedUpStar(human);
	}

}
