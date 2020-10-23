
using System;
namespace app.net
{
/**
 * 已完成所有任务
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTlNpcDone :BaseMessage
{

	public GCTlNpcDone ()
	{
	}

	protected override void ReadImpl()
	{


	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_TL_NPC_DONE;
	}
	
	public override string getEventType()
	{
		return TimelimitGCHandler.GCTlNpcDoneEvent;
	}
	

}
}