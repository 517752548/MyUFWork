package com.imop.lj.gameserver.pet;

import com.imop.lj.core.util.JsonUtils;

import net.sf.json.JSONObject;

public class PetSkillShortcutInfo {
	public static final String INDEX_KEY = "1";
	public static final String SKILL_ID_KEY = "2";
	
	/** 技能快捷栏索引*/
	private int index;
	
	/** 技能Id*/
	private int skillId;
	
	public PetSkillShortcutInfo() {
	}

	public PetSkillShortcutInfo(int index, int skillId) {
		this.index = index;
		this.skillId = skillId;
	}

	public int getIndex() {
		return index;
	}

	public void setIndex(int index) {
		this.index = index;
	}

	public int getSkillId() {
		return skillId;
	}


	public void setSkillId(int skillId) {
		this.skillId = skillId;
	}

	public String toJson() {
		JSONObject json = new JSONObject();
		json.put(INDEX_KEY, getIndex());
		json.put(SKILL_ID_KEY, getSkillId());
		return json.toString();
	}
	
	public static PetSkillShortcutInfo fromJson(String jsonStr) {
		if(jsonStr == null || jsonStr.isEmpty()){
			return null;
		}
		
		JSONObject json = JSONObject.fromObject(jsonStr);
		if(json == null || json.isEmpty() || json.isNullObject()){
			return null;
		}
		
		PetSkillShortcutInfo data = new PetSkillShortcutInfo();
		data.setIndex(JsonUtils.getInt(json, INDEX_KEY));
		data.setSkillId(JsonUtils.getInt(json, SKILL_ID_KEY));
		return data;
	}

	@Override
	public String toString() {
		return "PetSkillShortcutInfo [index=" + index + ", skillId=" + skillId + "]";
	}
	
}
