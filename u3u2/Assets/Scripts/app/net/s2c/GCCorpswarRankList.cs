
using System;
namespace app.net
{
/**
 * 帮派竞赛排行榜
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCorpswarRankList :BaseMessage
{
	/** 帮派竞赛排行榜信息 */
	private CorpsWarRankInfo[] cwRankInfoList;

	public GCCorpswarRankList ()
	{
	}

	protected override void ReadImpl()
	{

	// 帮派竞赛排行榜信息
	int cwRankInfoListSize = ReadShort();
	CorpsWarRankInfo[] _cwRankInfoList = new CorpsWarRankInfo[cwRankInfoListSize];
	int cwRankInfoListIndex = 0;
	CorpsWarRankInfo _cwRankInfoListTmp = null;
	for(cwRankInfoListIndex=0; cwRankInfoListIndex<cwRankInfoListSize; cwRankInfoListIndex++){
		_cwRankInfoListTmp = new CorpsWarRankInfo();
		_cwRankInfoList[cwRankInfoListIndex] = _cwRankInfoListTmp;
	// 军团id
	long _cwRankInfoList_corpsId = ReadLong();	_cwRankInfoListTmp.corpsId = _cwRankInfoList_corpsId;
		// 军团名称
	string _cwRankInfoList_name = ReadString();	_cwRankInfoListTmp.name = _cwRankInfoList_name;
		// 排名
	int _cwRankInfoList_rank = ReadInt();	_cwRankInfoListTmp.rank = _cwRankInfoList_rank;
		// 积分
	int _cwRankInfoList_score = ReadInt();	_cwRankInfoListTmp.score = _cwRankInfoList_score;
		}
	//end



		this.cwRankInfoList = _cwRankInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_CORPSWAR_RANK_LIST;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCCorpswarRankListEvent;
	}
	

	public CorpsWarRankInfo[] getCwRankInfoList(){
		return cwRankInfoList;
	}


}
}