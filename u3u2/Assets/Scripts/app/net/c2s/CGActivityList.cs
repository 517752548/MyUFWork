using System;
using System.IO;
namespace app.net
{

/**
 * 打开活动面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGActivityList :BaseMessage
{
	
	
	public CGActivityList ()
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
		return (short)MessageType.CG_ACTIVITY_LIST;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}