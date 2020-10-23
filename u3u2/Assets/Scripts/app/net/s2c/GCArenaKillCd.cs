
using System;
namespace app.net
{
/**
 * 消除竞技场cd成功
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCArenaKillCd :BaseMessage
{

	public GCArenaKillCd ()
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
		return (short)MessageType.GC_ARENA_KILL_CD;
	}
	
	public override string getEventType()
	{
		return ArenaGCHandler.GCArenaKillCdEvent;
	}
	

}
}