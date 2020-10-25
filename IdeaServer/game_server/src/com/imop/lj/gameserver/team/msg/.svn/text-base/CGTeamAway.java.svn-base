package com.imop.lj.gameserver.team.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.team.handler.TeamHandlerFactory;

/**
 * 暂离队伍
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamAway extends CGMessage{
	
	
	public CGTeamAway (){
	}
	
	
	@Override
	protected boolean readImpl() {


		return true;
	}
	
	@Override
	protected boolean writeImpl() {

		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_TEAM_AWAY;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TEAM_AWAY";
	}


	@Override
	public void execute() {
		TeamHandlerFactory.getHandler().handleTeamAway(this.getSession().getPlayer(), this);
	}
}