package com.imop.lj.gameserver.nvn.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.nvn.handler.NvnHandlerFactory;

/**
 * nvn取消匹配
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGNvnCancleMatch extends CGMessage{
	
	
	public CGNvnCancleMatch (){
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
		return MessageType.CG_NVN_CANCLE_MATCH;
	}
	
	@Override
	public String getTypeName() {
		return "CG_NVN_CANCLE_MATCH";
	}


	@Override
	public void execute() {
		NvnHandlerFactory.getHandler().handleNvnCancleMatch(this.getSession().getPlayer(), this);
	}
}