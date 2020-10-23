package com.imop.lj.gameserver.battle.report;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.IBattle;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;

/**
 * 回合战斗信息
 * @author yuanbo.gao
 *
 */
public class RoundReportRecord implements IReportRecord{
	Logger logger = Loggers.battleLogger;
	private int roundNum;
	private List<RecordContent> roundStartReports;
	private List<RecordContent> roundEndReports;
	private List<ActionReportRecord> actionRecodes;
	
	public RoundReportRecord(){
		this.roundStartReports = new ArrayList<RecordContent>();
		this.roundEndReports = new ArrayList<RecordContent>();
		this.actionRecodes = new ArrayList<ActionReportRecord>();
	}
	
	@Override
	public void addToContent(Phase phase, List<RecordContent> peportItems) {
		switch(phase){
		case ROUND_START:
			roundStartReports.addAll(peportItems);
			break;
		case ROUND_END:
			roundEndReports.addAll(peportItems);
			break;
		default:
			logger.error("RoundRecord add is error this phase is " + phase);
			break;
		}
	}
	
	@Override
	public void addToContent(Phase phase, RecordContent recordContent) {
		switch(phase){
		case ROUND_START:
			roundStartReports.add(recordContent);
			break;
		case ROUND_END:
			roundEndReports.add(recordContent);
			break;
		default:
			logger.error("RoundRecord single add is error this phase is " + phase);
			break;
		}
	}
	
	public void addActionRecodes(List<ActionReportRecord> actionRecordList){
		this.actionRecodes.addAll(actionRecordList);
	}
	
	public void setRoundNum(int roundNum) {
		this.roundNum = roundNum;
	}
	
//	public String toJsonStr(){
//		JSONObject js = new JSONObject();
//		if(roundStartReports != null && roundStartReports.size() > 0){
//			JSONArray array = new JSONArray();
//			for(RecordContent content : roundStartReports){
//				array.add(content.toJsonStr());
//			}
//			js.put(BattleReportDefine.BATTLE_REPORT_ROUND_START, array.toString());
//		}
//		
//		if(actionRecodes != null && actionRecodes.size() > 0){
//			JSONArray array = new JSONArray();
//			for(ActionReportRecord content : actionRecodes){
//				array.add(content.toJsonStr());
//			}
//			js.put(BattleReportDefine.BATTLE_REPORT_ROUND_IN_PROGRESS, array.toString());
//		}
//		
//		if(roundEndReports != null && roundEndReports.size() > 0){
//			JSONArray array = new JSONArray();
//			for(RecordContent content : roundEndReports){
//				array.add(content.toJsonStr());
//			}
//			js.put(BattleReportDefine.BATTLE_REPORT_ROUND_END, array.toString());
//		}
//		return js.toString();
//	}
	
	public Object toMap(){
		Map<Integer,Object> js = new HashMap<Integer,Object>();
		//轮数
		js.put(BattleReportDefine.BATTLE_ROUND_NUM, roundNum);
		
		if(roundStartReports != null && roundStartReports.size() > 0){
			List<Object> array = new ArrayList<Object>();
			for(RecordContent content : roundStartReports){
				array.add(content.toMap());
			}
			js.put(BattleReportDefine.BATTLE_ROUND_START, array);
		}
		
		if(actionRecodes != null && actionRecodes.size() > 0){
			List<Object> array = new ArrayList<Object>();
			for(ActionReportRecord content : actionRecodes){
				array.add(content.toMap());
			}
			js.put(BattleReportDefine.BATTLE_ROUND_IN_PROGRESS, array);
		}
		
		if(roundEndReports != null && roundEndReports.size() > 0){
			List<Object> array = new ArrayList<Object>();
			for(RecordContent content : roundEndReports){
				array.add(content.toMap());
			}
			js.put(BattleReportDefine.BATTLE_ROUND_END, array);
		}
		return js;
	}

	@Override
	public String toString() {
		return "RoundReportRecord [logger=" + logger + ", roundStartReports=" + roundStartReports + ", roundEndReports=" + roundEndReports
				+ ", actionRecodes=" + actionRecodes + "]";
	}

	@Override
	public void setBattle(IBattle battle) {
		// TODO Auto-generated method stub
		
	}
}
