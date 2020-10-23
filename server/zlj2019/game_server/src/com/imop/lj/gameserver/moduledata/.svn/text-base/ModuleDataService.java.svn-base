package com.imop.lj.gameserver.moduledata;

import java.util.List;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.db.model.ModuleDataEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.moduledata.ModuleDataDef.ModuleDataType;
import com.imop.lj.gameserver.moduledata.holder.AbstractDataHolder;

/**
 * 模块数据服务
 * 
 * @author xiaowei.liu
 * 
 */
public class ModuleDataService implements InitializeRequired {

	@Override
	public void init() {
		List<ModuleDataEntity> list = Globals.getDaoService().getModuleDataDao().loadAllModuleDataEntity();
		for(ModuleDataEntity entity : list){
			ModuleDataType type = ModuleDataType.valueOf(entity.getId());
			if(type == null){
				Loggers.moduleDataLogger.error("#ModuleDataService#init module type does not exist , id = " + entity.getId() + ", json = " + entity.getJson());
				continue;
			}
			
			type.getDataHolder().getModuleData().fromEntity(entity);
		}
		
		for(ModuleDataType type : ModuleDataType.values()){
			type.getDataHolder().getModuleData().getLifeCycle().activate();
		}
	}
	
	@SuppressWarnings("unchecked")
	public <T> T getDataHolder(ModuleDataType type){
		if(type == null){
			return null;
		}
		
		return (T) type.getDataHolder();
	}
	
	/**
	 * 更新数据
	 * 
	 * @param type
	 */
	public void setModified(ModuleDataType type) {
		if(type == null){
			return;
		}
		AbstractDataHolder holder = type.getDataHolder();
		holder.setModified();
	}
}
