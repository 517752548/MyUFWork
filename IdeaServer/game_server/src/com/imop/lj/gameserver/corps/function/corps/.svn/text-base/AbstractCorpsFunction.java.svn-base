package com.imop.lj.gameserver.corps.function.corps;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.function.IGameFunc;
import com.imop.lj.gameserver.corps.CorpsDef;
import com.imop.lj.gameserver.human.Human;

/**
 * 军团功能抽象类，标记
 * 
 * @author xiaowei.liu
 * 
 */
public abstract class AbstractCorpsFunction implements IGameFunc<CorpsDef.CorpsTypeEnum, Long> {
	
	@Override
	public int getIndex() {
		return 0;
	}

	@Override
	public String getTitle() {
		return Globals.getLangService().readSysLang(this.getTitleLangId());
	}

	@Override
	public String getDesc() {
		return Globals.getLangService().readSysLang(this.getDescLangId());
	}
	
	public String getDesc(Human human, long corpsId){
		return this.getDesc();
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
