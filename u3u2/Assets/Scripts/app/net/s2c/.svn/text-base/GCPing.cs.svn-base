
using System;
namespace app.net
{
/**
 * 服务器端响应的时间同步的消息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPing :BaseMessage
{
	/** 服务器当前时间戳 */
	private long timestamp;

	public GCPing ()
	{
	}

	protected override void ReadImpl()
	{
	// 服务器当前时间戳
	long _timestamp = ReadLong();


		this.timestamp = _timestamp;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PING;
	}
	
	public override string getEventType()
	{
		return CommonGCHandler.GCPingEvent;
	}
	

	public long getTimestamp(){
		return timestamp;
	}
		

}
}