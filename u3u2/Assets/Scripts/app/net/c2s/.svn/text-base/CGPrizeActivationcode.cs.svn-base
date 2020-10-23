using System;
using System.IO;
namespace app.net
{

/**
 * 激活码激活
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPrizeActivationcode :BaseMessage
{
	
	/** 激活码 */
	private string activationCode;
	
	public CGPrizeActivationcode ()
	{
	}
	
	public CGPrizeActivationcode (
			string activationCode )
	{
			this.activationCode = activationCode;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 激活码
	WriteString(activationCode);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PRIZE_ACTIVATIONCODE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}