package com.imop.lj.gameserver.team.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.team.handler.TeamHandlerFactory;

/**
 * 邀请成员列表
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamInviteList extends CGMessage{
	
	/** 邀请类型，1好友，2军团 */
	private int inviteTypeId;
	
	public CGTeamInviteList (){
	}
	
	public CGTeamInviteList (
			int inviteTypeId ){
			this.inviteTypeId = inviteTypeId;
	}
	
	@Override
	protected boolean readImpl() {

	// 邀请类型，1好友，2军团
	int _inviteTypeId = readInteger();
	//end



			this.inviteTypeId = _inviteTypeId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 邀请类型，1好友，2军团
	writeInteger(inviteTypeId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_TEAM_INVITE_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TEAM_INVITE_LIST";
	}

	public int getInviteTypeId(){
		return inviteTypeId;
	}
		
	public void setInviteTypeId(int inviteTypeId){
		this.inviteTypeId = inviteTypeId;
	}


	@Override
	public void execute() {
		TeamHandlerFactory.getHandler().handleTeamInviteList(this.getSession().getPlayer(), this);
	}
}