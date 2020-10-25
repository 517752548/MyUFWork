package com.imop.lj.gameserver.nvn.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.nvn.handler.NvnHandlerFactory;

/**
 * nvn开始匹配
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGNvnStartMatch extends CGMessage{
	
	
	public CGNvnStartMatch (){
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
		return MessageType.CG_NVN_START_MATCH;
	}
	
	@Override
	public String getTypeName() {
		return "CG_NVN_START_MATCH";
	}


	@Override
	public void execute() {
		NvnHandlerFactory.getHandler().handleNvnStartMatch(this.getSession().getPlayer(), this);
	}
}