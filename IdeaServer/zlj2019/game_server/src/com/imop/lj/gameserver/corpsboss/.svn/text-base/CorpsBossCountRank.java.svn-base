package com.imop.lj.gameserver.corpsboss;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.CorpsBossCountRankEntity;
import com.imop.lj.gameserver.common.Globals;

/**
 * 帮派boss挑战次数排名对象 
 *
 */
public class CorpsBossCountRank implements PersistanceObject<Long, CorpsBossCountRankEntity>{

	/**主键*/
	private long id;
	/**帮派Id*/
	private long corpsId;
	/**帮派排名*/
	private int rank;
	/**帮派等级*/
	private int level;
	/** 帮派boss挑战次数*/
	private int bossKillCount;
	/**最后更新时间 */
	private long lastUpdateTime;
	
	/** 此实例是否在db中 */
	private boolean isInDb;
	/** 生命期 */
	private final LifeCycle lifeCycle;
	
	public CorpsBossCountRank() {
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
	
	public int getLevel() {
		return level;
	}

	public void setLevel(int level) {
		this.level = level;
	}
	
	public int getBossKillCount() {
		return bossKillCount;
	}

	public void setBossKillCount(int bossKillCount) {
		this.bossKillCount = bossKillCount;
	}
	
	/**
	 * 增加帮派挑战次数
	 * @param count
	 */
	public void addBossKillCount(int count){
		if(count > Integer.MAX_VALUE - this.bossKillCount){
			count = Integer.MAX_VALUE;
		}
		this.bossKillCount += count; 
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
		return "CorpsBossRank#" + this.getDbId();
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
	public CorpsBossCountRankEntity toEntity() {
		CorpsBossCountRankEntity entity = new CorpsBossCountRankEntity();
		entity.setId(getId());
		entity.setCorpsId(getCorpsId());
		entity.setRank(getRank());
		entity.setLevel(getLevel());
		entity.setBossKillCount(getBossKillCount());
		entity.setLastUpdateTime(getLastUpdateTime());
		return entity;
		
	}

	@Override
	public void fromEntity(CorpsBossCountRankEntity entity) {
		setId(entity.getId());
		setCorpsId(entity.getCorpsId());
		setRank(entity.getRank());
		setLevel(entity.getLevel());
		setBossKillCount(entity.getBossKillCount());
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

	@Override
	public String toString() {
		return "CorpsBossCountRank [id=" + id + ", corpsId=" + corpsId + ", rank=" + rank + ", level=" + level
				+ ", bossKillCount=" + bossKillCount + ", lastUpdateTime=" + lastUpdateTime + "]";
	}
}
