package com.imop.lj.gameserver.battle.effect.impl.buff;

import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.PetDef.PetAttackType;

/**
 * 伤害吸收盾值为0的时候攻击
 *
 */
public class HurtShieldBuffEffectAttack extends HurtShieldBuffEffect {

	/**
	 * 记录伤害吸收盾初始吸收值,反击攻击者的时候用
	 */
	private int initValue;
	
	public HurtShieldBuffEffectAttack(int effectId) {
		super(effectId);
	}
	
	@Override
	protected int calcBuffAddValue(FightUnit target, FightUnit doSkillOwner, int value) {
		//盾吸收的伤害=(（盾初始系数）*攻击力+技能等级加成*技能等级) * (1 + 骑宠加成)
		double addValue = 0;
		double part1 = EffectHelper.int2Double((int) getEffectTpl().getValueBase());
		//镶嵌的仙符效果取效果等级
		double part2 = EffectHelper.int2Double(getEffectTpl().getValueAdd()) * (isEmbedEffect() ? getEffectLevel() : getSkillLevel()); 
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
		//骑宠加成
		boolean isPetHorseAdd = target.getPetHorseAddMap().containsValue(this.skillId);
		double part3 = isPetHorseAdd ? 
				EffectHelper.int2Double(
						Globals.getTemplateCacheService().getBattleTemplateCache().getFinalSkillValue(
								target.getPetHorseSkillLevel(), target.getPetHorseAddTpl(target, this.skillId))
						) * target.getPetHorseSkillLevel()
				: 0;
		
		addValue = (part1 * baseAttack + part2) * (1 + part3);
//		//如果未负数，则取负数
//		if (getEffectTpl().isNegative()) {
//			addValue = -addValue;
//		}
		
		initValue = (int)addValue;
		
		return (int)addValue;
	}

	public int getInitValue() {
		return initValue;
	}

	public void setInitValue(int initValue) {
		this.initValue = initValue;
	}
	
}
