using System;
using System.IO;
namespace app.net
{

/**
 * 购买挑战次数
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGArenaBuyChallengeTime :BaseMessage
{
	
	
	public CGArenaBuyChallengeTime ()
	{
	}
	
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_ARENA_BUY_CHALLENGE_TIME;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}