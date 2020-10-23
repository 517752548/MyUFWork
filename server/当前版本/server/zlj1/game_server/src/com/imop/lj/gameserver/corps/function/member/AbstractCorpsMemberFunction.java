package com.imop.lj.gameserver.corps.function.member;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.function.IGameFunc;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsMemberTypeEnum;
import com.imop.lj.gameserver.human.Human;

/**
 * 军团成员功能 抽象类(所有权限在军团成员权限中配置)
 * 
 * @author xiaowei.liu
 * 
 */
public abstract class AbstractCorpsMemberFunction implements IGameFunc<CorpsMemberTypeEnum, Long> {
	
	@Override
	public boolean canSee(Human human, Long target) {
		return human.getUUID() != target;
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
	public int getIndex() {
		return 0;
	}

	@Override
	public String getTitle() {
		if(this.getTitleLangId() == 0){
			return "";
		}else{
			return Globals.getLangService().readSysLang(this.getTitleLangId());
		}
	}

	@Override
	public String getDesc() {
		if(this.getDescLangId() == 0){
			return "";
		}else{
			return Globals.getLangService().readSysLang(this.getDescLangId());
		}
	}

	@Override
	public void setIndex(int value) {

	}

	@Override
	public void setTitle(String value) {

	}

	@Override
	public void setDesc(String value) {

	}

	@Override
	public void setArgs(String[] values) {

	}

	@Override
	public int getTypeId() {
		return this.getType().getIndex();
	}

	@Override
	public void checkArgs() {

	}

	@Override
	public int getPriority() {
		return 0;
	}

	@Override
	public String getAboutInfo(Human human, Long target) {
		return null;
	}

	/**
	 * 获取标题多语言 Id
	 * 
	 * @return
	 */
	public abstract int getTitleLangId();

	/**
	 * 获取描述多语言 Id
	 * 
	 * @return
	 */
	public abstract int getDescLangId();
}
