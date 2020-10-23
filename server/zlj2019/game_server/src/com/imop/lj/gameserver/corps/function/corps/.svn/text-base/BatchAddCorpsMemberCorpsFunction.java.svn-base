package com.imop.lj.gameserver.corps.function.corps;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsTypeEnum;
import com.imop.lj.gameserver.human.Human;

/**
 * 批量踢出成员
 * 
 * @author xiaowei.liu
 * 
 */
public class BatchAddCorpsMemberCorpsFunction extends AbstractCorpsFunction {

	@Override
	public CorpsTypeEnum getType() {
		return CorpsTypeEnum.BATCH_FIRE_CORPS_MEMBER_CORPS_FUNCTION;
	}

	@Override
	public boolean canSee(Human human, Long target) {
		return isAvailable(human, target)==null;
	}

	@Override
	public void onClick(Human human, Long target) {
		//这个没有操作,前台应该发另外的消息
	}

	@Override
	public String isAvailable(Human human, Long target) {
		if(Globals.getCorpsService().canUseBatchAddMember(human, target)){
			return null;
		}
		return "is not available";
	}

	@Override
	public int getTitleLangId() {
		return LangConstants.BATCH_ADD_MEMBER;
	}

	@Override
	public int getDescLangId() {
		return LangConstants.BATCH_ADD_MEMBER;
	}

}
