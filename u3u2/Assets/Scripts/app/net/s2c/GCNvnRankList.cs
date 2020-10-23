
using System;
namespace app.net
{
/**
 * nvn联赛排行榜
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCNvnRankList :BaseMessage
{
	/** 我的排名 */
	private int myRank;
	/** 我的积分 */
	private int myScore;
	/** 我的连胜数 */
	private int myConWinNum;
	/** nvn联赛排行榜信息 */
	private NvnRankInfo[] nvnRankInfoList;

	public GCNvnRankList ()
	{
	}

	protected override void ReadImpl()
	{
	// 我的排名
	int _myRank = ReadInt();
	// 我的积分
	int _myScore = ReadInt();
	// 我的连胜数
	int _myConWinNum = ReadInt();

	// nvn联赛排行榜信息
	int nvnRankInfoListSize = ReadShort();
	NvnRankInfo[] _nvnRankInfoList = new NvnRankInfo[nvnRankInfoListSize];
	int nvnRankInfoListIndex = 0;
	NvnRankInfo _nvnRankInfoListTmp = null;
	for(nvnRankInfoListIndex=0; nvnRankInfoListIndex<nvnRankInfoListSize; nvnRankInfoListIndex++){
		_nvnRankInfoListTmp = new NvnRankInfo();
		_nvnRankInfoList[nvnRankInfoListIndex] = _nvnRankInfoListTmp;
	// 玩家id
	long _nvnRankInfoList_roleId = ReadLong();	_nvnRankInfoListTmp.roleId = _nvnRankInfoList_roleId;
		// 玩家模板id
	int _nvnRankInfoList_tplId = ReadInt();	_nvnRankInfoListTmp.tplId = _nvnRankInfoList_tplId;
		// 玩家名称
	string _nvnRankInfoList_name = ReadString();	_nvnRankInfoListTmp.name = _nvnRankInfoList_name;
		// 排名
	int _nvnRankInfoList_rank = ReadInt();	_nvnRankInfoListTmp.rank = _nvnRankInfoList_rank;
		// 积分
	int _nvnRankInfoList_score = ReadInt();	_nvnRankInfoListTmp.score = _nvnRankInfoList_score;
		// 连胜数
	int _nvnRankInfoList_conWinNum = ReadInt();	_nvnRankInfoListTmp.conWinNum = _nvnRankInfoList_conWinNum;
		}
	//end



		this.myRank = _myRank;
		this.myScore = _myScore;
		this.myConWinNum = _myConWinNum;
		this.nvnRankInfoList = _nvnRankInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_NVN_RANK_LIST;
	}
	
	public override string getEventType()
	{
		return NvnGCHandler.GCNvnRankListEvent;
	}
	

	public int getMyRank(){
		return myRank;
	}
		

	public int getMyScore(){
		return myScore;
	}
		

	public int getMyConWinNum(){
		return myConWinNum;
	}
		

	public NvnRankInfo[] getNvnRankInfoList(){
		return nvnRankInfoList;
	}


}
}