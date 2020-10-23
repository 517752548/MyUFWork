package com.imop.lj.gameserver.corpswar.model;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.CorpsWarRankEntity;
import com.imop.lj.gameserver.common.Globals;

/**
 * 军团战排名对象
 * @author yu.zhao
 *
 */
public class CorpsWarRank implements PersistanceObject<Long, CorpsWarRankEntity> {
	/**主键*/
	private long id;
	/**军团Id*/
	private long corpsId;
	/**军团排名*/
	private int rank;
	/**军团得分*/
	private int score;
	/**最后更新时间 */
	private long lastUpdateTime;
	
	/** 此实例是否在db中 */
	private boolean isInDb;
	/** 生命期 */
	private final LifeCycle lifeCycle;
	
	public CorpsWarRank() {
		lifeCycle = new LifeCycleImpl(this);
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public long getCorpsId() {
		return corpsId;
	}

	public void setCorpsId(long corpsId) {
		this.corpsId = corpsId;
	}

	public int getRank() {
		return rank;
	}

	public void setRank(int rank) {
		this.rank = rank;
	}

	public int getScore() {
		return score;
	}

	public void setScore(int score) {
		this.score = score;
	}

	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}

	@Override
	public void setDbId(Long id) {
		this.setId(id);
	}

	@Override
	public Long getDbId() {
		return getId();
	}

	@Override
	public String getGUID() {
		return "CorpsWarRank#" + this.getDbId();
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
		return getDbId();
	}

	@Override
	public CorpsWarRankEntity toEntity() {
		CorpsWarRankEntity entity = new CorpsWarRankEntity();
		entity.setId(getId());
		entity.setCorpsId(getCorpsId());
		entity.setRank(getRank());
		entity.setScore(getScore());
		entity.setLastUpdateTime(getLastUpdateTime());
		return entity;
	}

	@Override
	public void fromEntity(CorpsWarRankEntity entity) {
		setId(entity.getId());
		setCorpsId(entity.getCorpsId());
		setRank(entity.getRank());
		setScore(entity.getScore());
		setLastUpdateTime(entity.getLastUpdateTime());
		
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
	 * 删除
	 */
	public void onDelete() {
		this.lifeCycle.destroy();
		Globals.getSceneService().getCommonScene().getCommonDataUpdater().addDelete(lifeCycle);
	}
	
}
