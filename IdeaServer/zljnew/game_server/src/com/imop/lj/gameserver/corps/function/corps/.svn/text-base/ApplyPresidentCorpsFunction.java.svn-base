package com.imop.lj.gameserver.corps.function.corps;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsTypeEnum;
import com.imop.lj.gameserver.corps.CorpsDef.MemberJob;
import com.imop.lj.gameserver.human.Human;

/**
 * 申请团长
 * 
 * @author xiaowei.liu
 * 
 */
public class ApplyPresidentCorpsFunction extends AbstractCorpsFunction {

	@Override
	public CorpsTypeEnum getType() {
		return CorpsTypeEnum.APPLY_PRESIDENT_CORPS_FUNCTION;
	}

	@Override
	public boolean canSee(Human human, Long target) {
		return false;
	}

	@Override
	public void onClick(Human human, Long target) {
		Globals.getCorpsService().applyPresident(human, target);
	}

	@Override
	public String isAvailable(Human human, Long target) {
//		if(Globals.getCorpsService().canUseApplyPresident(human, target)){
//			return null;
//		}else{
//			return "is not available";
//		}
//		
		return "is not available";
	}

	@Override
	public int getTitleLangId() {
		return LangConstants.APPLY_PRESIDENT;
	}

	@Override
	public int getDescLangId() {
		return LangConstants.APPLY_PRESIDENT_TIPS;
	}

	@Override
	public String getDesc(Human human, long corpsId) {
		if(Globals.getCorpsService().matchJob(human, corpsId, MemberJob.PRESIDENT)){
			return Globals.getLangService().readSysLang(LangConstants.PRESIDENT_APPLY_PRESIDENT_TIPS);
		}else{
			return Globals.getLangService().readSysLang(LangConstants.APPLY_PRESIDENT_TIPS);
		}
	}
}
