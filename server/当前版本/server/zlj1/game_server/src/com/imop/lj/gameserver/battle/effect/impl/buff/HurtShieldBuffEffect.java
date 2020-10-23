package com.imop.lj.gameserver.battle.effect.impl.buff;

import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;

/**
 * 伤害吸收盾
 * @author yu.zhao
 *
 */
public class HurtShieldBuffEffect extends BaseBuffEffect {

	public HurtShieldBuffEffect(int effectId) {
		super(effectId);
	}
	
	@Override
	protected int calcBuffAddValue(FightUnit target, FightUnit doSkillOwner, int value) {
		//盾吸收的伤害=（盾初始系数+心法成长系数*心法等级）*攻击力+技能等级加成*技能等级
		double addValue = 0;
		double part1 = EffectHelper.int2Double(getEffectTpl().getValueCoef()) + 
				EffectHelper.int2Double(getEffectTpl().getExtraCoef1()) * doSkillOwner.getMindLevel();
		//镶嵌的仙符效果取效果等级
		double part2 = EffectHelper.int2Double(getEffectTpl().getValueAdd()) * (isEmbedEffect() ? getEffectLevel() : getSkillLevel()); 
		addValue = part1 * BattleCalculateHelper.getBaseAttack(doSkillOwner) + part2;
//		//如果未负数，则取负数
//		if (getEffectTpl().isNegative()) {
//			addValue = -addValue;
//		}
		
		return (int)addValue;
	}
	
	public int costValue(int damage) {
		int left = getValue().intValue() - damage;
		setValue(Double.valueOf(left));
		return left;
	}
	
	public boolean hasEnoughValue(int damage) {
		return getValue() > 0 && getValue() > damage;
	}
	
}
