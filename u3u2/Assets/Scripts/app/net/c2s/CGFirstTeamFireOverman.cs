using System;
using System.IO;
namespace app.net
{

/**
 * 申请解除师徒关系
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFirstTeamFireOverman :BaseMessage
{
	
	
	public CGFirstTeamFireOverman ()
	{
	}
	
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_FIRST_TEAM_FIRE_OVERMAN;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}