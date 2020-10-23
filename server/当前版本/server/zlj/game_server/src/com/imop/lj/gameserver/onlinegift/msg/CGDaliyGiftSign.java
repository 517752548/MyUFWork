package com.imop.lj.gameserver.onlinegift.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.onlinegift.handler.OnlinegiftHandlerFactory;

/**
 * 申请签到
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGDaliyGiftSign extends CGMessage{
	
	
	public CGDaliyGiftSign (){
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
		return MessageType.CG_DALIY_GIFT_SIGN;
	}
	
	@Override
	public String getTypeName() {
		return "CG_DALIY_GIFT_SIGN";
	}


	@Override
	public void execute() {
		OnlinegiftHandlerFactory.getHandler().handleDaliyGiftSign(this.getSession().getPlayer(), this);
	}
}