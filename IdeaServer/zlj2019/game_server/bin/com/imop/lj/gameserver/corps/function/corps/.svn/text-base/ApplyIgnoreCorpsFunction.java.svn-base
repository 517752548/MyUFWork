package com.imop.lj.gameserver.corps.function.corps;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsTypeEnum;
import com.imop.lj.gameserver.human.Human;

/**
 * 忽略所有申请
 * 
 * @author xiaowei.liu
 * 
 */
public class ApplyIgnoreCorpsFunction extends AbstractCorpsFunction {

	@Override
	public CorpsTypeEnum getType() {
		return CorpsTypeEnum.APPLY_IGNORE_CORPS_FUNCTION;
	}

	@Override
	public boolean canSee(Human human, Long target) {
		return this.isAvailable(human, target) == null;
	}

	@Override
	public void onClick(Human human, Long target) {
		Globals.getCorpsService().ignoreAllApply(human, target);
	}

	@Override
	public String isAvailable(Human human, Long target) {
		if(Globals.getCorpsService().canUseIgnoreAllApply(human, target)){
			return null;
		}else{
			return "is not available";
		}
	}

	@Override
	public int getTitleLangId() {
		return LangConstants.IGNORE_ALL_APPLY;
	}

	@Override
	public int getDescLangId() {
		return LangConstants.IGNORE_ALL_APPLY;
	}

}
