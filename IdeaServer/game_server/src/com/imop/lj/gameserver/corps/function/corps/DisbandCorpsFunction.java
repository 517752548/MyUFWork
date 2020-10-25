package com.imop.lj.gameserver.corps.function.corps;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsTypeEnum;
import com.imop.lj.gameserver.human.Human;

/**
 * 解散帮派
 * 
 * @author xiaowei.liu
 * 
 */
public class DisbandCorpsFunction extends AbstractCorpsFunction {

	@Override
	public CorpsTypeEnum getType() {
		return CorpsTypeEnum.DISBAND_CORPS_FUNCTION;
	}

	@Override
	public boolean canSee(Human human, Long target) {
		return true;
	}

	@Override
	public void onClick(Human human, Long target) {
		Globals.getCorpsService().tryDisbandCorps(human, target);
	}

	@Override
	public String isAvailable(Human human, Long target) {
		if(Globals.getCorpsService().canUseDisbandCorps(human, target)){
			return null;
		}
		return "is not available";
	}

	@Override
	public int getTitleLangId() {
		return LangConstants.DISBAND_CORPS;
	}

	@Override
	public int getDescLangId() {
		return LangConstants.DISBAND_CORPS;
	}

}
