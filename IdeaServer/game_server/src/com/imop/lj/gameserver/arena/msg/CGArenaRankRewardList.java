package com.imop.lj.gameserver.arena.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.arena.handler.ArenaHandlerFactory;

/**
 * 竞技场排名奖励列表
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGArenaRankRewardList extends CGMessage{
	
	
	public CGArenaRankRewardList (){
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
		return MessageType.CG_ARENA_RANK_REWARD_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ARENA_RANK_REWARD_LIST";
	}


	@Override
	public void execute() {
		ArenaHandlerFactory.getHandler().handleArenaRankRewardList(this.getSession().getPlayer(), this);
	}
}