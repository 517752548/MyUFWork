using System;
using System.IO;
namespace app.net
{

/**
 * 战斗加速
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBattleSpeedup :BaseMessage
{
	
	/** 速度倍数 */
	private int speed;
	
	public CGBattleSpeedup ()
	{
	}
	
	public CGBattleSpeedup (
			int speed )
	{
			this.speed = speed;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 速度倍数
	WriteInt(speed);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_BATTLE_SPEEDUP;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}