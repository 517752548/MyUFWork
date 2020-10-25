package com.imop.lj.gameserver.cdkeygift.persistance;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.CDKeyPlansEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.scene.CommonScene;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年7月8日 下午3:40:10
 * @version 1.0
 */

public class CDKeyPlansPO implements PersistanceObject<Integer, CDKeyPlansEntity> {

	private int id;
	private int cdkeyPlansId;
	private String cdkeyPlansName;
	private long startTime;
	private long endTime;
	private long createTime;
	private int gmId;
	
	/** 是否已经在数据库中 */
	private boolean inDb = false;
	/** 生命期 */
	private final LifeCycle lifeCycle;
	/** 公共场景 */
	private CommonScene commonScene;
	
	public CDKeyPlansPO() {
		this.lifeCycle = new LifeCycleImpl(this);
		commonScene = Globals.getSceneService().getCommonScene();
	}
	
	
	@Override
	public void setDbId(Integer id) {
		this.id = id;
	}

	@Override
	public Integer getDbId() {
		return null;
	}

	@Override
	public String getGUID() {
		return "CDKeyPlansEntity#" + id;
	}

	@Override
	public boolean isInDb() {
		return inDb;
	}

	@Override
	public void setInDb(boolean inDb) {
		this.inDb = inDb;
	}

	@Override
	public long getCharId() {
		return 0;
	}

	@Override
	public CDKeyPlansEntity toEntity() {
		CDKeyPlansEntity entity = new CDKeyPlansEntity();
		entity.setId(id);
		entity.setCdkeyPlansId(cdkeyPlansId);
		entity.setCdkeyPlansName(cdkeyPlansName);
		entity.setCreateTime(createTime);
		entity.setStartTime(startTime);
		entity.setEndTime(endTime);
		entity.setGmId(gmId);
		return entity;
	}

	@Override
	public void fromEntity(CDKeyPlansEntity entity) {
		this.id = entity.getId();
		this.cdkeyPlansId = entity.getCdkeyPlansId();
		this.cdkeyPlansName = entity.getCdkeyPlansName();
		this.createTime = entity.getCreateTime();
		this.startTime = entity.getStartTime();
		this.endTime = entity.getEndTime();
		this.gmId = entity.getGmId();
		this.setInDb(true);
		this.active();
	}


	/**
	 * 激活此对象，并初始化属性 此方法在玩家登录加载完数据
	 */
	public void active() {
		getLifeCycle().activate();
	}
	
	@Override
	public LifeCycle getLifeCycle() {
		return lifeCycle;
	}

	@Override
	public void setModified() {
		if (this.lifeCycle.isActive()) {
			commonScene.getCommonDataUpdater().addUpdate(lifeCycle);
		}
	}

	public long getStartTime() {
		return startTime;
	}

	public long getEndTime() {
		return endTime;
	}

}
