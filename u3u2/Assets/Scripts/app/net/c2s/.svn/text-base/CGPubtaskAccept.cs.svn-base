using System;
using System.IO;
namespace app.net
{

/**
 * 接受任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPubtaskAccept :BaseMessage
{
	
	/** 任务Id */
	private int questId;
	
	public CGPubtaskAccept ()
	{
	}
	
	public CGPubtaskAccept (
			int questId )
	{
			this.questId = questId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 任务Id
	WriteInt(questId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PUBTASK_ACCEPT;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}