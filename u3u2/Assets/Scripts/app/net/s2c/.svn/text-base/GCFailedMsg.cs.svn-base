
using System;
namespace app.net
{
/**
 * GS向CLIENT发送操作失败消息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCFailedMsg :BaseMessage
{
	/** 错误号 */
	private short errorNo;
	/** 错误提示信息 */
	private string errMsg;

	public GCFailedMsg ()
	{
	}

	protected override void ReadImpl()
	{
	// 错误号
	short _errorNo = ReadShort();
	// 错误提示信息
	string _errMsg = ReadString();


		this.errorNo = _errorNo;
		this.errMsg = _errMsg;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_FAILED_MSG;
	}
	
	public override string getEventType()
	{
		return PlayerGCHandler.GCFailedMsgEvent;
	}
	

	public short getErrorNo(){
		return errorNo;
	}
		

	public string getErrMsg(){
		return errMsg;
	}
		

}
}