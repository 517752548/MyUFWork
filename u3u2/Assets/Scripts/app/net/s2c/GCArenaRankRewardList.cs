
using System;
namespace app.net
{
/**
 * 竞技场排名奖励列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCArenaRankRewardList :BaseMessage
{
	/** 排名奖励列表 */
	private string[] rewardInfoList;
	/** 排名列表 */
	private int[] rank;

	public GCArenaRankRewardList ()
	{
	}

	protected override void ReadImpl()
	{
	// 排名奖励列表
	int rewardInfoListSize = ReadShort();
	string[] _rewardInfoList = new string[rewardInfoListSize];
	int rewardInfoListIndex = 0;
	for(rewardInfoListIndex=0; rewardInfoListIndex<rewardInfoListSize; rewardInfoListIndex++){
		_rewardInfoList[rewardInfoListIndex] = ReadString();
	}//end
	
	// 排名列表
	int rankSize = ReadShort();
	int[] _rank = new int[rankSize];
	int rankIndex = 0;
	for(rankIndex=0; rankIndex<rankSize; rankIndex++){
		_rank[rankIndex] = ReadInt();
	}//end
	


		this.rewardInfoList = _rewardInfoList;
		this.rank = _rank;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_ARENA_RANK_REWARD_LIST;
	}
	
	public override string getEventType()
	{
		return ArenaGCHandler.GCArenaRankRewardListEvent;
	}
	

	public string[] getRewardInfoList(){
		return rewardInfoList;
	}


	public int[] getRank(){
		return rank;
	}


}
}