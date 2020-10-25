package com.imop.lj.gameserver.battle.effect.impl.action;

import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.PetDef.PetAttackType;

/**
 * 侠客效果
 * 
 */
public class Fumo3Main extends AttackCoef {

	public Fumo3Main(int effectId) {
		super(effectId);
	}
	
	@Override
	protected int getAttackerAttack(FightUnit attacker, FightUnit defender) {
		//伤害 = ((初始数值*攻击力+增量*等级层数对应值) * (1 + 损失生命/生命上限)) * (1 + 骑宠加成)
		//其中 损失生命/生命上限结果的正负号由附加参数1决定
		double baseCoef = EffectHelper.int2Double((int)getEffectTpl().getValueBase());
		
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
		
		double valueAdd = EffectHelper.int2Double(getEffectTpl().getValueAdd());
		//镶嵌的仙符效果取效果等级
		int skillLevel = isEmbedEffect() ? getEffectLevel() : getSkillLevel();
		double part2 =  Math.abs(attacker.getAttr(BattleDef.HP + BattleDef.MAX) - attacker.getAttr(BattleDef.HP));
		double part3 =  attacker.getAttr(BattleDef.HP + BattleDef.MAX);
		double part4 = part2 / part3;
		//读取配置决定正负
		if(getEffectTpl().getExtraCoef1() == 1){
			part4 = - part4;
		}
		//骑宠加成
		boolean isPetHorseAdd = attacker.getPetHorseAddMap().containsValue(this.skillId);
		double part5 = isPetHorseAdd ? 
				EffectHelper.int2Double(
						Globals.getTemplateCacheService().getBattleTemplateCache().getFinalSkillValue(
								attacker.getPetHorseSkillLevel(), attacker.getPetHorseAddTpl(attacker, this.skillId))
						) * attacker.getPetHorseSkillLevel()
				: 0;
		
		int finalAtk = (int)(( (baseCoef * baseAttack + valueAdd * skillLevel) * (1 + part4) )  * (1 + part5));
		
		return finalAtk;
	}
	
	
}