package com.imop.lj.gameserver.corpsboss.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corpsboss.handler.CorpsbossHandlerFactory;

/**
 * 请求查看帮派boss单一排行榜的录像
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpsbossRankReplay extends CGMessage{
	
	/** 排名 */
	private int rank;
	
	public CGCorpsbossRankReplay (){
	}
	
	public CGCorpsbossRankReplay (
			int rank ){
			this.rank = rank;
	}
	
	@Override
	protected boolean readImpl() {

	// 排名
	int _rank = readInteger();
	//end



			this.rank = _rank;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 排名
	writeInteger(rank);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CORPSBOSS_RANK_REPLAY;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CORPSBOSS_RANK_REPLAY";
	}

	public int getRank(){
		return rank;
	}
		
	public void setRank(int rank){
		this.rank = rank;
	}


	@Override
	public void execute() {
		CorpsbossHandlerFactory.getHandler().handleCorpsbossRankReplay(this.getSession().getPlayer(), this);
	}
}