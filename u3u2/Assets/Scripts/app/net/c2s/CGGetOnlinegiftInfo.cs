using System;
using System.IO;
namespace app.net
{

/**
 * 获取在线礼包信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGetOnlinegiftInfo :BaseMessage
{
	
	
	public CGGetOnlinegiftInfo ()
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
		return (short)MessageType.CG_GET_ONLINEGIFT_INFO;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}