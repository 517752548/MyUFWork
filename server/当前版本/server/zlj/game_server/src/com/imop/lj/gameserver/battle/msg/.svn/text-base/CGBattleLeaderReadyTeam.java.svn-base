package com.imop.lj.gameserver.battle.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.battle.handler.BattleHandlerFactory;

/**
 * 主将准备中状态已完毕team
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBattleLeaderReadyTeam extends CGMessage{
	
	
	public CGBattleLeaderReadyTeam (){
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
		return MessageType.CG_BATTLE_LEADER_READY_TEAM;
	}
	
	@Override
	public String getTypeName() {
		return "CG_BATTLE_LEADER_READY_TEAM";
	}


	@Override
	public void execute() {
		BattleHandlerFactory.getHandler().handleBattleLeaderReadyTeam(this.getSession().getPlayer(), this);
	}
}