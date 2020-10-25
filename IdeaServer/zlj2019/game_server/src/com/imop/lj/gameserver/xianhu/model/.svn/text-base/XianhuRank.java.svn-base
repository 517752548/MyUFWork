package com.imop.lj.gameserver.xianhu.model;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.XianhuRankEntity;
import com.imop.lj.gameserver.common.Globals;

/**
 * 仙葫排名对象
 * @author yu.zhao
 *
 */
public class XianhuRank implements PersistanceObject<Long, XianhuRankEntity> {
	/** 主键 */
	private long id;
	
	/** 排行类型 */
	private int rankType;
	/** 排名 */
	private int rank;
	/** 所属角色 */
	private long charId;
	/** 次数 */
	private int targetCount;
	/** 最后一次更新时间 */
	private long lastTime;
	/** 是否已领取奖励，0未领取，1已领取 */
	private int rewardFlag;
	/** 领取奖励时间 */
	private long rewardTime;
	
	/** 此实例是否在db中 */
	private boolean isInDb;
	/** 生命期 */
	private final LifeCycle lifeCycle;
	
	public XianhuRank() {
		lifeCycle = new LifeCycleImpl(this);
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public long getRoleId() {
		return charId;
	}

	public void setRoleId(long roleId) {
		this.charId = roleId;
	}

	public int getRank() {
		return rank;
	}

	public void setRank(int rank) {
		this.rank = rank;
	}

	public int getRankType() {
		return rankType;
	}

	public void setRankType(int rankType) {
		this.rankType = rankType;
	}

	public int getTargetCount() {
		return targetCount;
	}

	public void setTargetCount(int targetCount) {
		this.targetCount = targetCount;
	}

	public long getLastTime() {
		return lastTime;
	}

	public void setLastTime(long lastTime) {
		this.lastTime = lastTime;
	}

	public int getRewardFlag() {
		return rewardFlag;
	}

	public void setRewardFlag(int rewardFlag) {
		this.rewardFlag = rewardFlag;
	}

	public long getRewardTime() {
		return rewardTime;
	}

	public void setRewardTime(long rewardTime) {
		this.rewardTime = rewardTime;
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
		return "XianhuRank#" + this.getId();
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
		return getRoleId();
	}

	@Override
	public XianhuRankEntity toEntity() {
		XianhuRankEntity entity = new XianhuRankEntity();
		entity.setId(getId());
		entity.setRankType(getRankType());
		entity.setRank(getRank());
		entity.setCharId(getRoleId());
		entity.setLastTime(getLastTime());
		entity.setRewardFlag(getRewardFlag());
		entity.setRewardTime(getRewardTime());
		entity.setTargetCount(getTargetCount());
		return entity;
	}

	@Override
	public void fromEntity(XianhuRankEntity entity) {
		setId(entity.getId());
		setRankType(entity.getRankType());
		setRank(entity.getRank());
		setRoleId(entity.getCharId());
		setLastTime(entity.getLastTime());
		setRewardFlag(entity.getRewardFlag());
		setRewardTime(entity.getRewardTime());
		setTargetCount(entity.getTargetCount());
		
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
