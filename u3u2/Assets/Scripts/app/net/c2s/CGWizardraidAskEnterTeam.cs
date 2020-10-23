using System;
using System.IO;
namespace app.net
{

/**
 * 队长请求进入组队副本
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGWizardraidAskEnterTeam :BaseMessage
{
	
	/** 副本id */
	private int raidId;
	
	public CGWizardraidAskEnterTeam ()
	{
	}
	
	public CGWizardraidAskEnterTeam (
			int raidId )
	{
			this.raidId = raidId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 副本id
	WriteInt(raidId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_WIZARDRAID_ASK_ENTER_TEAM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}