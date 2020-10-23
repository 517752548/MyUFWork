package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.LabelCatalog;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.AbstractAction;
import com.imop.lj.gameserver.battle.effect.impl.buff.BaseBuffEffect;
import com.imop.lj.gameserver.battle.helper.EffectFactory;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;

/**
 * 嘲讽技能
 */
public class Taunt extends AbstractAction {

	public Taunt(int effectId) {
		super(effectId, EffectType.Taunt, new Phase[] {Phase.ACTION_TARGET, Phase.ACTION_EXECUTE});
	}

	
	@Override
	public boolean isVaild(Phase phase) {
		if (!super.isVaild(phase)) {
			return false;
		}
		
		//判断概率是否命中
		double prob = calcProb();
		return RandomUtils.isHit(prob, getOwner().getRandom());
	}
	
	/**
	 * 概率
	 * @return
	 */
	protected double calcProb() {
		//几率= 附加参数1(等级不同, 参数越高)
		double prob = EffectHelper.int2Double((int)getEffectTpl().getExtraCoef1());
		return prob;
	}
	
	@Override
	protected List<ReportItem> doActionExecute(Phase paramPhase, Action action) {
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("call " + effectId + ".doActionExecute()");
		}
		
		List<FightUnit> tList = action.getTargets(this);
		//目前只有一个目标
		FightUnit target = null;
		if (tList != null && !tList.isEmpty()) {
			target = tList.get(0);
		}
		
		List<ReportItem> content = new ArrayList<ReportItem>();
		
		BaseBuffEffect buffEffect = EffectFactory.buildBuffEffect(this);
		List<ReportItem> report = buffEffect.addTo(target, 0, null);
		
		//侠义之心标记
		if(getOwner().getChivalricTimes() > 0){
			ReportItem item = ReportItem.valueOf(getOwner(), this);
			item.updateAction(BattleReportDefine.REPORT_ITEM_CHIVALRIC_ID, LabelCatalog.CHIVALRIC.getIndex());
			item.updateAction(BattleReportDefine.REPORT_ITEM_CHIVALRIC, Boolean.valueOf(true));
			content.add(item);
		}

		content.addAll(report);
		
		if (content.isEmpty()) {
			return null;
		}
		return content;
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
