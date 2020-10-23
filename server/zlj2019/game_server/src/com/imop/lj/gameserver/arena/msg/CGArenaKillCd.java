package com.imop.lj.gameserver.arena.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.arena.handler.ArenaHandlerFactory;

/**
 * 消除竞技场cd
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGArenaKillCd extends CGMessage{
	
	
	public CGArenaKillCd (){
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
		return MessageType.CG_ARENA_KILL_CD;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ARENA_KILL_CD";
	}


	@Override
	public void execute() {
		ArenaHandlerFactory.getHandler().handleArenaKillCd(this.getSession().getPlayer(), this);
	}
}