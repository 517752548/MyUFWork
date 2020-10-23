using System;
using System.IO;
namespace app.net
{

/**
 * 邀请成员弹出提示框的响应
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamInvitePlayerAnswer :BaseMessage
{
	
	/** 邀请玩家的队伍Id */
	private int teamId;
	/** 是否同意邀请，0拒绝，1同意 */
	private int agree;
	
	public CGTeamInvitePlayerAnswer ()
	{
	}
	
	public CGTeamInvitePlayerAnswer (
			int teamId,
			int agree )
	{
			this.teamId = teamId;
			this.agree = agree;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 邀请玩家的队伍Id
	WriteInt(teamId);
	// 是否同意邀请，0拒绝，1同意
	WriteInt(agree);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_TEAM_INVITE_PLAYER_ANSWER;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}