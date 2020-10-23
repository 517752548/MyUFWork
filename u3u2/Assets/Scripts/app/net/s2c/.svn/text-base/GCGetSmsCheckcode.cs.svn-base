
using System;
namespace app.net
{
/**
 * 获取验证码结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGetSmsCheckcode :BaseMessage
{
	/** 获取验证码结果，1成功，2失败 */
	private int result;

	public GCGetSmsCheckcode ()
	{
	}

	protected override void ReadImpl()
	{
	// 获取验证码结果，1成功，2失败
	int _result = ReadInt();


		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_GET_SMS_CHECKCODE;
	}
	
	public override string getEventType()
	{
		return PlayerGCHandler.GCGetSmsCheckcodeEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}