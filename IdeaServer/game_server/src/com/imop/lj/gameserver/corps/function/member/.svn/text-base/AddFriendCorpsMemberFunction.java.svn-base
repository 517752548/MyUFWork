package com.imop.lj.gameserver.corps.function.member;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsMemberTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.relation.RelationTypeEnum;

/**
 * 添加好友
 * 
 * @author xiaowei.liu
 * 
 */
public class AddFriendCorpsMemberFunction extends AbstractCorpsMemberFunction {

	@Override
	public CorpsMemberTypeEnum getType() {
		return CorpsMemberTypeEnum.ADD_FRIEND_CORPS_MEMBER_FUNCTION;
	}

	@Override
	public void onClick(Human human, Long target) {
		Globals.getRelationService().addRelation(human, target, RelationTypeEnum.FRIEND);
	}

	@Override
	public int getTitleLangId() {
		return LangConstants.ADD_FRIEND;
	}

	@Override
	public int getDescLangId() {
		return LangConstants.ADD_FRIEND;
	}
}
