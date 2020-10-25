package com.imop.lj.common.model;

public class NpcInfo {
	/** 唯一Id */
	private String uuid = "";
	/** npcId */
	private int npcId;
	/** 地图ID */
	private int mapId;
	/** npc位置坐标x */
	private int x;
	/** npc位置坐标y */
	private int y;
	/** 是否处于战斗中 */
	private int battleId;
	/** 活动战斗类型*/
	private int activityType;
	/** 动态生成npc的时间*/
	private long createTime;

	public NpcInfo() {

	}

	public String getUuid() {
		return uuid;
	}

	public void setUuid(String uuid) {
		this.uuid = uuid;
	}

	public int getNpcId() {
		return npcId;
	}

	public void setNpcId(int npcId) {
		this.npcId = npcId;
	}

	public int getMapId() {
		return mapId;
	}

	public void setMapId(int mapId) {
		this.mapId = mapId;
	}

	public int getX() {
		return x;
	}

	public void setX(int x) {
		this.x = x;
	}

	public int getY() {
		return y;
	}

	public void setY(int y) {
		this.y = y;
	}

	public int getIsInBattle() {
		return battleId > 0 ? 1 : 0;
	}

	public void setIsInBattle(int battleId) {
		this.battleId = battleId;
	}
	
	public int getBattleId() {
		return battleId;
	}
	
	public void setBattleId(int battleId) {
		this.battleId = battleId;
	}
	
	public boolean isInBattle() {
		return this.battleId > 0;
	}
	
	public int getActivityType() {
		return activityType;
	}

	public void setActivityType(int activityType) {
		this.activityType = activityType;
	}

	public long getCreateTime() {
		return createTime;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}

	@Override
	public String toString() {
		return "NpcInfo [uuid=" + uuid + ", npcId=" + npcId + ", mapId=" + mapId + ", x=" + x + ", y=" + y
				+ ", battleId=" + battleId + ", activityType=" + activityType + ", createTime=" + createTime + "]";
	}

}
