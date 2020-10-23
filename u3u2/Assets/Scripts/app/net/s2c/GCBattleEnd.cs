
using System;
namespace app.net
{
/**
 * 战斗结束
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBattleEnd :BaseMessage
{

	public GCBattleEnd ()
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
		return (short)MessageType.GC_BATTLE_END;
	}
	
	public override string getEventType()
	{
		return BattleGCHandler.GCBattleEndEvent;
	}
	

}
}