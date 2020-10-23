using System;
using System.IO;
namespace app.net
{

/**
 * 放弃已接任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGiveUpThesweeneytask :BaseMessage
{
	
	
	public CGGiveUpThesweeneytask ()
	{
	}
	
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_GIVE_UP_THESWEENEYTASK;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}