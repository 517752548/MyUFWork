package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.FightUnitStatus;
import com.imop.lj.gameserver.battle.effect.AbstractAction;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.battle.helper.TargetHelper;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;
import com.imop.lj.gameserver.common.Globals;

/**
 * 逃跑技能
 * @author yu.zhao
 *
 */
public class Escape extends AbstractAction {

	public Escape(int effectId) {
		super(effectId, EffectType.Escape, new Phase[] {Phase.ACTION_TARGET, Phase.ACTION_EXECUTE});
	}

	@Override
	protected List<ReportItem> doActionExecute(Phase paramPhase, Action action) {
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("call " + effectId + ".doActionExecute()");
		}
		
		if (TargetHelper.targetNotFound(action, this)) {
			return null;
		}
		
		List<ReportItem> content = new ArrayList<ReportItem>();
		ReportItem report = ReportItem.valueOf(getOwner(), this);
		
		boolean isEscape = false;
		boolean canEscape = canEscape();
		if (!canEscape) {
			//混乱，不能逃跑
			report.updateAction(BattleReportDefine.REPORT_ITEM_ESCAPE, Boolean.valueOf(false));
		} else {
			//判断概率是否命中
			double prob = getEscapeProb();
			
			if (this.logger.isDebugEnabled()) {
				this.logger.debug("逃跑概率为 " + prob);
			}
			
			boolean isHit = RandomUtils.isHit(prob, getOwner().getRandom());
			if (isHit) {
				isEscape = true;
			} else {
				report.updateAction(BattleReportDefine.REPORT_ITEM_ESCAPE, Boolean.valueOf(false));
			}
			
			//记录逃跑次数
			getOwner().addEscapeTimes();
		}
		//是否逃跑成功
		if (isEscape) {
			//所有己方的人，都变为逃跑状态
			for (FightUnit target : action.getTargets(this)) {
				//增加逃跑状态
				target.addStatus(FightUnitStatus.ESCAPE);
				
				ReportItem ri = ReportItem.valueOf(target, this);
				ri.updateAction(BattleReportDefine.REPORT_ITEM_ESCAPE, Boolean.valueOf(true));
				content.add(ri);
			}
			
			if (this.logger.isDebugEnabled()) {
				this.logger.debug("逃跑成功！");
			}
			
		} else {
			//逃跑失败
			content.add(report);
			
			if (this.logger.isDebugEnabled()) {
				this.logger.debug("逃跑失败！");
			}
		}
		
		return content;
	}
	
	protected boolean canEscape() {
		//非混乱，非眩晕状态， 才能逃跑
		return !getOwner().hasStatus(FightUnitStatus.CHAOS) && !getOwner().hasStatus(FightUnitStatus.DISABLE);
	}
	
	protected double getEscapeProb() {
		double prob = Globals.getGameConstants().getBattleEscapeProbBase();
		int times = getOwner().getEscapeTimes();
		prob += times * Globals.getGameConstants().getBattleEscapeProbAdd();
		return prob;
	}

	@Override
	protected List<ReportItem> doActionStart(Phase paramPhase,
			Action paramAction) {
		return null;
	}
	
	@Override
	protected List<ReportItem> doActionEnd(Phase paramPhase, Action paramAction) {
		return null;
	}
	
}
