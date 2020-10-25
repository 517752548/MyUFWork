package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.BattleDef.BuffLabel;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.PetDef.PetAttackType;

/**
 * 术士效果,和四相决的诅咒buff有关
 * 
 */
public class CurseAttack extends AttackCoef {
	
	/** 诅咒buff个数*/
	private int curseBuffNum;

	public CurseAttack(int effectId) {
		super(effectId);
	}
	
	@Override
	protected int getAttackerAttack(FightUnit attacker, FightUnit defender) {
		//伤害=(（初始数值*面板攻击力+增量*等级层数对应值）*（1+附加参数1*诅咒buff个数）) * (1 + 骑宠加成)
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
		double part2 =  EffectHelper.int2Double((int)getEffectTpl().getExtraCoef1());
		//骑宠加成
		boolean isPetHorseAdd = attacker.getPetHorseAddMap().containsValue(this.skillId);
		double part3 = isPetHorseAdd ? 
				EffectHelper.int2Double(
						Globals.getTemplateCacheService().getBattleTemplateCache().getFinalSkillValue(
								attacker.getPetHorseSkillLevel(), attacker.getPetHorseAddTpl(attacker, this.skillId))
						) * attacker.getPetHorseSkillLevel()
				: 0;
		
		int finalAtk = (int)(( (baseCoef * baseAttack + valueAdd * skillLevel) * (1 + part2 * curseBuffNum) ) * (1 + part3));
		
		return finalAtk;
	}
	
	
	@Override
	protected List<ReportItem> beforeCalcDamage(FightUnit target) {
		if (target == null) {
			Loggers.battleLogger.error("target is null!");
			return null;
		}
		
		List<ReportItem> reportList = new ArrayList<ReportItem>();
		curseBuffNum = 0;
		//保存诅咒buff个数，计算伤害的时候用
		List<IEffect> addEList = new ArrayList<IEffect>();
		addEList.addAll(target.getAddEffectList());
		for (IEffect e : addEList) {
			if (e.isBuff() 
					&& e.getEffectTpl().isBad()
					&& e.getEffectTpl().getExtraCoef4() == BuffLabel.CURSE.getIndex()) {
				//增加计数
				curseBuffNum++;
			}
		}
		
		
		return reportList;
	}
	
	
}