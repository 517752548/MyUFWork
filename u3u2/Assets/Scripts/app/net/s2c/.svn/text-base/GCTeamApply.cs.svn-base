
using System;
namespace app.net
{
/**
 * 申请加入队伍成功
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTeamApply :BaseMessage
{
	/** 队伍Id */
	private int teamId;

	public GCTeamApply ()
	{
	}

	protected override void ReadImpl()
	{
	// 队伍Id
	int _teamId = ReadInt();


		this.teamId = _teamId;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_TEAM_APPLY;
	}
	
	public override string getEventType()
	{
		return TeamGCHandler.GCTeamApplyEvent;
	}
	

	public int getTeamId(){
		return teamId;
	}
		

}
}