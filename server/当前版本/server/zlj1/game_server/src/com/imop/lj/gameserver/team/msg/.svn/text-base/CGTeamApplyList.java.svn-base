package com.imop.lj.gameserver.team.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.team.handler.TeamHandlerFactory;

/**
 * 申请列表
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamApplyList extends CGMessage{
	
	
	public CGTeamApplyList (){
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
		return MessageType.CG_TEAM_APPLY_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TEAM_APPLY_LIST";
	}


	@Override
	public void execute() {
		TeamHandlerFactory.getHandler().handleTeamApplyList(this.getSession().getPlayer(), this);
	}
}