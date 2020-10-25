package com.imop.lj.gameserver.promote.promoter;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.promote.AbstractPromoter;
import com.imop.lj.gameserver.promote.PromoteDef.PromoteID;

public class PutOnGemPromoter extends AbstractPromoter {

	public PutOnGemPromoter() {
		super(PromoteID.PUT_ON_GEM);
	}
	
	@Override
	public boolean canPromote(Human human) {
		return Globals.getEquipService().isNeedPutonGem(human)
				&& Globals.getFuncService().hasOpenedFunc(human, FuncTypeEnum.GEM_EQUIP);
	}

}
