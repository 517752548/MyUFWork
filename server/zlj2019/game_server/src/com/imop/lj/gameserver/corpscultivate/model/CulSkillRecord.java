package com.imop.lj.gameserver.corpscultivate.model;

import net.sf.json.JSONArray;

public class CulSkillRecord {
	/** 技能等级*/
	private int level;
	/** 技能经验*/
	private long exp;
	
	public CulSkillRecord() {
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
		return "CulSkillRecord [level=" + level + ", exp=" + exp + "]";
	}
	
	public String toJson() {
		JSONArray jsonArr = new JSONArray();
		jsonArr.add(getLevel());
		jsonArr.add(getExp());
		return jsonArr.toString();
	}
	
	public void loadJson(String json) {
		if (null == json || json.equalsIgnoreCase("")) {
			return;
		}
		
		JSONArray jsonArr = JSONArray.fromObject(json);
		if (null == jsonArr || jsonArr.isEmpty()) {
			return;
		}
		
		setLevel(jsonArr.getInt(0));
		setExp(jsonArr.getLong(1));
	}
}
