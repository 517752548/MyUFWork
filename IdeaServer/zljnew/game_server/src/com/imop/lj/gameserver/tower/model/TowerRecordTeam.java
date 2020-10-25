package com.imop.lj.gameserver.tower.model;

/**
 * 通天塔做成了组队状态下挂机,这样服务器只处理组队PVE的状态即可
 * 单人的话也必须是组队状态,对人物没有要求
 */
public class TowerRecordTeam {

	private int teamId;
	
	public int getTeamId() {
		return teamId;
	}

	public void setTeamId(int teamId) {
		this.teamId = teamId;
	}
	
	
}
