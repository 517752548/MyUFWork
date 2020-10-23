package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 点击军团按钮
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGClickCorpsPanel extends CGMessage{
	
	
	public CGClickCorpsPanel (){
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
		return MessageType.CG_CLICK_CORPS_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CLICK_CORPS_PANEL";
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleClickCorpsPanel(this.getSession().getPlayer(), this);
	}
}