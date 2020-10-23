package com.imop.lj.gameserver.pubtask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pubtask.handler.PubtaskHandlerFactory;

/**
 * 打开酒馆任务面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOpenPubtaskPanel extends CGMessage{
	
	
	public CGOpenPubtaskPanel (){
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
		return MessageType.CG_OPEN_PUBTASK_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_OPEN_PUBTASK_PANEL";
	}


	@Override
	public void execute() {
		PubtaskHandlerFactory.getHandler().handleOpenPubtaskPanel(this.getSession().getPlayer(), this);
	}
}