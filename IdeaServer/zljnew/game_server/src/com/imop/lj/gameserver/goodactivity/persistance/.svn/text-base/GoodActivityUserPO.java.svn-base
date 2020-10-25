package com.imop.lj.gameserver.goodactivity.persistance;

import java.sql.Timestamp;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.GoodActivityUserEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.scene.CommonScene;

public class GoodActivityUserPO implements PersistanceObject<Long, GoodActivityUserEntity> {
	/** 主键 */
	private Long id;
	
	/** 玩家uuid */
	private long charId;
	/** 活动Id */
	private long activityId;
	
	/** 创建时间 */
	private long createTime;
	/** 最后一次更新时间 */
	private long lastUpdateTime;
	
	/** 是否已删除，如果回档的时候，可能会删掉 */
	private int deleted;
	/** 删除时间 */
	private Timestamp deleteDate;

	private AbstractUserGoodActivity userGoodActivity;
	
	/** 是否已经在数据库中 */
	private boolean inDb;
	/** 生命期 */
	private final LifeCycle lifeCycle;
	/** 场景 */
	private CommonScene commonScene;
	
	public GoodActivityUserPO(AbstractUserGoodActivity userGoodActivity) {
		this.userGoodActivity = userGoodActivity;
		commonScene = Globals.getSceneService().getCommonScene();
		this.lifeCycle = new LifeCycleImpl(this);
	}
	
	public long getActivityId() {
		return activityId;
	}

	public void setActivityId(long activityId) {
		this.activityId = activityId;
	}

	public long getCreateTime() {
		return createTime;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}

	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}

	public int getDeleted() {
		return deleted;
	}

	public void setDeleted(int deleted) {
		this.deleted = deleted;
	}

	public Timestamp getDeleteDate() {
		return deleteDate;
	}

	public void setDeleteDate(Timestamp deleteDate) {
		this.deleteDate = deleteDate;
	}

	@Override
	public void setDbId(Long id) {
		this.id = id;
	}

	@Override
	public Long getDbId() {
		return id;
	}

	@Override
	public String getGUID() {
		return "GoodActivityUserEntity#" + this.id;
	}

	@Override
	public boolean isInDb() {
		return this.inDb;
	}

	@Override
	public void setInDb(boolean inDb) {
		this.inDb = inDb;
	}

	@Override
	public long getCharId() {
		return this.charId;
	}
	
	public void setCharId(long charId) {
		this.charId = charId;
	}
	
	private String getActivityData() {
		String d = "";
		if (null != userGoodActivity && null != userGoodActivity.getUserDataModel()) {
			d = userGoodActivity.getUserDataModel().userDataToJson();
		}
		return d;
	}

	@Override
	public GoodActivityUserEntity toEntity() {
		GoodActivityUserEntity entity = new GoodActivityUserEntity();
		entity.setId(getDbId());
		entity.setCharId(getCharId());
		entity.setActivityId(getActivityId());
		entity.setActivityData(getActivityData());
		entity.setCreateTime(getCreateTime());
		entity.setLastUpdateTime(getLastUpdateTime());
		entity.setDeleted(getDeleted());
		entity.setDeleteDate(getDeleteDate());
		return entity;
	}

	@Override
	public void fromEntity(GoodActivityUserEntity entity) {
		this.id = entity.getId();
		this.activityId = entity.getActivityId();
		this.charId = entity.getCharId();
		this.createTime = entity.getCreateTime();
		this.lastUpdateTime = entity.getLastUpdateTime();
		this.setDeleted(entity.getDeleted());
		this.setDeleteDate(entity.getDeleteDate());
		if (null != this.userGoodActivity && null != this.userGoodActivity.getUserDataModel()) {
			this.userGoodActivity.getUserDataModel().userDataFromJson(entity.getActivityData());
		}
		this.setInDb(true);
		this.active();
	}

	@Override
	public LifeCycle getLifeCycle() {
		return lifeCycle;
	}
	
	/**
	 * 激活此关系
	 */
	public void active() {
		getLifeCycle().activate();
	}

	@Override
	public void setModified() {
		if (this.lifeCycle.isActive()) {
			commonScene.getCommonDataUpdater().addUpdate(lifeCycle);
		}
	}
	
	/**
	 * 关系被删除回调处理
	 */
	public void onDelete() {
		this.lifeCycle.destroy();
		this.commonScene.getCommonDataUpdater().addDelete(lifeCycle);
	}

	@Override
	public String toString() {
		return "GoodActivityUserPO [id=" + id + ", charId=" + charId
				+ ", activityId=" + activityId + ", createTime=" + createTime
				+ ", lastUpdateTime=" + lastUpdateTime + "]";
	}
	
}
