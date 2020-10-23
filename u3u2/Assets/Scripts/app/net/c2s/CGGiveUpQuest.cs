using System;
using System.IO;
namespace app.net
{

/**
 * 放弃已接任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGiveUpQuest :BaseMessage
{
	
	/** 任务Id */
	private int questId;
	
	public CGGiveUpQuest ()
	{
	}
	
	public CGGiveUpQuest (
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
		return (short)MessageType.CG_GIVE_UP_QUEST;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}