
using System;
namespace app.net
{
/**
 * 队长请求进入组队副本
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWizardraidAskEnterTeam :BaseMessage
{
	/** 副本id */
	private int raidId;

	public GCWizardraidAskEnterTeam ()
	{
	}

	protected override void ReadImpl()
	{
	// 副本id
	int _raidId = ReadInt();


		this.raidId = _raidId;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_WIZARDRAID_ASK_ENTER_TEAM;
	}
	
	public override string getEventType()
	{
		return WizardraidGCHandler.GCWizardraidAskEnterTeamEvent;
	}
	

	public int getRaidId(){
		return raidId;
	}
		

}
}