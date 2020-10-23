
using System;
namespace app.net
{
/**
 * 邀请成员列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTeamInviteList :BaseMessage
{
	/** 邀请类型，1好友，2军团 */
	private int inviteTypeId;
	/** 邀请玩家信息列表 */
	private TeamInvitePlayerInfo[] teamInvitePlayerInfos;

	public GCTeamInviteList ()
	{
	}

	protected override void ReadImpl()
	{
	// 邀请类型，1好友，2军团
	int _inviteTypeId = ReadInt();

	// 邀请玩家信息列表
	int teamInvitePlayerInfosSize = ReadShort();
	TeamInvitePlayerInfo[] _teamInvitePlayerInfos = new TeamInvitePlayerInfo[teamInvitePlayerInfosSize];
	int teamInvitePlayerInfosIndex = 0;
	TeamInvitePlayerInfo _teamInvitePlayerInfosTmp = null;
	for(teamInvitePlayerInfosIndex=0; teamInvitePlayerInfosIndex<teamInvitePlayerInfosSize; teamInvitePlayerInfosIndex++){
		_teamInvitePlayerInfosTmp = new TeamInvitePlayerInfo();
		_teamInvitePlayerInfos[teamInvitePlayerInfosIndex] = _teamInvitePlayerInfosTmp;
	// 玩家唯一Id
	long _teamInvitePlayerInfos_uuid = ReadLong();	_teamInvitePlayerInfosTmp.uuid = _teamInvitePlayerInfos_uuid;
		// 名字 
	string _teamInvitePlayerInfos_name = ReadString();	_teamInvitePlayerInfosTmp.name = _teamInvitePlayerInfos_name;
		// 职业Id
	int _teamInvitePlayerInfos_jobTypeId = ReadInt();	_teamInvitePlayerInfosTmp.jobTypeId = _teamInvitePlayerInfos_jobTypeId;
		// 等级
	int _teamInvitePlayerInfos_level = ReadInt();	_teamInvitePlayerInfosTmp.level = _teamInvitePlayerInfos_level;
		// 模板Id
	int _teamInvitePlayerInfos_tplId = ReadInt();	_teamInvitePlayerInfosTmp.tplId = _teamInvitePlayerInfos_tplId;
		}
	//end



		this.inviteTypeId = _inviteTypeId;
		this.teamInvitePlayerInfos = _teamInvitePlayerInfos;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_TEAM_INVITE_LIST;
	}
	
	public override string getEventType()
	{
		return TeamGCHandler.GCTeamInviteListEvent;
	}
	

	public int getInviteTypeId(){
		return inviteTypeId;
	}
		

	public TeamInvitePlayerInfo[] getTeamInvitePlayerInfos(){
		return teamInvitePlayerInfos;
	}


	public override bool isCompress() {
		return true;
	}
}
}