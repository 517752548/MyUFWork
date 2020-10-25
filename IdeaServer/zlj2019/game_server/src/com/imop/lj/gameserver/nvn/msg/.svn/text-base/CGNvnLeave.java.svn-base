package com.imop.lj.gameserver.nvn.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.nvn.handler.NvnHandlerFactory;

/**
 * 退出nvn联赛
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGNvnLeave extends CGMessage{
	
	
	public CGNvnLeave (){
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
		return MessageType.CG_NVN_LEAVE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_NVN_LEAVE";
	}


	@Override
	public void execute() {
		NvnHandlerFactory.getHandler().handleNvnLeave(this.getSession().getPlayer(), this);
	}
}