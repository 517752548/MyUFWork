package com.imop.lj.gameserver.team.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 邀请成员列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTeamInviteList extends GCMessage{
	
	/** 邀请类型，1好友，2军团 */
	private int inviteTypeId;
	/** 邀请玩家信息列表 */
	private com.imop.lj.common.model.team.TeamInvitePlayerInfo[] teamInvitePlayerInfos;

	public GCTeamInviteList (){
	}
	
	public GCTeamInviteList (
			int inviteTypeId,
			com.imop.lj.common.model.team.TeamInvitePlayerInfo[] teamInvitePlayerInfos ){
			this.inviteTypeId = inviteTypeId;
			this.teamInvitePlayerInfos = teamInvitePlayerInfos;
	}

	@Override
	protected boolean readImpl() {

	// 邀请类型，1好友，2军团
	int _inviteTypeId = readInteger();
	//end


	// 邀请玩家信息列表
	int teamInvitePlayerInfosSize = readUnsignedShort();
	com.imop.lj.common.model.team.TeamInvitePlayerInfo[] _teamInvitePlayerInfos = new com.imop.lj.common.model.team.TeamInvitePlayerInfo[teamInvitePlayerInfosSize];
	int teamInvitePlayerInfosIndex = 0;
	for(teamInvitePlayerInfosIndex=0; teamInvitePlayerInfosIndex<teamInvitePlayerInfosSize; teamInvitePlayerInfosIndex++){
		_teamInvitePlayerInfos[teamInvitePlayerInfosIndex] = new com.imop.lj.common.model.team.TeamInvitePlayerInfo();
	// 玩家唯一Id
	long _teamInvitePlayerInfos_uuid = readLong();
	//end
	_teamInvitePlayerInfos[teamInvitePlayerInfosIndex].setUuid (_teamInvitePlayerInfos_uuid);

	// 名字 
	String _teamInvitePlayerInfos_name = readString();
	//end
	_teamInvitePlayerInfos[teamInvitePlayerInfosIndex].setName (_teamInvitePlayerInfos_name);

	// 职业Id
	int _teamInvitePlayerInfos_jobTypeId = readInteger();
	//end
	_teamInvitePlayerInfos[teamInvitePlayerInfosIndex].setJobTypeId (_teamInvitePlayerInfos_jobTypeId);

	// 等级
	int _teamInvitePlayerInfos_level = readInteger();
	//end
	_teamInvitePlayerInfos[teamInvitePlayerInfosIndex].setLevel (_teamInvitePlayerInfos_level);

	// 模板Id
	int _teamInvitePlayerInfos_tplId = readInteger();
	//end
	_teamInvitePlayerInfos[teamInvitePlayerInfosIndex].setTplId (_teamInvitePlayerInfos_tplId);
	}
	//end



		this.inviteTypeId = _inviteTypeId;
		this.teamInvitePlayerInfos = _teamInvitePlayerInfos;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 邀请类型，1好友，2军团
	writeInteger(inviteTypeId);


	// 邀请玩家信息列表
	writeShort(teamInvitePlayerInfos.length);
	int teamInvitePlayerInfosIndex = 0;
	int teamInvitePlayerInfosSize = teamInvitePlayerInfos.length;
	for(teamInvitePlayerInfosIndex=0; teamInvitePlayerInfosIndex<teamInvitePlayerInfosSize; teamInvitePlayerInfosIndex++){

	long teamInvitePlayerInfos_uuid = teamInvitePlayerInfos[teamInvitePlayerInfosIndex].getUuid();

	// 玩家唯一Id
	writeLong(teamInvitePlayerInfos_uuid);

	String teamInvitePlayerInfos_name = teamInvitePlayerInfos[teamInvitePlayerInfosIndex].getName();

	// 名字 
	writeString(teamInvitePlayerInfos_name);

	int teamInvitePlayerInfos_jobTypeId = teamInvitePlayerInfos[teamInvitePlayerInfosIndex].getJobTypeId();

	// 职业Id
	writeInteger(teamInvitePlayerInfos_jobTypeId);

	int teamInvitePlayerInfos_level = teamInvitePlayerInfos[teamInvitePlayerInfosIndex].getLevel();

	// 等级
	writeInteger(teamInvitePlayerInfos_level);

	int teamInvitePlayerInfos_tplId = teamInvitePlayerInfos[teamInvitePlayerInfosIndex].getTplId();

	// 模板Id
	writeInteger(teamInvitePlayerInfos_tplId);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_TEAM_INVITE_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_TEAM_INVITE_LIST";
	}

	public int getInviteTypeId(){
		return inviteTypeId;
	}
		
	public void setInviteTypeId(int inviteTypeId){
		this.inviteTypeId = inviteTypeId;
	}

	public com.imop.lj.common.model.team.TeamInvitePlayerInfo[] getTeamInvitePlayerInfos(){
		return teamInvitePlayerInfos;
	}

	public void setTeamInvitePlayerInfos(com.imop.lj.common.model.team.TeamInvitePlayerInfo[] teamInvitePlayerInfos){
		this.teamInvitePlayerInfos = teamInvitePlayerInfos;
	}	
	public boolean isCompress() {
		return true;
	}
}