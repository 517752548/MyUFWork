package com.imop.lj.gameserver.team.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.team.handler.TeamHandlerFactory;

/**
 * 回到队伍，暂离状态下
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamBack extends CGMessage{
	
	
	public CGTeamBack (){
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
		return MessageType.CG_TEAM_BACK;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TEAM_BACK";
	}


	@Override
	public void execute() {
		TeamHandlerFactory.getHandler().handleTeamBack(this.getSession().getPlayer(), this);
	}
}