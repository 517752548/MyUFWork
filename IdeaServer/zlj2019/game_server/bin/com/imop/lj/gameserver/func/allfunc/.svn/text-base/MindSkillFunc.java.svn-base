package com.imop.lj.gameserver.func.allfunc;

import com.imop.lj.common.model.humanskill.MainSkillTipsInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.AbstractFunc;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;

public class MindSkillFunc extends AbstractFunc {

	public MindSkillFunc(Human human, FuncTypeEnum funcType) {
		super(human, funcType);
	}

	@Override
	public boolean canOpen() {
		return Globals.getFuncService().hasOpenedFunc(getOwner(), getFuncType());
	}

	@Override
	public boolean canShowEffect() {
		//心法和技能
		return Globals.getHumanSkillService().canMindLevelUpgrade(getOwner(), new MainSkillTipsInfo())
				||
				Globals.getHumanSkillService().canMindSkillUpgrade(getOwner(), new MainSkillTipsInfo());
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
