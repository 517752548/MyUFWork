using System;
using System.IO;
namespace app.net
{

/**
 * 请求进入单人副本
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGWizardraidEnterSingle :BaseMessage
{
	
	/** 副本id */
	private int raidId;
	
	public CGWizardraidEnterSingle ()
	{
	}
	
	public CGWizardraidEnterSingle (
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
		return (short)MessageType.CG_WIZARDRAID_ENTER_SINGLE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}