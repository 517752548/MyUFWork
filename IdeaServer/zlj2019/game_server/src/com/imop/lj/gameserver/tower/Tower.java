package com.imop.lj.gameserver.tower;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.TowerEntity;
import com.imop.lj.gameserver.common.Globals;

public class Tower implements PersistanceObject<String, TowerEntity>{

    /**
     * 通天塔的实例UUID
     */
    private String id;
    /**
     * 通天塔的生命期的状态
     */
    private final LifeCycle lifeCycle;
    
    /**
     * 此实例是否在db中
     */
    private boolean isInDb;
    
    /**
     * 通天塔层数
     */
    private int towerLevel;
    
    /**
     * 最先击败者角色ID
     */
    private long fCharId;
    
    /**
     * 最先击败者角色等级
     */
    private int fLevel;
    
    /**
     * 最先击败者回合数
     */
    private int fRound;
    
    /**
     * 最先击败者战斗结束时间
     */
	private long battleEndTime;
    
    /**
     * 最先击败者战报
     */
    private String firstKiller;
    
    /**
     * 最优击败者战报
     */
    private String bestKiller;
    
    /**
     * 最优击败者角色ID
     */
    private long bCharId;
    
    /**
     * 最优击败者角色等级
     */
    private int bLevel;
    
    /**
     * 最优击败者回合数
     */
    private int bRound;
    
    /**
     * 最优击败者战斗持续时间
     */
	private long battleDuration;
    
    public Tower() {
        super();
        lifeCycle = new LifeCycleImpl(this);
	}
    
	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}



	@Override
	public void setDbId(String id) {
		this.setId(id);
	}

	@Override
	public String getDbId() {
		return getId();
	}


	@Override
	public String getGUID() {
		 return "tower#" + this.id;
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
		return 0;
	}
	
	
	public int getTowerLevel() {
		return towerLevel;
	}

	public void setTowerLevel(int towerLevel) {
		this.towerLevel = towerLevel;
	}
	
	public long getfCharId() {
		return fCharId;
	}

	public void setfCharId(long fCharId) {
		this.fCharId = fCharId;
	}

	public int getfLevel() {
		return fLevel;
	}

	public void setfLevel(int fLevel) {
		this.fLevel = fLevel;
	}

	public int getfRound() {
		return fRound;
	}

	public void setfRound(int fRound) {
		this.fRound = fRound;
	}

	public long getBattleEndTime() {
		return battleEndTime;
	}

	public void setBattleEndTime(long battleEndTime) {
		this.battleEndTime = battleEndTime;
	}

	
	
	public String getFirstKiller() {
		return firstKiller;
	}

	public void setFirstKiller(String firstKiller) {
		this.firstKiller = firstKiller;
	}
	
	public long getbCharId() {
		return bCharId;
	}

	public void setbCharId(long bCharId) {
		this.bCharId = bCharId;
	}

	public int getbLevel() {
		return bLevel;
	}

	public void setbLevel(int bLevel) {
		this.bLevel = bLevel;
	}

	public int getbRound() {
		return bRound;
	}

	public void setbRound(int bRound) {
		this.bRound = bRound;
	}

	public long getBattleDuration() {
		return battleDuration;
	}
	
	public void setBattleDuration(long battleDuration) {
		this.battleDuration = battleDuration;
	}
	
	public String getBestKiller() {
		return bestKiller;
	}

	public void setBestKiller(String bestKiller) {
		this.bestKiller = bestKiller;
	}
	
	@Override
	public TowerEntity toEntity() {
		TowerEntity entity = new TowerEntity();
		entity.setId(this.id);
		entity.setTowerLevel(getTowerLevel());
		//最先
		entity.setfCharId(this.fCharId);
		entity.setfRound(this.fRound);
		entity.setfLevel(this.fLevel);
		entity.setBattleEndTime(this.battleEndTime);
		entity.setFirstKiller(this.firstKiller);
		//最优
		entity.setbCharId(this.bCharId);
		entity.setbRound(this.bRound);
		entity.setbLevel(this.bLevel);
		entity.setBattleDuration(this.battleDuration);
		entity.setBestKiller(this.bestKiller);
		return entity;
	}

	@Override
	public void fromEntity(TowerEntity entity) {
		this.id = entity.getId();
		this.towerLevel = entity.getTowerLevel();
		//最先
		this.fCharId = entity.getfCharId();
		this.fRound = entity.getfRound();
		this.fLevel = entity.getfLevel();
		this.battleEndTime = entity.getBattleEndTime();
		this.firstKiller = entity.getFirstKiller();
		//最优
		this.bCharId = entity.getbCharId();
		this.bRound = entity.getbRound();
		this.bLevel = entity.getbLevel();
		this.battleDuration = entity.getBattleDuration();
		this.bestKiller = entity.getBestKiller();
		
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
