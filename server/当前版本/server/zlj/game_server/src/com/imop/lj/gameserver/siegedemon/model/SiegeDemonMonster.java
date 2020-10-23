package com.imop.lj.gameserver.siegedemon.model;

import com.imop.lj.gameserver.siegedemon.SiegeDemonDef.SDMonsterType;

public class SiegeDemonMonster {
	private String uuid;
	
	private SDMonsterType type;
	
	private int npcId;
	
	public SiegeDemonMonster() {
		
	}
	
	public boolean isMJXF() {
		return type == SDMonsterType.MJXF;
	}
	public boolean isMJTL() {
		return type == SDMonsterType.MJTL;
	}
	public boolean isMJDJ() {
		return type == SDMonsterType.MJDJ;
	}
	public boolean isMJKZS() {
		return type == SDMonsterType.MJKZS;
	}
	public boolean isMJMN() {
		return type == SDMonsterType.MJMN;
	}
	public boolean isMJSW() {
		return type == SDMonsterType.MJSW;
	}

	public String getUuid() {
		return uuid;
	}

	public void setUuid(String uuid) {
		this.uuid = uuid;
	}

	public SDMonsterType getType() {
		return type;
	}

	public void setType(SDMonsterType type) {
		this.type = type;
	}

	public int getNpcId() {
		return npcId;
	}

	public void setNpcId(int npcId) {
		this.npcId = npcId;
	}

	@Override
	public String toString() {
		return "SiegeDemonMonster [uuid=" + uuid + ", type=" + type + ", npcId=" + npcId + "]";
	}
}
