package com.imop.lj.gm.model.log;

import java.util.List;

public class MissionLog extends BaseLog {
//	mission_type
//	stage_id
//	enemy_id
//	state
	private int mission_type;
	private int stage_id;
	private int enemy_id;
	private int state;
	public int getMission_type() {
		return mission_type;
	}
	public void setMission_type(int mission_type) {
		this.mission_type = mission_type;
	}
	public int getStage_id() {
		return stage_id;
	}
	public void setStage_id(int stage_id) {
		this.stage_id = stage_id;
	}
	public int getEnemy_id() {
		return enemy_id;
	}
	public void setEnemy_id(int enemy_id) {
		this.enemy_id = enemy_id;
	}
	public int getState() {
		return state;
	}
	public void setState(int state) {
		this.state = state;
	}
	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(this.mission_type);
		list.add(this.stage_id);
		list.add(this.enemy_id);
		list.add(this.state);
		return list;
	}
}
