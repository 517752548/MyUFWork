package com.imop.lj.gameserver.battle.effect.impl.buff;

import com.imop.lj.gameserver.battle.core.FightUnit;

/**
 * 指定吸收值的伤害吸收盾
 *
 */
public class HurtShieldBuffEffectWithValue extends HurtShieldBuffEffect {

	public HurtShieldBuffEffectWithValue(int effectId) {
		super(effectId);
	}
	
	@Override
	protected int calcBuffAddValue(FightUnit target, FightUnit doSkillOwner, int value) {
		return value;
	}
	
}
