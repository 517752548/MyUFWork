package com.imop.lj.gameserver.battle.effect.impl.buff;

import java.util.List;

import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.BattleDef.BuffCatalog;
import com.imop.lj.gameserver.battle.effect.IEffect;

public class BeTreatBuffEffect extends BaseBuffEffect {

	public BeTreatBuffEffect(int effectId) {
		super(effectId);
	}
	
	@Override
	protected boolean canAddBuff(FightUnit target) {
		//如果目标有物理防御buff,则不加此buff
		List<IEffect> eListPhysical = target.getBuffEffectByCatalog(BuffCatalog.PHYSICAL_DEFENCE);
		if(!eListPhysical.isEmpty()){
			return false;
		}
		return true;
	}
	
}
