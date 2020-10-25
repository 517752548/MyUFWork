package com.imop.lj.gameserver.battle.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 战斗加速结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBattleSpeedup extends GCMessage{
	
	/** 速度倍数 */
	private int speed;
	/** 能否使用加速，0否，1是 */
	private int canSpeedup;

	public GCBattleSpeedup (){
	}
	
	public GCBattleSpeedup (
			int speed,
			int canSpeedup ){
			this.speed = speed;
			this.canSpeedup = canSpeedup;
	}

	@Override
	protected boolean readImpl() {

	// 速度倍数
	int _speed = readInteger();
	//end


	// 能否使用加速，0否，1是
	int _canSpeedup = readInteger();
	//end



		this.speed = _speed;
		this.canSpeedup = _canSpeedup;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 速度倍数
	writeInteger(speed);


	// 能否使用加速，0否，1是
	writeInteger(canSpeedup);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_BATTLE_SPEEDUP;
	}
	
	@Override
	public String getTypeName() {
		return "GC_BATTLE_SPEEDUP";
	}

	public int getSpeed(){
		return speed;
	}
		
	public void setSpeed(int speed){
		this.speed = speed;
	}

	public int getCanSpeedup(){
		return canSpeedup;
	}
		
	public void setCanSpeedup(int canSpeedup){
		this.canSpeedup = canSpeedup;
	}
}