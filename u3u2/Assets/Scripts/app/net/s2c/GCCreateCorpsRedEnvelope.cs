
using System;
namespace app.net
{
/**
 * 返回请求发送帮派红包
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCreateCorpsRedEnvelope :BaseMessage
{
	/** 结果,1成功,2失败 */
	private int result;

	public GCCreateCorpsRedEnvelope ()
	{
	}

	protected override void ReadImpl()
	{
	// 结果,1成功,2失败
	int _result = ReadInt();


		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_CREATE_CORPS_RED_ENVELOPE;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCCreateCorpsRedEnvelopeEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}