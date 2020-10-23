package com.imop.lj.gameserver.battle.helper;

import java.util.ArrayList;
import java.util.List;

import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectValueType;
import com.imop.lj.gameserver.battle.core.BattleDef.ValueType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.impl.buff.BaseBuffEffect;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.PetDef.PetAttackType;

/**
 * 技能效果helper类
 * 
 * @author yuanbo.gao
 * 
 */
public class EffectHelper {

	public static final Logger logger = Loggers.battleLogger;
	
	/**
	 * 调整buff
	 * 
	 * @param target
	 * @param alter
	 * @param value
	 * @return
	 */
	public static List<ReportItem> alterValue(FightUnit target, BaseBuffEffect buffEffect, int add, ReportItem result, boolean updateValueFlag) {
		List<ReportItem> ret = new ArrayList<ReportItem>();
		EffectValueType evType = buffEffect.getEffectTpl().getEffectValueType();
		ValueType vT = buffEffect.getEffectTpl().getValueType();
		if (evType == null) {
			Loggers.battleLogger.error("evType is null!effectTplId=" + buffEffect.getEffectTpl().getId());
		}
		
		boolean needCalc = false;
		int addValue = 0;
		Double realValue = 0D;
		switch (evType) {
		case HP:
			addValue = needCalc ? calcAddValue(target.getAttr(BattleDef.HP), add, vT) : add;
			if (addValue < 0) {
				if (Loggers.battleLogger.isDebugEnabled()) {
					Loggers.battleLogger.debug("buff产生的减血效果，buffId=" + buffEffect.getEffectTpl().getBuffTypeId());
				}
				double tmpHp = target.getAttr(BattleDef.HP);
				ret.addAll(BattleCalculateHelper.onReduceHp(null, buffEffect.getOwner(), target, addValue, result, null, null));
				realValue = target.getAttr(BattleDef.HP) - tmpHp;
			} else {
				realValue = target.updateAttr(BattleDef.HP, addValue);
				result.updateAttr(BattleReportDefine.REPORT_ITEM_HP, addValue);
			}
			break;
		case MP:
			addValue = needCalc ? calcAddValue(target.getAttr(BattleDef.MP), add, vT) : add;
			realValue = target.updateAttr(BattleDef.MP, addValue);
			result.updateAttr(BattleReportDefine.REPORT_ITEM_MP, realValue);
			break;
		case SP:
			addValue = needCalc ? calcAddValue(target.getAttr(BattleDef.SP), add, vT) : add;
			realValue = target.updateAttr(BattleDef.SP, addValue);
			result.updateAttr(BattleReportDefine.REPORT_ITEM_SP, realValue);
			break;
		case SPEED:
			addValue = needCalc ? calcAddValue(target.getAttr(BattleDef.SPEED), add, vT) : add;
			realValue = target.updateAttr(BattleDef.SPEED, addValue);
			result.updateAttr(BattleReportDefine.REPORT_ITEM_SPEED, realValue);
			break;
		case ATTACK:
			if (target.getAttackType() == PetAttackType.STRENGTH) {
				addValue = needCalc ? calcAddValue(Double.valueOf(target.getAttr(BattleDef.PHYSICAL_ATTACK)), add, vT) : add;
				realValue = target.updateAttr(BattleDef.PHYSICAL_ATTACK, addValue);
				result.updateAttr(BattleReportDefine.REPORT_ITEM_PHYSICAL_ATTACK, realValue);
			} else {
				addValue = needCalc ? calcAddValue(Double.valueOf(target.getAttr(BattleDef.MAGIC_ATTACK)), add, vT) : add;
				realValue = target.updateAttr(BattleDef.MAGIC_ATTACK, addValue);
				result.updateAttr(BattleReportDefine.REPORT_ITEM_MAGIC_ATTACK, realValue);
			}
			break;
		case DEFEND:
			if (target.getAttackType() == PetAttackType.STRENGTH) {
				addValue = needCalc ? calcAddValue(Double.valueOf(target.getAttr(BattleDef.PHYSICAL_ARMOR)), add, vT) : add;
				realValue = target.updateAttr(BattleDef.PHYSICAL_ARMOR, addValue);
				result.updateAttr(BattleReportDefine.REPORT_ITEM_PHYSICAL_ARMOR, realValue);
			} else {
				addValue = needCalc ? calcAddValue(Double.valueOf(target.getAttr(BattleDef.MAGIC_ARMOR)), add, vT) : add;
				realValue = target.updateAttr(BattleDef.MAGIC_ARMOR, addValue);
				result.updateAttr(BattleReportDefine.REPORT_ITEM_MAGIC_ARMOR, realValue);
			}
			break;
		case ALL_DEFENCE:
			//物理防御
			addValue = needCalc ? calcAddValue(Double.valueOf(target.getAttr(BattleDef.PHYSICAL_ARMOR)), add, vT) : add;
			realValue = target.updateAttr(BattleDef.PHYSICAL_ARMOR, addValue);
			result.updateAttr(BattleReportDefine.REPORT_ITEM_PHYSICAL_ARMOR, realValue);
			//法术防御
			addValue = needCalc ? calcAddValue(Double.valueOf(target.getAttr(BattleDef.MAGIC_ARMOR)), add, vT) : add;
			realValue = target.updateAttr(BattleDef.MAGIC_ARMOR, addValue);
			result.updateAttr(BattleReportDefine.REPORT_ITEM_MAGIC_ARMOR, realValue);
			break;
		case PHYSICAL_DEFENCE:
			//物理防御
			addValue = needCalc ? calcAddValue(Double.valueOf(target.getAttr(BattleDef.PHYSICAL_ARMOR)), add, vT) : add;
			realValue = target.updateAttr(BattleDef.PHYSICAL_ARMOR, addValue);
			result.updateAttr(BattleReportDefine.REPORT_ITEM_PHYSICAL_ARMOR, realValue);
		case MAGIC_DEFENCE:
			//法术防御
			addValue = needCalc ? calcAddValue(Double.valueOf(target.getAttr(BattleDef.MAGIC_ARMOR)), add, vT) : add;
			realValue = target.updateAttr(BattleDef.MAGIC_ARMOR, addValue);
			result.updateAttr(BattleReportDefine.REPORT_ITEM_MAGIC_ARMOR, realValue);
			break;
		case CRIT:
			if (target.getAttackType() == PetAttackType.STRENGTH) {
				addValue = needCalc ? calcAddValue(target.getAttr(BattleDef.PHYSICAL_CRIT), add, vT) : add;
				realValue = target.updateAttr(BattleDef.PHYSICAL_CRIT, addValue);
				result.updateAttr(BattleReportDefine.REPORT_ITEM_PHYSICAL_CRIT, realValue);
			} else {
				addValue = needCalc ? calcAddValue(target.getAttr(BattleDef.MAGIC_CRIT), add, vT) : add;
				realValue = target.updateAttr(BattleDef.MAGIC_CRIT, addValue);
				result.updateAttr(BattleReportDefine.REPORT_ITEM_MAGIC_CRIT, realValue);
			}
			break;
		case MAGIC_CRIT:
			addValue = needCalc ? calcAddValue(target.getAttr(BattleDef.MAGIC_CRIT), add, vT) : add;
			realValue = target.updateAttr(BattleDef.MAGIC_CRIT, addValue);
			result.updateAttr(BattleReportDefine.REPORT_ITEM_MAGIC_CRIT, realValue);
			break;
		case PHYSICAL_CRIT:
			addValue = needCalc ? calcAddValue(target.getAttr(BattleDef.PHYSICAL_CRIT), add, vT) : add;
			realValue = target.updateAttr(BattleDef.PHYSICAL_CRIT, addValue);
			result.updateAttr(BattleReportDefine.REPORT_ITEM_PHYSICAL_CRIT, realValue);
			break;
		case MAGIC_ATTACK:
			addValue = needCalc ? calcAddValue(target.getAttr(BattleDef.MAGIC_ATTACK), add, vT) : add;
			realValue = target.updateAttr(BattleDef.MAGIC_ATTACK, addValue);
			result.updateAttr(BattleReportDefine.REPORT_ITEM_MAGIC_ATTACK, realValue);
			break;
		case PHYSICAL_ATTACK:
			addValue = needCalc ? calcAddValue(target.getAttr(BattleDef.PHYSICAL_ATTACK), add, vT) : add;
			realValue = target.updateAttr(BattleDef.PHYSICAL_ATTACK, addValue);
			result.updateAttr(BattleReportDefine.REPORT_ITEM_PHYSICAL_ATTACK, realValue);
			break;
		case MAGIC_HIT:
			addValue = needCalc ? calcAddValue(target.getAttr(BattleDef.MAGIC_HIT), add, vT) : add;
			realValue = target.updateAttr(BattleDef.MAGIC_HIT, addValue);
			result.updateAttr(BattleReportDefine.REPORT_ITEM_MAGIC_HIT, realValue);
			break;
		case PHYSICAL_HIT:
			addValue = needCalc ? calcAddValue(target.getAttr(BattleDef.PHYSICAL_HIT), add, vT) : add;
			realValue = target.updateAttr(BattleDef.PHYSICAL_HIT, addValue);
			result.updateAttr(BattleReportDefine.REPORT_ITEM_PHYSICAL_HIT, realValue);
			break;
		case ALL_DODGY:
			//物理闪避
			addValue = needCalc ? calcAddValue(Double.valueOf(target.getAttr(BattleDef.PHYSICAL_DODGY)), add, vT) : add;
			realValue = target.updateAttr(BattleDef.PHYSICAL_DODGY, addValue);
			result.updateAttr(BattleReportDefine.REPORT_ITEM_PHYSICAL_DODGY, realValue);
			//法术闪避
			addValue = needCalc ? calcAddValue(Double.valueOf(target.getAttr(BattleDef.MAGIC_DODGY)), add, vT) : add;
			realValue = target.updateAttr(BattleDef.MAGIC_DODGY, addValue);
			result.updateAttr(BattleReportDefine.REPORT_ITEM_MAGIC_DODGY, realValue);
			break;
			
		case STATUS:
			realValue = Double.valueOf(add);
			long status = add;
			if (status > 0L) {
				//加状态
				target.addStatus(status);
			} else {
				//减状态
				target.removeStatus(-status);
			}
			break;
		case HURT_SHIELD:
			realValue = Double.valueOf(add);
			break;
		default:
			logger.error("invalid effect value type!" + evType);
			break;
		}
		if (updateValueFlag) {
			buffEffect.setValue(buffEffect.getValue() + realValue);
		}
		return ret;
	}
	
