package com.imop.lj.gameserver.marry.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.marry.handler.MarryHandlerFactory;

/**
 * 获取当前用户的结婚信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGMarryInfo extends CGMessage{
	
	
	public CGMarryInfo (){
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
		return MessageType.CG_MARRY_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "CG_MARRY_INFO";
	}


	@Override
	public void execute() {
		MarryHandlerFactory.getHandler().handleMarryInfo(this.getSession().getPlayer(), this);
	}
}