package com.imop.lj.gameserver.battle.report;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.slf4j.Logger;

import com.google.gson.Gson;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleResult;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.IBattle;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;

/**
 * 全局战斗信息
 * 
 * @author yuanbo.gao
 * 
 */
public class BattleReportRecord implements IReportRecord{
	Logger logger = Loggers.battleLogger;
	
	private IBattle battle;
	
	private List<RecordContent> battleStartReports;
	private List<RecordContent> battleEndReports;
//	private List<RoundReportRecord> roundRecodes;
	
	private BattleResult battleResult;
	
//	private BattleType battleType;
	
	private String recordStr = "";
	
	public BattleReportRecord() {
		this.battleStartReports = new ArrayList<RecordContent>();
		this.battleEndReports = new ArrayList<RecordContent>();
//		this.roundRecodes = new ArrayList<RoundReportRecord>();
	}
	
	@Override
	public void setBattle(IBattle battle) {
		this.battle = battle;
	}

	@Override
	public void addToContent(Phase phase, List<RecordContent> peportItems) {
		switch(phase){
		case BATTLE_START:
			battleStartReports.addAll(peportItems);
			break;
		case BATTLE_END:
			battleEndReports.addAll(peportItems);
			break;
		default:
			logger.error("BattleRecord add is error this phase is " + phase);
			break;
		}
	}
	
	@Override
	public void addToContent(Phase phase, RecordContent recordContent) {
		switch(phase){
		case BATTLE_START:
			battleStartReports.add(recordContent);
			break;
		case BATTLE_END:
			battleEndReports.add(recordContent);
			break;
		default:
			logger.error("BattleRecord single add is error this phase is " + phase);
			break;
		}
	}
	
//	public void addRoundRecodes(List<RoundReportRecord> roundRecordList){
//		this.roundRecodes.addAll(roundRecordList);
//	}
	
	/**
	 * 获取战斗轮数
	 * @return
	 */
	public int getRoundNum() {
		return battle.getRound();
	}
	
	public void setBattleResult(BattleResult battleResult){
		this.battleResult = battleResult;
	}

	public BattleResult getBattleResult() {
		return battleResult;
	}

//	public BattleType getBattleType() {
//		return battleType;
//	}
//
//	public void setBattleType(BattleType battleType) {
//		this.battleType = battleType;
//	}

	protected Object toMap() {
		Map<Integer,Object> js = new HashMap<Integer,Object>();
//		if(battleStartReports != null && battleStartReports.size() > 0){
//			List<Object> array = new ArrayList<Object>();
//			for(RecordContent content : battleStartReports){
//				array.add(content.toMap());
//			}
//			js.put(BattleReportDefine.BATTLE_REPORT_BATTLE_START, array);
//		}
//		
//		if(roundRecodes != null && roundRecodes.size() > 0){
//			List<Object> array = new ArrayList<Object>();
//			for(RoundReportRecord content : roundRecodes){
//				array.add(content.toMap());
//			}
//			js.put(BattleReportDefine.BATTLE_REPORT_BATTLE_IN_PROGRESS, array);
//		}
//		
//		if(battleEndReports != null && battleEndReports.size() > 0){
//			List<Object> array = new ArrayList<Object>();
//			for(RecordContent content : battleEndReports){
//				array.add(content.toMap());
//			}
//			js.put(BattleReportDefine.BATTLE_REPORT_BATTLE_END, array);
//		}
//		
//		if (battle.getInitialAttackers() != null && battle.getInitialAttackers().size()>0) {
//			List<Object> array = new ArrayList<Object>();
//			for(FightUnit content : this.battle.getInitialAttackers()){
//				array.add(content.toMap());
//			}
//			js.put(BattleReportDefine.BATTLE_REPORT_ATTACK_ARMY, array);
//		}
//		
//		if(battle.getInitialDefenders() != null && battle.getInitialDefenders().size()>0){
//			List<Object> array = new ArrayList<Object>();
//			for(FightUnit content : this.battle.getInitialDefenders()){
//				array.add(content.toMap());
//			}
//			js.put(BattleReportDefine.BATTLE_REPORT_DEFANCE_ARMY, array);
//		}
//		
//		// 战斗结果
//		js.put(BattleReportDefine.BATTLE_REPORT_RESULT, battleResult != null ? battleResult.getIndex() : BattleResult.TIE);
		
		return js;
	}
	
