package com.imop.lj.gameserver.enemy;

/** 打怪物时用到的参数，封装成一个类*/
public class EnemyParamContent {
	//怪物组模板ID
	private Integer enemyArmyId = 0;
	//玩家数量(主将和伙伴)
	private Integer humanNum = 0;
	
	/** 等级，怪物可能根据玩家等级不同而有不同的等级 */
	private int level;
	
	/** 地图*/
	private int mapId;
	
	/** 是否是帮派boss怪物,1-是,0-否*/
	private boolean isCorpsBoss;
	
	/** 玩家是否挂机*/
	private boolean guaji;
	
	public EnemyParamContent(Integer enemyArmyId, Integer humanNum, int level, int mapId, boolean isCorpsBoss, boolean guaji){
		super();
		this.enemyArmyId = enemyArmyId;
		this.humanNum = humanNum;
		this.level = level;
		this.mapId = mapId;
		this.isCorpsBoss = isCorpsBoss;
		this.guaji = guaji;
	}
	public Integer getEnemyArmyId() {
		return enemyArmyId;
	}
	public void setEnemyArmyId(Integer enemyArmyId) {
		this.enemyArmyId = enemyArmyId;
	}
	public Integer getHumanNum() {
		return humanNum;
	}
	public void setHumanNum(Integer humanNum) {
		this.humanNum = humanNum;
	}
	public int getLevel() {
		return level;
	}
	public void setLevel(int level) {
		this.level = level;
	}
	public int getMapId() {
		return mapId;
	}
	public void setMapId(int mapId) {
		this.mapId = mapId;
	}
	public boolean isCorpsBoss() {
		return isCorpsBoss;
	}
	public void setCorpsBoss(boolean isCorpsBoss) {
		this.isCorpsBoss = isCorpsBoss;
	}
	public boolean isGuaji() {
		return guaji;
	}
	public void setGuaji(boolean guaji) {
		this.guaji = guaji;
	}
	
}
