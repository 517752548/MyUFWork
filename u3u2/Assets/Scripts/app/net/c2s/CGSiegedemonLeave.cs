using System;
using System.IO;
namespace app.net
{

/**
 * 离开副本
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSiegedemonLeave :BaseMessage
{
	
	
	public CGSiegedemonLeave ()
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
		return (short)MessageType.CG_SIEGEDEMON_LEAVE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}