
using System;
namespace app.net
{
/**
 * 玩家创建角色时间
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCreateTime :BaseMessage
{
	/** 创建角色时间，毫秒 */
	private long createTime;

	public GCCreateTime ()
	{
	}

	protected override void ReadImpl()
	{
	// 创建角色时间，毫秒
	long _createTime = ReadLong();


		this.createTime = _createTime;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_CREATE_TIME;
	}
	
	public override string getEventType()
	{
		return HumanGCHandler.GCCreateTimeEvent;
	}
	

	public long getCreateTime(){
		return createTime;
	}
		

}
}