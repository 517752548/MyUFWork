using System;
using System.IO;
namespace app.net
{

/**
 * 请离队伍
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamKick :BaseMessage
{
	
	/** 目标玩家id */
	private long targetPlayerId;
	
	public CGTeamKick ()
	{
	}
	
	public CGTeamKick (
			long targetPlayerId )
	{
			this.targetPlayerId = targetPlayerId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 目标玩家id
	WriteLong(targetPlayerId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_TEAM_KICK;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}