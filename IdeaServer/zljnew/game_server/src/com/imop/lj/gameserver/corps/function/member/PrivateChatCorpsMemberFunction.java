package com.imop.lj.gameserver.corps.function.member;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsMemberTypeEnum;
import com.imop.lj.gameserver.human.Human;

/**
 * 发起私聊
 * 
 * @author xiaowei.liu
 * 
 */
public class PrivateChatCorpsMemberFunction extends AbstractCorpsMemberFunction {

	@Override
	public CorpsMemberTypeEnum getType() {
		return CorpsMemberTypeEnum.PRIVATE_CHAT_CORPS_MEMBER_FUNCTION;
	}

	@Override
	public void onClick(Human human, Long target) {
		// TODO 

	}

	@Override
	public int getTitleLangId() {
		return LangConstants.PRIVATE_CHAT;
	}

	@Override
	public int getDescLangId() {
		return LangConstants.PRIVATE_CHAT;
	}

}
