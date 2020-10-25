package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.human.handler.HumanHandlerFactory;

/**
 * 领取仙葫排名奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGXianhuRankReward extends CGMessage{
	
	/** 排行类型 */
	private int rankType;
	
	public CGXianhuRankReward (){
	}
	
	public CGXianhuRankReward (
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
		return MessageType.CG_XIANHU_RANK_REWARD;
	}
	
	@Override
	public String getTypeName() {
		return "CG_XIANHU_RANK_REWARD";
	}

	public int getRankType(){
		return rankType;
	}
		
	public void setRankType(int rankType){
		this.rankType = rankType;
	}


	@Override
	public void execute() {
		HumanHandlerFactory.getHandler().handleXianhuRankReward(this.getSession().getPlayer(), this);
	}
}