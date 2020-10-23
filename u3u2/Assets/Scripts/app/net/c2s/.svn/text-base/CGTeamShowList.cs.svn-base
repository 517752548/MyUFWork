using System;
using System.IO;
namespace app.net
{

/**
 * 显示队伍列表界面
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamShowList :BaseMessage
{
	
	/** 目标Id */
	private int targetId;
	
	public CGTeamShowList ()
	{
	}
	
	public CGTeamShowList (
			int targetId )
	{
			this.targetId = targetId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 目标Id
	WriteInt(targetId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_TEAM_SHOW_LIST;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}