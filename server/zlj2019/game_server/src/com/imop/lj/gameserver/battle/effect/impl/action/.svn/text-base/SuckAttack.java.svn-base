package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.List;

import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectValueType;
import com.imop.lj.gameserver.battle.core.Context;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.helper.TargetHelper;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.PetDef.PetAttackType;

/**
 * 吸*攻击,可以是hp和mp等等
 * 
 */
public class SuckAttack extends AttackCoef {

	public SuckAttack(int effectId) {
		super(effectId);
	}
	
	@Override
	protected int getAttackerAttack(FightUnit attacker, FightUnit defender) {
		//攻击力=(X%攻击力+增量*技能等级) *(1 + 骑宠加成)
		double baseCoef = EffectHelper.int2Double((int)getEffectTpl().getValueBase());
		//镶嵌的仙符效果取效果等级
		int skillLevel = isEmbedEffect() ? getEffectLevel() : getSkillLevel();

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
		
		//骑宠加成
		boolean isPetHorseAdd = attacker.getPetHorseAddMap().containsValue(this.skillId);
		double part3 = isPetHorseAdd ? 
				EffectHelper.int2Double(
						Globals.getTemplateCacheService().getBattleTemplateCache().getFinalSkillValue(
								attacker.getPetHorseSkillLevel(), attacker.getPetHorseAddTpl(attacker, this.skillId))
						) * attacker.getPetHorseSkillLevel()
				: 0;
		
		int finalAtk = (int)( (baseCoef * baseAttack + valueAdd * skillLevel) * (1 + part3));
		return finalAtk;
	}
	
	@Override
	protected void afterDamageNotDead(Action action, FightUnit target, FightUnit owner, int realDamage, List<ReportItem> content, int preCostValue) {
		//和普攻一样的target
		Context context = action.getContext();
		if (TargetHelper.targetNotFound(action, this)) {
			return;
		}
		
		ReportItem item = ReportItem.valueOf(owner, this);
		//恢复值= 本次实际伤害的Y%
		int value = (int) (Math.abs(realDamage) * EffectHelper.int2Double(getEffectTpl().getValueCoef()));

		EffectValueType evType = getEffectTpl().getEffectValueType();
		context.put(owner, EffectHelper.getAttrKey(owner, evType), Integer.valueOf(value));
		item.updateAttr(EffectHelper.getReportAttrKey(owner, evType), Integer.valueOf(value));
		content.add(item);

		if (content.isEmpty()) {
			return ;
		}
		
	}
	
}