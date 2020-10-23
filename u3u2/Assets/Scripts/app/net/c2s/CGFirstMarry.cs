using System;
using System.IO;
namespace app.net
{

/**
 * 申请结婚,弹框
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFirstMarry :BaseMessage
{
	
	
	public CGFirstMarry ()
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
		return (short)MessageType.CG_FIRST_MARRY;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}