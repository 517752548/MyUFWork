using System;
using System.IO;
namespace app.net
{

/**
 * 请求我的队伍
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamMy :BaseMessage
{
	
	
	public CGTeamMy ()
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
		return (short)MessageType.CG_TEAM_MY;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}