using System;
using System.IO;
namespace app.net
{

/**
 * 创建队伍
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamCreate :BaseMessage
{
	
	
	public CGTeamCreate ()
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
		return (short)MessageType.CG_TEAM_CREATE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}