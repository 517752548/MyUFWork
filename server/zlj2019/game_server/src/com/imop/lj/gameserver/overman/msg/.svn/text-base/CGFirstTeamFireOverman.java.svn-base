package com.imop.lj.gameserver.overman.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.overman.handler.OvermanHandlerFactory;

/**
 * 申请解除师徒关系
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFirstTeamFireOverman extends CGMessage{
	
	
	public CGFirstTeamFireOverman (){
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
		return MessageType.CG_FIRST_TEAM_FIRE_OVERMAN;
	}
	
	@Override
	public String getTypeName() {
		return "CG_FIRST_TEAM_FIRE_OVERMAN";
	}


	@Override
	public void execute() {
		OvermanHandlerFactory.getHandler().handleFirstTeamFireOverman(this.getSession().getPlayer(), this);
	}
}