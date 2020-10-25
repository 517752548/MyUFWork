package com.imop.lj.gameserver.battle.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.battle.handler.BattleHandlerFactory;

/**
 * 请求组队PVP战斗
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBattleStartTeampvp extends CGMessage{
	
	/** 目标玩家Id */
	private long targetPlayerId;
	
	public CGBattleStartTeampvp (){
	}
	
	public CGBattleStartTeampvp (
			long targetPlayerId ){
			this.targetPlayerId = targetPlayerId;
	}
	
	@Override
	protected boolean readImpl() {

	// 目标玩家Id
	long _targetPlayerId = readLong();
	//end



			this.targetPlayerId = _targetPlayerId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 目标玩家Id
	writeLong(targetPlayerId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_BATTLE_START_TEAMPVP;
	}
	
	@Override
	public String getTypeName() {
		return "CG_BATTLE_START_TEAMPVP";
	}

	public long getTargetPlayerId(){
		return targetPlayerId;
	}
		
	public void setTargetPlayerId(long targetPlayerId){
		this.targetPlayerId = targetPlayerId;
	}


	@Override
	public void execute() {
		BattleHandlerFactory.getHandler().handleBattleStartTeampvp(this.getSession().getPlayer(), this);
	}
}