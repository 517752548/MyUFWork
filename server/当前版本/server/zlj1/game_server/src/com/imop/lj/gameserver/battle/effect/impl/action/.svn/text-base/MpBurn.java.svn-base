package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.List;

import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.Context;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.model.RealDamage;
import com.imop.lj.gameserver.battle.report.ReportItem;

/**
 * 法力灼烧
 * 
 */
public class MpBurn extends AttackCoef {

	public MpBurn(int effectId) {
		super(effectId);
	}
	
	@Override
	protected int getAttackerAttack(FightUnit attacker, FightUnit defender) {
		//攻击力=80%*攻击力+增量*技能等级
		double baseCoef = EffectHelper.int2Double((int)getEffectTpl().getValueBase());
		double baseAttack = BattleCalculateHelper.getBaseAttack(attacker);
		double valueAdd = EffectHelper.int2Double(getEffectTpl().getValueAdd());
		//镶嵌的仙符效果取效果等级
		int skillLevel = isEmbedEffect() ? getEffectLevel() : getSkillLevel();
		int finalAtk = (int)(baseCoef * baseAttack + valueAdd * skillLevel);
		return finalAtk;
	}
	
	@Override
	protected List<ReportItem> afterCost(Context context, Action action, IEffect effect, FightUnit owner,
			FightUnit target, int damageHp, ReportItem r, RealDamage realDamage) {
		return BattleCalculateHelper.onAttackEnemyMp(context, action, effect, owner, target, damageHp, r, realDamage);
	}
	
	@Override
	protected void afterDamageNotDead(Action action, FightUnit target, FightUnit owner, int realDamage, List<ReportItem> content, int preCostValue) {
		ReportItem r = ReportItem.valueOf(target,this);
		//对其造成扣除法力值10%的伤害
		int value = (int) (realDamage * EffectHelper.int2Double(getEffectTpl().getValueCoef()));
		List<ReportItem> atkReportList = BattleCalculateHelper.onAttackEnemy(action.getContext(), action, this, owner, target, value, r, null);
		
		if(atkReportList != null && !atkReportList.isEmpty()){
			content.addAll(atkReportList);
		}
		
	}
	
}