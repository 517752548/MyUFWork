package com.imop.lj.gameserver.promote.promoter;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.promote.AbstractPromoter;
import com.imop.lj.gameserver.promote.PromoteDef.PromoteID;

public class AddPointLeaderPromoter extends AbstractPromoter {

	public AddPointLeaderPromoter() {
		super(PromoteID.ADD_POINT_LEADER);
	}
	
	@Override
	public boolean canPromote(Human human) {
		return Globals.getPetService().isNeedAddPointLeader(human);
	}

}
