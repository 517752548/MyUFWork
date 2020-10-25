package com.imop.lj.gameserver.team.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.team.handler.TeamHandlerFactory;

/**
 * 退出队伍
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamQuit extends CGMessage{
	
	
	public CGTeamQuit (){
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
		return MessageType.CG_TEAM_QUIT;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TEAM_QUIT";
	}


	@Override
	public void execute() {
		TeamHandlerFactory.getHandler().handleTeamQuit(this.getSession().getPlayer(), this);
	}
}