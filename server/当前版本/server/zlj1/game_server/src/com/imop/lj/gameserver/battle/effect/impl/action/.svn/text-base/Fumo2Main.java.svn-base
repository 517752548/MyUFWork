package com.imop.lj.gameserver.battle.effect.impl.action;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;

/**
 * 伏魔刀法坚韧心法主效果
 * 
 */
public class Fumo2Main extends AttackCoef {

	public Fumo2Main(int effectId) {
		super(effectId);
	}

	@Override
	protected int getAttackerAttack(FightUnit attacker, FightUnit defender) {
		//攻击力=（初始伤害系数+心法提升伤害系数*心法等级）*攻击力+等级提升技能伤害加值*技能等级+心法提升伤害加值*心法等级
		double baseCoef = EffectHelper.int2Double((int)getEffectTpl().getValueBase());
		double mindCoef = EffectHelper.int2Double(getEffectTpl().getMindCoef());
		double skillLevelCoef = EffectHelper.int2Double(getEffectTpl().getValueAdd());
		double extra2Coef = EffectHelper.int2Double(getEffectTpl().getExtraCoef2());
		
		double part1 = (baseCoef + mindCoef * attacker.getMindLevel()) * BattleCalculateHelper.getBaseAttack(attacker);
		//镶嵌的仙符效果取效果等级
		double part2 = skillLevelCoef * (isEmbedEffect() ? getEffectLevel() : getSkillLevel());
		double part3 = extra2Coef * attacker.getMindLevel();
		int finalAtk = (int)(part1 + part2 + part3);
		return finalAtk;
	}
	
	@Override
	protected int getTargetNum(FightUnit owner) {
		double numCoef = EffectHelper.int2Double(getEffectTpl().getValueCoef());
		double max = EffectHelper.int2Double(getEffectTpl().getExtraCoef1());
		//攻击人数=【1+（心法提升攻击人数*心法等级）】取整<=n
		double num = getEffectTpl().getTargetNum() + numCoef * owner.getMindLevel();
		if (num > max) {
			num = max;
		}
		if (num < 1) {
			num = 1;
			Loggers.battleLogger.error("targetNum is less than 1!");
		}
		return (int)num;
	}
	
}