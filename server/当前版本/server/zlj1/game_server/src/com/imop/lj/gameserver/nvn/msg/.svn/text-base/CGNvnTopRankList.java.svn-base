package com.imop.lj.gameserver.nvn.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.nvn.handler.NvnHandlerFactory;

/**
 * 请求nvn联赛排行榜
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGNvnTopRankList extends CGMessage{
	
	
	public CGNvnTopRankList (){
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
		return MessageType.CG_NVN_TOP_RANK_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "CG_NVN_TOP_RANK_LIST";
	}


	@Override
	public void execute() {
		NvnHandlerFactory.getHandler().handleNvnTopRankList(this.getSession().getPlayer(), this);
	}
}