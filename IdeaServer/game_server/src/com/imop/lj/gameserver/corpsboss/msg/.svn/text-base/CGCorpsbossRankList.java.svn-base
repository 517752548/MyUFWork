package com.imop.lj.gameserver.corpsboss.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corpsboss.handler.CorpsbossHandlerFactory;

/**
 * 请求帮派boss排行榜
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpsbossRankList extends CGMessage{
	
	
	public CGCorpsbossRankList (){
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
		return MessageType.CG_CORPSBOSS_RANK_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CORPSBOSS_RANK_LIST";
	}


	@Override
	public void execute() {
		CorpsbossHandlerFactory.getHandler().handleCorpsbossRankList(this.getSession().getPlayer(), this);
	}
}