	public static Double getAttrByEffectValueType(FightUnit target, EffectValueType evType) {
		Double value = 0D;
		switch (evType) {
		case HP:
			value = target.getAttr(BattleDef.HP);
			break;
		case MP:
			value = target.getAttr(BattleDef.MP);
			break;
		case SP:
			value = target.getAttr(BattleDef.SP);
			break;
		case SPEED:
			value = target.getAttr(BattleDef.SPEED);
			break;
		case ATTACK:
			if (target.getAttackType() == PetAttackType.STRENGTH) {
				value = target.getAttr(BattleDef.PHYSICAL_ATTACK);
			} else {
				value = target.getAttr(BattleDef.MAGIC_ATTACK);
			}
			break;
		case DEFEND:
			if (target.getAttackType() == PetAttackType.STRENGTH) {
				value = target.getAttr(BattleDef.PHYSICAL_ARMOR);
			} else {
				value = target.getAttr(BattleDef.MAGIC_ARMOR);
			}
			break;
		case STATUS:
			value = target.getStatus() * 1.0D;
		case HP_MAX:
			value = target.getAttr(BattleDef.HP + BattleDef.MAX);
			break;
		case SPEED_MAX:
			value = target.getAttr(BattleDef.SPEED + BattleDef.MAX);
			break;
		case CRIT:
			if (target.getAttackType() == PetAttackType.STRENGTH) {
				value = target.getAttr(BattleDef.PHYSICAL_CRIT);
			} else {
				value = target.getAttr(BattleDef.MAGIC_CRIT);
			}
			break;
		case MAGIC_CRIT:
			value = target.getAttr(BattleDef.MAGIC_CRIT);
			break;
		case PHYSICAL_CRIT:
			value = target.getAttr(BattleDef.PHYSICAL_CRIT);
			break;
		case MAGIC_ATTACK:
			value = target.getAttr(BattleDef.MAGIC_ATTACK);
			break;
		case PHYSICAL_ATTACK:
			value = target.getAttr(BattleDef.PHYSICAL_ATTACK);
			break;
		case MAGIC_HIT:
			value = target.getAttr(BattleDef.MAGIC_HIT);
			break;
		case PHYSICAL_HIT:
			value = target.getAttr(BattleDef.PHYSICAL_HIT);
			break;
		case PHYSICAL_DEFENCE:
			value = target.getAttr(BattleDef.PHYSICAL_ARMOR);
			break;
		case MAGIC_DEFENCE:
			value = target.getAttr(BattleDef.MAGIC_ARMOR);
			break;
		default:
			logger.error("invalid effect value type!" + evType);
			break;
		}
		
		return value;
	}
	
