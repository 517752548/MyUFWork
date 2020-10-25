package com.imop.lj.gameserver.battle.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.battle.handler.BattleHandlerFactory;

/**
 * 主将准备中状态已完毕pvp
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBattleLeaderReadyPvp extends CGMessage{
	
	
	public CGBattleLeaderReadyPvp (){
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
		return MessageType.CG_BATTLE_LEADER_READY_PVP;
	}
	
	@Override
	public String getTypeName() {
		return "CG_BATTLE_LEADER_READY_PVP";
	}


	@Override
	public void execute() {
		BattleHandlerFactory.getHandler().handleBattleLeaderReadyPvp(this.getSession().getPlayer(), this);
	}
}