using System;
using System.IO;
namespace app.net
{

/**
 * 请求限时抢购队列
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTimeLimitItemList :BaseMessage
{
	
	
	public CGTimeLimitItemList ()
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
		return (short)MessageType.CG_TIME_LIMIT_ITEM_LIST;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}