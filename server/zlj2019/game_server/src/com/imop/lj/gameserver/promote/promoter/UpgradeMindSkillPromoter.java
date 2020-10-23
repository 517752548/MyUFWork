package com.imop.lj.gameserver.promote.promoter;

import com.imop.lj.common.model.humanskill.MainSkillTipsInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.promote.AbstractPromoter;
import com.imop.lj.gameserver.promote.PromoteDef.PromoteID;

public class UpgradeMindSkillPromoter extends AbstractPromoter {

	public UpgradeMindSkillPromoter() {
		super(PromoteID.MIND_SKILL_UP);
	}
	
	@Override
	public boolean canPromote(Human human) {
		return Globals.getHumanSkillService().canMindSkillUpgrade(human, new MainSkillTipsInfo())
				&& Globals.getFuncService().hasOpenedFunc(human, FuncTypeEnum.MINDSKILL);
	}

}