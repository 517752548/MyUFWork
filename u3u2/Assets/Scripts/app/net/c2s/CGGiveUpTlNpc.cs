using System;
using System.IO;
namespace app.net
{

/**
 * 放弃已接任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGiveUpTlNpc :BaseMessage
{
	
	
	public CGGiveUpTlNpc ()
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
		return (short)MessageType.CG_GIVE_UP_TL_NPC;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}