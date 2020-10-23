package com.imop.lj.gameserver.arena.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.arena.handler.ArenaHandlerFactory;

/**
 * 购买挑战次数
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGArenaBuyChallengeTime extends CGMessage{
	
	
	public CGArenaBuyChallengeTime (){
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
		return MessageType.CG_ARENA_BUY_CHALLENGE_TIME;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ARENA_BUY_CHALLENGE_TIME";
	}


	@Override
	public void execute() {
		ArenaHandlerFactory.getHandler().handleArenaBuyChallengeTime(this.getSession().getPlayer(), this);
	}
}