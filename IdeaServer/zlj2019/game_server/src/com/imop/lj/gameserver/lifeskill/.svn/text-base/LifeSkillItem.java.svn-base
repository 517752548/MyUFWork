package com.imop.lj.gameserver.lifeskill;

import com.imop.lj.core.util.JsonUtils;

import net.sf.json.JSONObject;

public class LifeSkillItem {
	public static final String SKILL_ID = "skillId";
	public static final String LEVEL = "level";
	public static final String LAYER = "layer";
	public static final String PROFICIENCY = "proficiency";
	
	private int skillId;
	private int level;
	private int layer;
	private long proficiency;
	
	public LifeSkillItem(int skillId, int level, int layer, long proficiency) {
		this.skillId = skillId;
		this.level = level;
		this.layer = layer;
		this.proficiency = proficiency;
	}
	
	public static LifeSkillItem fromJson(String str) {
		JSONObject obj = JSONObject.fromObject(str);
		int id = JsonUtils.getInt(obj, SKILL_ID);
		int level = JsonUtils.getInt(obj, LEVEL);
		int layer = JsonUtils.getInt(obj, LAYER);
		int proficiency = JsonUtils.getInt(obj, PROFICIENCY);

		return new LifeSkillItem(id, level, layer, proficiency);
	}

	public String toJson() {
		JSONObject obj = new JSONObject();
		obj.put(SKILL_ID, this.skillId);
		obj.put(LEVEL, this.level);
		obj.put(LAYER, this.layer);
		obj.put(PROFICIENCY, this.proficiency);
		return obj.toString();
	}

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
	
	
	
}
