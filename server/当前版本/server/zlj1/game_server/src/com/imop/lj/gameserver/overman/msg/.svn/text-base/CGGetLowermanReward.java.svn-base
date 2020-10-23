package com.imop.lj.gameserver.overman.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.overman.handler.OvermanHandlerFactory;

/**
 * 获得徒弟所有的奖励状态
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGetLowermanReward extends CGMessage{
	
	
	public CGGetLowermanReward (){
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
		return MessageType.CG_GET_LOWERMAN_REWARD;
	}
	
	@Override
	public String getTypeName() {
		return "CG_GET_LOWERMAN_REWARD";
	}


	@Override
	public void execute() {
		OvermanHandlerFactory.getHandler().handleGetLowermanReward(this.getSession().getPlayer(), this);
	}
}