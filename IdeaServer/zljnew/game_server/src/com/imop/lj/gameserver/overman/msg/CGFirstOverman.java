package com.imop.lj.gameserver.overman.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.overman.handler.OvermanHandlerFactory;

/**
 * 申请收徒,弹框
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFirstOverman extends CGMessage{
	
	
	public CGFirstOverman (){
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
		return MessageType.CG_FIRST_OVERMAN;
	}
	
	@Override
	public String getTypeName() {
		return "CG_FIRST_OVERMAN";
	}


	@Override
	public void execute() {
		OvermanHandlerFactory.getHandler().handleFirstOverman(this.getSession().getPlayer(), this);
	}
}