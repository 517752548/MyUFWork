package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.effect.impl.buff.BaseBuffEffect;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.report.ReportItem;

/**
 * 烈焰风暴主效果
 * 
 */
public class LieyanMain extends AttackCoef {
	private int debuffNum;

	public LieyanMain(int effectId) {
		super(effectId);
	}

	@Override
	protected int getAttackerAttack(FightUnit attacker, FightUnit defender) {
		//攻击力=[（初始伤害系数+心法提升伤害系数*心法等级）*法术强度+等级提升技能伤害加值*技能等级]*(1+DEBUFF个数*DEBUFF伤害修正系数）。
		double baseCoef = EffectHelper.int2Double((int)getEffectTpl().getValueBase());
		double mindCoef = EffectHelper.int2Double(getEffectTpl().getMindCoef());
		double skillLevelCoef = EffectHelper.int2Double(getEffectTpl().getValueAdd());
		double extra1Coef = EffectHelper.int2Double(getEffectTpl().getExtraCoef1());
		
		double part1 = (baseCoef + mindCoef * attacker.getMindLevel()) * BattleCalculateHelper.getBaseAttack(attacker);
		//镶嵌的仙符效果取效果等级
		double part2 = skillLevelCoef * (isEmbedEffect() ? getEffectLevel() : getSkillLevel());
		double part3 = 1 + debuffNum * extra1Coef;
		int finalAtk = (int)((part1 + part2) * part3);
		return finalAtk;
	}
	
	@Override
	protected List<ReportItem> beforeCalcDamage(FightUnit target) {
		if (target == null) {
			Loggers.battleLogger.error("target is null!");
			return null;
		}
		
		debuffNum = 0;
		//清除target身上的负面buff，保存个数，计算伤害的时候用
		List<ReportItem> reportList = new ArrayList<ReportItem>();
		List<IEffect> addEList = new ArrayList<IEffect>();
		addEList.addAll(target.getAddEffectList());
		for (IEffect e : addEList) {
			if (e.isBuff() && e.getEffectTpl().isBad()) {
				//移除负面buff
				BaseBuffEffect buff = (BaseBuffEffect)e;
				List<ReportItem> r = buff.remove();
				reportList.addAll(r);
				//增加计数
				debuffNum++;
			}
		}
		return reportList;
	}
}