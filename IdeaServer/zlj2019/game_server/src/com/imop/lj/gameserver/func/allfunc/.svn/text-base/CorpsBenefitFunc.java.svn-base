package com.imop.lj.gameserver.func.allfunc;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.AbstractFunc;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;

/**
 * 帮派福利
 * 
 */
public class CorpsBenefitFunc extends AbstractFunc {

	public CorpsBenefitFunc(Human human, FuncTypeEnum funcType) {
		super(human, funcType);
	}

	@Override
	public boolean canOpen() {
		return Globals.getFuncService().hasOpenedFunc(getOwner(), getFuncType());
	}

	@Override
	public boolean canShowEffect() {
		//福利
		//帮派修炼
		//帮派辅助
		return (Globals.getCorpsService().hasBenefit(getOwner())
				||Globals.getCorpsCultivateService().canCultivate(getOwner())
				|| Globals.getCorpsAssistService().canAssist(getOwner()));
	}

	@Override
	public int getShowNum() {
		return 0;
	}

	@Override
	public long getCountDownTime() {
		return 0;
	}

}
