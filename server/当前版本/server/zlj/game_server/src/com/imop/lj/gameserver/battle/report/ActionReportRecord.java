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
 * 动作战斗信息
 * @author yuanbo.gao
 *
 */
public class ActionReportRecord implements IReportRecord{
	Logger logger = Loggers.battleLogger;
	
	private List<RecordContent> actionStartReports;
	private List<RecordContent> actionTargetReports;
	private List<RecordContent> actionExecuteReports;
//	private List<RecordContent> actionTalentTargetReports;
//	private List<RecordContent> actionTalentExecuteReports;
	private List<RecordContent> actionDefenceReports;
	private List<RecordContent> actionAdjustReports;
	private List<RecordContent> actionEndReports;
	
	private List<List<Map<Integer,String>>> debugReport;
	
	public ActionReportRecord(){
		this.actionStartReports = new ArrayList<RecordContent>();
		this.actionTargetReports = new ArrayList<RecordContent>();
		this.actionExecuteReports = new ArrayList<RecordContent>();
//		this.actionTalentTargetReports = new ArrayList<RecordContent>();
//		this.actionTalentExecuteReports = new ArrayList<RecordContent>();
		this.actionDefenceReports = new ArrayList<RecordContent>();
		this.actionAdjustReports = new ArrayList<RecordContent>();
		this.actionEndReports = new ArrayList<RecordContent>();
		this.debugReport = new ArrayList<List<Map<Integer,String>>>();
	}
	
	@Override
	public void addToContent(Phase phase, List<RecordContent> reportItems) {
		for (RecordContent recordContent : reportItems) {
			addToContent(phase, recordContent);
		}
	}
	
	@Override
	public void addToContent(Phase phase, RecordContent recordContent) {
		switch(phase){
		case ACTION_START:
			actionStartReports.add(recordContent);
			break;
		case ACTION_TARGET_AFTER:
		case ACTION_EXECUTE:
		case ACTION_EXECUTE_AFTER:
			if (!actionExecuteReports.isEmpty()) {
				//XXX 仙符:如果新来的战报和当前最后一个战报的owner相同，技能id也相同，则合并到一个里面，这样前台就播放一次了，否则会播放多次技能释放效果
				//连击需要播放两次技能效果,需要排除掉它
				RecordContent last = actionExecuteReports.get(actionExecuteReports.size() - 1);
				if (last.getOwner() == recordContent.getOwner() &&
						last.getSkillId() == recordContent.getSkillId()
						&& !recordContent.isDoubleAttack()) {
					last.addAllReports(recordContent.getReports());
					break;
				}
			}
			actionExecuteReports.add(recordContent);
			break;
		case ACTION_DEFENCE:
			actionDefenceReports.add(recordContent);
			break;
		case ACTION_ADJUST:
			actionAdjustReports.add(recordContent);
			break;
		case ACTION_END:
			actionEndReports.add(recordContent);
			break;
		case ACTION_TARGET:
			actionTargetReports.add(recordContent);
			break;
		default:
			logger.error("ActionRecord single add is error this phase is " + phase);
			break;
		}
		
	}
	
	public void saveDebugInfo(List<Map<Integer,String>> info){
		debugReport.add(info);
	}
	
	public Object toMap(){
		Map<Integer,Object> js = new HashMap<Integer,Object>();
		if(actionStartReports != null && actionStartReports.size() > 0){
			List<Object> array = new ArrayList<Object>();
			for(RecordContent content : actionStartReports){
				array.add(content.toMap());
			}
			js.put(BattleReportDefine.BATTLE_ACTION_START, array);
		}
		
//		if(actionTalentExecuteReports != null && actionTalentExecuteReports.size() > 0){
//			List<Object> array = new ArrayList<Object>();
//			for(RecordContent content : actionTalentExecuteReports){
//				array.add(content.toMap());
//			}			
//			js.put(BattleReportDefine.BATTLE_REPORT_ACTION_TALENT_EXECUTE, array);
//		}
		
		if(actionExecuteReports != null && actionExecuteReports.size() > 0){
			List<Object> array = new ArrayList<Object>();
			for(RecordContent content : actionExecuteReports){
				array.add(content.toMap());
			}
			js.put(BattleReportDefine.BATTLE_ACTION_EXECUTE, array);
		}
		
		if(actionDefenceReports != null && actionDefenceReports.size() > 0){
			List<Object> array = new ArrayList<Object>();
			for(RecordContent content : actionDefenceReports){
				array.add(content.toMap());
			}
			js.put(BattleReportDefine.BATTLE_ACTION_DEFENCE, array);
		}
		
		if(actionAdjustReports != null && actionAdjustReports.size() > 0){
			List<Object> array = new ArrayList<Object>();
			for(RecordContent content : actionAdjustReports){
				array.add(content.toMap());
			}
			js.put(BattleReportDefine.BATTLE_ACTION_ADJUST, array);
		}
		
		if(actionEndReports != null && actionEndReports.size() > 0){
			List<Object> array = new ArrayList<Object>();
			for(RecordContent content : actionEndReports){
				array.add(content.toMap());
			}
			js.put(BattleReportDefine.BATTLE_ACTION_END, array);
		}
		
//		if(Globals.getServerConfig().isBattleDebug()){
//			if(debugReport != null && debugReport.size() > 0){
//				List<Object> array = new ArrayList<Object>();
//				for(List<Map<Integer,String>> infos : debugReport){
//					List<Object> infosArray = new ArrayList<Object>();
//					for(Map<Integer,String> info : infos){
//						Map<String,Object> jsonObject = new HashMap<String,Object>();
//						for(Entry<Integer,String> entry : info.entrySet()){
//							jsonObject.put(entry.getKey() + "", entry.getValue() + "");
//						}
//						infosArray.add(jsonObject);
//					}
//					array.add(infosArray);
//				}
//				js.put(BattleReportDefine.BATTLE_ACTION_DEBUG, array);
//			}
//		}
		return js;
	}
	
	/**
	 * 获取寻找目标阶段的ReportItem
	 * 
	 * @param phase
	 * @return
	 */
	public List<ReportItem> getReportItemAtTarget(){
		List<ReportItem> list = new ArrayList<ReportItem>();
		for(RecordContent content : this.actionTargetReports){
			list.addAll(content.getReports());
		}
		return list;
	}

	@Override
	public String toString() {
		return "ActionReportRecord [logger=" + logger + ", actionStartReports=" + actionStartReports + ", actionExecuteReports="
				+ actionExecuteReports + ", actionDefenceReports=" + actionDefenceReports + ", actionAdjustReports=" + actionAdjustReports
				+ ", actionEndReports=" + actionEndReports + "]";
	}

	@Override
	public void setBattle(IBattle battle) {
		// TODO Auto-generated method stub
		
	}
}
