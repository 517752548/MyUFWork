using System;
using System.IO;
namespace app.net
{

/**
 * 应答请求PVP战斗
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBattleStartPvpConfirm :BaseMessage
{
	
	/** 是否同意切磋，0不同意，1同意 */
	private int agree;
	/** 发起切磋玩家Id */
	private long sourcePlayerId;
	
	public CGBattleStartPvpConfirm ()
	{
	}
	
	public CGBattleStartPvpConfirm (
			int agree,
			long sourcePlayerId )
	{
			this.agree = agree;
			this.sourcePlayerId = sourcePlayerId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 是否同意切磋，0不同意，1同意
	WriteInt(agree);
	// 发起切磋玩家Id
	WriteLong(sourcePlayerId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_BATTLE_START_PVP_CONFIRM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}