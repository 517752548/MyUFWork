package com.imop.lj.gameserver.onlinegift.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.onlinegift.handler.OnlinegiftHandlerFactory;

/**
 * 申请每日签到面板信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGDaliyGiftPannelApply extends CGMessage{
	
	
	public CGDaliyGiftPannelApply (){
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
		return MessageType.CG_DALIY_GIFT_PANNEL_APPLY;
	}
	
	@Override
	public String getTypeName() {
		return "CG_DALIY_GIFT_PANNEL_APPLY";
	}


	@Override
	public void execute() {
		OnlinegiftHandlerFactory.getHandler().handleDaliyGiftPannelApply(this.getSession().getPlayer(), this);
	}
}