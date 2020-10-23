package com.imop.lj.gameserver.battle.effect.impl.buff;

import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.EffectHelper;

public class ParamBuffEffect extends BaseBuffEffect {

	public ParamBuffEffect(int effectId) {
		super(effectId);
	}
	
	@Override
	protected int calcBuffAddValue(FightUnit target, FightUnit doSkillOwner, int value) {
		//buff附加值=初始降低值+技能等级加值*技能等级+心法等级加值*心法等级
		double addValue = 0;
		//镶嵌的仙符效果取效果等级
		addValue = EffectHelper.int2Double(getEffectTpl().getValueCoef()) + 
				EffectHelper.int2Double(getEffectTpl().getValueAdd()) * (isEmbedEffect() ? getEffectLevel() : getSkillLevel()) + 
				EffectHelper.int2Double(getEffectTpl().getExtraCoef1()) * doSkillOwner.getMindLevel();
		//如果未负数，则取负数
		if (getEffectTpl().isNegative()) {
			addValue = -addValue;
		}
		return (int)addValue;
	}
	
}
