package com.imop.lj.gameserver.promote.promoter;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.promote.AbstractPromoter;
import com.imop.lj.gameserver.promote.PromoteDef.PromoteID;

public class UpgradeWingPromoter extends AbstractPromoter {

	public UpgradeWingPromoter() {
		super(PromoteID.WING_UP);
	}
	
	@Override
	public boolean canPromote(Human human) {
		return Globals.getWingService().isNeedUpgrade(human)
				&& Globals.getFuncService().hasOpenedFunc(human, FuncTypeEnum.WING);
	}

}
