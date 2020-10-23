package com.imop.lj.gameserver.battle.effect.impl.action;

import com.imop.lj.gameserver.battle.helper.EffectHelper;

public class AddBuffParam extends AddBuff {

	public AddBuffParam(int effectId) {
		super(effectId);
	}

	@Override
	protected double calcAddBuffProb() {
		//BUFF附加几率=BUFF附加的初始几率+心法等级*心法提升几率
		double prob = EffectHelper.int2Double((int)getEffectTpl().getValueBase()) + 
				getOwner().getMindLevel() * EffectHelper.int2Double(getEffectTpl().getMindCoef());
		
//		prob = 1.0D;//测试用，需要删掉 TODO FIXME
		
		return prob;
	}
}
