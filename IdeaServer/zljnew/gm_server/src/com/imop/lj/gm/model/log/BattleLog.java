package com.imop.lj.gm.model.log;

import java.util.List;

import com.imop.lj.gm.utils.DateUtil;

public class BattleLog extends BaseLog {
    private int mapId;
    private String mapName;
    private long battleTime;
    private int battleResult;
    private int attackLoss;
    private int defenceLoss;

	public int getMapId() {
		return mapId;
	}



	public void setMapId(int mapId) {
		this.mapId = mapId;
	}



	public long getBattleTime() {
		return battleTime;
	}



	public void setBattleTime(long battleTime) {
		this.battleTime = battleTime;
	}



	public int getBattleResult() {
		return battleResult;
	}



	public void setBattleResult(int battleResult) {
		this.battleResult = battleResult;
	}




	public String getMapName() {
		return mapName;
	}



	public void setMapName(String mapName) {
		this.mapName = mapName;
	}



	public int getAttackLoss() {
		return attackLoss;
	}



	public void setAttackLoss(int attackLoss) {
		this.attackLoss = attackLoss;
	}



	public int getDefenceLoss() {
		return defenceLoss;
	}



	public void setDefenceLoss(int defenceLoss) {
		this.defenceLoss = defenceLoss;
	}



	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(mapId);
		list.add(mapName);
		list.add(DateUtil.formateDateLong(battleTime));
		list.add(battleResult);
		list.add(attackLoss);
		list.add(defenceLoss);
		return list;
	}
}

