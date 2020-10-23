package com.imop.lj.gameserver.battle.effect.impl.action;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.PetDef.PetAttackType;

/**
 * 伏魔刀法坚韧心法主效果
 * 
 */
public class Fumo2Main extends AttackCoef {

	public Fumo2Main(int effectId) {
		super(effectId);
	}

	@Override
	protected int getAttackerAttack(FightUnit attacker, FightUnit defender) {
		//攻击力=(（初始伤害系数）*攻击力+等级提升技能伤害加值*技能等级  )*(1 + 骑宠加成)
		double baseCoef = EffectHelper.int2Double((int)getEffectTpl().getValueBase());
		double skillLevelCoef = EffectHelper.int2Double(getEffectTpl().getValueAdd());
		
		double baseAttack = 0d;
		boolean isDefault = this.getEffectTpl().isDefaultAttack();
		boolean isStrength = this.getEffectTpl().isPhsicalAttack();
		boolean isMagic = this.getEffectTpl().isMagicAttack();
		if(isDefault){
			//默认-取面板攻击
			baseAttack = BattleCalculateHelper.getBaseAttack(attacker);
		}else if(isStrength){
			baseAttack = BattleCalculateHelper.getBaseAttackByType(attacker, PetAttackType.STRENGTH );
		}else if(isMagic){
			baseAttack = BattleCalculateHelper.getBaseAttackByType(attacker, PetAttackType.INTELLECT );
		}
		
		double part1 = (baseCoef) * baseAttack;
		//镶嵌的仙符效果取效果等级
		double part2 = skillLevelCoef * (isEmbedEffect() ? getEffectLevel() : getSkillLevel());
		//骑宠加成
		boolean isPetHorseAdd = attacker.getPetHorseAddMap().containsValue(this.skillId);
		double part3 = isPetHorseAdd ? 
				EffectHelper.int2Double(
						Globals.getTemplateCacheService().getBattleTemplateCache().getFinalSkillValue(
								attacker.getPetHorseSkillLevel(), attacker.getPetHorseAddTpl(attacker, this.skillId))
						) * attacker.getPetHorseSkillLevel()
				: 0;
		
		int finalAtk = (int)( (part1 + part2) * (1 + part3));
		return finalAtk;
	}

	@Override
	protected int getTargetNum(FightUnit owner) {
		double max = EffectHelper.int2Double(getEffectTpl().getExtraCoef1());
		//攻击人数=【1】取整<=n
		double num = getEffectTpl().getTargetNum();
		if (num > max) {
			num = max;
		}
		if (num < 1) {
			num = 1;
			Loggers.battleLogger.error("targetNum is less than 1!");
		}
		return (int)num;
	}
	
}