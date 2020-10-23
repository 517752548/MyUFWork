
using System;
namespace app.net
{
/**
 * 军团事件通知
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCorpsEventNotice :BaseMessage
{
	/** 事件类型 */
	private int corpsEventType;
	/** 事件参数 */
	private long param;

	public GCCorpsEventNotice ()
	{
	}

	protected override void ReadImpl()
	{
	// 事件类型
	int _corpsEventType = ReadInt();
	// 事件参数
	long _param = ReadLong();


		this.corpsEventType = _corpsEventType;
		this.param = _param;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_CORPS_EVENT_NOTICE;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCCorpsEventNoticeEvent;
	}
	

	public int getCorpsEventType(){
		return corpsEventType;
	}
		

	public long getParam(){
		return param;
	}
		

}
}