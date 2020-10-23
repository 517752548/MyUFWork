package com.imop.lj.gameserver.promote.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.promote.handler.PromoteHandlerFactory;

/**
 * 打开提升面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPromotePanel extends CGMessage{
	
	
	public CGPromotePanel (){
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
		return MessageType.CG_PROMOTE_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PROMOTE_PANEL";
	}


	@Override
	public void execute() {
		PromoteHandlerFactory.getHandler().handlePromotePanel(this.getSession().getPlayer(), this);
	}
}