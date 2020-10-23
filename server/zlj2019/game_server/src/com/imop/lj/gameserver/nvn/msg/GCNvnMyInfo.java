package com.imop.lj.gameserver.nvn.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * nvn联赛我的信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCNvnMyInfo extends GCMessage{
	
	/** 排名 */
	private int rank;
	/** 连胜数 */
	private int conWinNum;
	/** 积分 */
	private int score;
	/** 队伍积分 */
	private int teamScore;
	/** 队伍状态 */
	private int teamStatus;
	/** 积分日志列表 */
	private String[] myLog;

	public GCNvnMyInfo (){
	}
	
	public GCNvnMyInfo (
			int rank,
			int conWinNum,
			int score,
			int teamScore,
			int teamStatus,
			String[] myLog ){
			this.rank = rank;
			this.conWinNum = conWinNum;
			this.score = score;
			this.teamScore = teamScore;
			this.teamStatus = teamStatus;
			this.myLog = myLog;
	}

	@Override
	protected boolean readImpl() {

	// 排名
	int _rank = readInteger();
	//end


	// 连胜数
	int _conWinNum = readInteger();
	//end


	// 积分
	int _score = readInteger();
	//end


	// 队伍积分
	int _teamScore = readInteger();
	//end


	// 队伍状态
	int _teamStatus = readInteger();
	//end


	// 积分日志列表
	int myLogSize = readUnsignedShort();
	String[] _myLog = new String[myLogSize];
	int myLogIndex = 0;
	for(myLogIndex=0; myLogIndex<myLogSize; myLogIndex++){
		_myLog[myLogIndex] = readString();
	}//end



		this.rank = _rank;
		this.conWinNum = _conWinNum;
		this.score = _score;
		this.teamScore = _teamScore;
		this.teamStatus = _teamStatus;
		this.myLog = _myLog;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 排名
	writeInteger(rank);


	// 连胜数
	writeInteger(conWinNum);


	// 积分
	writeInteger(score);


	// 队伍积分
	writeInteger(teamScore);


	// 队伍状态
	writeInteger(teamStatus);


	// 积分日志列表
	writeShort(myLog.length);
	int myLogSize = myLog.length;
	int myLogIndex = 0;
	for(myLogIndex=0; myLogIndex<myLogSize; myLogIndex++){
		writeString(myLog [ myLogIndex ]);
	}//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_NVN_MY_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_NVN_MY_INFO";
	}

	public int getRank(){
		return rank;
	}
		
	public void setRank(int rank){
		this.rank = rank;
	}

	public int getConWinNum(){
		return conWinNum;
	}
		
	public void setConWinNum(int conWinNum){
		this.conWinNum = conWinNum;
	}

	public int getScore(){
		return score;
	}
		
	public void setScore(int score){
		this.score = score;
	}

	public int getTeamScore(){
		return teamScore;
	}
		
	public void setTeamScore(int teamScore){
		this.teamScore = teamScore;
	}

	public int getTeamStatus(){
		return teamStatus;
	}
		
	public void setTeamStatus(int teamStatus){
		this.teamStatus = teamStatus;
	}

	public String[] getMyLog(){
		return myLog;
	}

	public void setMyLog(String[] myLog){
		this.myLog = myLog;
	}	
}