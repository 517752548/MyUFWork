package com.imop.lj.gameserver.arena.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.arena.handler.ArenaHandlerFactory;

/**
 * 显示竞技场榜首信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGArenaTopRankList extends CGMessage{
	
	
	public CGArenaTopRankList (){
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
		return MessageType.CG_ARENA_TOP_RANK_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ARENA_TOP_RANK_LIST";
	}


	@Override
	public void execute() {
		ArenaHandlerFactory.getHandler().handleArenaTopRankList(this.getSession().getPlayer(), this);
	}
}