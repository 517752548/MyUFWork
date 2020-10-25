package com.imop.lj.gameserver.onlinegift.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.onlinegift.handler.OnlinegiftHandlerFactory;

/**
 * 获取在线礼物展示信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGetSpecOnlineGiftShowInfo extends CGMessage{
	
	
	public CGGetSpecOnlineGiftShowInfo (){
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
		return MessageType.CG_GET_SPEC_ONLINE_GIFT_SHOW_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "CG_GET_SPEC_ONLINE_GIFT_SHOW_INFO";
	}


	@Override
	public void execute() {
		OnlinegiftHandlerFactory.getHandler().handleGetSpecOnlineGiftShowInfo(this.getSession().getPlayer(), this);
	}
}