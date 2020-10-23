package com.imop.lj.gameserver.battle.effect.impl.action;

import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.FightUnit;

/**
 * 
 * 根据目标判断是否加buff
 */
public class AddBuffWithTarget extends AddBuff {
	
	public AddBuffWithTarget(int effectId) {
		super(effectId);
	}
	
	@Override
	protected boolean canExucute(FightUnit owner, Action action) {
		//只有是友方的时候才会加buff
		for (FightUnit target : action.getTargets(this)) {
			if(getOwner().isAttacker() == target.isAttacker()){
				return true;
			}
		}
		return false;
	}
}
