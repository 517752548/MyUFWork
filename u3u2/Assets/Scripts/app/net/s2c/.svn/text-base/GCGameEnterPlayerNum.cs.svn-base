
using System;
namespace app.net
{
/**
 * 进入玩家角色人数
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGameEnterPlayerNum :BaseMessage
{
	/** 进入玩家角色人数 */
	private int enterPlayerNum;

	public GCGameEnterPlayerNum ()
	{
	}

	protected override void ReadImpl()
	{
	// 进入玩家角色人数
	int _enterPlayerNum = ReadInt();


		this.enterPlayerNum = _enterPlayerNum;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_GAME_ENTER_PLAYER_NUM;
	}
	
	public override string getEventType()
	{
		return PlayerGCHandler.GCGameEnterPlayerNumEvent;
	}
	

	public int getEnterPlayerNum(){
		return enterPlayerNum;
	}
		

}
}