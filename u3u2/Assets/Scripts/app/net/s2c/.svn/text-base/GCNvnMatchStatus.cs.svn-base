
using System;
namespace app.net
{
/**
 * nvn队伍状态变化
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCNvnMatchStatus :BaseMessage
{
	/** 队伍状态 */
	private int teamStatus;

	public GCNvnMatchStatus ()
	{
	}

	protected override void ReadImpl()
	{
	// 队伍状态
	int _teamStatus = ReadInt();


		this.teamStatus = _teamStatus;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_NVN_MATCH_STATUS;
	}
	
	public override string getEventType()
	{
		return NvnGCHandler.GCNvnMatchStatusEvent;
	}
	

	public int getTeamStatus(){
		return teamStatus;
	}
		

}
}