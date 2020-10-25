package com.imop.lj.gameserver.prize.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.prize.handler.PrizeHandlerFactory;

/**
 * 查询平台玩家奖励列表和gm补偿列表
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPrizeList extends CGMessage{
	
	
	public CGPrizeList (){
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
		return MessageType.CG_PRIZE_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PRIZE_LIST";
	}


	@Override
	public void execute() {
		PrizeHandlerFactory.getHandler().handlePrizeList(this.getSession().getPlayer(), this);
	}
}