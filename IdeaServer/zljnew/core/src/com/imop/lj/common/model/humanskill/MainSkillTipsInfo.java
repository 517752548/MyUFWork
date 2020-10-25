package com.imop.lj.common.model.humanskill;

public class MainSkillTipsInfo {

	/** 心法Id*/
	private int mindId;
	/** 升级技能Id*/
	private int skillId;
	public int getMindId() {
		return mindId;
	}
	public void setMindId(int mindId) {
		this.mindId = mindId;
	}
	public int getSkillId() {
		return skillId;
	}
	public void setSkillId(int skillId) {
		this.skillId = skillId;
	}
	@Override
	public String toString() {
		return "MainSkillTipsInfo [mindId=" + mindId + ", skillId=" + skillId + "]";
	}

	
}
