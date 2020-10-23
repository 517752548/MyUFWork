
using System;
namespace app.net
{
/**
 * 退出nvn联赛
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCNvnLeave :BaseMessage
{

	public GCNvnLeave ()
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
		return (short)MessageType.GC_NVN_LEAVE;
	}
	
	public override string getEventType()
	{
		return NvnGCHandler.GCNvnLeaveEvent;
	}
	

}
}