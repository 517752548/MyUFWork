package com.imop.lj.gameserver.promote;

import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.promote.PromoteDef.PromoteID;

public abstract class AbstractPromoter implements IPromoter {
	
	protected PromoteID promoteId;
	
	public AbstractPromoter(PromoteID promoteId) {
		this.promoteId = promoteId;
	}
	
	public PromoteID getPromoteId() {
		return promoteId;
	}

	@Override
	public boolean canPromote(Human human) {
		return false;
	}

}
