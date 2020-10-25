package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.AbstractAction;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.helper.TargetHelper;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;

public class Revive extends AbstractAction {

	public Revive(int effectId) {
		super(effectId, EffectType.Revive, new Phase[] {Phase.ACTION_TARGET, Phase.ACTION_EXECUTE});
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
		for (FightUnit target : action.getTargets(this)) {
			if (!target.isDead()) {
				continue;
			}
			
			//非法状态的不能复活
			if (!target.canOp()) {
				continue;
			}
			
			//复活目标单位
			double hpPercent = calcRecoverPercent(target);
			double hpMax = target.getAttr(BattleDef.HP + BattleDef.MAX);
			int recoverHp = (int)(hpMax * hpPercent);
			if (recoverHp <= 0) {
				//至少有1滴血
				recoverHp = 1;
			}
			if (recoverHp > hpMax) {
				recoverHp = (int)hpMax;
			}
			
			//复活参数设置
			target.getReviveAttrMap().put(BattleDef.HP, Double.valueOf(recoverHp));
			
			//复活的战报
			ReportItem r = ReportItem.valueOf(target, this);
			r.updateAction(BattleReportDefine.REPORT_ITEM_REVIVE, Boolean.valueOf(true));
			r.updateAttr(BattleReportDefine.REPORT_ITEM_HP, recoverHp);
			
			content.add(r);
		}

		if (content.isEmpty()) {
			return null;
		}
		return content;
	}
	
	private double calcRecoverPercent(FightUnit target) {
		//复活后恢复生命百分比=初始恢复系数
		double per = EffectHelper.int2Double((int)getEffectTpl().getValueBase());
		return per;
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
