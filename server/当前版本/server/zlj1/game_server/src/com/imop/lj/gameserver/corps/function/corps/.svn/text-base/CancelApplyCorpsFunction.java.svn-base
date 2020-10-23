package com.imop.lj.gameserver.corps.function.corps;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsTypeEnum;
import com.imop.lj.gameserver.human.Human;

public class CancelApplyCorpsFunction extends AbstractCorpsFunction {

	@Override
	public CorpsTypeEnum getType() {
		return CorpsTypeEnum.CANCEL_APPLY_CORPS_FUNCTION;
	}

	@Override
	public boolean canSee(Human human, Long target) {
		return Globals.getCorpsService().canSeeCancelApply(human, target);
	}

	@Override
	public void onClick(Human human, Long target) {
		Globals.getCorpsService().cancelApply(human, target);
	}

	@Override
	public String isAvailable(Human human, Long target) {
		if(this.canSee(human, target)){
			return null;
		}else{
			return "is not available";
		}
	}

	@Override
	public String getAboutInfo(Human human, Long target) {
		return null;
	}

	@Override
	public int getTitleLangId() {
		return LangConstants.CACEL_CORPS_APPLY;
	}

	@Override
	public int getDescLangId() {
		return LangConstants.CACEL_CORPS_APPLY;
	}

}
