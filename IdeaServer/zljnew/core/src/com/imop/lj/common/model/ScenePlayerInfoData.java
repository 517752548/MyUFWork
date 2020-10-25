package com.imop.lj.common.model;


public class ScenePlayerInfoData {
	
	/** 角色id */
	private long uuid;
	/** json串信息 */
	private String playerDataJson;
	
	public ScenePlayerInfoData() {
		
	}
	
	public ScenePlayerInfoData(long uuid, String playerDataJson) {
		this.uuid = uuid;
		this.playerDataJson = playerDataJson;
	}

	public long getUuid() {
		return uuid;
	}

	public void setUuid(long uuid) {
		this.uuid = uuid;
	}

	public String getPlayerDataJson() {
		return playerDataJson;
	}

	public void setPlayerDataJson(String playerDataJson) {
		this.playerDataJson = playerDataJson;
	}

}
