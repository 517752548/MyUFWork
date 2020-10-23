package com.imop.lj.gameserver.battle.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.battle.handler.BattleHandlerFactory;

/**
 * 战斗加速
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBattleSpeedup extends CGMessage{
	
	/** 速度倍数 */
	private int speed;
	
	public CGBattleSpeedup (){
	}
	
	public CGBattleSpeedup (
			int speed ){
			this.speed = speed;
	}
	
	@Override
	protected boolean readImpl() {

	// 速度倍数
	int _speed = readInteger();
	//end



			this.speed = _speed;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 速度倍数
	writeInteger(speed);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_BATTLE_SPEEDUP;
	}
	
	@Override
	public String getTypeName() {
		return "CG_BATTLE_SPEEDUP";
	}

	public int getSpeed(){
		return speed;
	}
		
	public void setSpeed(int speed){
		this.speed = speed;
	}


	@Override
	public void execute() {
		BattleHandlerFactory.getHandler().handleBattleSpeedup(this.getSession().getPlayer(), this);
	}
}