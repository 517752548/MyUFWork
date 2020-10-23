package com.imop.lj.gameserver.battle.effect.impl.buff;

import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.PetDef.PetAttackType;

public class PetTalent1BuffEffect extends BaseBuffEffect {

	public PetTalent1BuffEffect(int effectId) {
		super(effectId);
	}
	
	@Override
	protected int calcBuffAddValue(FightUnit target, FightUnit doSkillOwner, int value) {
		//BUFF伤害值=(BUFF伤害系数*物理攻击+BUFF伤害加值) * (1 + 骑宠加成)
		double part1 = EffectHelper.int2Double(getEffectTpl().getValueCoef());
		
		double baseAttack = 0d;
		boolean isDefault = this.getEffectTpl().isDefaultAttack();
		boolean isStrength = this.getEffectTpl().isPhsicalAttack();
		boolean isMagic = this.getEffectTpl().isMagicAttack();
		if(isDefault){
			//默认-取面板攻击
			baseAttack = BattleCalculateHelper.getBaseAttack(doSkillOwner);
		}else if(isStrength){
			baseAttack = BattleCalculateHelper.getBaseAttackByType(doSkillOwner, PetAttackType.STRENGTH );
		}else if(isMagic){
			baseAttack = BattleCalculateHelper.getBaseAttackByType(doSkillOwner, PetAttackType.INTELLECT );
		}
		
		double part2 = EffectHelper.int2Double(getEffectTpl().getValueAdd());
		//骑宠加成
		boolean isPetHorseAdd = target.getPetHorseAddMap().containsValue(this.skillId);
		double part3 = isPetHorseAdd ? 
				EffectHelper.int2Double(
						Globals.getTemplateCacheService().getBattleTemplateCache().getFinalSkillValue(
								target.getPetHorseSkillLevel(), target.getPetHorseAddTpl(target, this.skillId))
						) * target.getPetHorseSkillLevel()
				: 0;
		
		double finalValue = (part1 * baseAttack + part2) * (1 + part3);
		//如果未负数，则取负数
		if (getEffectTpl().isNegative()) {
			finalValue = -finalValue;
		}
		return (int)finalValue;
	}
	
}
