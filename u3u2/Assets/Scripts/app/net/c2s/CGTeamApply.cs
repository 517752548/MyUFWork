using System;
using System.IO;
namespace app.net
{

/**
 * 申请加入队伍
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamApply :BaseMessage
{
	
	/** 队伍Id */
	private int teamId;
	
	public CGTeamApply ()
	{
	}
	
	public CGTeamApply (
			int teamId )
	{
			this.teamId = teamId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 队伍Id
	WriteInt(teamId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_TEAM_APPLY;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}