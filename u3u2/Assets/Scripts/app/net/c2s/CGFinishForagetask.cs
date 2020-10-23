using System;
using System.IO;
namespace app.net
{

/**
 * 完成任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFinishForagetask :BaseMessage
{
	
	
	public CGFinishForagetask ()
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
		return (short)MessageType.CG_FINISH_FORAGETASK;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}