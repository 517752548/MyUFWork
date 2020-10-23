package com.imop.lj.gameserver.arena.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.arena.handler.ArenaHandlerFactory;

/**
 * 攻击挑战列表对手
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGArenaAttackOpponent extends CGMessage{
	
	/** 对手序号，从1开始 */
	private int targetNum;
	
	public CGArenaAttackOpponent (){
	}
	
	public CGArenaAttackOpponent (
			int targetNum ){
			this.targetNum = targetNum;
	}
	
	@Override
	protected boolean readImpl() {

	// 对手序号，从1开始
	int _targetNum = readInteger();
	//end



			this.targetNum = _targetNum;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 对手序号，从1开始
	writeInteger(targetNum);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_ARENA_ATTACK_OPPONENT;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ARENA_ATTACK_OPPONENT";
	}

	public int getTargetNum(){
		return targetNum;
	}
		
	public void setTargetNum(int targetNum){
		this.targetNum = targetNum;
	}


	@Override
	public void execute() {
		ArenaHandlerFactory.getHandler().handleArenaAttackOpponent(this.getSession().getPlayer(), this);
	}
}