package com.imop.lj.gameserver.corps.function.corps;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsTypeEnum;
import com.imop.lj.gameserver.human.Human;

/**
 * 退出军团
 * 
 * @author xiaowei.liu
 * 
 */
public class ExitCorpsFunction extends AbstractCorpsFunction {

	@Override
	public CorpsTypeEnum getType() {
		return CorpsTypeEnum.EXIT_CORPS_FUNCTION;
	}

	@Override
	public boolean canSee(Human human, Long target) {
		return true;
	}

	@Override
	public void onClick(Human human, Long target) {
		Globals.getCorpsService().exitCorps(human);
	}

	@Override
	public String isAvailable(Human human, Long target) {
		return null;
	}

	@Override
	public int getTitleLangId() {
		return LangConstants.EXIT_CORPS;
	}

	@Override
	public int getDescLangId() {
		return LangConstants.EXIT_CORPS;
	}

}
