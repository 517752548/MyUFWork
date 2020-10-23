package com.imop.lj.gm.model.log;

import java.util.List;

public class BasicPlayerLog extends BaseLog {
	/** 角色IP地址 */
    private String ip;
    /** 角色官职ID */
    private int rankId;
    /** 角色官职名称 */
    private String rankName;
    /** 角色所在场景ID */
    private int sceneId;
    /** 角色所在场景名称 */
    private String sceneName;
    /** 角色当前打到的最远关卡ID */
    private int missionId;
    /** 角色当前打到的最远关卡名称 */
    private String missionName;



	public int getRankId() {
		return rankId;
	}


	public void setRankId(int rankId) {
		this.rankId = rankId;
	}


	public String getRankName() {
		return rankName;
	}


	public void setRankName(String rankName) {
		this.rankName = rankName;
	}


	public int getSceneId() {
		return sceneId;
	}


	public void setSceneId(int sceneId) {
		this.sceneId = sceneId;
	}


	public String getSceneName() {
		return sceneName;
	}


	public void setSceneName(String sceneName) {
		this.sceneName = sceneName;
	}


	public int getMissionId() {
		return missionId;
	}


	public void setMissionId(int missionId) {
		this.missionId = missionId;
	}


	public String getMissionName() {
		return missionName;
	}


	public void setMissionName(String missionName) {
		this.missionName = missionName;
	}


	public String getIp() {
		return ip;
	}


	public void setIp(String ip) {
		this.ip = ip;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(ip);
	    list.add(rankId);
	    list.add(rankName);
	    list.add(sceneId);
	    list.add(sceneName);
	    list.add(missionId);
	    list.add(missionName);
		return list;
	}
}