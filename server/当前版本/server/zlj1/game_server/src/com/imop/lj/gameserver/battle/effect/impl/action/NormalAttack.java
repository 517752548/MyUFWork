package com.imop.lj.gameserver.battle.effect.impl.action;

import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.common.Globals;

/**
 * 普通攻击
 * 
 */
public class NormalAttack extends AttackCoef {

	public NormalAttack() {
		super(Globals.getTemplateCacheService().getBattleTemplateCache().getNormalAttackEffectId());
	}

	/**
	 * 普通攻击，可能触发连击
	 */
	protected void afterDamageNotDead(Action action, FightUnit target) {
		//连击是和普攻一样的target
//		action.addEffectExtra(this, target, DoubleAttack.class);
	}
	
}