package com.imop.lj.gameserver.title.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.title.handler.TitleHandlerFactory;

/**
 * 申请称号界面
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTitlePanel extends CGMessage{
	
	
	public CGTitlePanel (){
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
		return MessageType.CG_TITLE_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TITLE_PANEL";
	}


	@Override
	public void execute() {
		TitleHandlerFactory.getHandler().handleTitlePanel(this.getSession().getPlayer(), this);
	}
}