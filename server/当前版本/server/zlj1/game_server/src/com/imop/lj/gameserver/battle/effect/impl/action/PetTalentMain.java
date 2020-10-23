package com.imop.lj.gameserver.battle.effect.impl.action;

import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;

/**
 * 宠物天赋技能主效果
 * 
 */
public class PetTalentMain extends AttackCoef {

	public PetTalentMain(int effectId) {
		super(effectId);
	}

	@Override
	protected int getAttackerAttack(FightUnit attacker, FightUnit defender) {
		//攻击力=伤害系数值*指定攻击力+技能伤害加值
		double baseCoef = EffectHelper.int2Double((int)getEffectTpl().getValueBase());
//		PetAttackType attackType = PetAttackType.valueOf(getEffectTpl().getExtraCoef1());
		double attack = BattleCalculateHelper.getBaseAttack(attacker);
		double skillCoef = EffectHelper.int2Double(getEffectTpl().getValueAdd());
		
		int finalAtk = (int)(baseCoef * attack + skillCoef);
		return finalAtk;
	}
	
}