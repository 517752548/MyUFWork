package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.human.handler.HumanHandlerFactory;

/**
 * 领取月卡返利
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGetMonthCardGift extends CGMessage{
	
	
	public CGGetMonthCardGift (){
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
		return MessageType.CG_GET_MONTH_CARD_GIFT;
	}
	
	@Override
	public String getTypeName() {
		return "CG_GET_MONTH_CARD_GIFT";
	}


	@Override
	public void execute() {
		HumanHandlerFactory.getHandler().handleGetMonthCardGift(this.getSession().getPlayer(), this);
	}
}