package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 请求帮派竞赛排行榜
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpswarRankList extends CGMessage{
	
	
	public CGCorpswarRankList (){
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
		return MessageType.CG_CORPSWAR_RANK_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CORPSWAR_RANK_LIST";
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleCorpswarRankList(this.getSession().getPlayer(), this);
	}
}