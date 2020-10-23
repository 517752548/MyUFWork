package com.imop.lj.gameserver.battle.logic;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.report.IReportRecord;
import com.imop.lj.gameserver.battle.report.RecordContent;
import com.imop.lj.gameserver.battle.report.ReportItem;

/**
 * 主要记录战斗各个状态
 * @author yuanbo.gao
 *
 */
public abstract class LogicBase {
	protected final Logger logger = Loggers.battleLogger;
	//改写record
	protected IReportRecord reportRecord;

	public LogicBase(IReportRecord reportRecord) {
		this.reportRecord = reportRecord;
	}

	public IReportRecord getReportRecord() {
		return reportRecord;
	}

	protected void saveReports(Phase phase, List<RecordContent> reports) {
		if (reports == null || reports.size() == 0) {
			return;
		}
		getReportRecord().addToContent(phase, reports);
	}
	
	protected void saveReport(Phase phase, RecordContent report) {
		if (report == null) {
			return;
		}
		getReportRecord().addToContent(phase, report);
	}

	protected List<RecordContent> executeEffects(Phase phase, List<FightUnit> units) {
		List<IEffect> effects = new ArrayList<IEffect>();
		for (FightUnit u : units) {
			effects.addAll(u.getEffectsForExec(phase));
			//新增防御技能，需要在回合开始时释放，效果为给自己加防御buff
			effects.addAll(u.getSelSkillEffectList(phase));
		}
		Collections.sort(effects);

		List<RecordContent> result = new ArrayList<RecordContent>();
		for (IEffect e : effects) {
			if (e.isVaild(phase, this)) {
				List<ReportItem> reportItems = e.execute(phase, this);
				if ((reportItems != null) && (!reportItems.isEmpty())) {
					int skillId = e.getSkillId();
					String owner = e.getOwner().getIdentifier();
					RecordContent recordContent = new RecordContent(owner, skillId, reportItems);

					result.add(recordContent);
				}
			}
		}
		return result;
	}
	
	/**
	 * 执行效果并实时保存战报记录
	 * 
	 * @param phase
	 * @param units
	 */
	protected void executeEffectsAndImmeSaveReport(Phase phase, List<FightUnit> units) {
		List<IEffect> effects = new ArrayList<IEffect>();
		for (FightUnit u : units) {
			effects.addAll(u.getEffectsForExec(phase));
		}
		Collections.sort(effects);

		for (IEffect e : effects) {
			if (e.isVaild(phase, this)) {
				List<ReportItem> reportItems = e.execute(phase, this);
				if ((reportItems != null) && (!reportItems.isEmpty())) {
					int skillId = e.getSkillId();
					String owner = e.getOwner().getIdentifier();
					RecordContent recordContent = new RecordContent(owner, skillId, reportItems);
					getReportRecord().addToContent(phase, recordContent);
				}
			}
		}
	}
	
}