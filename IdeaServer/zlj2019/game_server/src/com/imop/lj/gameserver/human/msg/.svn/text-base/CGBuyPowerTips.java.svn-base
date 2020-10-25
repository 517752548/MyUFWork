package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.human.handler.HumanHandlerFactory;

/**
 * 购买体力tips信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBuyPowerTips extends CGMessage{
	
	
	public CGBuyPowerTips (){
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
		return MessageType.CG_BUY_POWER_TIPS;
	}
	
	@Override
	public String getTypeName() {
		return "CG_BUY_POWER_TIPS";
	}


	@Override
	public void execute() {
		HumanHandlerFactory.getHandler().handleBuyPowerTips(this.getSession().getPlayer(), this);
	}
}