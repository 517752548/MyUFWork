package com.imop.lj.gameserver.overman.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.overman.handler.OvermanHandlerFactory;

/**
 * 申请出师
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFirstFireOverman extends CGMessage{
	
	
	public CGFirstFireOverman (){
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
		return MessageType.CG_FIRST_FIRE_OVERMAN;
	}
	
	@Override
	public String getTypeName() {
		return "CG_FIRST_FIRE_OVERMAN";
	}


	@Override
	public void execute() {
		OvermanHandlerFactory.getHandler().handleFirstFireOverman(this.getSession().getPlayer(), this);
	}
}