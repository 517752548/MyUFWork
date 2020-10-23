using System;
using System.IO;
namespace app.net
{

/**
 * IOS和android直冲查询
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGIosAndroidCharge :BaseMessage
{
	
	
	public CGIosAndroidCharge ()
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
		return (short)MessageType.CG_IOS_ANDROID_CHARGE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}