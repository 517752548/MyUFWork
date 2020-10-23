package com.imop.lj.gameserver.nvn.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.nvn.handler.NvnHandlerFactory;

/**
 * 请求进入nvn联赛
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGNvnEnter extends CGMessage{
	
	
	public CGNvnEnter (){
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
		return MessageType.CG_NVN_ENTER;
	}
	
	@Override
	public String getTypeName() {
		return "CG_NVN_ENTER";
	}


	@Override
	public void execute() {
		NvnHandlerFactory.getHandler().handleNvnEnter(this.getSession().getPlayer(), this);
	}
}