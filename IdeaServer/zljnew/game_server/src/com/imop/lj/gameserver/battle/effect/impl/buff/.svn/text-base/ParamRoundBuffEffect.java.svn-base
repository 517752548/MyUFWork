package com.imop.lj.gameserver.battle.effect.impl.buff;

import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.EffectFactory;
import com.imop.lj.gameserver.battle.helper.EffectHelper;

public class ParamRoundBuffEffect extends BaseBuffEffect {

	public ParamRoundBuffEffect(int effectId) {
		super(effectId);
	}
	
	@Override
	protected int calcBuffAddValue(FightUnit target, FightUnit doSkillOwner, int value) {
		//BUFF伤害值= （【初始数值】*技能实际伤害值）*（1+（【BUFF持续回合数】-剩余回合数）*【附加参数1】）
		double part1 = EffectHelper.int2Double((int) getEffectTpl().getValueBase());
		BaseBuffEffect buffEffect = EffectFactory.buildBuffEffect(this);
		double part2 = getEffectTpl().getBuffContinued();
		double part3 = buffEffect.getLeftTimes();
		double part4 = EffectHelper.int2Double(getEffectTpl().getExtraCoef1());
		double finalValue = (part1 * value )* (1 + (Math.abs(part2 - part3)) * part4);
//		//如果未负数，则取负数
//		if (getEffectTpl().isNegative()) {
//			finalValue = -finalValue;
//		}
		return (int)finalValue;
	}
	
}
