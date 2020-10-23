package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 请求打开帮派辅助技能面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOpenCorpsAssistPanel extends CGMessage{
	
	
	public CGOpenCorpsAssistPanel (){
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
		return MessageType.CG_OPEN_CORPS_ASSIST_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_OPEN_CORPS_ASSIST_PANEL";
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleOpenCorpsAssistPanel(this.getSession().getPlayer(), this);
	}
}