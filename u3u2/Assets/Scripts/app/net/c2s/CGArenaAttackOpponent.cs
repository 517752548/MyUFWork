using System;
using System.IO;
namespace app.net
{

/**
 * 攻击挑战列表对手
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGArenaAttackOpponent :BaseMessage
{
	
	/** 对手序号，从1开始 */
	private int targetNum;
	
	public CGArenaAttackOpponent ()
	{
	}
	
	public CGArenaAttackOpponent (
			int targetNum )
	{
			this.targetNum = targetNum;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 对手序号，从1开始
	WriteInt(targetNum);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_ARENA_ATTACK_OPPONENT;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}