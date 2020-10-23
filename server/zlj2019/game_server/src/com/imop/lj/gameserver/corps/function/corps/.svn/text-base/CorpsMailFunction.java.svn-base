package com.imop.lj.gameserver.corps.function.corps;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsTypeEnum;
import com.imop.lj.gameserver.corps.CorpsDef.MemberJob;
import com.imop.lj.gameserver.human.Human;

/**
 * 军团邮件功能
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsMailFunction extends AbstractCorpsFunction {

	@Override
	public CorpsTypeEnum getType() {
		return CorpsTypeEnum.CORPS_MAIL_FUNCTION;
	}

	@Override
	public boolean canSee(Human human, Long target) {
		return isAvailable(human, target) == null;
	}

	@Override
	public void onClick(Human human, Long target) {
		//这里不写,前台应该发另外的消息
	}

	@Override
	public String isAvailable(Human human, Long target) {
		if(Globals.getCorpsService().matchJob(human, target, MemberJob.PRESIDENT, MemberJob.VICE_CHAIRMAN)){
			return null;
		}else{
			return "is not available";
		}
	}

	@Override
	public int getTitleLangId() {
		return LangConstants.CORPS_MAIL;
	}

	@Override
	public int getDescLangId() {
		return LangConstants.CORPS_MAIL;
	}

}
