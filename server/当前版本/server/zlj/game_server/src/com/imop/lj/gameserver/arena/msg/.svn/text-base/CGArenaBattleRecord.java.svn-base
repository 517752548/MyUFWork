package com.imop.lj.gameserver.arena.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.arena.handler.ArenaHandlerFactory;

/**
 * 请求竞技场战斗记录
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGArenaBattleRecord extends CGMessage{
	
	
	public CGArenaBattleRecord (){
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
		return MessageType.CG_ARENA_BATTLE_RECORD;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ARENA_BATTLE_RECORD";
	}


	@Override
	public void execute() {
		ArenaHandlerFactory.getHandler().handleArenaBattleRecord(this.getSession().getPlayer(), this);
	}
}