
using System;
namespace app.net
{
/**
 * 申请排行榜信息结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCRankApply :BaseMessage
{
	/** 申请的排行榜信息类型(1等级排行,2战力排行,3宠物评分排行,4职业战力排行) */
	private int rankType;
	/** 申请对应排行榜信息的时间戳 */
	private long timeId;
	/** 排行榜信息 */
	private RankInfo[] rankInfoList;

	public GCRankApply ()
	{
	}

	protected override void ReadImpl()
	{
	// 申请的排行榜信息类型(1等级排行,2战力排行,3宠物评分排行,4职业战力排行)
	int _rankType = ReadInt();
	// 申请对应排行榜信息的时间戳
	long _timeId = ReadLong();

	// 排行榜信息
	int rankInfoListSize = ReadShort();
	RankInfo[] _rankInfoList = new RankInfo[rankInfoListSize];
	int rankInfoListIndex = 0;
	RankInfo _rankInfoListTmp = null;
	for(rankInfoListIndex=0; rankInfoListIndex<rankInfoListSize; rankInfoListIndex++){
		_rankInfoListTmp = new RankInfo();
		_rankInfoList[rankInfoListIndex] = _rankInfoListTmp;
	// 排名
	int _rankInfoList_rank = ReadInt();	_rankInfoListTmp.rank = _rankInfoList_rank;
		// 玩家姓名
	string _rankInfoList_humanName = ReadString();	_rankInfoListTmp.humanName = _rankInfoList_humanName;
		// 宠物姓名
	string _rankInfoList_petName = ReadString();	_rankInfoListTmp.petName = _rankInfoList_petName;
		// 所属帮派
	string _rankInfoList_corpsName = ReadString();	_rankInfoListTmp.corpsName = _rankInfoList_corpsName;
		// 级别
	int _rankInfoList_level = ReadInt();	_rankInfoListTmp.level = _rankInfoList_level;
		// 玩家职业
	int _rankInfoList_humanJob = ReadInt();	_rankInfoListTmp.humanJob = _rankInfoList_humanJob;
		// 战力
	int _rankInfoList_fightPower = ReadInt();	_rankInfoListTmp.fightPower = _rankInfoList_fightPower;
		// 评分
	int _rankInfoList_score = ReadInt();	_rankInfoListTmp.score = _rankInfoList_score;
		// 玩家ID
	long _rankInfoList_humanId = ReadLong();	_rankInfoListTmp.humanId = _rankInfoList_humanId;
		// 宠物ID
	long _rankInfoList_petId = ReadLong();	_rankInfoListTmp.petId = _rankInfoList_petId;
		}
	//end



		this.rankType = _rankType;
		this.timeId = _timeId;
		this.rankInfoList = _rankInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_RANK_APPLY;
	}
	
	public override string getEventType()
	{
		return RankGCHandler.GCRankApplyEvent;
	}
	

	public int getRankType(){
		return rankType;
	}
		

	public long getTimeId(){
		return timeId;
	}
		

	public RankInfo[] getRankInfoList(){
		return rankInfoList;
	}


}
}