	public static String getAttrKey(FightUnit target, EffectValueType evType) {
		String key = "";
		switch (evType) {
		case HP:
			key = BattleDef.HP;
			break;
		case MP:
			key = BattleDef.MP;
			break;
		case SP:
			key = BattleDef.SP;
			break;
		case SPEED:
			key = BattleDef.SPEED;
			break;
		case ATTACK:
			if (target.getAttackType() == PetAttackType.STRENGTH) {
				key = BattleDef.PHYSICAL_ATTACK;
			} else {
				key = BattleDef.MAGIC_ATTACK;
			}
			break;
		case DEFEND:
			if (target.getAttackType() == PetAttackType.STRENGTH) {
				key = BattleDef.PHYSICAL_ARMOR;
			} else {
				key = BattleDef.MAGIC_ARMOR;
			}
			break;
		case HP_MAX:
			key = BattleDef.HP + BattleDef.MAX;
			break;
		case SPEED_MAX:
			key = BattleDef.SPEED + BattleDef.MAX;
			break;
		case CRIT:
			if (target.getAttackType() == PetAttackType.STRENGTH) {
				key = BattleDef.PHYSICAL_CRIT;
			} else {
				key = BattleDef.MAGIC_CRIT;
			}
			break;
		case MAGIC_CRIT:
			key = BattleDef.MAGIC_CRIT;
			break;
		case PHYSICAL_CRIT:
			key = BattleDef.PHYSICAL_CRIT;
			break;
		case MAGIC_ATTACK:
			key = BattleDef.MAGIC_ATTACK;
			break;
		case PHYSICAL_ATTACK:
			key = BattleDef.PHYSICAL_ATTACK;
			break;
		case MAGIC_HIT:
			key = BattleDef.MAGIC_HIT;
			break;
		case PHYSICAL_HIT:
			key = BattleDef.PHYSICAL_HIT;
			break;
		default:
			logger.error("invalid effect value type!" + evType);
			break;
		}
		return key;
	}
	
