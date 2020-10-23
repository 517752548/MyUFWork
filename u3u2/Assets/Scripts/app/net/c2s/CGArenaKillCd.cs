using System;
using System.IO;
namespace app.net
{

/**
 * 消除竞技场cd
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGArenaKillCd :BaseMessage
{
	
	
	public CGArenaKillCd ()
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
		return (short)MessageType.CG_ARENA_KILL_CD;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}