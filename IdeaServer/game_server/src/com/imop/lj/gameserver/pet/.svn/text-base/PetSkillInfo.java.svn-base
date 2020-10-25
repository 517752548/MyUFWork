package com.imop.lj.gameserver.pet;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.skill.template.SkillTemplate;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

public class PetSkillInfo {
	private static int ID_KEY = 1;
	private static int LEVEL_KEY = 2;
	private static int LAST_UPDATE_TIME_KEY = 3;
	private static int IS_TALENT_KEY = 4;
	private static int EMBED_EFFECT_KEY = 5;
	private static int LAYER_KEY = 6;
	private static int PROFICIENCY_KEY = 7;
	
	private int skillId;
	private int level;
	private long lastUpdateTime;
	/** 是否天赋技能 */
	private boolean isTalent;
	/** 层数*/
	private int layer;
	/** 熟练度*/
	private long proficiency;
	
	/** 技能镶嵌的效果列表，列表长度是开启的格子数量，空格子也会存储 */
	private List<PetSkillEffectInfo> embedEffectList = new ArrayList<PetSkillEffectInfo>();
	
	public PetSkillInfo(int skillId, int level, long lastUpdateTime, boolean isTalent) {
		this.skillId = skillId;
		this.level = level;
		this.lastUpdateTime = lastUpdateTime;
		this.isTalent = isTalent;
	}
	
	public PetSkillInfo(int skillId, int level, long lastUpdateTime) {
		this.skillId = skillId;
		this.level = level;
		this.lastUpdateTime = lastUpdateTime;
	}
	
	public PetSkillInfo(int skillId, int level, long lastUpdateTime, int layer, int proficiency) {
		this.skillId = skillId;
		this.level = level;
		this.lastUpdateTime = lastUpdateTime;
		this.layer = layer;
		this.proficiency = proficiency;
	}
	
	private PetSkillInfo() {
		
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

	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}
	
	public boolean isTalent() {
		return isTalent;
	}

	public void setTalent(boolean isTalent) {
		this.isTalent = isTalent;
	}
	
	public List<PetSkillEffectInfo> getEmbedEffectList() {
		return embedEffectList;
	}
	
	public void addEffect(PetSkillEffectInfo effectInfo) {
		this.embedEffectList.add(effectInfo);
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

	public SkillTemplate getSkillTemplate() {
		return Globals.getTemplateCacheService().get(this.skillId, SkillTemplate.class);
	}
	
	public PetSkillEffectInfo getEmbedEffectByIndex(int index) {
		if (index >= 0 && index < this.embedEffectList.size()) {
			return this.embedEffectList.get(index);
		}
		return null;
	}
	
	public int getPosNum() {
		return this.embedEffectList.size();
	}
	
	public String getJsonStr() {
		JSONObject json = new JSONObject();
		json.put(ID_KEY, getSkillId());
		json.put(LEVEL_KEY, getLevel());
		json.put(LAST_UPDATE_TIME_KEY, getLastUpdateTime());
		json.put(IS_TALENT_KEY, isTalent());
		
		//镶嵌的仙符处理
		JSONArray arr = new JSONArray();
		for (PetSkillEffectInfo effectInfo : getEmbedEffectList()) {
			arr.add(effectInfo.getJsonStr());
		}
		json.put(EMBED_EFFECT_KEY, arr);
		
		json.put(LAYER_KEY, getLayer());
		json.put(PROFICIENCY_KEY, getProficiency());
		
		return json.toString();
	}
	
	public static PetSkillInfo fromJsonStr(String jsonStr) {
		if (jsonStr == null || jsonStr.isEmpty()) {
			return null;
		}
		JSONObject json = JSONObject.fromObject(jsonStr);
		int skillId = JsonUtils.getInt(json, ID_KEY);
		if (Globals.getTemplateCacheService().get(skillId, SkillTemplate.class) == null) {
			Loggers.petLogger.error("invalid pet skill id!" + jsonStr);
			return null;
		}
		
		PetSkillInfo info = new PetSkillInfo();
		info.setSkillId(skillId);
		info.setLevel(JsonUtils.getInt(json, LEVEL_KEY));
		info.setLastUpdateTime(JsonUtils.getLong(json, LAST_UPDATE_TIME_KEY));
		info.setTalent(JsonUtils.getBoolean(json, IS_TALENT_KEY));
		
		//镶嵌的仙符处理
		JSONArray arr = JsonUtils.getJSONArray(json, EMBED_EFFECT_KEY);
		if (arr != null && !arr.isEmpty()) {
			for (int i = 0; i < arr.size(); i++) {
				PetSkillEffectInfo effectInfo = PetSkillEffectInfo.fromJsonStr(arr.getString(i));
				if (effectInfo != null) {
					effectInfo.setSkillId(skillId);
					info.addEffect(effectInfo);
				}
			}
		}
		
		info.setLayer(JsonUtils.getInt(json, LAYER_KEY));
		info.setProficiency(JsonUtils.getInt(json, PROFICIENCY_KEY));
		
		return info;
	}

	@Override
	public String toString() {
		return "PetSkillInfo [skillId=" + skillId + ", level=" + level + ", lastUpdateTime=" + lastUpdateTime
				+ ", isTalent=" + isTalent + ", layer=" + layer + ", proficiency=" + proficiency + ", embedEffectList="
				+ embedEffectList + "]";
	}

}
