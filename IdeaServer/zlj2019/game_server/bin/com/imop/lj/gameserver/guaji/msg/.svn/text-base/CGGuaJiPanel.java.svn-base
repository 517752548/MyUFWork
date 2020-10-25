package com.imop.lj.gameserver.guaji.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.guaji.handler.GuajiHandlerFactory;

/**
 * 打开挂机面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGuaJiPanel extends CGMessage{
	
	
	public CGGuaJiPanel (){
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
		return MessageType.CG_GUA_JI_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_GUA_JI_PANEL";
	}


	@Override
	public void execute() {
		GuajiHandlerFactory.getHandler().handleGuaJiPanel(this.getSession().getPlayer(), this);
	}
}