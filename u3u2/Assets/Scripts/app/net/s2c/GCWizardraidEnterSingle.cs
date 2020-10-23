
using System;
namespace app.net
{
/**
 * 进入单人副本
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWizardraidEnterSingle :BaseMessage
{
	/** 副本id */
	private int raidId;

	public GCWizardraidEnterSingle ()
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
		return (short)MessageType.GC_WIZARDRAID_ENTER_SINGLE;
	}
	
	public override string getEventType()
	{
		return WizardraidGCHandler.GCWizardraidEnterSingleEvent;
	}
	

	public int getRaidId(){
		return raidId;
	}
		

}
}