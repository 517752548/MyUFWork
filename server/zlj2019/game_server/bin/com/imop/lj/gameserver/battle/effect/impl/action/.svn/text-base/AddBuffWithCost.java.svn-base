package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.List;

import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.model.RealDamage;
import com.imop.lj.gameserver.battle.report.ReportItem;

/**
 * 
 *加buff之前需要消耗自身hp或者mp
 */
public class AddBuffWithCost extends AddBuff {
	
	private int cost;

	public AddBuffWithCost(int effectId) {
		super(effectId);
	}
	
	@Override
	public boolean isVaild(Phase phase) {
		if (!super.isVaild(phase)) {
			return false;
		}
		//目前加buff会肯定加上
		return true;
	}
	
	public boolean preCost(FightUnit owner, FightUnit target, List<ReportItem> content, RealDamage realDamageHp) {
		return true;
	}
	
	public int getCost() {
		return cost;
	}

	public void setCost(int cost) {
		this.cost = cost;
	}
}
