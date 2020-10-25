package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 打开帮派福利面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOpenCorpsBenifitPanel extends CGMessage{
	
	
	public CGOpenCorpsBenifitPanel (){
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
		return MessageType.CG_OPEN_CORPS_BENIFIT_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_OPEN_CORPS_BENIFIT_PANEL";
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleOpenCorpsBenifitPanel(this.getSession().getPlayer(), this);
	}
}