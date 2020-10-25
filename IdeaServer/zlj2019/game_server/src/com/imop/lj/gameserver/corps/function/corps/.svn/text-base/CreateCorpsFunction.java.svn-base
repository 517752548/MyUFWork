package com.imop.lj.gameserver.corps.function.corps;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsTypeEnum;
import com.imop.lj.gameserver.human.Human;

/**
 * 创建军团功能
 * 
 * @author xiaowei.liu
 * 
 */
public class CreateCorpsFunction extends AbstractCorpsFunction {

	@Override
	public CorpsTypeEnum getType() {
		return CorpsTypeEnum.CREATE_CORPS_FUNCTION;
	}

	@Override
	public boolean canSee(Human human, Long target) {
		return !Globals.getCorpsService().inCorps(human.getUUID());
	}

	@Override
	public void onClick(Human human, Long target) {
		//不做处理
	}

	@Override
	public String isAvailable(Human human, Long target) {
		if(this.canSee(human, target)){
			return null;
		}else{
			return "is not available";
		}
	}
	
	@Override
	public String getDesc() {
		return Globals.getGameConstants().getCreateCorpsNeedGold() + "";
	}

	@Override
	public int getTitleLangId() {
		return LangConstants.CREATE_CORPS;
	}

	@Override
	public int getDescLangId() {
		return LangConstants.CREATE_CORPS_TIPS;
	}

}
