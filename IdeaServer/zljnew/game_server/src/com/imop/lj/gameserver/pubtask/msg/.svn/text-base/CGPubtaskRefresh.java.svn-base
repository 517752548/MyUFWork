package com.imop.lj.gameserver.pubtask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pubtask.handler.PubtaskHandlerFactory;

/**
 * 酒馆任务手动刷新
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPubtaskRefresh extends CGMessage{
	
	
	public CGPubtaskRefresh (){
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
		return MessageType.CG_PUBTASK_REFRESH;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PUBTASK_REFRESH";
	}


	@Override
	public void execute() {
		PubtaskHandlerFactory.getHandler().handlePubtaskRefresh(this.getSession().getPlayer(), this);
	}
}