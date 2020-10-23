using System;
using System.IO;
namespace app.net
{

/**
 * 邀请成员加入队伍
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamInvitePlayer :BaseMessage
{
	
	/** 邀请类型，1好友，2军团 */
	private int inviteTypeId;
	/** 目标玩家id */
	private long targetPlayerId;
	
	public CGTeamInvitePlayer ()
	{
	}
	
	public CGTeamInvitePlayer (
			int inviteTypeId,
			long targetPlayerId )
	{
			this.inviteTypeId = inviteTypeId;
			this.targetPlayerId = targetPlayerId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 邀请类型，1好友，2军团
	WriteInt(inviteTypeId);
	// 目标玩家id
	WriteLong(targetPlayerId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_TEAM_INVITE_PLAYER;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}