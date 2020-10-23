package com.imop.lj.gameserver.allocate.model;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.AllocateActivityStorageEntity;
import com.imop.lj.gameserver.activity.function.ActivityDef.ActivityType;
import com.imop.lj.gameserver.common.Globals;

public class AllocateActivityStorage implements PersistanceObject<Long, AllocateActivityStorageEntity>{
	
	
	private long uuid;
	
	private ActivityType activityType;
	
	private long corpsId;
	
	private AllocateActivityStorageData storage;
	
	/** 此实例是否在db中 */
	private boolean isInDb;
	/** 生命期 */
	private final LifeCycle lifeCycle;
	
	public AllocateActivityStorage() {
		lifeCycle = new LifeCycleImpl(this);
		storage = new AllocateActivityStorageData();
	}
	
	
	public long getUuid() {
		return uuid;
	}

	public void setUuid(long uuid) {
		this.uuid = uuid;
	}

	public ActivityType getActivityType() {
		return activityType;
	}


	public void setActivityType(ActivityType activityType) {
		this.activityType = activityType;
	}


	public long getCorpsId() {
		return corpsId;
	}


	public void setCorpsId(long corpsId) {
		this.corpsId = corpsId;
	}

	
	
	public AllocateActivityStorageData getStorage() {
		return storage;
	}


	public void setStorage(AllocateActivityStorageData storage) {
		this.storage = storage;
	}


	@Override
	public String toString() {
		return "AllocateActivityStorage [uuid=" + uuid + ", activityType=" + activityType + ", corpsId=" + corpsId
				+ ", storage=" + storage + ", isInDb=" + isInDb + ", lifeCycle=" + lifeCycle + "]";
	}


	@Override
	public void setDbId(Long id) {
		this.uuid = Long.valueOf(id);
		
	}
	@Override
	public Long getDbId() {
		return this.uuid;
	}
	@Override
	public String getGUID() {
		return "AllocateActivityStorage#" + getUuid();
	}
	@Override
	public boolean isInDb() {
		return isInDb;
	}
	@Override
	public void setInDb(boolean inDb) {
		this.isInDb = inDb;
		
	}
	@Override
	public long getCharId() {
		return activityType.getIndex();
	}
	@Override
	public AllocateActivityStorageEntity toEntity() {
		AllocateActivityStorageEntity entity = new AllocateActivityStorageEntity();
		entity.setId(this.getDbId());
		entity.setActivityType(this.getActivityType().getIndex());
		entity.setCorpsId(this.getCorpsId());
		entity.setAllocateInfo(storage.toJson());
		return entity;
	}
	@Override
	public void fromEntity(AllocateActivityStorageEntity entity) {
		this.setDbId(entity.getId());
		this.setActivityType(ActivityType.valueOf(entity.getActivityType()));
		this.setCorpsId(entity.getCorpsId());
		storage.fromJson(entity.getAllocateInfo());
		
		setInDb(true);
        active();
	}
	
	@Override
	public LifeCycle getLifeCycle() {
		return lifeCycle;
	}
	@Override
	public void setModified() {
		if (this.lifeCycle.isActive()) {
			Globals.getSceneService().getCommonScene().getCommonDataUpdater().addUpdate(lifeCycle);
		}
	}
	
	/**
	 * 激活
	 */
	public void active() {
		this.lifeCycle.activate();
	}

	/**
	 * 删除红包
	 */
	public void delete() {
		onDelete();
	}
	
	/**
	 * 删除
	 */
	public void onDelete() {
		this.lifeCycle.destroy();
		Globals.getSceneService().getCommonScene().getCommonDataUpdater().addDelete(lifeCycle);
	}


}
