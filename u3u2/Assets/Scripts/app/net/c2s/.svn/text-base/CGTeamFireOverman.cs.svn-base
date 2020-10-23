using System;
using System.IO;
namespace app.net
{

/**
 * 确认解除师徒关系师傅徒弟都发 1是同意
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamFireOverman :BaseMessage
{
	
	/** 是否同意 1是同意 徒弟发 */
	private int canOverman;
	
	public CGTeamFireOverman ()
	{
	}
	
	public CGTeamFireOverman (
			int canOverman )
	{
			this.canOverman = canOverman;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 是否同意 1是同意 徒弟发
	WriteInt(canOverman);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_TEAM_FIRE_OVERMAN;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}