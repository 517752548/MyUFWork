using System;
using System.IO;
namespace app.net
{

/**
 * 队长请求挑战帮派boss
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpsbossAskEnterTeam :BaseMessage
{
	
	/** boss进度 */
	private int bossLevel;
	
	public CGCorpsbossAskEnterTeam ()
	{
	}
	
	public CGCorpsbossAskEnterTeam (
			int bossLevel )
	{
			this.bossLevel = bossLevel;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// boss进度
	WriteInt(bossLevel);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CORPSBOSS_ASK_ENTER_TEAM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}