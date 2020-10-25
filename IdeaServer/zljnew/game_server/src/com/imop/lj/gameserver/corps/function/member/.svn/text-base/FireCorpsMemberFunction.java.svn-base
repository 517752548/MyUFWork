package com.imop.lj.gameserver.corps.function.member;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsMemberTypeEnum;
import com.imop.lj.gameserver.human.Human;

/**
 * 开除成员
 * 
 * @author xiaowei.liu
 * 
 */
public class FireCorpsMemberFunction extends AbstractCorpsMemberFunction {

	@Override
	public CorpsMemberTypeEnum getType() {
		return CorpsMemberTypeEnum.FIRE_CORPS_MEMBER_FUNCTION;
	}

	@Override
	public void onClick(Human human, Long target) {
		Globals.getCorpsService().fireCorpsMember(human, target, true,false,false);
	}

	@Override
	public int getTitleLangId() {
		return LangConstants.FIRE_MEMBER;
	}

	@Override
	public int getDescLangId() {
		return LangConstants.FIRE_MEMBER;
	}

	@Override
	public boolean canSee(Human human, Long target) {
		return isAvailable(human, target) == null;
	}

	@Override
	public String isAvailable(Human human, Long target) {
		if(Globals.getCorpsService().canUseFireMember(human, target)){
			return null;
		}else{
			return "is not available";
		}
	}

}
