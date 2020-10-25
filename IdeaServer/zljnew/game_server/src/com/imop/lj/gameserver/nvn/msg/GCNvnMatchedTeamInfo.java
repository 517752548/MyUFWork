package com.imop.lj.gameserver.nvn.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * nvn联赛匹配到的队伍信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCNvnMatchedTeamInfo extends GCMessage{
	
	/** 队伍积分 */
	private int teamScore;
	/** 队员信息列表 */
	private com.imop.lj.common.model.team.TeamMemberInfo[] teamMemberInfos;

	public GCNvnMatchedTeamInfo (){
	}
	
	public GCNvnMatchedTeamInfo (
			int teamScore,
			com.imop.lj.common.model.team.TeamMemberInfo[] teamMemberInfos ){
			this.teamScore = teamScore;
			this.teamMemberInfos = teamMemberInfos;
	}

	@Override
	protected boolean readImpl() {

	// 队伍积分
	int _teamScore = readInteger();
	//end


	// 队员信息列表
	int teamMemberInfosSize = readUnsignedShort();
	com.imop.lj.common.model.team.TeamMemberInfo[] _teamMemberInfos = new com.imop.lj.common.model.team.TeamMemberInfo[teamMemberInfosSize];
	int teamMemberInfosIndex = 0;
	for(teamMemberInfosIndex=0; teamMemberInfosIndex<teamMemberInfosSize; teamMemberInfosIndex++){
		_teamMemberInfos[teamMemberInfosIndex] = new com.imop.lj.common.model.team.TeamMemberInfo();
	// 队员唯一Id
	long _teamMemberInfos_uuid = readLong();
	//end
	_teamMemberInfos[teamMemberInfosIndex].setUuid (_teamMemberInfos_uuid);

	// 是否队长
	int _teamMemberInfos_isLeader = readInteger();
	//end
	_teamMemberInfos[teamMemberInfosIndex].setIsLeader (_teamMemberInfos_isLeader);

	// 模板Id
	int _teamMemberInfos_tplId = readInteger();
	//end
	_teamMemberInfos[teamMemberInfosIndex].setTplId (_teamMemberInfos_tplId);

	// 是否伙伴，0否，1是
	int _teamMemberInfos_isFriend = readInteger();
	//end
	_teamMemberInfos[teamMemberInfosIndex].setIsFriend (_teamMemberInfos_isFriend);

	// 名字 
	String _teamMemberInfos_name = readString();
	//end
	_teamMemberInfos[teamMemberInfosIndex].setName (_teamMemberInfos_name);

	// 职业Id
	int _teamMemberInfos_jobTypeId = readInteger();
	//end
	_teamMemberInfos[teamMemberInfosIndex].setJobTypeId (_teamMemberInfos_jobTypeId);

	// 等级
	int _teamMemberInfos_level = readInteger();
	//end
	_teamMemberInfos[teamMemberInfosIndex].setLevel (_teamMemberInfos_level);

	// 位置Id，从1开始计数
	int _teamMemberInfos_position = readInteger();
	//end
	_teamMemberInfos[teamMemberInfosIndex].setPosition (_teamMemberInfos_position);

	// 状态，1队伍中，2暂离
	int _teamMemberInfos_status = readInteger();
	//end
	_teamMemberInfos[teamMemberInfosIndex].setStatus (_teamMemberInfos_status);

	// 主将武器模板Id
	int _teamMemberInfos_equipWeaponId = readInteger();
	//end
	_teamMemberInfos[teamMemberInfosIndex].setEquipWeaponId (_teamMemberInfos_equipWeaponId);
	}
	//end



		this.teamScore = _teamScore;
		this.teamMemberInfos = _teamMemberInfos;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 队伍积分
	writeInteger(teamScore);


	// 队员信息列表
	writeShort(teamMemberInfos.length);
	int teamMemberInfosIndex = 0;
	int teamMemberInfosSize = teamMemberInfos.length;
	for(teamMemberInfosIndex=0; teamMemberInfosIndex<teamMemberInfosSize; teamMemberInfosIndex++){

	long teamMemberInfos_uuid = teamMemberInfos[teamMemberInfosIndex].getUuid();

	// 队员唯一Id
	writeLong(teamMemberInfos_uuid);

	int teamMemberInfos_isLeader = teamMemberInfos[teamMemberInfosIndex].getIsLeader();

	// 是否队长
	writeInteger(teamMemberInfos_isLeader);

	int teamMemberInfos_tplId = teamMemberInfos[teamMemberInfosIndex].getTplId();

	// 模板Id
	writeInteger(teamMemberInfos_tplId);

	int teamMemberInfos_isFriend = teamMemberInfos[teamMemberInfosIndex].getIsFriend();

	// 是否伙伴，0否，1是
	writeInteger(teamMemberInfos_isFriend);

	String teamMemberInfos_name = teamMemberInfos[teamMemberInfosIndex].getName();

	// 名字 
	writeString(teamMemberInfos_name);

	int teamMemberInfos_jobTypeId = teamMemberInfos[teamMemberInfosIndex].getJobTypeId();

	// 职业Id
	writeInteger(teamMemberInfos_jobTypeId);

	int teamMemberInfos_level = teamMemberInfos[teamMemberInfosIndex].getLevel();

	// 等级
	writeInteger(teamMemberInfos_level);

	int teamMemberInfos_position = teamMemberInfos[teamMemberInfosIndex].getPosition();

	// 位置Id，从1开始计数
	writeInteger(teamMemberInfos_position);

	int teamMemberInfos_status = teamMemberInfos[teamMemberInfosIndex].getStatus();

	// 状态，1队伍中，2暂离
	writeInteger(teamMemberInfos_status);

	int teamMemberInfos_equipWeaponId = teamMemberInfos[teamMemberInfosIndex].getEquipWeaponId();

	// 主将武器模板Id
	writeInteger(teamMemberInfos_equipWeaponId);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_NVN_MATCHED_TEAM_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_NVN_MATCHED_TEAM_INFO";
	}

	public int getTeamScore(){
		return teamScore;
	}
		
	public void setTeamScore(int teamScore){
		this.teamScore = teamScore;
	}

	public com.imop.lj.common.model.team.TeamMemberInfo[] getTeamMemberInfos(){
		return teamMemberInfos;
	}

	public void setTeamMemberInfos(com.imop.lj.common.model.team.TeamMemberInfo[] teamMemberInfos){
		this.teamMemberInfos = teamMemberInfos;
	}	
}