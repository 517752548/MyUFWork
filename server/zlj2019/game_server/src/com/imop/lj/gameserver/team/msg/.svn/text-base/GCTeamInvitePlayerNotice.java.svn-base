package com.imop.lj.gameserver.team.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 邀请成员加入队伍的弹出提示框
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTeamInvitePlayerNotice extends GCMessage{
	
	/** 邀请玩家的队伍Id */
	private int teamId;
	/** 邀请者的玩家Id */
	private long inviterRoleId;
	/** 邀请者的名字 */
	private String inviterName;

	public GCTeamInvitePlayerNotice (){
	}
	
	public GCTeamInvitePlayerNotice (
			int teamId,
			long inviterRoleId,
			String inviterName ){
			this.teamId = teamId;
			this.inviterRoleId = inviterRoleId;
			this.inviterName = inviterName;
	}

	@Override
	protected boolean readImpl() {

	// 邀请玩家的队伍Id
	int _teamId = readInteger();
	//end


	// 邀请者的玩家Id
	long _inviterRoleId = readLong();
	//end


	// 邀请者的名字
	String _inviterName = readString();
	//end



		this.teamId = _teamId;
		this.inviterRoleId = _inviterRoleId;
		this.inviterName = _inviterName;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 邀请玩家的队伍Id
	writeInteger(teamId);


	// 邀请者的玩家Id
	writeLong(inviterRoleId);


	// 邀请者的名字
	writeString(inviterName);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_TEAM_INVITE_PLAYER_NOTICE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_TEAM_INVITE_PLAYER_NOTICE";
	}

	public int getTeamId(){
		return teamId;
	}
		
	public void setTeamId(int teamId){
		this.teamId = teamId;
	}

	public long getInviterRoleId(){
		return inviterRoleId;
	}
		
	public void setInviterRoleId(long inviterRoleId){
		this.inviterRoleId = inviterRoleId;
	}

	public String getInviterName(){
		return inviterName;
	}
		
	public void setInviterName(String inviterName){
		this.inviterName = inviterName;
	}
}