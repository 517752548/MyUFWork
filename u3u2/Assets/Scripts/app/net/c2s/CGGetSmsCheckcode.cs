using System;
using System.IO;
namespace app.net
{

/**
 * 获取验证码
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGetSmsCheckcode :BaseMessage
{
	
	/** 手机号 */
	private string phoneNum;
	
	public CGGetSmsCheckcode ()
	{
	}
	
	public CGGetSmsCheckcode (
			string phoneNum )
	{
			this.phoneNum = phoneNum;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 手机号
	WriteString(phoneNum);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_GET_SMS_CHECKCODE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}