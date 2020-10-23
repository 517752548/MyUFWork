package com.imop.lj.gameserver.siegedemon.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.siegedemon.handler.SiegedemonHandlerFactory;

/**
 * 离开副本
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSiegedemonLeave extends CGMessage{
	
	
	public CGSiegedemonLeave (){
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
		return MessageType.CG_SIEGEDEMON_LEAVE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_SIEGEDEMON_LEAVE";
	}


	@Override
	public void execute() {
		SiegedemonHandlerFactory.getHandler().handleSiegedemonLeave(this.getSession().getPlayer(), this);
	}
}