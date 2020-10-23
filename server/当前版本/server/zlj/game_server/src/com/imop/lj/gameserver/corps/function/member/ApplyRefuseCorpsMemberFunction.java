package com.imop.lj.gameserver.corps.function.member;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsMemberTypeEnum;
import com.imop.lj.gameserver.human.Human;

/**
 * 拒绝加入军团申请
 * 
 * @author xiaowei.liu
 * 
 */
public class ApplyRefuseCorpsMemberFunction extends AbstractCorpsMemberFunction {

	@Override
	public CorpsMemberTypeEnum getType() {
		return CorpsMemberTypeEnum.APPLY_REFUSE_CORPS_MEMBER_FUCNTION;
	}

	@Override
	public void onClick(Human human, Long target) {
		Globals.getCorpsService().refuseCorpsApply(human, target, this.getTypeId());
	}

	@Override
	public int getTitleLangId() {
		return LangConstants.APPLY_REFUSE;
	}

	@Override
	public int getDescLangId() {
		return LangConstants.APPLY_REFUSE;
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