	public static int getReportAttrKey(FightUnit target, EffectValueType evType) {
		int key = 0;
		switch (evType) {
		case HP:
			key = BattleReportDefine.REPORT_ITEM_HP;
			break;
		case MP:
			key = BattleReportDefine.REPORT_ITEM_MP;
			break;
		case SP:
			key = BattleReportDefine.REPORT_ITEM_SP;
			break;
		case SPEED:
			key = BattleReportDefine.REPORT_ITEM_SPEED;
			break;
		case ATTACK:
			if (target.getAttackType() == PetAttackType.STRENGTH) {
				key = BattleReportDefine.REPORT_ITEM_PHYSICAL_ATTACK;
			} else {
				key = BattleReportDefine.REPORT_ITEM_MAGIC_ATTACK;
			}
			break;
		case DEFEND:
			if (target.getAttackType() == PetAttackType.STRENGTH) {
				key = BattleReportDefine.REPORT_ITEM_PHYSICAL_ARMOR;
			} else {
				key = BattleReportDefine.REPORT_ITEM_MAGIC_ARMOR;
			}
			break;
		case HP_MAX:
			key = BattleReportDefine.FIGHTUNIT_HP_MAX;
			break;
//		case SPEED_MAX:
//			key = BattleReportDefine.;
//			break;
		case CRIT:
			if (target.getAttackType() == PetAttackType.STRENGTH) {
				key = BattleReportDefine.REPORT_ITEM_PHYSICAL_CRIT;
			} else {
				key = BattleReportDefine.REPORT_ITEM_MAGIC_CRIT;
			}
			break;
		case MAGIC_CRIT:
			key = BattleReportDefine.REPORT_ITEM_MAGIC_CRIT;
			break;
		case PHYSICAL_CRIT:
			key = BattleReportDefine.REPORT_ITEM_PHYSICAL_CRIT;
			break;
		case MAGIC_ATTACK:
			key = BattleReportDefine.REPORT_ITEM_MAGIC_ATTACK;
			break;
		case PHYSICAL_ATTACK:
			key = BattleReportDefine.REPORT_ITEM_PHYSICAL_ATTACK;
			break;
		case MAGIC_HIT:
			key = BattleReportDefine.REPORT_ITEM_MAGIC_HIT;
			break;
		case PHYSICAL_HIT:
			key = BattleReportDefine.REPORT_ITEM_PHYSICAL_HIT;
			break;
			
		default:
			logger.error("invalid effect value type!" + evType);
			break;
		}
		return key;
	}
	
