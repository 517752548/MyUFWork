package com.imop.lj.gameserver.wing.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.wing.handler.WingHandlerFactory;

/**
 * 打开翅膀面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGWingPanel extends CGMessage{
	
	
	public CGWingPanel (){
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
		return MessageType.CG_WING_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_WING_PANEL";
	}


	@Override
	public void execute() {
		WingHandlerFactory.getHandler().handleWingPanel(this.getSession().getPlayer(), this);
	}
}