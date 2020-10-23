
using System;
namespace app.net
{
/**
 * 验证验证码结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCheckSmsCheckcode :BaseMessage
{
	/** 验证结果，1成功，2失败 */
	private int result;
	/** QQ号 */
	private string qqNum;
	/** 手机号 */
	private string phoneNum;

	public GCCheckSmsCheckcode ()
	{
	}

	protected override void ReadImpl()
	{
	// 验证结果，1成功，2失败
	int _result = ReadInt();
	// QQ号
	string _qqNum = ReadString();
	// 手机号
	string _phoneNum = ReadString();


		this.result = _result;
		this.qqNum = _qqNum;
		this.phoneNum = _phoneNum;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_CHECK_SMS_CHECKCODE;
	}
	
	public override string getEventType()
	{
		return PlayerGCHandler.GCCheckSmsCheckcodeEvent;
	}
	

	public int getResult(){
		return result;
	}
		

	public string getQqNum(){
		return qqNum;
	}
		

	public string getPhoneNum(){
		return phoneNum;
	}
		

}
}