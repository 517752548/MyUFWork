
using System;
namespace app.net
{
/**
 * 通知客户端
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCNotifyException :BaseMessage
{
	/** 错误码 */
	private int code;
	/** 错误信息，如果为空就显示默认的 */
	private string errMsg;

	public GCNotifyException ()
	{
	}

	protected override void ReadImpl()
	{
	// 错误码
	int _code = ReadInt();
	// 错误信息，如果为空就显示默认的
	string _errMsg = ReadString();


		this.code = _code;
		this.errMsg = _errMsg;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_NOTIFY_EXCEPTION;
	}
	
	public override string getEventType()
	{
		return PlayerGCHandler.GCNotifyExceptionEvent;
	}
	

	public int getCode(){
		return code;
	}
		

	public string getErrMsg(){
		return errMsg;
	}
		

}
}