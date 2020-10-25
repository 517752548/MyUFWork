package com.imop.lj.gameserver.team.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 显示队伍列表界面
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTeamShowList extends GCMessage{
	
	/** 队伍信息列表 */
	private com.imop.lj.common.model.team.TeamInfo[] teamInfos;
	/** 等待匹配的队长数量 */
	private int waitingLeaderNum;
	/** 等待匹配的队员数量 */
	private int waitingMemberNum;

	public GCTeamShowList (){
	}
	
	public GCTeamShowList (
			com.imop.lj.common.model.team.TeamInfo[] teamInfos,
			int waitingLeaderNum,
			int waitingMemberNum ){
			this.teamInfos = teamInfos;
			this.waitingLeaderNum = waitingLeaderNum;
			this.waitingMemberNum = waitingMemberNum;
	}

	@Override
	protected boolean readImpl() {

	// 队伍信息列表
	int teamInfosSize = readUnsignedShort();
	com.imop.lj.common.model.team.TeamInfo[] _teamInfos = new com.imop.lj.common.model.team.TeamInfo[teamInfosSize];
	int teamInfosIndex = 0;
	for(teamInfosIndex=0; teamInfosIndex<teamInfosSize; teamInfosIndex++){
		_teamInfos[teamInfosIndex] = new com.imop.lj.common.model.team.TeamInfo();
	// 队伍Id
	int _teamInfos_teamId = readInteger();
	//end
	_teamInfos[teamInfosIndex].setTeamId (_teamInfos_teamId);

	// 名字 
	String _teamInfos_name = readString();
	//end
	_teamInfos[teamInfosIndex].setName (_teamInfos_name);

	// 等级
	int _teamInfos_level = readInteger();
	//end
	_teamInfos[teamInfosIndex].setLevel (_teamInfos_level);

	// 职业Id
	int _teamInfos_jobTypeId = readInteger();
	//end
	_teamInfos[teamInfosIndex].setJobTypeId (_teamInfos_jobTypeId);

	// 目标Id
	int _teamInfos_targetId = readInteger();
	//end
	_teamInfos[teamInfosIndex].setTargetId (_teamInfos_targetId);

	// 队员数量
	int _teamInfos_memberNum = readInteger();
	//end
	_teamInfos[teamInfosIndex].setMemberNum (_teamInfos_memberNum);

	// 队伍要求等级下限
	int _teamInfos_levelMin = readInteger();
	//end
	_teamInfos[teamInfosIndex].setLevelMin (_teamInfos_levelMin);

	// 队伍要求等级上限
	int _teamInfos_levelMax = readInteger();
	//end
	_teamInfos[teamInfosIndex].setLevelMax (_teamInfos_levelMax);

	// 申请状态，0可申请，1已申请
	int _teamInfos_applyStatus = readInteger();
	//end
	_teamInfos[teamInfosIndex].setApplyStatus (_teamInfos_applyStatus);
	}
	//end


	// 等待匹配的队长数量
	int _waitingLeaderNum = readInteger();
	//end


	// 等待匹配的队员数量
	int _waitingMemberNum = readInteger();
	//end



		this.teamInfos = _teamInfos;
		this.waitingLeaderNum = _waitingLeaderNum;
		this.waitingMemberNum = _waitingMemberNum;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 队伍信息列表
	writeShort(teamInfos.length);
	int teamInfosIndex = 0;
	int teamInfosSize = teamInfos.length;
	for(teamInfosIndex=0; teamInfosIndex<teamInfosSize; teamInfosIndex++){

	int teamInfos_teamId = teamInfos[teamInfosIndex].getTeamId();

	// 队伍Id
	writeInteger(teamInfos_teamId);

	String teamInfos_name = teamInfos[teamInfosIndex].getName();

	// 名字 
	writeString(teamInfos_name);

	int teamInfos_level = teamInfos[teamInfosIndex].getLevel();

	// 等级
	writeInteger(teamInfos_level);

	int teamInfos_jobTypeId = teamInfos[teamInfosIndex].getJobTypeId();

	// 职业Id
	writeInteger(teamInfos_jobTypeId);

	int teamInfos_targetId = teamInfos[teamInfosIndex].getTargetId();

	// 目标Id
	writeInteger(teamInfos_targetId);

	int teamInfos_memberNum = teamInfos[teamInfosIndex].getMemberNum();

	// 队员数量
	writeInteger(teamInfos_memberNum);

	int teamInfos_levelMin = teamInfos[teamInfosIndex].getLevelMin();

	// 队伍要求等级下限
	writeInteger(teamInfos_levelMin);

	int teamInfos_levelMax = teamInfos[teamInfosIndex].getLevelMax();

	// 队伍要求等级上限
	writeInteger(teamInfos_levelMax);

	int teamInfos_applyStatus = teamInfos[teamInfosIndex].getApplyStatus();

	// 申请状态，0可申请，1已申请
	writeInteger(teamInfos_applyStatus);
	}
	//end


	// 等待匹配的队长数量
	writeInteger(waitingLeaderNum);


	// 等待匹配的队员数量
	writeInteger(waitingMemberNum);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_TEAM_SHOW_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_TEAM_SHOW_LIST";
	}

	public com.imop.lj.common.model.team.TeamInfo[] getTeamInfos(){
		return teamInfos;
	}

	public void setTeamInfos(com.imop.lj.common.model.team.TeamInfo[] teamInfos){
		this.teamInfos = teamInfos;
	}	

	public int getWaitingLeaderNum(){
		return waitingLeaderNum;
	}
		
	public void setWaitingLeaderNum(int waitingLeaderNum){
		this.waitingLeaderNum = waitingLeaderNum;
	}

	public int getWaitingMemberNum(){
		return waitingMemberNum;
	}
		
	public void setWaitingMemberNum(int waitingMemberNum){
		this.waitingMemberNum = waitingMemberNum;
	}
	public boolean isCompress() {
		return true;
	}
}