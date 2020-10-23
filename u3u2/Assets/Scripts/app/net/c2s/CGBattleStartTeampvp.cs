using System;
using System.IO;
namespace app.net
{

/**
 * 请求组队PVP战斗
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBattleStartTeampvp :BaseMessage
{
	
	/** 目标玩家Id */
	private long targetPlayerId;
	
	public CGBattleStartTeampvp ()
	{
	}
	
	public CGBattleStartTeampvp (
			long targetPlayerId )
	{
			this.targetPlayerId = targetPlayerId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 目标玩家Id
	WriteLong(targetPlayerId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_BATTLE_START_TEAMPVP;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}