using System;
using System.IO;
namespace app.net
{

/**
 * 购买体力
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBuyPower :BaseMessage
{
	
	
	public CGBuyPower ()
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
		return (short)MessageType.CG_BUY_POWER;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}