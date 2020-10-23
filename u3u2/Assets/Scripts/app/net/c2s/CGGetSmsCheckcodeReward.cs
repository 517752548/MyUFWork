using System;
using System.IO;
namespace app.net
{

/**
 * 领取手机验证奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGetSmsCheckcodeReward :BaseMessage
{
	
	
	public CGGetSmsCheckcodeReward ()
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
		return (short)MessageType.CG_GET_SMS_CHECKCODE_REWARD;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}