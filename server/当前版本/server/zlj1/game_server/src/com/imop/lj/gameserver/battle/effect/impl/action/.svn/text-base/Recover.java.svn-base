package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectValueType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.Context;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.AbstractAction;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.helper.TargetHelper;
import com.imop.lj.gameserver.battle.report.ReportItem;

/**
 * 回复
 */
public class Recover extends AbstractAction {

	public Recover(int effectId) {
		super(effectId, 
			EffectType.Recover, new Phase[]{Phase.ACTION_TARGET, Phase.ACTION_EXECUTE});
	}

	@Override
	protected List<ReportItem> doActionExecute(Phase phase, Action action) {
		FightUnit owner = getOwner();
		Context context = action.getContext();
		List<ReportItem> content = new ArrayList<ReportItem>();
		
		if (TargetHelper.targetNotFound(action, this)) {
			// 一般不会出现这种问题
			return null;
		}
		
		for (FightUnit target : action.getTargets(this)) {
			ReportItem item = ReportItem.valueOf(target, this);
			
			if(Loggers.battleLogger.isDebugEnabled()){
				logger.debug("行动方:" + action.getOwner() + "FightUnit id: " + action.getOwner().getIdentifier() + " tplId :" + action.getOwner().getTplId());
				logger.debug("被动方:" + target + "FightUnit id: " + target.getIdentifier() + " tplId :" + target.getTplId());
			}
			
			int value = getRecoverValue(owner, target);

			EffectValueType evType = getEffectTpl().getEffectValueType();
			context.put(target, EffectHelper.getAttrKey(target, evType), Integer.valueOf(value));
			item.updateAttr(EffectHelper.getReportAttrKey(target, evType), Integer.valueOf(value));
			content.add(item);
		}

		if (content.isEmpty()) {
			return null;
		}

		return content;
	}
	
	protected int getRecoverValue(FightUnit owner, FightUnit target) {
		//恢复值=（初始恢复系数+心法提升恢复系数*心法等级）*攻击力+等级提升技能恢复加值*技能等级
		double baseCoef = EffectHelper.int2Double((int)getEffectTpl().getValueBase());
		double mindCoef = EffectHelper.int2Double(getEffectTpl().getMindCoef());
		double skillLevelCoef = EffectHelper.int2Double(getEffectTpl().getValueAdd());
		
		double part1 = (baseCoef + mindCoef * owner.getMindLevel()) * BattleCalculateHelper.getBaseAttack(owner);
		//镶嵌的仙符效果取效果等级
		double part2 = skillLevelCoef * (isEmbedEffect() ? getEffectLevel() : getSkillLevel());
		int finalAtk = (int)(part1 + part2);
		return finalAtk;
	}
	
	/**
	 * 行动开始阶段
	 */
	@Override
	protected List<ReportItem> doActionStart(Phase phase, Action action) {
		return null;
	}

	/**
	 * 行动结束阶段
	 */
	@Override
	protected List<ReportItem> doActionEnd(Phase phase, Action action) {
		return null;
	}
}