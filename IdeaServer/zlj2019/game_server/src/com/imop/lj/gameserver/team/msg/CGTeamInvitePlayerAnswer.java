package com.imop.lj.gameserver.team.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.team.handler.TeamHandlerFactory;

/**
 * 邀请成员弹出提示框的响应
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamInvitePlayerAnswer extends CGMessage{
	
	/** 邀请玩家的队伍Id */
	private int teamId;
	/** 是否同意邀请，0拒绝，1同意 */
	private int agree;
	
	public CGTeamInvitePlayerAnswer (){
	}
	
	public CGTeamInvitePlayerAnswer (
			int teamId,
			int agree ){
			this.teamId = teamId;
			this.agree = agree;
	}
	
	@Override
	protected boolean readImpl() {

	// 邀请玩家的队伍Id
	int _teamId = readInteger();
	//end


	// 是否同意邀请，0拒绝，1同意
	int _agree = readInteger();
	//end



			this.teamId = _teamId;
			this.agree = _agree;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 邀请玩家的队伍Id
	writeInteger(teamId);


	// 是否同意邀请，0拒绝，1同意
	writeInteger(agree);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_TEAM_INVITE_PLAYER_ANSWER;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TEAM_INVITE_PLAYER_ANSWER";
	}

	public int getTeamId(){
		return teamId;
	}
		
	public void setTeamId(int teamId){
		this.teamId = teamId;
	}

	public int getAgree(){
		return agree;
	}
		
	public void setAgree(int agree){
		this.agree = agree;
	}


	@Override
	public void execute() {
		TeamHandlerFactory.getHandler().handleTeamInvitePlayerAnswer(this.getSession().getPlayer(), this);
	}
}