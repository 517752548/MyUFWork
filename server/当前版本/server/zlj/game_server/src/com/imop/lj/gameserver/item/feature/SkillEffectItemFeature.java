package com.imop.lj.gameserver.item.feature;

import net.sf.json.JSONObject;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.RoleConstants;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.item.Item;

/**
 * 仙符道具feature
 * 
 */
public class SkillEffectItemFeature extends AbstractFeature {
	private static String LevelKey = "lv";
	private static String ExpKey = "exp";
	
	/** 等级，默认为1级 */
	private int level = RoleConstants.HUMAN_INIT_LEVEL_NUM;
	/** 经验 */
	private int exp;
	
	public SkillEffectItemFeature(Item item) {
		super(item);
	}
	
	@Override
	public void fromPros(String props) {
		if (props == null || props.isEmpty()) {
			Loggers.itemLogger.error("SkillEffectItemFeature fromProps , props = " + props + "humanid = " + this.item.getOwner().getUUID());
			return;
		}
		JSONObject obj = JSONObject.fromObject(props);
		if (obj == null || obj.isEmpty()) {
			Loggers.itemLogger.error("SkillEffectItemFeature fromProps , JsonObject,  props = " + props + "humanid = " + this.item.getOwner().getUUID());
			return;
		}
		
		int level = JsonUtils.getInt(obj, LevelKey);
		int exp = JsonUtils.getInt(obj, ExpKey);
		if (level <= 0) {
			Loggers.itemLogger.error("ERROR!SkillEffectItemFeature level is invalid!props=" + props + "humanid = " + this.item.getOwner().getUUID());
			return;
		}
		//设置等级 经验
		setLevel(level);
		setExp(exp);
	}
	
	@Override
	public String toProps(boolean isShow) {
		JSONObject obj = new JSONObject();
		obj.put(LevelKey, getLevel());
		obj.put(ExpKey, getExp());
		return obj.toString();
	}

	public int getLevel() {
		return level;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	public int getExp() {
		return exp;
	}

	public void setExp(int exp) {
		this.exp = exp;
	}
	
}
