package com.imop.lj.gameserver.onlinegift.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.onlinegift.handler.OnlinegiftHandlerFactory;

/**
 * 申请补签
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGDaliyGiftRetroactive extends CGMessage{
	
	
	public CGDaliyGiftRetroactive (){
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
		return MessageType.CG_DALIY_GIFT_RETROACTIVE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_DALIY_GIFT_RETROACTIVE";
	}


	@Override
	public void execute() {
		OnlinegiftHandlerFactory.getHandler().handleDaliyGiftRetroactive(this.getSession().getPlayer(), this);
	}
}