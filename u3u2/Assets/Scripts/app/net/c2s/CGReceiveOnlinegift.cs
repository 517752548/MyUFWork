using System;
using System.IO;
namespace app.net
{

/**
 * 领取在线礼包
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGReceiveOnlinegift :BaseMessage
{
	
	
	public CGReceiveOnlinegift ()
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
		return (short)MessageType.CG_RECEIVE_ONLINEGIFT;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}