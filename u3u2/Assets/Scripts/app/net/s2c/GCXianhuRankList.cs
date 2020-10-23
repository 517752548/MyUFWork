
using System;
namespace app.net
{
/**
 * 仙葫排行数据
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCXianhuRankList :BaseMessage
{
	/** 排行类型 */
	private int rankType;
	/** 我的排名 */
	private int myRank;
	/** 我的开启次数 */
	private int myNum;
	/** 我的军团Id */
	private long myCorpsId;
	/** 我的军团名字 */
	private string myCorpsName;
	/** 仙葫排行榜信息 */
	private XianhuRankInfo[] xianhuRankInfoList;

	public GCXianhuRankList ()
	{
	}

	protected override void ReadImpl()
	{
	// 排行类型
	int _rankType = ReadInt();
	// 我的排名
	int _myRank = ReadInt();
	// 我的开启次数
	int _myNum = ReadInt();
	// 我的军团Id
	long _myCorpsId = ReadLong();
	// 我的军团名字
	string _myCorpsName = ReadString();

	// 仙葫排行榜信息
	int xianhuRankInfoListSize = ReadShort();
	XianhuRankInfo[] _xianhuRankInfoList = new XianhuRankInfo[xianhuRankInfoListSize];
	int xianhuRankInfoListIndex = 0;
	XianhuRankInfo _xianhuRankInfoListTmp = null;
	for(xianhuRankInfoListIndex=0; xianhuRankInfoListIndex<xianhuRankInfoListSize; xianhuRankInfoListIndex++){
		_xianhuRankInfoListTmp = new XianhuRankInfo();
		_xianhuRankInfoList[xianhuRankInfoListIndex] = _xianhuRankInfoListTmp;
	// 玩家ID
	long _xianhuRankInfoList_roleId = ReadLong();	_xianhuRankInfoListTmp.roleId = _xianhuRankInfoList_roleId;
		// 玩家姓名
	string _xianhuRankInfoList_name = ReadString();	_xianhuRankInfoListTmp.name = _xianhuRankInfoList_name;
		// 排名
	int _xianhuRankInfoList_rank = ReadInt();	_xianhuRankInfoListTmp.rank = _xianhuRankInfoList_rank;
		// 级别
	int _xianhuRankInfoList_level = ReadInt();	_xianhuRankInfoListTmp.level = _xianhuRankInfoList_level;
		// 玩家模板Id
	int _xianhuRankInfoList_tplId = ReadInt();	_xianhuRankInfoListTmp.tplId = _xianhuRankInfoList_tplId;
		// 帮派ID
	long _xianhuRankInfoList_corpsId = ReadLong();	_xianhuRankInfoListTmp.corpsId = _xianhuRankInfoList_corpsId;
		// 帮派名称
	string _xianhuRankInfoList_corpsName = ReadString();	_xianhuRankInfoListTmp.corpsName = _xianhuRankInfoList_corpsName;
		// 开启次数
	int _xianhuRankInfoList_num = ReadInt();	_xianhuRankInfoListTmp.num = _xianhuRankInfoList_num;
		}
	//end



		this.rankType = _rankType;
		this.myRank = _myRank;
		this.myNum = _myNum;
		this.myCorpsId = _myCorpsId;
		this.myCorpsName = _myCorpsName;
		this.xianhuRankInfoList = _xianhuRankInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_XIANHU_RANK_LIST;
	}
	
	public override string getEventType()
	{
		return HumanGCHandler.GCXianhuRankListEvent;
	}
	

	public int getRankType(){
		return rankType;
	}
		

	public int getMyRank(){
		return myRank;
	}
		

	public int getMyNum(){
		return myNum;
	}
		

	public long getMyCorpsId(){
		return myCorpsId;
	}
		

	public string getMyCorpsName(){
		return myCorpsName;
	}
		

	public XianhuRankInfo[] getXianhuRankInfoList(){
		return xianhuRankInfoList;
	}


}
}