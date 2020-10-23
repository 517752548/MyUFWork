using System;
using System.IO;
namespace app.net
{

/**
 * 验证验证码
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCheckSmsCheckcode :BaseMessage
{
	
	/** QQ号 */
	private string qqNum;
	/** 手机号 */
	private string phoneNum;
	/** 验证码 */
	private string checkCode;
	
	public CGCheckSmsCheckcode ()
	{
	}
	
	public CGCheckSmsCheckcode (
			string qqNum,
			string phoneNum,
			string checkCode )
	{
			this.qqNum = qqNum;
			this.phoneNum = phoneNum;
			this.checkCode = checkCode;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// QQ号
	WriteString(qqNum);
	// 手机号
	WriteString(phoneNum);
	// 验证码
	WriteString(checkCode);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CHECK_SMS_CHECKCODE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}