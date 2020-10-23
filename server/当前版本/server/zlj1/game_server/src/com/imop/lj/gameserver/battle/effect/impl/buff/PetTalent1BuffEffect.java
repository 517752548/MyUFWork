package com.imop.lj.gameserver.battle.effect.impl.buff;

import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;

public class PetTalent1BuffEffect extends BaseBuffEffect {

	public PetTalent1BuffEffect(int effectId) {
		super(effectId);
	}
	
	@Override
	protected int calcBuffAddValue(FightUnit target, FightUnit doSkillOwner, int value) {
		//BUFF伤害值=BUFF伤害系数*物理攻击+BUFF伤害加值
		double part1 = EffectHelper.int2Double(getEffectTpl().getValueCoef());
//		PetAttackType attackType = PetAttackType.valueOf(getEffectTpl().getExtraCoef1());
		double part2 = BattleCalculateHelper.getBaseAttack(doSkillOwner);
		double part3 = EffectHelper.int2Double(getEffectTpl().getValueAdd());
		
		double finalValue = part1 * part2 + part3;
		//如果未负数，则取负数
		if (getEffectTpl().isNegative()) {
			finalValue = -finalValue;
		}
		return (int)finalValue;
	}
	
}
