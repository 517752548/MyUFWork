package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectValueType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.Context;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.model.RealDamage;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;

/**
 * 反伤
 *
 */
public class DefenceWithValue extends DefenceAttack {

	public DefenceWithValue(int effectId) {
		super(effectId);
	}

	@Override
	protected int getAttackerAttack(FightUnit attacker, FightUnit defender) {
		//攻击方攻击力不计算反伤的伤害,伤害在执行的时候计算
		return 0;
	}
	
	@Override
	protected List<ReportItem> doExecute(Phase phase, Object context) {
		Action action = (Action) context;
		FightUnit owner = getOwner();
		FightUnit target = action.getOwner();

		Context ctx = action.getContext();
		// 反伤的 	伤害 owner对action.getOwner()
		int val = getDamageValue(owner, target);
		int damage = -val;
		
		ReportItem item = ReportItem.valueOf(target, this);
		
		RealDamage realDamage = new RealDamage();
		//计算 伤害吸收盾等的伤害
		BattleCalculateHelper.onAttackEnemy(ctx, null, this, owner, target, damage, item, realDamage);
		
		item.updateAction(BattleReportDefine.REPORT_ITEM_DEFENCE_WITH_VALUE, Boolean.TRUE);
		List<ReportItem> ret = new ArrayList<ReportItem>();
		ret.add(item);
		
		// 对攻击者造成(本次扣血*15%)的伤害。
		int part1 = realDamage.getRealDamage();
		double part2 = EffectHelper.int2Double(getEffectTpl().getExtraCoef1());
		//镶嵌的仙符效果取效果等级
//		int skillLevel = isEmbedEffect() ? getEffectLevel() : getSkillLevel();
		int value = (int) ( part1 * part2);

		EffectValueType evType = getEffectTpl().getEffectValueType();
		ctx.put(owner, EffectHelper.getAttrKey(owner, evType), Integer.valueOf(value));
		item.updateAttr(EffectHelper.getReportAttrKey(owner, evType), Integer.valueOf(value));
		ret.add(item);
		
		return ret;
	}
	
	
}
