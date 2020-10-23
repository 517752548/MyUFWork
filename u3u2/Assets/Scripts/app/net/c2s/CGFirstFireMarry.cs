using System;
using System.IO;
namespace app.net
{

/**
 * 申请离婚
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFirstFireMarry :BaseMessage
{
	
	
	public CGFirstFireMarry ()
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
		return (short)MessageType.CG_FIRST_FIRE_MARRY;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}