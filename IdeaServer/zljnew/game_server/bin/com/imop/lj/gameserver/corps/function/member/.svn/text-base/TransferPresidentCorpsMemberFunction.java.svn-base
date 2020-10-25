package com.imop.lj.gameserver.corps.function.member;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsMemberTypeEnum;
import com.imop.lj.gameserver.human.Human;

/**
 * 转让团长
 * 
 * @author xiaowei.liu
 * 
 */
public class TransferPresidentCorpsMemberFunction extends AbstractCorpsMemberFunction {

	@Override
	public CorpsMemberTypeEnum getType() {
		return CorpsMemberTypeEnum.TRANSFER_PRESIDENT_CORPS_MEMBER_FUNCTION;
	}

	@Override
	public void onClick(Human human, Long target) {
		Globals.getCorpsService().transferPresident(human, target, true);
	}

	@Override
	public int getTitleLangId() {
		return LangConstants.TRANSFER_PRESIDENT;
	}

	@Override
	public int getDescLangId() {
		return LangConstants.TRANSFER_PRESIDENT;
	}

	@Override
	public boolean canSee(Human human, Long target) {
		return isAvailable(human, target) == null;
	}

	@Override
	public String isAvailable(Human human, Long target) {
		if(Globals.getCorpsService().canUseTransferPresident(human, target)){
			return null;
		}else{
			return "is not available";
		}
	}

	
}
