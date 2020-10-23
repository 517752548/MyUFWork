using System;
using System.IO;
namespace app.net
{

/**
 * 调整队员位置
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamChangePosition :BaseMessage
{
	
	/** 目标玩家id */
	private long targetPlayerId;
	/** 目标玩家位置，从1开始计数 */
	private int targetPosition;
	
	public CGTeamChangePosition ()
	{
	}
	
	public CGTeamChangePosition (
			long targetPlayerId,
			int targetPosition )
	{
			this.targetPlayerId = targetPlayerId;
			this.targetPosition = targetPosition;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 目标玩家id
	WriteLong(targetPlayerId);
	// 目标玩家位置，从1开始计数
	WriteInt(targetPosition);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_TEAM_CHANGE_POSITION;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}