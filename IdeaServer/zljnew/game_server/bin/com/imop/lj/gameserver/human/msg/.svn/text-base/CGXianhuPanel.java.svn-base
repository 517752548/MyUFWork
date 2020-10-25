package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.human.handler.HumanHandlerFactory;

/**
 * 仙葫面板消息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGXianhuPanel extends CGMessage{
	
	
	public CGXianhuPanel (){
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
		return MessageType.CG_XIANHU_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_XIANHU_PANEL";
	}


	@Override
	public void execute() {
		HumanHandlerFactory.getHandler().handleXianhuPanel(this.getSession().getPlayer(), this);
	}
}