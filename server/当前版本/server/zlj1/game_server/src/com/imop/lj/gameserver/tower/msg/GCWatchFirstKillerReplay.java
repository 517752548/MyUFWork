package com.imop.lj.gameserver.tower.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回最先击败者战报
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWatchFirstKillerReplay extends GCMessage{
	
	/** 玩家Id */
	private long charId;
	/** 玩家挑战回合数 */
	private int round;
	/** 玩家等级 */
	private int level;
	/** 玩家挑战结束时间 */
	private long battleEndTime;
	/** 最先击败者战报 */
	private String firstKillerInfo;

	public GCWatchFirstKillerReplay (){
	}
	
	public GCWatchFirstKillerReplay (
			long charId,
			int round,
			int level,
			long battleEndTime,
			String firstKillerInfo ){
			this.charId = charId;
			this.round = round;
			this.level = level;
			this.battleEndTime = battleEndTime;
			this.firstKillerInfo = firstKillerInfo;
	}

	@Override
	protected boolean readImpl() {

	// 玩家Id
	long _charId = readLong();
	//end


	// 玩家挑战回合数
	int _round = readInteger();
	//end


	// 玩家等级
	int _level = readInteger();
	//end


	// 玩家挑战结束时间
	long _battleEndTime = readLong();
	//end


	// 最先击败者战报
	String _firstKillerInfo = readString();
	//end



		this.charId = _charId;
		this.round = _round;
		this.level = _level;
		this.battleEndTime = _battleEndTime;
		this.firstKillerInfo = _firstKillerInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 玩家Id
	writeLong(charId);


	// 玩家挑战回合数
	writeInteger(round);


	// 玩家等级
	writeInteger(level);


	// 玩家挑战结束时间
	writeLong(battleEndTime);


	// 最先击败者战报
	writeString(firstKillerInfo);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_WATCH_FIRST_KILLER_REPLAY;
	}
	
	@Override
	public String getTypeName() {
		return "GC_WATCH_FIRST_KILLER_REPLAY";
	}

	public long getCharId(){
		return charId;
	}
		
	public void setCharId(long charId){
		this.charId = charId;
	}

	public int getRound(){
		return round;
	}
		
	public void setRound(int round){
		this.round = round;
	}

	public int getLevel(){
		return level;
	}
		
	public void setLevel(int level){
		this.level = level;
	}

	public long getBattleEndTime(){
		return battleEndTime;
	}
		
	public void setBattleEndTime(long battleEndTime){
		this.battleEndTime = battleEndTime;
	}

	public String getFirstKillerInfo(){
		return firstKillerInfo;
	}
		
	public void setFirstKillerInfo(String firstKillerInfo){
		this.firstKillerInfo = firstKillerInfo;
	}
	public boolean isCompress() {
		return true;
	}
}