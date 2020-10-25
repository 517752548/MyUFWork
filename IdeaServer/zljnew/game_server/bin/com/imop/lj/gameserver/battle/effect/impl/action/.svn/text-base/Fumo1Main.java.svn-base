package com.imop.lj.gameserver.battle.effect.impl.action;

import com.imop.lj.gameserver.battle.core.BattleDef.EffectValueType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.PetDef.PetAttackType;

/**
 * 伏魔刀法英勇心法主效果
 * 
 */
public class Fumo1Main extends AttackCoef {

	public Fumo1Main(int effectId) {
		super(effectId);
	}
	
	@Override
	protected int getAttackerAttack(FightUnit attacker, FightUnit defender) {
		//攻击力=(【((我方[属性]/敌方[属性])<=n)*额外增加伤害系数+（初始伤害系数）】*物理攻击力+等级提升技能伤害加值*技能等级 ) * (1 + 骑宠加成)
		EffectValueType evType = getEffectTpl().getEffectValueType();
		double atkAttrMax = EffectHelper.getAttrByEffectValueType(attacker, evType);
		double defAttrMax = EffectHelper.getAttrByEffectValueType(defender, evType);
		double attrPercent = atkAttrMax / defAttrMax;
		double max = EffectHelper.int2Double(getEffectTpl().getExtraCoef1());
		if (attrPercent > max) {
			attrPercent = max;
		}
		
		double extCoef = EffectHelper.int2Double(getEffectTpl().getValueCoef());
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
		
		
		double part1 = (attrPercent * extCoef + (baseCoef)) * baseAttack;
		//镶嵌的仙符效果取效果等级
		double part2 = (isEmbedEffect() ? getEffectLevel() : getSkillLevel()) * skillLevelCoef;
		
		//骑宠加成
		boolean isPetHorseAdd = attacker.getPetHorseAddMap().containsValue(this.skillId);
		double part3 = isPetHorseAdd ? 
				EffectHelper.int2Double(
						Globals.getTemplateCacheService().getBattleTemplateCache().getFinalSkillValue(
								attacker.getPetHorseSkillLevel(), attacker.getPetHorseAddTpl(attacker, this.skillId))
						) * attacker.getPetHorseSkillLevel()
				: 0;
		
		int finalAtk = (int)(( part1 + part2 )* (1 + part3));
		
		return finalAtk;
	}
	
	
}