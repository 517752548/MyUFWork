
using System;
namespace app.net
{
/**
 * 进入组队副本
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWizardraidEnterTeam :BaseMessage
{
	/** 副本id */
	private int raidId;

	public GCWizardraidEnterTeam ()
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
		return (short)MessageType.GC_WIZARDRAID_ENTER_TEAM;
	}
	
	public override string getEventType()
	{
		return WizardraidGCHandler.GCWizardraidEnterTeamEvent;
	}
	

	public int getRaidId(){
		return raidId;
	}
		

}
}