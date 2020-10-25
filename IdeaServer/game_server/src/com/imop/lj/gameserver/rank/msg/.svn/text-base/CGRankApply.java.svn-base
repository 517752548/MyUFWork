package com.imop.lj.gameserver.rank.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.rank.handler.RankHandlerFactory;

/**
 * 申请排行榜信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGRankApply extends CGMessage{
	
	/** 申请的排行榜信息类型(1等级排行,2战力排行,3宠物评分排行,4职业战力排行) */
	private int rankType;
	/** 申请对应排行榜信息的时间戳 */
	private long timeId;
	
	public CGRankApply (){
	}
	
	public CGRankApply (
			int rankType,
			long timeId ){
			this.rankType = rankType;
			this.timeId = timeId;
	}
	
	@Override
	protected boolean readImpl() {

	// 申请的排行榜信息类型(1等级排行,2战力排行,3宠物评分排行,4职业战力排行)
	int _rankType = readInteger();
	//end


	// 申请对应排行榜信息的时间戳
	long _timeId = readLong();
	//end



			this.rankType = _rankType;
			this.timeId = _timeId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 申请的排行榜信息类型(1等级排行,2战力排行,3宠物评分排行,4职业战力排行)
	writeInteger(rankType);


	// 申请对应排行榜信息的时间戳
	writeLong(timeId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_RANK_APPLY;
	}
	
	@Override
	public String getTypeName() {
		return "CG_RANK_APPLY";
	}

	public int getRankType(){
		return rankType;
	}
		
	public void setRankType(int rankType){
		this.rankType = rankType;
	}

	public long getTimeId(){
		return timeId;
	}
		
	public void setTimeId(long timeId){
		this.timeId = timeId;
	}


	@Override
	public void execute() {
		RankHandlerFactory.getHandler().handleRankApply(this.getSession().getPlayer(), this);
	}
}