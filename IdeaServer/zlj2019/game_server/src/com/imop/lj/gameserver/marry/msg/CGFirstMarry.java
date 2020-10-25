package com.imop.lj.gameserver.marry.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.marry.handler.MarryHandlerFactory;

/**
 * 申请结婚,弹框
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFirstMarry extends CGMessage{
	
	
	public CGFirstMarry (){
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
		return MessageType.CG_FIRST_MARRY;
	}
	
	@Override
	public String getTypeName() {
		return "CG_FIRST_MARRY";
	}


	@Override
	public void execute() {
		MarryHandlerFactory.getHandler().handleFirstMarry(this.getSession().getPlayer(), this);
	}
}