package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectValueType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.AbstractAction;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.helper.TargetHelper;
import com.imop.lj.gameserver.battle.report.ReportItem;

/**
 * 一次出手中增加攻击类属性，仙符数值型
 */
public class AddAttrInAction extends AbstractAction {

	public AddAttrInAction(int effectId) {
		super(effectId, 
			EffectType.AddAttrInAction, new Phase[]{Phase.ACTION_TARGET, Phase.ACTION_TARGET_AFTER, Phase.ACTION_END});
	}

	/**
	 * 行动开始阶段
	 */
	@Override
	protected List<ReportItem> doActionTargetAfter(Phase phase, Action action) {
		FightUnit owner = getOwner();
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
			
			//数值为正数，即在行动开始的时候增加
			int value = getAddValue(owner, target);
			
			EffectValueType evType = getEffectTpl().getEffectValueType();
			String attrKey = EffectHelper.getAttrKey(target, evType);

			//目标属性直接修改
			target.updateAttr(attrKey, value);
			
			//战报
			item.updateAttr(EffectHelper.getReportAttrKey(target, evType), Integer.valueOf(value));
			content.add(item);
		}

		if (content.isEmpty()) {
			return null;
		}

		return content;
	}

	/**
	 * 行动结束阶段
	 */
	@Override
	protected List<ReportItem> doActionEnd(Phase phase, Action action) {
		FightUnit owner = getOwner();
		if (TargetHelper.targetNotFound(action, this)) {
			// 一般不会出现这种问题
			return null;
		}
		
		for (FightUnit target : action.getTargets(this)) {
			if (Loggers.battleLogger.isDebugEnabled()) {
				logger.debug("行动方:" + action.getOwner() + "FightUnit id: " + action.getOwner().getIdentifier() + " tplId :" + action.getOwner().getTplId());
				logger.debug("被动方:" + target + "FightUnit id: " + target.getIdentifier() + " tplId :" + target.getTplId());
			}
			
			//数值为负值，即在行动结束的时候扣除
			int value = -getAddValue(owner, target);
			
			EffectValueType evType = getEffectTpl().getEffectValueType();
			String attrKey = EffectHelper.getAttrKey(target, evType);

			//目标属性直接修改
			target.updateAttr(attrKey, value);
		}

		return null;
	}
	
	protected int getAddValue(FightUnit owner, FightUnit target) {
		//增加属性数值=初始数值 + 增量数值 * 效果等级
		double base = getEffectTpl().getValueBase() + 
				getEffectTpl().getValueAdd() * getEffectLevel();
		return (int)base;
	}
	
	@Override
	protected List<ReportItem> doActionStart(Phase paramPhase,
			Action paramAction) {
		return null;
	}
	
	@Override
	protected List<ReportItem> doActionExecute(Phase phase, Action action) {
		return null;
	}
	
}