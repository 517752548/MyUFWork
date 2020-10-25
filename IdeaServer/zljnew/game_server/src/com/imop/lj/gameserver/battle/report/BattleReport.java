package com.imop.lj.gameserver.battle.report;

import java.util.Collection;
import java.util.HashMap;
import java.util.Map;

import com.imop.lj.gameserver.battle.core.BattleDef.BattleResult;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.IBattle;

/**
 * 战斗所有相关记录
 * 
 * @author yuanbo.gao
 *
 */
public class BattleReport {
	private IBattle battle;
	private BattleReportRecord report;
	private BattleResult result;
	private Map<String, FightUnit> attackers;
	private Map<String, FightUnit> defenders;
	private Collection<FightUnit> initialAttackers;
	private Collection<FightUnit> initialDefenders;

	/** 战报Id */
	private long reportId;
	
	public static BattleReport valueOf(IBattle battle) {
		BattleReport result = new BattleReport();
		result.battle = battle;
		result.report = (BattleReportRecord)battle.getReportRecord();
		result.attackers = battle.getAttackers();
		result.initialAttackers = battle.getInitialAttackers();
		result.defenders = battle.getDefenders();
		result.initialDefenders = battle.getInitialDefenders();
		result.result = result.report.getBattleResult();
//		// 生成战报字符串
//		result.report.makeRecordStr();
		return result;
	}

	public IBattle getBattle() {
		return this.battle;
	}

	public void setBattle(IBattle battle) {
		this.battle = battle;
	}

	public BattleReportRecord getReport() {
		return report;
	}

	public void setReport(BattleReportRecord report) {
		this.report = report;
	}

	public BattleResult getResult() {
		return this.result;
	}

	public void setResult(BattleResult result) {
		this.result = result;
	}
	
	/**
	 * 获取以uuid为key的攻击方战斗对象map
	 * @return
	 */
	public Map<String, FightUnit> getAttackersWithUUIdKeyMap() {
		Map<String, FightUnit> map = new HashMap<String, FightUnit>();
		for (FightUnit fightUnit : getAttackers().values()) {
			map.put(fightUnit.getUuid(), fightUnit);
		}
		return map;
	}
	
	/**
	 * 获取以uuid为key的防守方战斗对象map
	 * @return
	 */
	public Map<String, FightUnit> getDefendersWithUUIdKeyMap() {
		Map<String, FightUnit> map = new HashMap<String, FightUnit>();
		for (FightUnit fightUnit : getDefenders().values()) {
			map.put(fightUnit.getUuid(), fightUnit);
		}
		return map;
	}

	public Map<String, FightUnit> getAttackers() {
		return this.attackers;
	}

	public void setAttackers(Map<String, FightUnit> attackers) {
		this.attackers = attackers;
	}

	public Map<String, FightUnit> getDefenders() {
		return this.defenders;
	}

	public void setDefenders(Map<String, FightUnit> defenders) {
		this.defenders = defenders;
	}

	public Collection<FightUnit> getInitialAttackers() {
		return this.initialAttackers;
	}

	public void setInitialAttackers(Collection<FightUnit> initialAttackers) {
		this.initialAttackers = initialAttackers;
	}

	public Collection<FightUnit> getInitialDefenders() {
		return this.initialDefenders;
	}

	public void setInitialDefenders(Collection<FightUnit> initialDefenders) {
		this.initialDefenders = initialDefenders;
	}
	
	public String buildBattleReport(){
		return toString();
	}

	public long getReportId() {
		return reportId;
	}

	public void setReportId(long reportId) {
		this.reportId = reportId;
	}
	
	/**
	 * 获取战斗轮数
	 * @return
	 */
	public int getRoundNum() {
		return report.getRoundNum();
	}
}