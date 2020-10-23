using System;
using System.IO;
namespace app.net
{

/**
 * 邀请成员列表
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamInviteList :BaseMessage
{
	
	/** 邀请类型，1好友，2军团 */
	private int inviteTypeId;
	
	public CGTeamInviteList ()
	{
	}
	
	public CGTeamInviteList (
			int inviteTypeId )
	{
			this.inviteTypeId = inviteTypeId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 邀请类型，1好友，2军团
	WriteInt(inviteTypeId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_TEAM_INVITE_LIST;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}