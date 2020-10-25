/**
 *
 */
package com.imop.lj.gm.dto;


/**
 *
 * 技能显示VO
 *
 * @author linfan
 *
 */
public class SkillVO {


	/** 技能ID */
	private String skillId;

	/** 技能名称 */
	private String skillName;

	/** 技能等级 */
	private int skillLevel;

	public int getSkillLevel() {
		return skillLevel;
	}

	public void setSkillLevel(int skillLevel) {
		this.skillLevel = skillLevel;
	}

	public String getSkillId() {
		return skillId;
	}

	public void setSkillId(String skillId) {
		this.skillId = skillId;
	}

	public String getSkillName() {
		return skillName;
	}

	public void setSkillName(String skillName) {
		this.skillName = skillName;
	}

}
