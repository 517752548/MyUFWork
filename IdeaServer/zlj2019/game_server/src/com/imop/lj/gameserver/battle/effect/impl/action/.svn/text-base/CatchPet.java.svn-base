package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.AbstractAction;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.battle.helper.TargetHelper;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.template.PetTemplate;

/**
 * 捕捉宠物技能
 * @author yu.zhao
 *
 */
public class CatchPet extends AbstractAction {

	public CatchPet(int effectId) {
		super(effectId, EffectType.CatchPet, new Phase[] {Phase.ACTION_TARGET, Phase.ACTION_EXECUTE});
	}

	@Override
	protected List<ReportItem> doActionStart(Phase paramPhase,
			Action paramAction) {
		return null;
	}
	
	@Override
	protected List<ReportItem> doActionExecute(Phase paramPhase,
			Action action) {
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("call " + effectId + ".doActionExecute()");
		}
		
		if (TargetHelper.targetNotFound(action, this)) {
			return null;
		}

		List<ReportItem> content = new ArrayList<ReportItem>();
		for (FightUnit target : action.getTargets(this)) {
			ReportItem ri = null;
			double prob = getCatchProb(target);
			boolean isHit = RandomUtils.isHit(prob, getOwner().getRandom());
			
			//命中，则抓捕成功
			if (isHit) {
				ri = targetBeCaught(target);
			} else {
				//抓捕失败
				ri = ReportItem.valueOf(target, this);
				ri.updateAction(BattleReportDefine.REPORT_ITEM_BE_CAUGHT, Boolean.valueOf(false));
			}
			content.add(ri);
			
			//每次捕捉一个
			break;
		}

		if (content.isEmpty()) {
			return null;
		}
		return content;
	}
	
	private ReportItem targetBeCaught(FightUnit target) {
		//被捕捉的处理
		target.onBeCaught(getOwner().getOwnerId());
		
		//被捕捉的行为记录
		ReportItem reportItem = ReportItem.valueOf(target, this);
		reportItem.updateAction(BattleReportDefine.REPORT_ITEM_BE_CAUGHT, Boolean.valueOf(true));
		return reportItem;
	}

	@Override
	protected List<ReportItem> doActionEnd(Phase paramPhase, Action paramAction) {
		return null;
	}

	protected double getCatchProb(FightUnit target) {
		PetTemplate petTpl = Globals.getTemplateCacheService().get(target.getCatchPetId(), PetTemplate.class);
		double prob = Globals.getGameConstants().getPetCatchProb();
		if (petTpl.getCatchProb() > 0) {
			prob = 1.0D * petTpl.getCatchProb() / Globals.getGameConstants().getRandomBase();
		}
		return prob;
	}
	
}
