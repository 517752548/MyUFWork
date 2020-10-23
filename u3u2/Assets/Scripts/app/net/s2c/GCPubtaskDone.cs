
using System;
namespace app.net
{
/**
 * 已完成所有任务
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPubtaskDone :BaseMessage
{

	public GCPubtaskDone ()
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
		return (short)MessageType.GC_PUBTASK_DONE;
	}
	
	public override string getEventType()
	{
		return PubtaskGCHandler.GCPubtaskDoneEvent;
	}
	

}
}