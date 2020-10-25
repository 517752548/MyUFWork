package com.imop.lj.gameserver.battle.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 组队战斗的战报
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBattleReportTeam extends GCMessage{
	
	/** 0战斗开始，1每轮战报 */
	private int playType;
	/** 战报数据包 */
	private String reportPack;
	/** 队伍Id */
	private int teamId;
	/** 该轮开始时间 */
	private long roundStartTime;
	/** 当前时间 */
	private long curTime;
	/** 最近一次战斗是否自动，0否，1是 */
	private int lastAutoFlag;
	/** 攻击方1，防守方2 */
	private int isAttacker;
	/** 战斗附加json串，存储funcId等信息 */
	private String additionPack;

	public GCBattleReportTeam (){
	}
	
	public GCBattleReportTeam (
			int playType,
			String reportPack,
			int teamId,
			long roundStartTime,
			long curTime,
			int lastAutoFlag,
			int isAttacker,
			String additionPack ){
			this.playType = playType;
			this.reportPack = reportPack;
			this.teamId = teamId;
			this.roundStartTime = roundStartTime;
			this.curTime = curTime;
			this.lastAutoFlag = lastAutoFlag;
			this.isAttacker = isAttacker;
			this.additionPack = additionPack;
	}

	@Override
	protected boolean readImpl() {

	// 0战斗开始，1每轮战报
	int _playType = readInteger();
	//end


	// 战报数据包
	String _reportPack = readString();
	//end


	// 队伍Id
	int _teamId = readInteger();
	//end


	// 该轮开始时间
	long _roundStartTime = readLong();
	//end


	// 当前时间
	long _curTime = readLong();
	//end


	// 最近一次战斗是否自动，0否，1是
	int _lastAutoFlag = readInteger();
	//end


	// 攻击方1，防守方2
	int _isAttacker = readInteger();
	//end


	// 战斗附加json串，存储funcId等信息
	String _additionPack = readString();
	//end



		this.playType = _playType;
		this.reportPack = _reportPack;
		this.teamId = _teamId;
		this.roundStartTime = _roundStartTime;
		this.curTime = _curTime;
		this.lastAutoFlag = _lastAutoFlag;
		this.isAttacker = _isAttacker;
		this.additionPack = _additionPack;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 0战斗开始，1每轮战报
	writeInteger(playType);


	// 战报数据包
	writeString(reportPack);


	// 队伍Id
	writeInteger(teamId);


	// 该轮开始时间
	writeLong(roundStartTime);


	// 当前时间
	writeLong(curTime);


	// 最近一次战斗是否自动，0否，1是
	writeInteger(lastAutoFlag);


	// 攻击方1，防守方2
	writeInteger(isAttacker);


	// 战斗附加json串，存储funcId等信息
	writeString(additionPack);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_BATTLE_REPORT_TEAM;
	}
	
	@Override
	public String getTypeName() {
		return "GC_BATTLE_REPORT_TEAM";
	}

	public int getPlayType(){
		return playType;
	}
		
	public void setPlayType(int playType){
		this.playType = playType;
	}

	public String getReportPack(){
		return reportPack;
	}
		
	public void setReportPack(String reportPack){
		this.reportPack = reportPack;
	}

	public int getTeamId(){
		return teamId;
	}
		
	public void setTeamId(int teamId){
		this.teamId = teamId;
	}

	public long getRoundStartTime(){
		return roundStartTime;
	}
		
	public void setRoundStartTime(long roundStartTime){
		this.roundStartTime = roundStartTime;
	}

	public long getCurTime(){
		return curTime;
	}
		
	public void setCurTime(long curTime){
		this.curTime = curTime;
	}

	public int getLastAutoFlag(){
		return lastAutoFlag;
	}
		
	public void setLastAutoFlag(int lastAutoFlag){
		this.lastAutoFlag = lastAutoFlag;
	}

	public int getIsAttacker(){
		return isAttacker;
	}
		
	public void setIsAttacker(int isAttacker){
		this.isAttacker = isAttacker;
	}

	public String getAdditionPack(){
		return additionPack;
	}
		
	public void setAdditionPack(String additionPack){
		this.additionPack = additionPack;
	}
	public boolean isCompress() {
		return true;
	}
}