
using System;
namespace app.net
{
/**
 * 邀请成员加入队伍的弹出提示框
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTeamInvitePlayerNotice :BaseMessage
{
	/** 邀请玩家的队伍Id */
	private int teamId;
	/** 邀请者的玩家Id */
	private long inviterRoleId;
	/** 邀请者的名字 */
	private string inviterName;

	public GCTeamInvitePlayerNotice ()
	{
	}

	protected override void ReadImpl()
	{
	// 邀请玩家的队伍Id
	int _teamId = ReadInt();
	// 邀请者的玩家Id
	long _inviterRoleId = ReadLong();
	// 邀请者的名字
	string _inviterName = ReadString();


		this.teamId = _teamId;
		this.inviterRoleId = _inviterRoleId;
		this.inviterName = _inviterName;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_TEAM_INVITE_PLAYER_NOTICE;
	}
	
	public override string getEventType()
	{
		return TeamGCHandler.GCTeamInvitePlayerNoticeEvent;
	}
	

	public int getTeamId(){
		return teamId;
	}
		

	public long getInviterRoleId(){
		return inviterRoleId;
	}
		

	public string getInviterName(){
		return inviterName;
	}
		

}
}