using System;
using System.IO;
namespace app.net
{

/**
 * 设置队伍自动匹配
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamAutoMatch :BaseMessage
{
	
	/** 是否自动匹配，0否1是 */
	private int isAutoMatch;
	
	public CGTeamAutoMatch ()
	{
	}
	
	public CGTeamAutoMatch (
			int isAutoMatch )
	{
			this.isAutoMatch = isAutoMatch;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 是否自动匹配，0否1是
	WriteInt(isAutoMatch);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_TEAM_AUTO_MATCH;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}