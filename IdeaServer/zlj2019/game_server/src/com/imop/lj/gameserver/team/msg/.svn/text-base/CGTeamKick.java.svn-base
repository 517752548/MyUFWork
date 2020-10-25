package com.imop.lj.gameserver.team.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.team.handler.TeamHandlerFactory;

/**
 * 请离队伍
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamKick extends CGMessage{
	
	/** 目标玩家id */
	private long targetPlayerId;
	
	public CGTeamKick (){
	}
	
	public CGTeamKick (
			long targetPlayerId ){
			this.targetPlayerId = targetPlayerId;
	}
	
	@Override
	protected boolean readImpl() {

	// 目标玩家id
	long _targetPlayerId = readLong();
	//end



			this.targetPlayerId = _targetPlayerId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 目标玩家id
	writeLong(targetPlayerId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_TEAM_KICK;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TEAM_KICK";
	}

	public long getTargetPlayerId(){
		return targetPlayerId;
	}
		
	public void setTargetPlayerId(long targetPlayerId){
		this.targetPlayerId = targetPlayerId;
	}


	@Override
	public void execute() {
		TeamHandlerFactory.getHandler().handleTeamKick(this.getSession().getPlayer(), this);
	}
}