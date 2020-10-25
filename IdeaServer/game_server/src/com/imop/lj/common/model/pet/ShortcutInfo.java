package com.imop.lj.common.model.pet;

public class ShortcutInfo {
	/** 快捷栏索引, 默认为-1*/
	private int shortcutIndex;
	/** 技能Id*/
	private int skillId;
	public int getShortcutIndex() {
		return shortcutIndex;
	}
	public void setShortcutIndex(int shortcutIndex) {
		this.shortcutIndex = shortcutIndex;
	}
	public int getSkillId() {
		return skillId;
	}
	public void setSkillId(int skillId) {
		this.skillId = skillId;
	}
	@Override
	public String toString() {
		return "ShortcutInfo [shortcutIndex=" + shortcutIndex + ", skillId=" + skillId + "]";
	}
	
	
}
