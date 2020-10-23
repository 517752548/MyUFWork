
using System;
namespace app.net
{
/**
 * 显示队伍列表界面
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTeamShowList :BaseMessage
{
	/** 队伍信息列表 */
	private TeamInfo[] teamInfos;
	/** 等待匹配的队长数量 */
	private int waitingLeaderNum;
	/** 等待匹配的队员数量 */
	private int waitingMemberNum;

	public GCTeamShowList ()
	{
	}

	protected override void ReadImpl()
	{

	// 队伍信息列表
	int teamInfosSize = ReadShort();
	TeamInfo[] _teamInfos = new TeamInfo[teamInfosSize];
	int teamInfosIndex = 0;
	TeamInfo _teamInfosTmp = null;
	for(teamInfosIndex=0; teamInfosIndex<teamInfosSize; teamInfosIndex++){
		_teamInfosTmp = new TeamInfo();
		_teamInfos[teamInfosIndex] = _teamInfosTmp;
	// 队伍Id
	int _teamInfos_teamId = ReadInt();	_teamInfosTmp.teamId = _teamInfos_teamId;
		// 名字 
	string _teamInfos_name = ReadString();	_teamInfosTmp.name = _teamInfos_name;
		// 等级
	int _teamInfos_level = ReadInt();	_teamInfosTmp.level = _teamInfos_level;
		// 职业Id
	int _teamInfos_jobTypeId = ReadInt();	_teamInfosTmp.jobTypeId = _teamInfos_jobTypeId;
		// 目标Id
	int _teamInfos_targetId = ReadInt();	_teamInfosTmp.targetId = _teamInfos_targetId;
		// 队员数量
	int _teamInfos_memberNum = ReadInt();	_teamInfosTmp.memberNum = _teamInfos_memberNum;
		// 队伍要求等级下限
	int _teamInfos_levelMin = ReadInt();	_teamInfosTmp.levelMin = _teamInfos_levelMin;
		// 队伍要求等级上限
	int _teamInfos_levelMax = ReadInt();	_teamInfosTmp.levelMax = _teamInfos_levelMax;
		// 申请状态，0可申请，1已申请
	int _teamInfos_applyStatus = ReadInt();	_teamInfosTmp.applyStatus = _teamInfos_applyStatus;
		}
	//end

	// 等待匹配的队长数量
	int _waitingLeaderNum = ReadInt();
	// 等待匹配的队员数量
	int _waitingMemberNum = ReadInt();


		this.teamInfos = _teamInfos;
		this.waitingLeaderNum = _waitingLeaderNum;
		this.waitingMemberNum = _waitingMemberNum;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_TEAM_SHOW_LIST;
	}
	
	public override string getEventType()
	{
		return TeamGCHandler.GCTeamShowListEvent;
	}
	

	public TeamInfo[] getTeamInfos(){
		return teamInfos;
	}


	public int getWaitingLeaderNum(){
		return waitingLeaderNum;
	}
		

	public int getWaitingMemberNum(){
		return waitingMemberNum;
	}
		

	public override bool isCompress() {
		return true;
	}
}
}