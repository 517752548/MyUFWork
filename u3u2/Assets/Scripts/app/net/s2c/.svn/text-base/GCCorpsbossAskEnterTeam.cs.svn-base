
using System;
namespace app.net
{
/**
 * 返回队长请求挑战帮派boss
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCorpsbossAskEnterTeam :BaseMessage
{
	/** boss进度 */
	private int bossLevel;

	public GCCorpsbossAskEnterTeam ()
	{
	}

	protected override void ReadImpl()
	{
	// boss进度
	int _bossLevel = ReadInt();


		this.bossLevel = _bossLevel;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_CORPSBOSS_ASK_ENTER_TEAM;
	}
	
	public override string getEventType()
	{
		return CorpsbossGCHandler.GCCorpsbossAskEnterTeamEvent;
	}
	

	public int getBossLevel(){
		return bossLevel;
	}
		

}
}