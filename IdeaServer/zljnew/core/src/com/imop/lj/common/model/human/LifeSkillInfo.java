package com.imop.lj.common.model.human;

public class LifeSkillInfo {

	private int skillId;
	private int level;
	private int layer;
	private long proficiency;
	public int getSkillId() {
		return skillId;
	}
	public void setSkillId(int skillId) {
		this.skillId = skillId;
	}
	public int getLevel() {
		return level;
	}
	public void setLevel(int level) {
		this.level = level;
	}
	public int getLayer() {
		return layer;
	}
	public void setLayer(int layer) {
		this.layer = layer;
	}
	public long getProficiency() {
		return proficiency;
	}
	public void setProficiency(long proficiency) {
		this.proficiency = proficiency;
	}
	@Override
	public String toString() {
		return "LifeSkillInfo [skillId=" + skillId + ", level=" + level + ", layer=" + layer + ", proficiency="
				+ proficiency + "]";
	}
	
	
}
