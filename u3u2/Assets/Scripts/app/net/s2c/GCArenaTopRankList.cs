
using System;
namespace app.net
{
/**
 * 显示竞技场榜首信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCArenaTopRankList :BaseMessage
{
	/** 我的排名 */
	private int myRank;
	/** 我的军团Id */
	private long myCorpsId;
	/** 我的军团名字 */
	private string myCorpsName;
	/** 排行榜人员列表 */
	private ArenaMemberData[] arenaTopMemberList;

	public GCArenaTopRankList ()
	{
	}

	protected override void ReadImpl()
	{
	// 我的排名
	int _myRank = ReadInt();
	// 我的军团Id
	long _myCorpsId = ReadLong();
	// 我的军团名字
	string _myCorpsName = ReadString();

	// 排行榜人员列表
	int arenaTopMemberListSize = ReadShort();
	ArenaMemberData[] _arenaTopMemberList = new ArenaMemberData[arenaTopMemberListSize];
	int arenaTopMemberListIndex = 0;
	ArenaMemberData _arenaTopMemberListTmp = null;
	for(arenaTopMemberListIndex=0; arenaTopMemberListIndex<arenaTopMemberListSize; arenaTopMemberListIndex++){
		_arenaTopMemberListTmp = new ArenaMemberData();
		_arenaTopMemberList[arenaTopMemberListIndex] = _arenaTopMemberListTmp;
	// 成员Id
	long _arenaTopMemberList_memberId = ReadLong();	_arenaTopMemberListTmp.memberId = _arenaTopMemberList_memberId;
		// 排名
	int _arenaTopMemberList_rank = ReadInt();	_arenaTopMemberListTmp.rank = _arenaTopMemberList_rank;
		// 名字
	string _arenaTopMemberList_name = ReadString();	_arenaTopMemberListTmp.name = _arenaTopMemberList_name;
		// 等级
	int _arenaTopMemberList_level = ReadInt();	_arenaTopMemberListTmp.level = _arenaTopMemberList_level;
		// 模板Id
	int _arenaTopMemberList_tplId = ReadInt();	_arenaTopMemberListTmp.tplId = _arenaTopMemberList_tplId;
		// 战力
	int _arenaTopMemberList_fightPower = ReadInt();	_arenaTopMemberListTmp.fightPower = _arenaTopMemberList_fightPower;
		// 是否自己，0否，1是
	int _arenaTopMemberList_isSelf = ReadInt();	_arenaTopMemberListTmp.isSelf = _arenaTopMemberList_isSelf;
		// 是否机器人，0否，1是
	int _arenaTopMemberList_isRobot = ReadInt();	_arenaTopMemberListTmp.isRobot = _arenaTopMemberList_isRobot;
		// 军团Id
	long _arenaTopMemberList_corpsId = ReadLong();	_arenaTopMemberListTmp.corpsId = _arenaTopMemberList_corpsId;
		// 军团名字
	string _arenaTopMemberList_corpsName = ReadString();	_arenaTopMemberListTmp.corpsName = _arenaTopMemberList_corpsName;
		}
	//end



		this.myRank = _myRank;
		this.myCorpsId = _myCorpsId;
		this.myCorpsName = _myCorpsName;
		this.arenaTopMemberList = _arenaTopMemberList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_ARENA_TOP_RANK_LIST;
	}
	
	public override string getEventType()
	{
		return ArenaGCHandler.GCArenaTopRankListEvent;
	}
	

	public int getMyRank(){
		return myRank;
	}
		

	public long getMyCorpsId(){
		return myCorpsId;
	}
		

	public string getMyCorpsName(){
		return myCorpsName;
	}
		

	public ArenaMemberData[] getArenaTopMemberList(){
		return arenaTopMemberList;
	}


}
}