
using System;
namespace app.net
{
/**
 * 通知客户端需要重新登录（一般有openkey过期造成）
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCRelogin :BaseMessage
{

	public GCRelogin ()
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
		return (short)MessageType.GC_RELOGIN;
	}
	
	public override string getEventType()
	{
		return PlayerGCHandler.GCReloginEvent;
	}
	

}
}