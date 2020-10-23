using System;
using System.IO;
namespace app.net
{

/**
 * 申请收徒,弹框
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFirstOverman :BaseMessage
{
	
	
	public CGFirstOverman ()
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
		return (short)MessageType.CG_FIRST_OVERMAN;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}