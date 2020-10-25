package com.imop.lj.gameserver.tower.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回最优击败者战报
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWatchBestKillerReplay extends GCMessage{
	
	/** 玩家Id */
	private long charId;
	/** 玩家挑战回合数 */
	private int round;
	/** 玩家等级 */
	private int level;
	/** 玩家挑战持续时间 */
	private long battleDuration;
	/** 最优击败者战报 */
	private String bestKillerInfo;

	public GCWatchBestKillerReplay (){
	}
	
	public GCWatchBestKillerReplay (
			long charId,
			int round,
			int level,
			long battleDuration,
			String bestKillerInfo ){
			this.charId = charId;
			this.round = round;
			this.level = level;
			this.battleDuration = battleDuration;
			this.bestKillerInfo = bestKillerInfo;
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


	// 玩家挑战持续时间
	long _battleDuration = readLong();
	//end


	// 最优击败者战报
	String _bestKillerInfo = readString();
	//end



		this.charId = _charId;
		this.round = _round;
		this.level = _level;
		this.battleDuration = _battleDuration;
		this.bestKillerInfo = _bestKillerInfo;
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


	// 玩家挑战持续时间
	writeLong(battleDuration);


	// 最优击败者战报
	writeString(bestKillerInfo);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_WATCH_BEST_KILLER_REPLAY;
	}
	
	@Override
	public String getTypeName() {
		return "GC_WATCH_BEST_KILLER_REPLAY";
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

	public long getBattleDuration(){
		return battleDuration;
	}
		
	public void setBattleDuration(long battleDuration){
		this.battleDuration = battleDuration;
	}

	public String getBestKillerInfo(){
		return bestKillerInfo;
	}
		
	public void setBestKillerInfo(String bestKillerInfo){
		this.bestKillerInfo = bestKillerInfo;
	}
	public boolean isCompress() {
		return true;
	}
}