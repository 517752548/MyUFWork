using System;
using System.IO;
namespace app.net
{

/**
 * 完成任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFinishQuest :BaseMessage
{
	
	/** 任务Id */
	private int questId;
	
	public CGFinishQuest ()
	{
	}
	
	public CGFinishQuest (
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
		return (short)MessageType.CG_FINISH_QUEST;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}