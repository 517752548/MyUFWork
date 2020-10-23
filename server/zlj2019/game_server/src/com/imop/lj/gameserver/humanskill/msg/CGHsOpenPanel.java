package com.imop.lj.gameserver.humanskill.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.humanskill.handler.HumanskillHandlerFactory;

/**
 * 打开心法技能面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGHsOpenPanel extends CGMessage{
	
	
	public CGHsOpenPanel (){
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
		return MessageType.CG_HS_OPEN_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_HS_OPEN_PANEL";
	}


	@Override
	public void execute() {
		HumanskillHandlerFactory.getHandler().handleHsOpenPanel(this.getSession().getPlayer(), this);
	}
}