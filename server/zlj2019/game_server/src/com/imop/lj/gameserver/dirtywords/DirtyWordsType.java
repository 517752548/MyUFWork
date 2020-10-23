package com.imop.lj.gameserver.dirtywords;

import java.sql.Timestamp;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.DirtyWordsTypeEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.scene.CommonScene;

public class DirtyWordsType implements PersistanceObject<Integer, DirtyWordsTypeEntity>{
	/** 主键 */
	private Integer id;
	/**  */
	private int dirtyWordsType;
	/** 更新时间 */
	private long updateTime;
	// 生命期 
	private final LifeCycle lifeCycle; 
	//公共场景
	private CommonScene commonScene;
	// 此实例是否在db中 
	private boolean isInDb;
	
	public DirtyWordsType(){
		this.commonScene = Globals.getSceneService().getCommonScene();
		this.lifeCycle = new LifeCycleImpl(this);
		this.lifeCycle.activate();
	}
	
	@Override
	public void setDbId(Integer id) {
		this.id = id;
	}

	@Override
	public Integer getDbId() {
		return this.id;
	}

	@Override
	public String getGUID() {
		return "DirtyWordsType#" + this.id;
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
		return this.id;
	}

	@Override
	public DirtyWordsTypeEntity toEntity() {
		DirtyWordsTypeEntity entity = new DirtyWordsTypeEntity();
		entity.setDirtyWordsType(this.getDirtyWordsType());
		entity.setId(getId());
		entity.setUpdateTime(new Timestamp(getUpdateTime()));
		return entity;
	}

	@Override
	public void fromEntity(DirtyWordsTypeEntity entity) {
		this.id = entity.getId();
		this.dirtyWordsType = entity.getDirtyWordsType();
		this.updateTime = entity.getUpdateTime().getTime();
		this.setInDb(true);
	}

	@Override
	public LifeCycle getLifeCycle() {
		return this.lifeCycle;
	}

	@Override
	public void setModified() {
		if (this.lifeCycle.isActive()) {
			commonScene.getCommonDataUpdater().addUpdate(lifeCycle);
		}
	}

	public Integer getId() {
		return id;
	}

	public void setId(Integer id) {
		this.id = id;
	}

	
	public int getDirtyWordsType() {
		return dirtyWordsType;
	}

	public void setDirtyWordsType(int dirtyWordsType) {
		this.dirtyWordsType = dirtyWordsType;
	}

	public long getUpdateTime() {
		return updateTime;
	}
	public void setUpdateTime(long updateTime) {
		this.updateTime = updateTime;
	}
}
