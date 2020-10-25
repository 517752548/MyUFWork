package com.imop.lj.gameserver.pet;

import net.sf.json.JSONObject;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.item.ItemDef.ItemType;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.item.template.SkillEffectItemTemplate;

public class PetSkillEffectInfo {
	private static int ITEMID_KEY = 1;
	private static int LEVEL_KEY = 2;
	private static int EXP_KEY = 3;
	
	/** 技能效果所属的技能id */
	private int skillId;
	
	/** 技能效果的仙符道具模板Id，为0表示是一个空的格子，没有镶嵌仙符 */
	private int effectItemTplId;
	/** 技能效果的等级 */
	private int effectLevel;
	/** 技能效果的经验 */
	private int effectExp;
	
	public PetSkillEffectInfo() {
		
	}

	public PetSkillEffectInfo(int skillId, int effectItemTplId, int effectLevel, int effectExp) {
		this.skillId = skillId;
		this.effectItemTplId = effectItemTplId;
		this.effectLevel = effectLevel;
		this.effectExp = effectExp;
	}
	
	/**
	 * 是否空格子
	 * @return
	 */
	public boolean isEmptyPos() {
		return effectItemTplId == 0;
	}
	
	/**
	 * 获取技能效果Id
	 * @return
	 */
	public int getEffectId() {
		if (getEffectItemTplId() > 0) {
			ItemTemplate itemTpl = Globals.getTemplateCacheService().get(getEffectItemTplId(), ItemTemplate.class);
			if (itemTpl != null && (itemTpl instanceof SkillEffectItemTemplate)) {
				SkillEffectItemTemplate tpl = (SkillEffectItemTemplate) itemTpl;
				return tpl.getSkillEffectId();
			}
		}
		return 0;
	}
	
	public int getLevelMax() {
		if (getEffectItemTemplate() != null) {
			return getEffectItemTemplate().getLevelMax();
		}
		return 0;
	}
	
	public boolean isLevelMax() {
		if (getEffectItemTemplate() != null) {
			return getEffectLevel() >= getEffectItemTemplate().getLevelMax();
		}
		return true;
	}
	
	public SkillEffectItemTemplate getEffectItemTemplate() {
		if (getEffectItemTplId() > 0) {
			ItemTemplate tpl = Globals.getTemplateCacheService().get(getEffectItemTplId(), ItemTemplate.class);
			if (tpl.isSkillEffectItem()) {
				return (SkillEffectItemTemplate) tpl;
			}
		}
		return null;
	}
	
	public String getJsonStr() {
		JSONObject json = new JSONObject();
		json.put(ITEMID_KEY, getEffectItemTplId());
		json.put(LEVEL_KEY, getEffectLevel());
		json.put(EXP_KEY, getEffectExp());
		
		return json.toString();
	}
	
	public static PetSkillEffectInfo fromJsonStr(String jsonStr) {
		if (jsonStr == null || jsonStr.isEmpty()) {
			return null;
		}
		JSONObject json = JSONObject.fromObject(jsonStr);
		int itemId = JsonUtils.getInt(json, ITEMID_KEY);
		if (itemId > 0) {
			ItemTemplate itemTpl = Globals.getTemplateCacheService().get(itemId, ItemTemplate.class);
			if (itemTpl == null) {
				Loggers.petLogger.error("invalid pet skill effect item id1!" + jsonStr);
				return null;
			}
			if (itemTpl.getItemType() != ItemType.SKILL_EFFECT_ITEM) {
				Loggers.petLogger.error("invalid pet skill effect item id2!" + jsonStr);
				return null;
			}
		} else {
			//表示空格子
			return new PetSkillEffectInfo();
		}
		
		PetSkillEffectInfo info = new PetSkillEffectInfo();
		info.setEffectItemTplId(JsonUtils.getInt(json, ITEMID_KEY));
		info.setEffectLevel(JsonUtils.getInt(json, LEVEL_KEY));
		info.setEffectExp(JsonUtils.getInt(json, EXP_KEY));
		
		return info;
	}
	
	public int getSkillId() {
		return skillId;
	}

	public void setSkillId(int skillId) {
		this.skillId = skillId;
	}

	public int getEffectItemTplId() {
		return effectItemTplId;
	}

	public void setEffectItemTplId(int effectItemTplId) {
		this.effectItemTplId = effectItemTplId;
	}

	public int getEffectLevel() {
		return effectLevel;
	}

	public void setEffectLevel(int effectLevel) {
		this.effectLevel = effectLevel;
	}

	public int getEffectExp() {
		return effectExp;
	}

	public void setEffectExp(int effectExp) {
		this.effectExp = effectExp;
	}

	@Override
	public String toString() {
		return "PetSkillEffectInfo [skillId=" + skillId + ", effectItemTplId="
				+ effectItemTplId + ", effectLevel=" + effectLevel
				+ ", effectExp=" + effectExp + "]";
	}
	
}
