package com.imop.lj.gameserver.battle.effect.impl.action;

import com.imop.lj.gameserver.battle.core.BattleDef.EffectValueType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;

/**
 * 伏魔刀法英勇心法主效果
 * 
 */
public class Fumo1Main extends AttackCoef {

	public Fumo1Main(int effectId) {
		super(effectId);
	}
	
	@Override
	protected int getAttackerAttack(FightUnit attacker, FightUnit defender) {
		//攻击力=【((我方[属性]/敌方[属性])<=n)*额外增加伤害系数+（初始伤害系数+英勇心法提升伤害系数*心法等级）】*物理攻击力+等级提升技能伤害加值*技能等级
		EffectValueType evType = getEffectTpl().getEffectValueType();
		double atkAttrMax = EffectHelper.getAttrByEffectValueType(attacker, evType);
		double defAttrMax = EffectHelper.getAttrByEffectValueType(defender, evType);
		double attrPercent = atkAttrMax / defAttrMax;
		double max = EffectHelper.int2Double(getEffectTpl().getExtraCoef1());
		if (attrPercent > max) {
			attrPercent = max;
		}
		
		double extCoef = EffectHelper.int2Double(getEffectTpl().getValueCoef());
		double baseCoef = EffectHelper.int2Double((int)getEffectTpl().getValueBase());
		double mindCoef = EffectHelper.int2Double(getEffectTpl().getMindCoef());
		double skillLevelCoef = EffectHelper.int2Double(getEffectTpl().getValueAdd());
		
		double part1 = (attrPercent * extCoef + (baseCoef + mindCoef * attacker.getMindLevel())) * BattleCalculateHelper.getBaseAttack(attacker);
		//镶嵌的仙符效果取效果等级
		double part2 = (isEmbedEffect() ? getEffectLevel() : getSkillLevel()) * skillLevelCoef;
		
		int finalAtk = (int)(part1 + part2);
		
		return finalAtk;
	}
	
	
}