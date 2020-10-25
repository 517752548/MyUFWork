package com.imop.lj.gameserver.guaji.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.guaji.handler.GuajiHandlerFactory;

/**
 * 暂停挂机
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPauseGuaJi extends CGMessage{
	
	
	public CGPauseGuaJi (){
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
		return MessageType.CG_PAUSE_GUA_JI;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PAUSE_GUA_JI";
	}


	@Override
	public void execute() {
		GuajiHandlerFactory.getHandler().handlePauseGuaJi(this.getSession().getPlayer(), this);
	}
}