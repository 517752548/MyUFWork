
using System;
namespace app.net
{
/**
 * 帮派boss挑战次数排行榜
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCorpsbossCountRankList :BaseMessage
{
	/** 本帮派boss挑战次数排行榜信息 */
	private CorpsBossCountRankInfo cbCountRankInfo;
	/** 所有帮派boss挑战次数排行榜信息 */
	private CorpsBossCountRankInfo[] cbCountRankInfoList;

	public GCCorpsbossCountRankList ()
	{
	}

	protected override void ReadImpl()
	{
	// 本帮派boss挑战次数排行榜信息
	CorpsBossCountRankInfo _cbCountRankInfo = new CorpsBossCountRankInfo();
	// 军团id
	long _cbCountRankInfo_corpsId = ReadLong();	_cbCountRankInfo.corpsId = _cbCountRankInfo_corpsId;
	// 军团名称
	string _cbCountRankInfo_name = ReadString();	_cbCountRankInfo.name = _cbCountRankInfo_name;
	// 排名
	int _cbCountRankInfo_rank = ReadInt();	_cbCountRankInfo.rank = _cbCountRankInfo_rank;
	// 排名
	int _cbCountRankInfo_count = ReadInt();	_cbCountRankInfo.count = _cbCountRankInfo_count;
	// 帮主名字
	string _cbCountRankInfo_presidentName = ReadString();	_cbCountRankInfo.presidentName = _cbCountRankInfo_presidentName;
	// 当前成员数量
	int _cbCountRankInfo_curMemberCount = ReadInt();	_cbCountRankInfo.curMemberCount = _cbCountRankInfo_curMemberCount;
	// 最大成员数量
	int _cbCountRankInfo_maxMemberCount = ReadInt();	_cbCountRankInfo.maxMemberCount = _cbCountRankInfo_maxMemberCount;


	// 所有帮派boss挑战次数排行榜信息
	int cbCountRankInfoListSize = ReadShort();
	CorpsBossCountRankInfo[] _cbCountRankInfoList = new CorpsBossCountRankInfo[cbCountRankInfoListSize];
	int cbCountRankInfoListIndex = 0;
	CorpsBossCountRankInfo _cbCountRankInfoListTmp = null;
	for(cbCountRankInfoListIndex=0; cbCountRankInfoListIndex<cbCountRankInfoListSize; cbCountRankInfoListIndex++){
		_cbCountRankInfoListTmp = new CorpsBossCountRankInfo();
		_cbCountRankInfoList[cbCountRankInfoListIndex] = _cbCountRankInfoListTmp;
	// 军团id
	long _cbCountRankInfoList_corpsId = ReadLong();	_cbCountRankInfoListTmp.corpsId = _cbCountRankInfoList_corpsId;
		// 军团名称
	string _cbCountRankInfoList_name = ReadString();	_cbCountRankInfoListTmp.name = _cbCountRankInfoList_name;
		// 排名
	int _cbCountRankInfoList_rank = ReadInt();	_cbCountRankInfoListTmp.rank = _cbCountRankInfoList_rank;
		// 排名
	int _cbCountRankInfoList_count = ReadInt();	_cbCountRankInfoListTmp.count = _cbCountRankInfoList_count;
		// 帮主名字
	string _cbCountRankInfoList_presidentName = ReadString();	_cbCountRankInfoListTmp.presidentName = _cbCountRankInfoList_presidentName;
		// 当前成员数量
	int _cbCountRankInfoList_curMemberCount = ReadInt();	_cbCountRankInfoListTmp.curMemberCount = _cbCountRankInfoList_curMemberCount;
		// 最大成员数量
	int _cbCountRankInfoList_maxMemberCount = ReadInt();	_cbCountRankInfoListTmp.maxMemberCount = _cbCountRankInfoList_maxMemberCount;
		}
	//end



		this.cbCountRankInfo = _cbCountRankInfo;
		this.cbCountRankInfoList = _cbCountRankInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_CORPSBOSS_COUNT_RANK_LIST;
	}
	
	public override string getEventType()
	{
		return CorpsbossGCHandler.GCCorpsbossCountRankListEvent;
	}
	

	public CorpsBossCountRankInfo getCbCountRankInfo(){
		return cbCountRankInfo;
	}
		

	public CorpsBossCountRankInfo[] getCbCountRankInfoList(){
		return cbCountRankInfoList;
	}


}
}