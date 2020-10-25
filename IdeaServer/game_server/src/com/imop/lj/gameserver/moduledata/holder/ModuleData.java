package com.imop.lj.gameserver.moduledata.holder;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.ModuleDataEntity;
import com.imop.lj.gameserver.common.Globals;

/**
 * 抽象数据管理
 * 
 * @author xiaowei.liu
 * 
 */
public class ModuleData implements PersistanceObject<Integer, ModuleDataEntity> {
	private AbstractDataHolder dataHolder;
	
	public ModuleData(AbstractDataHolder dataHolder){
		this.dataHolder = dataHolder;
		this.lifeCycle = new LifeCycleImpl(this);
	}
	/** 此实例是否在db中 */
	private boolean isInDb;

	/** 生命期 */
	private final LifeCycle lifeCycle;

	@Override
	public void setDbId(Integer id) {
		
	}

	@Override
	public Integer getDbId() {
		return this.dataHolder.getModuleDataType().index;
	}

	@Override
	public String getGUID() {
		return "module#" + this.dataHolder.getModuleDataType().index;
	}

	@Override
	public boolean isInDb() {
		return this.isInDb;
	}

	@Override
	public void setInDb(boolean inDb) {
		this.isInDb = inDb;
	}

	@Override
	public long getCharId() {
		return this.dataHolder.getModuleDataType().index;
	}

	@Override
	public ModuleDataEntity toEntity() {
		ModuleDataEntity entity = new ModuleDataEntity();
		entity.setId(this.dataHolder.getModuleDataType().index);
		entity.setJson(this.dataHolder.toJsonProp());
		return entity;
	}

	@Override
	public void fromEntity(ModuleDataEntity entity) {
		this.isInDb = true;
		this.dataHolder.loadJsonProp(entity.getJson());
	}

	@Override
	public LifeCycle getLifeCycle() {
		return this.lifeCycle;
	}

	@Override
	public void setModified() {
		this.lifeCycle.checkModifiable();
		if (this.lifeCycle.isActive()) {
			Globals.getSceneService().getCommonScene().getCommonDataUpdater().addUpdate(lifeCycle);
		}	
	}

}
