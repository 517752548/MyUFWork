
using System;
namespace app.net
{
/**
 * 返回下个限时列表上架CD
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCNextQueueCd :BaseMessage
{
	/** cd */
	private long cd;

	public GCNextQueueCd ()
	{
	}

	protected override void ReadImpl()
	{
	// cd
	long _cd = ReadLong();


		this.cd = _cd;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_NEXT_QUEUE_CD;
	}
	
	public override string getEventType()
	{
		return MallGCHandler.GCNextQueueCdEvent;
	}
	

	public long getCd(){
		return cd;
	}
		

}
}