using System;
using System.IO;
namespace app.net
{

/**
 * 请求帮派竞赛信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpswarInfo :BaseMessage
{
	
	
	public CGCorpswarInfo ()
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
		return (short)MessageType.CG_CORPSWAR_INFO;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}