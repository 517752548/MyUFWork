using System;
using System.IO;
namespace app.net
{

/**
 * 升为队长
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamChangeLeader :BaseMessage
{
	
	/** 目标玩家id */
	private long targetPlayerId;
	
	public CGTeamChangeLeader ()
	{
	}
	
	public CGTeamChangeLeader (
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
		return (short)MessageType.CG_TEAM_CHANGE_LEADER;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}