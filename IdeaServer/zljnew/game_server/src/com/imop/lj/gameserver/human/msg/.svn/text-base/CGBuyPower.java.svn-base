package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.human.handler.HumanHandlerFactory;

/**
 * 购买体力
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBuyPower extends CGMessage{
	
	
	public CGBuyPower (){
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
		return MessageType.CG_BUY_POWER;
	}
	
	@Override
	public String getTypeName() {
		return "CG_BUY_POWER";
	}


	@Override
	public void execute() {
		HumanHandlerFactory.getHandler().handleBuyPower(this.getSession().getPlayer(), this);
	}
}