package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.human.handler.HumanHandlerFactory;

/**
 * 请求月卡信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGMonthCardInfo extends CGMessage{
	
	
	public CGMonthCardInfo (){
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
		return MessageType.CG_MONTH_CARD_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "CG_MONTH_CARD_INFO";
	}


	@Override
	public void execute() {
		HumanHandlerFactory.getHandler().handleMonthCardInfo(this.getSession().getPlayer(), this);
	}
}