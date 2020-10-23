package com.imop.lj.gameserver.mall.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.mall.handler.MallHandlerFactory;

/**
 * 请求限时抢购队列
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTimeLimitItemList extends CGMessage{
	
	
	public CGTimeLimitItemList (){
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
		return MessageType.CG_TIME_LIMIT_ITEM_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TIME_LIMIT_ITEM_LIST";
	}


	@Override
	public void execute() {
		MallHandlerFactory.getHandler().handleTimeLimitItemList(this.getSession().getPlayer(), this);
	}
}