package com.imop.lj.gameserver.battle.effect.impl.action;

import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;

/**
 * 宠物普通技能主效果
 * 
 */
public class PetNormalMain extends AttackCoef {

	public PetNormalMain(int effectId) {
		super(effectId);
	}

	@Override
	protected int getAttackerAttack(FightUnit attacker, FightUnit defender) {
		//攻击力=X%攻击力+增量*技能等级
		double baseCoef = EffectHelper.int2Double((int)getEffectTpl().getValueBase());
		double attack = BattleCalculateHelper.getBaseAttack(attacker);
		double skillCoef = EffectHelper.int2Double(getEffectTpl().getValueAdd());
		//镶嵌的仙符效果取效果等级
		int skillLevel = isEmbedEffect() ? getEffectLevel() : getSkillLevel();
		
		int finalAtk = (int)(baseCoef * attack + skillCoef * skillLevel);
		return finalAtk;
	}
	
}