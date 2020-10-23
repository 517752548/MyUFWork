using System;
using System.IO;
namespace app.net
{

/**
 * 购买体力tips信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBuyPowerTips :BaseMessage
{
	
	
	public CGBuyPowerTips ()
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
		return (short)MessageType.CG_BUY_POWER_TIPS;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}