package com.imop.lj.gameserver.marry.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.marry.handler.MarryHandlerFactory;

/**
 * 强制离婚
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGForceFireMarry extends CGMessage{
	
	
	public CGForceFireMarry (){
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
		return MessageType.CG_FORCE_FIRE_MARRY;
	}
	
	@Override
	public String getTypeName() {
		return "CG_FORCE_FIRE_MARRY";
	}


	@Override
	public void execute() {
		MarryHandlerFactory.getHandler().handleForceFireMarry(this.getSession().getPlayer(), this);
	}
}