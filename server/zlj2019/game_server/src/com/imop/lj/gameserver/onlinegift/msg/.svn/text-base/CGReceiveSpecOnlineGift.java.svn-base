package com.imop.lj.gameserver.onlinegift.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.onlinegift.handler.OnlinegiftHandlerFactory;

/**
 * 领取在线礼物包
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGReceiveSpecOnlineGift extends CGMessage{
	
	
	public CGReceiveSpecOnlineGift (){
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
		return MessageType.CG_RECEIVE_SPEC_ONLINE_GIFT;
	}
	
	@Override
	public String getTypeName() {
		return "CG_RECEIVE_SPEC_ONLINE_GIFT";
	}


	@Override
	public void execute() {
		OnlinegiftHandlerFactory.getHandler().handleReceiveSpecOnlineGift(this.getSession().getPlayer(), this);
	}
}