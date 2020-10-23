using System;
using System.IO;
namespace app.net
{

/**
 * 召唤队友归队
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamCallBack :BaseMessage
{
	
	/** 目标玩家id */
	private long targetPlayerId;
	
	public CGTeamCallBack ()
	{
	}
	
	public CGTeamCallBack (
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
		return (short)MessageType.CG_TEAM_CALL_BACK;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}