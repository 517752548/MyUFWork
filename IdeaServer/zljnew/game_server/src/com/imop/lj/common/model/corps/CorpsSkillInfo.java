package com.imop.lj.common.model.corps;

/**
 * 帮派的修炼技能和辅助技能公用
 * @author Administrator
 *
 */
public class CorpsSkillInfo {

	private int skillId;
	private int level;
	private long exp;
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
	public long getExp() {
		return exp;
	}
	public void setExp(long exp) {
		this.exp = exp;
	}
	@Override
	public String toString() {
		return "CorpsSkillInfo [skillId=" + skillId + ", level=" + level + ", exp=" + exp + "]";
	}
	
}
