package com.imop.lj.gameserver.battle.effect.impl.action;

import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.effect.IEffect;

public class AddBuffFromAllAttack extends AddBuff {

	public AddBuffFromAllAttack(int effectId) {
		super(effectId);
		setPhases(new Phase[] {Phase.ACTION_EXECUTE_AFTER});
	}
	
	@Override
	public boolean isFrom(IEffect fromE) {
		if (fromE instanceof AttackCoef) {
			return true;
		}
		return false;
	}
}