	public static int calcAddValue(Double base, int add, ValueType vT) {
		Double ret = 0D;
		switch (vT) {
		case PERCENT:
			ret = base * int2Double(add);
			break;
		case LITERAL:
			ret = add * 1.0D;
			break;
		default:
			logger.error("invalid effect value type!" + vT);
			break;
		}
		return ret.intValue();
	}

	/**
	 * int 转换为 double
	 * 
	 * @param value
	 * @return
	 */
	public static double int2Double(int value){
		return ((double)value) / Globals.getGameConstants().getScale();
	}
	
//
//	/**
//	 * 初始化Enum
//	 * @param params
//	 * @param key
//	 * @param clz
//	 * @return
//	 */
//	@SuppressWarnings({ "rawtypes", "unchecked" })
//	public static <T extends Enum> T getInitializeEnum(Map<String, Object> params, String key, Class<T> clz) {
//		String name = (String) params.get(key);
//		return (T) Enum.valueOf(clz, name);
//	}
//
//	public static int getInitializeIntValue(Map<String, Object> params,String key){
//		return Integer.parseInt(params.get(key).toString().trim());
//	}
//	
//	public static String getInitializeStringValue(Map<String, Object> params,String key){
//		return params.get(key).toString().trim();
//	}
//	
//	public static Number getInitializeNumberValue(Map<String, Object> params,String key){
//		Number number = 0;
//		try {
//			number = NumberFormat.getInstance().parse(params.get(key).toString().trim());
//		} catch (ParseException e) {
//			e.printStackTrace();
//		}
//		return number;
//	}
//
//	/**
//	 * 初始化目标选取规则
//	 * 
//	 * @param params
//	 * @return
//	 */
//	//TODO
//	@SuppressWarnings("unchecked")
//	public static TargetType[] getInitializeTargetTypes(Map<String, Object> params) {
//		List<String> targets = (List<String>) params.get(BattleDef.EFFECT_TARGETS);
//		List<TargetType> types = new ArrayList<TargetType>();
//		for (String t : targets) {
//			types.add(TargetType.valueOf(t));
//		}
//		return (TargetType[]) types.toArray(new TargetType[0]);
//	}
	
}
