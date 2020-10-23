package com.imop.lj.gameserver.battle.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * PVP战斗的战报
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBattleReportPvp extends GCMessage{
	
	/** 0战斗开始，1每轮战报 */
	private int playType;
	/** 战报数据包 */
	private String reportPack;
	/** 攻击方玩家Id */
	private long attackerId;
	/** 防守方玩家Id */
	private long defenderId;
	/** 该轮开始时间 */
	private long roundStartTime;
	/** 当前时间 */
	private long curTime;
	/** 最近一次战斗是否自动，0否，1是 */
	private int lastAutoFlag;

	public GCBattleReportPvp (){
	}
	
	public GCBattleReportPvp (
			int playType,
			String reportPack,
			long attackerId,
			long defenderId,
			long roundStartTime,
			long curTime,
			int lastAutoFlag ){
			this.playType = playType;
			this.reportPack = reportPack;
			this.attackerId = attackerId;
			this.defenderId = defenderId;
			this.roundStartTime = roundStartTime;
			this.curTime = curTime;
			this.lastAutoFlag = lastAutoFlag;
	}

	@Override
	protected boolean readImpl() {

	// 0战斗开始，1每轮战报
	int _playType = readInteger();
	//end


	// 战报数据包
	String _reportPack = readString();
	//end


	// 攻击方玩家Id
	long _attackerId = readLong();
	//end


	// 防守方玩家Id
	long _defenderId = readLong();
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



		this.playType = _playType;
		this.reportPack = _reportPack;
		this.attackerId = _attackerId;
		this.defenderId = _defenderId;
		this.roundStartTime = _roundStartTime;
		this.curTime = _curTime;
		this.lastAutoFlag = _lastAutoFlag;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 0战斗开始，1每轮战报
	writeInteger(playType);


	// 战报数据包
	writeString(reportPack);


	// 攻击方玩家Id
	writeLong(attackerId);


	// 防守方玩家Id
	writeLong(defenderId);


	// 该轮开始时间
	writeLong(roundStartTime);


	// 当前时间
	writeLong(curTime);


	// 最近一次战斗是否自动，0否，1是
	writeInteger(lastAutoFlag);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_BATTLE_REPORT_PVP;
	}
	
	@Override
	public String getTypeName() {
		return "GC_BATTLE_REPORT_PVP";
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

	public long getAttackerId(){
		return attackerId;
	}
		
	public void setAttackerId(long attackerId){
		this.attackerId = attackerId;
	}

	public long getDefenderId(){
		return defenderId;
	}
		
	public void setDefenderId(long defenderId){
		this.defenderId = defenderId;
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
	public boolean isCompress() {
		return true;
	}
}