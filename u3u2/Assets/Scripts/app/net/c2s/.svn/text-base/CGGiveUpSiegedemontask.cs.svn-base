using System;
using System.IO;
namespace app.net
{

/**
 * 放弃已接任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGiveUpSiegedemontask :BaseMessage
{
	
	/** 任务类型 */
	private int questType;
	
	public CGGiveUpSiegedemontask ()
	{
	}
	
	public CGGiveUpSiegedemontask (
			int questType )
	{
			this.questType = questType;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 任务类型
	WriteInt(questType);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_GIVE_UP_SIEGEDEMONTASK;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}