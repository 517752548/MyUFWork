package com.imop.lj.gameserver.corps.function.member;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsMemberTypeEnum;
import com.imop.lj.gameserver.human.Human;

/**
 * 申请加入军团通过
 * 
 * @author xiaowei.liu
 * 
 */
public class ApplyPassCorpsMemberFunction extends AbstractCorpsMemberFunction {

	@Override
	public CorpsMemberTypeEnum getType() {
		return CorpsMemberTypeEnum.APPLY_PASS_CORPS_MEMBER_FUNCTION;
	}


	@Override
	public void onClick(Human human, Long target) {
		Globals.getCorpsService().passCorpsApply(human, target, this.getTypeId(),false);
	}

	@Override
	public int getTitleLangId() {
		return LangConstants.APPLY_PASS;
	}

	@Override
	public int getDescLangId() {
		return LangConstants.APPLY_PASS;
	}


	@Override
	public boolean canSee(Human human, Long target) {
		return isAvailable(human, target) == null;
	}


	@Override
	public String isAvailable(Human human, Long target) {
		if(Globals.getCorpsService().canUsePassAndRefuse(human, target)){
			return null;
		}else{
			return "is no available";
		}
	}

}
