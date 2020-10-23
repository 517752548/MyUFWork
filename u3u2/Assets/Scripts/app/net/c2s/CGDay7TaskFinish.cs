using System;
using System.IO;
namespace app.net
{

/**
 * 七日目标任务领取奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGDay7TaskFinish :BaseMessage
{
	
	/** 任务Id */
	private int questId;
	
	public CGDay7TaskFinish ()
	{
	}
	
	public CGDay7TaskFinish (
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
		return (short)MessageType.CG_DAY7_TASK_FINISH;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}