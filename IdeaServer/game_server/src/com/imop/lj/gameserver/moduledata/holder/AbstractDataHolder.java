package com.imop.lj.gameserver.moduledata.holder;

import com.imop.lj.gameserver.human.JsonPropDataHolder;
import com.imop.lj.gameserver.moduledata.ModuleDataDef.ModuleDataType;

public abstract class AbstractDataHolder implements JsonPropDataHolder {
	private ModuleData moduleData = new ModuleData(this);

	/***
	 * 获取数据类型
	 * 
	 * @return
	 */
	public abstract ModuleDataType getModuleDataType();

	/**
	 * 实体类数据
	 * 
	 * @return
	 */
	public ModuleData getModuleData(){
		return moduleData;
	}
	
	public void setModified(){
		this.moduleData.setModified();
	}
}
