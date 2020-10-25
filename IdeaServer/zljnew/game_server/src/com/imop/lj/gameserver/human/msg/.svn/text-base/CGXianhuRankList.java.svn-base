package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.human.handler.HumanHandlerFactory;

/**
 * 请求仙葫排行数据
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGXianhuRankList extends CGMessage{
	
	/** 排行类型 */
	private int rankType;
	
	public CGXianhuRankList (){
	}
	
	public CGXianhuRankList (
			int rankType ){
			this.rankType = rankType;
	}
	
	@Override
	protected boolean readImpl() {

	// 排行类型
	int _rankType = readInteger();
	//end



			this.rankType = _rankType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 排行类型
	writeInteger(rankType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_XIANHU_RANK_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "CG_XIANHU_RANK_LIST";
	}

	public int getRankType(){
		return rankType;
	}
		
	public void setRankType(int rankType){
		this.rankType = rankType;
	}


	@Override
	public void execute() {
		HumanHandlerFactory.getHandler().handleXianhuRankList(this.getSession().getPlayer(), this);
	}
}