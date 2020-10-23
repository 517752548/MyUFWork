package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.player.handler.PlayerHandlerFactory;

/**
 * 手机验证面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSmsCheckcodePanel extends CGMessage{
	
	
	public CGSmsCheckcodePanel (){
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
		return MessageType.CG_SMS_CHECKCODE_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_SMS_CHECKCODE_PANEL";
	}


	@Override
	public void execute() {
		PlayerHandlerFactory.getHandler().handleSmsCheckcodePanel(this.getSession().getPlayer(), this);
	}
}