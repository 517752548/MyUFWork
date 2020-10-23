package com.imop.lj.gameserver.battle.effect.impl.buff;

import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.EffectHelper;

public class Param2BuffEffect extends BaseBuffEffect {

	public Param2BuffEffect(int effectId) {
		super(effectId);
	}
	
	@Override
	protected int calcBuffAddValue(FightUnit target, FightUnit doSkillOwner, int value) {
		//buff降低的生命值=初始降低值*（1+心法等级*心法提升伤害系数）+技能等级加值*技能等级
		double part1 = EffectHelper.int2Double(getEffectTpl().getValueCoef());
		double part2 = 1 + doSkillOwner.getMindLevel() * EffectHelper.int2Double(getEffectTpl().getExtraCoef2());
		//镶嵌的仙符效果取效果等级
		double part3 = EffectHelper.int2Double(getEffectTpl().getValueAdd()) * (isEmbedEffect() ? getEffectLevel() : getSkillLevel());
		double addValue = part1 * part2 + part3;
		//如果未负数，则取负数
		if (getEffectTpl().isNegative()) {
			addValue = -addValue;
		}
		return (int)addValue;
	}
	
}
