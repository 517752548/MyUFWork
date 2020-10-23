package com.imop.lj.gameserver.battle.effect.impl.action;

import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.PetDef.PetAttackType;

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
	
	@Override
	protected int getAttackerAttack(FightUnit attacker, FightUnit defender) {
		//默认是攻击方基础攻击力
		double baseAttack = 0d;
		boolean isDefault = attacker.getNormalAttackTypeId() == PetAttackType.DEFAULT.getIndex();
		boolean isStrength = attacker.getNormalAttackTypeId() == PetAttackType.STRENGTH.getIndex();
		boolean isMagic = attacker.getNormalAttackTypeId() == PetAttackType.INTELLECT.getIndex();
		if(isDefault){
			//默认-取面板攻击
			baseAttack = BattleCalculateHelper.getBaseAttack(attacker);
		}else if(isStrength){
			baseAttack = BattleCalculateHelper.getBaseAttackByType(attacker, PetAttackType.STRENGTH );
		}else if(isMagic){
			baseAttack = BattleCalculateHelper.getBaseAttackByType(attacker, PetAttackType.INTELLECT );
		}
		return (int)baseAttack;
	}
	
}