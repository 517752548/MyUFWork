package com.imop.lj.gameserver.battle.effect.impl.action;

import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.EffectHelper;

public class DefenceAttackParam extends DefenceAttack {

	public DefenceAttackParam(int effectId) {
		super(effectId);
	}

	@Override
	protected int getAttackerAttack(FightUnit attacker, FightUnit defender) {
		//被攻击者受到的伤害=伤害系数值*（物理攻击+法术强度）+技能伤害加值
		double baseCoef = EffectHelper.int2Double((int)getEffectTpl().getValueBase());
		double attack = attacker.getAttr(BattleDef.PHYSICAL_ATTACK) + attacker.getAttr(BattleDef.MAGIC_ATTACK);
		double skillCoef = EffectHelper.int2Double(getEffectTpl().getValueAdd());
		
		int finalAtk = (int)(baseCoef * attack + skillCoef);
		return finalAtk;
	}
	
}
