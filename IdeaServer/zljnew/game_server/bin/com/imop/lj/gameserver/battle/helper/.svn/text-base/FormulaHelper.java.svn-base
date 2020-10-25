package com.imop.lj.gameserver.battle.helper;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.gameserver.battle.core.FightUnit;

/**
 * 计算公式判断
 * @author yuanbo.gao
 *
 */
public abstract class FormulaHelper {
	
	public static Map<String, Object> toOwnerTargetLevel(FightUnit owner, FightUnit target, int level, double factor, int added) {
		Map<String, Object> result = new HashMap<String, Object>(5);
		result.put("owner", owner);
		result.put("target", target);
		result.put("level", Integer.valueOf(level));
		result.put("factor", Double.valueOf(factor));
		result.put("added", Integer.valueOf(added));
		return result;
	}

	public static Map<String, Object> toOwnerTarget(FightUnit owner, FightUnit target) {
		Map<String, Object> result = new HashMap<String, Object>(2);
		result.put("owner", owner);
		result.put("target", target);
		return result;
	}

	public static Map<String, Object> toOwnerDamage(FightUnit owner, Integer damage) {
		Map<String, Object> result = new HashMap<String, Object>(2);
		result.put("owner", owner);
		result.put("damage", damage);
		return result;
	}

	public static Map<String, Object> toSkillSuccess(FightUnit owner, FightUnit target, double base, int level) {
		Map<String, Object> result = new HashMap<String, Object>(4);
		result.put("owner", owner);
		result.put("target", target);
		result.put("base", Double.valueOf(base));
		result.put("level", Integer.valueOf(level));
		return result;
	}
}