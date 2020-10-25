package com.imop.lj.gameserver.corps.function.corps;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsTypeEnum;
import com.imop.lj.gameserver.corps.CorpsDef.MemberJob;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.human.Human;

/**
 * 军团公告修改
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsNoticeUpdateFunction extends AbstractCorpsFunction {

	@Override
	public CorpsTypeEnum getType() {
		return CorpsTypeEnum.CORPS_NOTICE_UPDATE_FUNCTION;
	}

	@Override
	public boolean canSee(Human human, Long target) {
		return true;
	}

	@Override
	public void onClick(Human human, Long target) {
		// 不做处理
	}

	@Override
	public String isAvailable(Human human, Long target) {
		Corps corps = Globals.getCorpsService().getCorpsById(target);
		if(corps == null){
			return "corps does not exist";
		}
		
		if(corps.getLevel() < Globals.getGameConstants().getTheMinLevelForChangeCorpsNotice()){
			return "level doest not enough";
		}
		
		if(Globals.getCorpsService().matchJob(human, target, MemberJob.PRESIDENT, MemberJob.VICE_CHAIRMAN)){
			return null;
		}else{
			return "is not available";
		}
	}

	@Override
	public int getTitleLangId() {
		return LangConstants.CORPS_NOTICE_UPDATE;
	}

	@Override
	public int getDescLangId() {
		return LangConstants.CORPS_NOTICE_UPDATE;
	}

	@Override
	public String getDesc(Human human, long corpsId) {
		Corps corps = Globals.getCorpsService().getCorpsById(corpsId);
		if(corps == null){
			return "";
		}
		
		if(Globals.getCorpsService().matchJob(human, corpsId, MemberJob.PRESIDENT, MemberJob.VICE_CHAIRMAN) 
				&& corps.getLevel() < Globals.getGameConstants().getTheMinLevelForChangeCorpsNotice()){
			return Globals.getLangService().readSysLang(LangConstants.CHANGE_NOTICE_LIMIT, Globals.getGameConstants().getTheMinLevelForChangeCorpsNotice());
		}
		
		return "";
	}

	
}
