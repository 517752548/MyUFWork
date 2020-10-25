package com.imop.lj.gameserver.battle.effect.impl.buff;

import com.imop.lj.gameserver.battle.core.BattleDef.EffectValueType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.EffectHelper;

public class Param1BuffEffect extends BaseBuffEffect {

	public Param1BuffEffect(int effectId) {
		super(effectId);
	}
	
	@Override
	protected int calcBuffAddValue(FightUnit target, FightUnit doSkillOwner, int value) {
		//buff降低的生命值=初始降低值+（技能等级加值*技能等级+额外降低值）*【(我方[属性]/敌方[属性])<=3】
		double max = EffectHelper.int2Double(getEffectTpl().getExtraCoef2());
		double part1 = EffectHelper.int2Double(getEffectTpl().getValueCoef()); 
		//镶嵌的仙符效果取效果等级
		double part2 = EffectHelper.int2Double(getEffectTpl().getValueAdd()) * (isEmbedEffect() ? getEffectLevel() : getSkillLevel()) + 
				EffectHelper.int2Double(getEffectTpl().getExtraCoef1());
		EffectValueType evType = EffectValueType.valueOf(getEffectTpl().getExtraCoef3());
		double part3 = EffectHelper.getAttrByEffectValueType(doSkillOwner, evType) / EffectHelper.getAttrByEffectValueType(target, evType);
		if (part3 > max) {
			part3 = max;
		}
		
		double addValue = part1 + part2 * part3;
		//如果未负数，则取负数
		if (getEffectTpl().isNegative()) {
			addValue = -addValue;
		}
		return (int)addValue;
	}
	
}
