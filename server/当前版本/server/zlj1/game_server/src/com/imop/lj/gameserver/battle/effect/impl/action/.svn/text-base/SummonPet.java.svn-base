package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.AbstractAction;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;
import com.imop.lj.gameserver.common.Globals;

/**
 * 召唤宠物
 * @author yu.zhao
 *
 */
public class SummonPet extends AbstractAction {

	public SummonPet(int effectId) {
		super(effectId, EffectType.SummonPet, new Phase[] {Phase.ACTION_TARGET, Phase.ACTION_EXECUTE});
	}

	@Override
	protected List<ReportItem> doActionExecute(Phase paramPhase, Action action) {
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("call " + effectId + ".doActionExecute()");
		}
		
		List<ReportItem> content = new ArrayList<ReportItem>();
		ReportItem report = ReportItem.valueOf(getOwner(), this);
		
		boolean flag = false;
		FightUnit summonPet = summonPet(action);
		if (summonPet != null) {
			flag = true;
			//召唤成功
			report.updateAction(BattleReportDefine.REPORT_ITEM_SUMMON_PET_RESULT, Boolean.valueOf(true));
			report.updateAttr(BattleReportDefine.REPORT_ITEM_SUMMON_PET, summonPet.toMap());
			
			//在该轮的action列表中移除之前的宠物
			FightUnit curPetFu = action.getRound().getBattle().getBattleFU(getOwner().isAttacker(), false, getOwner().getOwnerId());
			if (curPetFu != null) {
				action.getRound().removeFightUnitFromSequence(curPetFu);
			}
		} else {
			//召唤失败
			report.updateAction(BattleReportDefine.REPORT_ITEM_SUMMON_PET_RESULT, Boolean.valueOf(false));
		}
		content.add(report);
		
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("召唤宠物结果=" + flag);
		}
		
		return content;
	}
	
	protected FightUnit summonPet(Action action) {
		FightUnit summonPet = Globals.getBattleService().summonPet(action.getRound().getBattle(), 
				getOwner().isAttacker(), getOwner().getOwnerId(), getOwner().getSummonPetId());
		return summonPet;
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
