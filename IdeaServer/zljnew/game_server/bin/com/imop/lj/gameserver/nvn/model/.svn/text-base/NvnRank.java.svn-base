package com.imop.lj.gameserver.nvn.model;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.NvnRankEntity;
import com.imop.lj.gameserver.common.Globals;

/**
 * nvn排名对象
 * @author yu.zhao
 *
 */
public class NvnRank implements PersistanceObject<Long, NvnRankEntity> {
	/**主键*/
	private long id;
	/**军团Id*/
	private long charId;
	/**积分*/
	private int score;
	/**连胜*/
	private int conWin;
	/**胜利*/
	private int win;
	/**失败*/
	private int loss;
	/**排名*/
	private int rank;
	/**最后更新时间 */
	private long lastUpdateTime;
	
	/** 此实例是否在db中 */
	private boolean isInDb;
	/** 生命期 */
	private final LifeCycle lifeCycle;
	
	public NvnRank() {
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

	public int getConWin() {
		return conWin;
	}

	public void setConWin(int conWin) {
		this.conWin = conWin;
	}

	public int getWin() {
		return win;
	}

	public void setWin(int win) {
		this.win = win;
	}

	public int getLoss() {
		return loss;
	}

	public void setLoss(int loss) {
		this.loss = loss;
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
		return "NvnRank#" + this.getCharId();
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
	public NvnRankEntity toEntity() {
		NvnRankEntity entity = new NvnRankEntity();
		entity.setId(getId());
		entity.setCharId(getRoleId());
		entity.setRank(getRank());
		entity.setScore(getScore());
		entity.setConWin(getConWin());
		entity.setWin(getWin());
		entity.setLoss(getLoss());
		entity.setLastUpdateTime(getLastUpdateTime());
		return entity;
	}

	@Override
	public void fromEntity(NvnRankEntity entity) {
		setId(entity.getId());
		setRoleId(entity.getCharId());
		setRank(entity.getRank());
		setScore(entity.getScore());
		setConWin(entity.getConWin());
		setWin(entity.getWin());
		setLoss(entity.getLoss());
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
