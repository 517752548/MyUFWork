package com.imop.lj.gameserver.corps.function.member;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsMemberTypeEnum;
import com.imop.lj.gameserver.human.Human;

/**
 * 查看成员详细信息
 * 
 * @author xiaowei.liu
 * 
 */
public class SeeDetailCorpsMemberFunction extends AbstractCorpsMemberFunction {

	@Override
	public CorpsMemberTypeEnum getType() {
		return CorpsMemberTypeEnum.SEE_DETAIL_CORPS_MEMBER_FUNCTION;
	}
	
	@Override
	public void onClick(Human human, Long target) {
		//TODO 未完待续
	}

	@Override
	public int getTitleLangId() {
		return LangConstants.SEE_DETAIL_CORPS_MEMBER_INFO;
	}

	@Override
	public int getDescLangId() {
		return LangConstants.SEE_DETAIL_CORPS_MEMBER_INFO;
	}

}
