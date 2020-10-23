
using System;
namespace app.net
{
/**
 * 目标玩家收到的请求PVP战斗
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBattleStartPvpInvite :BaseMessage
{
	/** 发起切磋玩家Id */
	private long sourcePlayerId;
	/** 发起切磋玩家名字 */
	private string sourcePlayerName;

	public GCBattleStartPvpInvite ()
	{
	}

	protected override void ReadImpl()
	{
	// 发起切磋玩家Id
	long _sourcePlayerId = ReadLong();
	// 发起切磋玩家名字
	string _sourcePlayerName = ReadString();


		this.sourcePlayerId = _sourcePlayerId;
		this.sourcePlayerName = _sourcePlayerName;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_BATTLE_START_PVP_INVITE;
	}
	
	public override string getEventType()
	{
		return BattleGCHandler.GCBattleStartPvpInviteEvent;
	}
	

	public long getSourcePlayerId(){
		return sourcePlayerId;
	}
		

	public string getSourcePlayerName(){
		return sourcePlayerName;
	}
		

}
}