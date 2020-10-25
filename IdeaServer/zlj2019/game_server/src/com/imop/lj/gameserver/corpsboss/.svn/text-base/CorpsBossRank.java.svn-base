package com.imop.lj.gameserver.corpsboss;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.CorpsBossRankEntity;
import com.imop.lj.gameserver.common.Globals;

/**
 * 帮派boss进度排名对象 
 *
 */
public class CorpsBossRank implements PersistanceObject<Long, CorpsBossRankEntity>{

	/**主键*/
	private long id;
	/**帮派Id*/
	private long corpsId;
	/**帮派排名*/
	private int rank;
	/**帮派等级*/
	private int level;
	/** 帮派boss最佳进度*/
	private int bossBestLevel;
	/** 回合数*/
	private int bossKillRound;
	/** 成员总战力*/
	private int bossKillPowerSum;
	/** 成员数量*/
	private int bossKillMemberNum;
	/** 成员总等级*/
	private int bossKillLevelSum;
	/** 帮派boss最优战报*/
	private String bossBestKiller;
	/**最后更新时间 */
	private long lastUpdateTime;
	
	/** 此实例是否在db中 */
	private boolean isInDb;
	/** 生命期 */
	private final LifeCycle lifeCycle;
	
	public CorpsBossRank() {
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
	
	public int getBossBestLevel() {
		return bossBestLevel;
	}

	public void setBossBestLevel(int bossBestLevel) {
		this.bossBestLevel = bossBestLevel;
	}

	public int getBossKillRound() {
		return bossKillRound;
	}

	public void setBossKillRound(int bossKillRound) {
		this.bossKillRound = bossKillRound;
	}

	public int getBossKillPowerSum() {
		return bossKillPowerSum;
	}

	public void setBossKillPowerSum(int bossKillPowerSum) {
		this.bossKillPowerSum = bossKillPowerSum;
	}

	public int getBossKillMemberNum() {
		return bossKillMemberNum;
	}

	public void setBossKillMemberNum(int bossKillMemberNum) {
		this.bossKillMemberNum = bossKillMemberNum;
	}

	public int getBossKillLevelSum() {
		return bossKillLevelSum;
	}

	public void setBossKillLevelSum(int bossKillLevelSum) {
		this.bossKillLevelSum = bossKillLevelSum;
	}

	public String getBossBestKiller() {
		return bossBestKiller;
	}

	public void setBossBestKiller(String bossBestKiller) {
		this.bossBestKiller = bossBestKiller;
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
	public CorpsBossRankEntity toEntity() {
		CorpsBossRankEntity entity = new CorpsBossRankEntity();
		entity.setId(getId());
		entity.setCorpsId(getCorpsId());
		entity.setRank(getRank());
		entity.setLevel(getLevel());
		entity.setBossBestLevel(getBossBestLevel());
		entity.setBossKillRound(getBossKillRound());
		entity.setBossKillPowerSum(getBossKillPowerSum());
		entity.setBossKillMemberNum(getBossKillMemberNum());
		entity.setBossKillLevelSum(getBossKillLevelSum());
		entity.setBossBestKiller(getBossBestKiller());
		entity.setLastUpdateTime(getLastUpdateTime());
		return entity;
		
	}

	@Override
	public void fromEntity(CorpsBossRankEntity entity) {
		setId(entity.getId());
		setCorpsId(entity.getCorpsId());
		setRank(entity.getRank());
		setLevel(entity.getLevel());
		setBossBestLevel(entity.getBossBestLevel());
		setBossKillRound(entity.getBossKillRound());
		setBossKillPowerSum(entity.getBossKillPowerSum());
		setBossKillMemberNum(entity.getBossKillMemberNum());
		setBossKillLevelSum(entity.getBossKillLevelSum());
		setBossBestKiller(entity.getBossBestKiller());
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
		return "CorpsBossRank [id=" + id + ", corpsId=" + corpsId + ", rank=" + rank + ", level=" + level
				+ ", bossBestLevel=" + bossBestLevel + ", bossKillRound=" + bossKillRound + ", bossKillPowerSum="
				+ bossKillPowerSum + ", bossKillMemberNum=" + bossKillMemberNum + ", bossKillLevelSum="
				+ bossKillLevelSum + ", bossBestKiller=" + bossBestKiller + ", lastUpdateTime=" + lastUpdateTime + "]";
	}

}
