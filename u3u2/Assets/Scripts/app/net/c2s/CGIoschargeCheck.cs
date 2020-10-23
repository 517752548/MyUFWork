using System;
using System.IO;
namespace app.net
{

/**
 * ios充值check
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGIoschargeCheck :BaseMessage
{
	
	/** 充值token */
	private string token;
	
	public CGIoschargeCheck ()
	{
	}
	
	public CGIoschargeCheck (
			string token )
	{
			this.token = token;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 充值token
	WriteString(token);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_IOSCHARGE_CHECK;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}