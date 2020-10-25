package com.imop.lj.gameserver.arena.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.arena.handler.ArenaHandlerFactory;

/**
 * 请求显示竞技场面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGShowArenaPanel extends CGMessage{
	
	
	public CGShowArenaPanel (){
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
		return MessageType.CG_SHOW_ARENA_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_SHOW_ARENA_PANEL";
	}


	@Override
	public void execute() {
		ArenaHandlerFactory.getHandler().handleShowArenaPanel(this.getSession().getPlayer(), this);
	}
}