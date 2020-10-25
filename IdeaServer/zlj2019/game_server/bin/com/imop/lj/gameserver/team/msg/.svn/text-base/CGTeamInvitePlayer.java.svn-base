package com.imop.lj.gameserver.team.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.team.handler.TeamHandlerFactory;

/**
 * 邀请成员加入队伍
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamInvitePlayer extends CGMessage{
	
	/** 邀请类型，1好友，2军团 */
	private int inviteTypeId;
	/** 目标玩家id */
	private long targetPlayerId;
	
	public CGTeamInvitePlayer (){
	}
	
	public CGTeamInvitePlayer (
			int inviteTypeId,
			long targetPlayerId ){
			this.inviteTypeId = inviteTypeId;
			this.targetPlayerId = targetPlayerId;
	}
	
	@Override
	protected boolean readImpl() {

	// 邀请类型，1好友，2军团
	int _inviteTypeId = readInteger();
	//end


	// 目标玩家id
	long _targetPlayerId = readLong();
	//end



			this.inviteTypeId = _inviteTypeId;
			this.targetPlayerId = _targetPlayerId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 邀请类型，1好友，2军团
	writeInteger(inviteTypeId);


	// 目标玩家id
	writeLong(targetPlayerId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_TEAM_INVITE_PLAYER;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TEAM_INVITE_PLAYER";
	}

	public int getInviteTypeId(){
		return inviteTypeId;
	}
		
	public void setInviteTypeId(int inviteTypeId){
		this.inviteTypeId = inviteTypeId;
	}

	public long getTargetPlayerId(){
		return targetPlayerId;
	}
		
	public void setTargetPlayerId(long targetPlayerId){
		this.targetPlayerId = targetPlayerId;
	}


	@Override
	public void execute() {
		TeamHandlerFactory.getHandler().handleTeamInvitePlayer(this.getSession().getPlayer(), this);
	}
}