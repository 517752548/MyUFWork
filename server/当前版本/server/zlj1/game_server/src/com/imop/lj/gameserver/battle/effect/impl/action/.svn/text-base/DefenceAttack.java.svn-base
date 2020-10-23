package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.Context;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.FightUnitStatus;
import com.imop.lj.gameserver.battle.effect.AbstractEffect;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;
import com.imop.lj.gameserver.common.Globals;

/**
 * 反击
 * @author yu.zhao
 *
 */
public class DefenceAttack extends AbstractEffect {

	public DefenceAttack(int effectId) {
		super(effectId, EffectType.DefenceAttack, new Phase[]{Phase.ACTION_DEFENCE});
	}

	@Override
	public boolean isVaild(Phase phase, Object context) {
		if (phase != Phase.ACTION_DEFENCE) {
			return false;
		}

		Action action = (Action) context;
		FightUnit owner = getOwner();
		if (action.getOwner() == owner) {
			return false;
		}
		if (action.getTargets() == null) {
			return false;
		}
		if (!action.getTargets().contains(owner)) {
			return false;
		}
		
		//之前的行动者对该玩家造成了伤害
		if (action.getContext().get(owner, BattleDef.HP) == null) {
			return false;
		}
		int detalHp = (int)(action.getContext().get(owner, BattleDef.HP));
		//给目标回血的不算
		if (detalHp > 0) {
			return false;
		}
		
		//要反击的人还没挂
		if (owner.getHp() + detalHp <= 0) {
			return false;
		}
		//且没被晕
		if (owner.hasStatus(FightUnitStatus.DISABLE)) {
			return false;
		}
		
		//不是近身
		if(!getEffectTpl().isNearby()){
			return false;
		}

		// 反击概率
		double blockRate = EffectHelper.int2Double(getEffectTpl().getValueCoef());
		if (!RandomUtils.isHit(blockRate, owner.getRandom())) {
			return false;
		}
		
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("效果[{}]:反击触发，机率[{}]", this.getEffectTpl().getId(), Double.valueOf(blockRate));
		}
		
		//反击的时间单独算
		String composeId = getOwner().getModelId() + getSkillId();
		action.addActionTime(Globals.getTemplateCacheService().getBattleTemplateCache().getSkillPerformTime(composeId));
		
		return true;
	}

	@Override
	protected int getAttackerAttack(FightUnit attacker, FightUnit defender) {
		//攻击力=(10%*技能等级)*攻击力+增量*技能等级
		double baseCoef = EffectHelper.int2Double((int)getEffectTpl().getValueBase());
		//镶嵌的仙符效果取效果等级
		int skillLevel = isEmbedEffect() ? getEffectLevel() : getSkillLevel();
		double baseAttack = BattleCalculateHelper.getBaseAttack(attacker);
		double valueAdd = EffectHelper.int2Double(getEffectTpl().getValueAdd());
		int finalAtk = (int)(baseCoef * skillLevel * baseAttack + valueAdd * skillLevel);
		return finalAtk;
	}
	
	
	@Override
	protected List<ReportItem> doExecute(Phase phase, Object context) {
		Action action = (Action) context;
		FightUnit owner = getOwner();
		FightUnit target = action.getOwner();

		Context ctx = action.getContext();
		// 反击伤害 owner对action.getOwner()
		int val = getDamageValue(owner, target);
		int damage = -val;
		
		ReportItem item = ReportItem.valueOf(target, this);
		
		List<ReportItem> atkReportList = BattleCalculateHelper.onAttackEnemy(ctx, null, this, owner, target, damage, item, null);
		
		// 反击
		item.updateAction(BattleReportDefine.REPORT_ITEM_DEFENCE_ATTACK, Boolean.TRUE);
		List<ReportItem> ret = new ArrayList<ReportItem>();
		ret.add(item);
		if (atkReportList != null && !atkReportList.isEmpty()) {
			ret.addAll(atkReportList);
		}
		return ret;
	}
	
}
