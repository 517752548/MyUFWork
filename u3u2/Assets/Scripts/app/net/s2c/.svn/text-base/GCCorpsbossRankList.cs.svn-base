
using System;
namespace app.net
{
/**
 * 帮派boss排行榜
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCorpsbossRankList :BaseMessage
{
	/** 本帮派boss排行榜信息 */
	private CorpsBossRankInfo cbRankInfo;
	/** 所有帮派boss排行榜信息 */
	private CorpsBossRankInfo[] cbRankInfoList;

	public GCCorpsbossRankList ()
	{
	}

	protected override void ReadImpl()
	{
	// 本帮派boss排行榜信息
	CorpsBossRankInfo _cbRankInfo = new CorpsBossRankInfo();
	// 军团id
	long _cbRankInfo_corpsId = ReadLong();	_cbRankInfo.corpsId = _cbRankInfo_corpsId;
	// 军团名称
	string _cbRankInfo_name = ReadString();	_cbRankInfo.name = _cbRankInfo_name;
	// 排名
	int _cbRankInfo_rank = ReadInt();	_cbRankInfo.rank = _cbRankInfo_rank;
	// 录像
	string _cbRankInfo_replay = ReadString();	_cbRankInfo.replay = _cbRankInfo_replay;
	// 最高纪录
	int _cbRankInfo_bossLevel = ReadInt();	_cbRankInfo.bossLevel = _cbRankInfo_bossLevel;
	// 回合数
	int _cbRankInfo_round = ReadInt();	_cbRankInfo.round = _cbRankInfo_round;


	// 所有帮派boss排行榜信息
	int cbRankInfoListSize = ReadShort();
	CorpsBossRankInfo[] _cbRankInfoList = new CorpsBossRankInfo[cbRankInfoListSize];
	int cbRankInfoListIndex = 0;
	CorpsBossRankInfo _cbRankInfoListTmp = null;
	for(cbRankInfoListIndex=0; cbRankInfoListIndex<cbRankInfoListSize; cbRankInfoListIndex++){
		_cbRankInfoListTmp = new CorpsBossRankInfo();
		_cbRankInfoList[cbRankInfoListIndex] = _cbRankInfoListTmp;
	// 军团id
	long _cbRankInfoList_corpsId = ReadLong();	_cbRankInfoListTmp.corpsId = _cbRankInfoList_corpsId;
		// 军团名称
	string _cbRankInfoList_name = ReadString();	_cbRankInfoListTmp.name = _cbRankInfoList_name;
		// 排名
	int _cbRankInfoList_rank = ReadInt();	_cbRankInfoListTmp.rank = _cbRankInfoList_rank;
		// 录像
	string _cbRankInfoList_replay = ReadString();	_cbRankInfoListTmp.replay = _cbRankInfoList_replay;
		// 最高纪录
	int _cbRankInfoList_bossLevel = ReadInt();	_cbRankInfoListTmp.bossLevel = _cbRankInfoList_bossLevel;
		// 回合数
	int _cbRankInfoList_round = ReadInt();	_cbRankInfoListTmp.round = _cbRankInfoList_round;
		}
	//end



		this.cbRankInfo = _cbRankInfo;
		this.cbRankInfoList = _cbRankInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_CORPSBOSS_RANK_LIST;
	}
	
	public override string getEventType()
	{
		return CorpsbossGCHandler.GCCorpsbossRankListEvent;
	}
	

	public CorpsBossRankInfo getCbRankInfo(){
		return cbRankInfo;
	}
		

	public CorpsBossRankInfo[] getCbRankInfoList(){
		return cbRankInfoList;
	}


}
}