	/**
	 * 获取攻击方附加属性json对象
	 */
	private Object buildAttackerAddJsonObject() {
		Map<Integer, Object> addJs = new HashMap<Integer, Object>();
		addJs.put(BattleReportDefine.BATTLE_LEFT_USEDRUGS_NUM, battle.getType().getMaxUseDrugsTimes() - battle.getUseDrugsTimes(true));
		return addJs;
	}
	
	/**
	 * 获取防守方附加属性json对象
	 */
	private Object buildDefenderAddJsonObject() {
		Map<Integer, Object> addJs = new HashMap<Integer, Object>();
		addJs.put(BattleReportDefine.BATTLE_LEFT_USEDRUGS_NUM, battle.getType().getMaxUseDrugsTimes() - battle.getUseDrugsTimes(false));
		return addJs;
	}
	
	/**
	 * 生成战报json字符串
	 */
	public void makeRecordStr() {
		Gson gs = new Gson();
		recordStr = gs.toJson(toMap());
	}
	
	/**
	 * 获取json战报
	 * @return
	 */
	public String getRecordStr() {
		return recordStr;
	}
	
	public void makeBeforeRoundAttrReport(Map<Integer, Object> js, int speed) {
		//双方的属性及buff数据
		
		//攻击方
		List<Object> attackerList = new ArrayList<Object>();
		for (FightUnit fu : battle.getAttackers().values()) {
			attackerList.add(fu.toMap());
		}
		for (FightUnit fu : battle.getDeadAttackers().values()) {
			attackerList.add(fu.toMap());
		}
		js.put(BattleReportDefine.ATTACKERS, attackerList);
		//XXX 这里用于给前端战斗前显示用
		js.put(BattleReportDefine.ATTACKERS_ADD, buildAttackerAddJsonObject());
		
		//防守方
		List<Object> defenderList = new ArrayList<Object>();
		for (FightUnit fu : battle.getDefenders().values()) {
			defenderList.add(fu.toMap());
		}
		for (FightUnit fu : battle.getDeadDefenders().values()) {
			defenderList.add(fu.toMap());
		}
		js.put(BattleReportDefine.DEFENDERS, defenderList);
		js.put(BattleReportDefine.DEFENDERS_ADD, buildDefenderAddJsonObject());
		
		js.put(BattleReportDefine.BATTLE_SPEED, speed);
		
		//轮数，前台需要显示
		js.put(BattleReportDefine.BATTLE_ROUND_NUM, getRoundNum());
	}
	
	private void makeBattleResultReport(Map<Integer, Object> js) {
		//战斗结束阶段的效果战报
		if (battleEndReports != null && !battleEndReports.isEmpty()) {
			List<Object> array = new ArrayList<Object>();
			for(RecordContent content : battleEndReports) {
				array.add(content.toMap());
			}
			js.put(BattleReportDefine.BATTLE_END, array);
		}
		
		// 战斗结果
		js.put(BattleReportDefine.BATTLE_RESULT, battleResult != null ? battleResult.getIndex() : BattleResult.TIE);
	}
	
	public void makeBattleStartReport(Map<Integer, Object> js) {
		//战斗开始的效果战报
		if (battleStartReports != null && battleStartReports.size() > 0) {
			List<Object> array = new ArrayList<Object>();
			for(RecordContent content : battleStartReports){
				array.add(content.toMap());
			}
			js.put(BattleReportDefine.BATTLE_START, array);
		}
	}
	
	public void makeLastRoundReport(Map<Integer, Object> js, int speed) {
		//该轮的战报
		RoundReportRecord rrr = battle.getLastRoundReport();
		Object lastRoundMap = rrr.toMap();
		
		js.put(BattleReportDefine.BATTLE_ROUND, lastRoundMap);
		js.put(BattleReportDefine.BATTLE_SPEED, speed);
		
		//嗑药次数
		//XXX 这里用于该轮结束后更新计数
		js.put(BattleReportDefine.ATTACKERS_ADD, buildAttackerAddJsonObject());
		js.put(BattleReportDefine.DEFENDERS_ADD, buildDefenderAddJsonObject());
		
		//如果战斗结束，则包含战斗结果战报
		if (battle.isEnd()) {
			makeBattleResultReport(js);
		}
	}
	
	@Override
	public String toString() {
		return "BattleReportRecord [battleStartReports=" + battleStartReports + ", battleEndReports=" + battleEndReports + 
				", battleResult=" + battleResult + "]";
	}
}
