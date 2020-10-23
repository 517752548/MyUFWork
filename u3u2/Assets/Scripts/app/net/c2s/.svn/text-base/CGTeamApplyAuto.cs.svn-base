using System;
using System.IO;
namespace app.net
{

/**
 * 自动申请加入队伍
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamApplyAuto :BaseMessage
{
	
	/** 是否自动申请，0否1是 */
	private int isAuto;
	/** 目标Id */
	private int targetId;
	
	public CGTeamApplyAuto ()
	{
	}
	
	public CGTeamApplyAuto (
			int isAuto,
			int targetId )
	{
			this.isAuto = isAuto;
			this.targetId = targetId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 是否自动申请，0否1是
	WriteInt(isAuto);
	// 目标Id
	WriteInt(targetId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_TEAM_APPLY_AUTO;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}