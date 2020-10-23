package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 请求帮派竞赛信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpswarInfo extends CGMessage{
	
	
	public CGCorpswarInfo (){
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
		return MessageType.CG_CORPSWAR_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CORPSWAR_INFO";
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleCorpswarInfo(this.getSession().getPlayer(), this);
	}
}