using System;
using System.IO;
namespace app.net
{

/**
 * 接受任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGForagetaskAccept :BaseMessage
{
	
	/** 任务Id */
	private int questId;
	
	public CGForagetaskAccept ()
	{
	}
	
	public CGForagetaskAccept (
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
		return (short)MessageType.CG_FORAGETASK_ACCEPT;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}