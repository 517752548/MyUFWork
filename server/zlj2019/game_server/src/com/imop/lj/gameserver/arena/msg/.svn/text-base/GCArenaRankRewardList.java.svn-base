package com.imop.lj.gameserver.arena.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 竞技场排名奖励列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCArenaRankRewardList extends GCMessage{
	
	/** 排名奖励列表 */
	private String[] rewardInfoList;
	/** 排名列表 */
	private int[] rank;

	public GCArenaRankRewardList (){
	}
	
	public GCArenaRankRewardList (
			String[] rewardInfoList,
			int[] rank ){
			this.rewardInfoList = rewardInfoList;
			this.rank = rank;
	}

	@Override
	protected boolean readImpl() {

	// 排名奖励列表
	int rewardInfoListSize = readUnsignedShort();
	String[] _rewardInfoList = new String[rewardInfoListSize];
	int rewardInfoListIndex = 0;
	for(rewardInfoListIndex=0; rewardInfoListIndex<rewardInfoListSize; rewardInfoListIndex++){
		_rewardInfoList[rewardInfoListIndex] = readString();
	}//end


	// 排名列表
	int rankSize = readUnsignedShort();
	int[] _rank = new int[rankSize];
	int rankIndex = 0;
	for(rankIndex=0; rankIndex<rankSize; rankIndex++){
		_rank[rankIndex] = readInteger();
	}//end



		this.rewardInfoList = _rewardInfoList;
		this.rank = _rank;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 排名奖励列表
	writeShort(rewardInfoList.length);
	int rewardInfoListSize = rewardInfoList.length;
	int rewardInfoListIndex = 0;
	for(rewardInfoListIndex=0; rewardInfoListIndex<rewardInfoListSize; rewardInfoListIndex++){
		writeString(rewardInfoList [ rewardInfoListIndex ]);
	}//end


	// 排名列表
	writeShort(rank.length);
	int rankSize = rank.length;
	int rankIndex = 0;
	for(rankIndex=0; rankIndex<rankSize; rankIndex++){
		writeInteger(rank [ rankIndex ]);
	}//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_ARENA_RANK_REWARD_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_ARENA_RANK_REWARD_LIST";
	}

	public String[] getRewardInfoList(){
		return rewardInfoList;
	}

	public void setRewardInfoList(String[] rewardInfoList){
		this.rewardInfoList = rewardInfoList;
	}	

	public int[] getRank(){
		return rank;
	}

	public void setRank(int[] rank){
		this.rank = rank;
	}	
}