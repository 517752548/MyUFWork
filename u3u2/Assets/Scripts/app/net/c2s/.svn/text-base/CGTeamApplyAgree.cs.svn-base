using System;
using System.IO;
namespace app.net
{

/**
 * 接受玩家申请加入
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamApplyAgree :BaseMessage
{
	
	/** 目标玩家id */
	private long targetPlayerId;
	
	public CGTeamApplyAgree ()
	{
	}
	
	public CGTeamApplyAgree (
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
		return (short)MessageType.CG_TEAM_APPLY_AGREE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}