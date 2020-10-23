package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.player.handler.PlayerHandlerFactory;

/**
 * 领取手机验证奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGetSmsCheckcodeReward extends CGMessage{
	
	
	public CGGetSmsCheckcodeReward (){
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
		return MessageType.CG_GET_SMS_CHECKCODE_REWARD;
	}
	
	@Override
	public String getTypeName() {
		return "CG_GET_SMS_CHECKCODE_REWARD";
	}


	@Override
	public void execute() {
		PlayerHandlerFactory.getHandler().handleGetSmsCheckcodeReward(this.getSession().getPlayer(), this);
	}
}