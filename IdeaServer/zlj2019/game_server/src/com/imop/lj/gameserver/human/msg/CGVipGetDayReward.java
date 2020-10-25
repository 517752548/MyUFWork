package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.human.handler.HumanHandlerFactory;

/**
 * 领取每日vip奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGVipGetDayReward extends CGMessage{
	
	
	public CGVipGetDayReward (){
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
		return MessageType.CG_VIP_GET_DAY_REWARD;
	}
	
	@Override
	public String getTypeName() {
		return "CG_VIP_GET_DAY_REWARD";
	}


	@Override
	public void execute() {
		HumanHandlerFactory.getHandler().handleVipGetDayReward(this.getSession().getPlayer(), this);
	}
}