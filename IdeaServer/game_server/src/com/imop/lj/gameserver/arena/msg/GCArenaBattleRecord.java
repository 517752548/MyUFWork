package com.imop.lj.gameserver.arena.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 请求竞技场战斗记录
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCArenaBattleRecord extends GCMessage{
	
	/** 当前时间 */
	private long curTime;
	/** 竞技场战斗记录 */
	private com.imop.lj.common.model.arena.ArenaReportHistoryInfo[] arenaReportHistoryList;

	public GCArenaBattleRecord (){
	}
	
	public GCArenaBattleRecord (
			long curTime,
			com.imop.lj.common.model.arena.ArenaReportHistoryInfo[] arenaReportHistoryList ){
			this.curTime = curTime;
			this.arenaReportHistoryList = arenaReportHistoryList;
	}

	@Override
	protected boolean readImpl() {

	// 当前时间
	long _curTime = readLong();
	//end


	// 竞技场战斗记录
	int arenaReportHistoryListSize = readUnsignedShort();
	com.imop.lj.common.model.arena.ArenaReportHistoryInfo[] _arenaReportHistoryList = new com.imop.lj.common.model.arena.ArenaReportHistoryInfo[arenaReportHistoryListSize];
	int arenaReportHistoryListIndex = 0;
	for(arenaReportHistoryListIndex=0; arenaReportHistoryListIndex<arenaReportHistoryListSize; arenaReportHistoryListIndex++){
		_arenaReportHistoryList[arenaReportHistoryListIndex] = new com.imop.lj.common.model.arena.ArenaReportHistoryInfo();
	// 战报Id
	String _arenaReportHistoryList_reportId = readString();
	//end
	_arenaReportHistoryList[arenaReportHistoryListIndex].setReportId (_arenaReportHistoryList_reportId);

	// 战报时间
	long _arenaReportHistoryList_reportTime = readLong();
	//end
	_arenaReportHistoryList[arenaReportHistoryListIndex].setReportTime (_arenaReportHistoryList_reportTime);

	// 对手Id
	long _arenaReportHistoryList_targetRoleId = readLong();
	//end
	_arenaReportHistoryList[arenaReportHistoryListIndex].setTargetRoleId (_arenaReportHistoryList_targetRoleId);

	// 对手模板Id
	int _arenaReportHistoryList_targetTplId = readInteger();
	//end
	_arenaReportHistoryList[arenaReportHistoryListIndex].setTargetTplId (_arenaReportHistoryList_targetTplId);

	// 对手等级
	int _arenaReportHistoryList_targetLevel = readInteger();
	//end
	_arenaReportHistoryList[arenaReportHistoryListIndex].setTargetLevel (_arenaReportHistoryList_targetLevel);

	// 对手名字
	String _arenaReportHistoryList_targetName = readString();
	//end
	_arenaReportHistoryList[arenaReportHistoryListIndex].setTargetName (_arenaReportHistoryList_targetName);

	// 名次变化
	int _arenaReportHistoryList_rankDelta = readInteger();
	//end
	_arenaReportHistoryList[arenaReportHistoryListIndex].setRankDelta (_arenaReportHistoryList_rankDelta);

	// 是否胜利
	int _arenaReportHistoryList_isWin = readInteger();
	//end
	_arenaReportHistoryList[arenaReportHistoryListIndex].setIsWin (_arenaReportHistoryList_isWin);
	}
	//end



		this.curTime = _curTime;
		this.arenaReportHistoryList = _arenaReportHistoryList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 当前时间
	writeLong(curTime);


	// 竞技场战斗记录
	writeShort(arenaReportHistoryList.length);
	int arenaReportHistoryListIndex = 0;
	int arenaReportHistoryListSize = arenaReportHistoryList.length;
	for(arenaReportHistoryListIndex=0; arenaReportHistoryListIndex<arenaReportHistoryListSize; arenaReportHistoryListIndex++){

	String arenaReportHistoryList_reportId = arenaReportHistoryList[arenaReportHistoryListIndex].getReportId();

	// 战报Id
	writeString(arenaReportHistoryList_reportId);

	long arenaReportHistoryList_reportTime = arenaReportHistoryList[arenaReportHistoryListIndex].getReportTime();

	// 战报时间
	writeLong(arenaReportHistoryList_reportTime);

	long arenaReportHistoryList_targetRoleId = arenaReportHistoryList[arenaReportHistoryListIndex].getTargetRoleId();

	// 对手Id
	writeLong(arenaReportHistoryList_targetRoleId);

	int arenaReportHistoryList_targetTplId = arenaReportHistoryList[arenaReportHistoryListIndex].getTargetTplId();

	// 对手模板Id
	writeInteger(arenaReportHistoryList_targetTplId);

	int arenaReportHistoryList_targetLevel = arenaReportHistoryList[arenaReportHistoryListIndex].getTargetLevel();

	// 对手等级
	writeInteger(arenaReportHistoryList_targetLevel);

	String arenaReportHistoryList_targetName = arenaReportHistoryList[arenaReportHistoryListIndex].getTargetName();

	// 对手名字
	writeString(arenaReportHistoryList_targetName);

	int arenaReportHistoryList_rankDelta = arenaReportHistoryList[arenaReportHistoryListIndex].getRankDelta();

	// 名次变化
	writeInteger(arenaReportHistoryList_rankDelta);

	int arenaReportHistoryList_isWin = arenaReportHistoryList[arenaReportHistoryListIndex].getIsWin();

	// 是否胜利
	writeInteger(arenaReportHistoryList_isWin);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_ARENA_BATTLE_RECORD;
	}
	
	@Override
	public String getTypeName() {
		return "GC_ARENA_BATTLE_RECORD";
	}

	public long getCurTime(){
		return curTime;
	}
		
	public void setCurTime(long curTime){
		this.curTime = curTime;
	}

	public com.imop.lj.common.model.arena.ArenaReportHistoryInfo[] getArenaReportHistoryList(){
		return arenaReportHistoryList;
	}

	public void setArenaReportHistoryList(com.imop.lj.common.model.arena.ArenaReportHistoryInfo[] arenaReportHistoryList){
		this.arenaReportHistoryList = arenaReportHistoryList;
	}	
}