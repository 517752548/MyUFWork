package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 请求打开帮派红包面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOpenCorpsRedEnvelopePanel extends CGMessage{
	
	
	public CGOpenCorpsRedEnvelopePanel (){
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
		return MessageType.CG_OPEN_CORPS_RED_ENVELOPE_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_OPEN_CORPS_RED_ENVELOPE_PANEL";
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleOpenCorpsRedEnvelopePanel(this.getSession().getPlayer(), this);
	}
}