
using System;
namespace app.net
{
/**
 * 邀请成员加入队伍操作成功
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTeamInvitePlayer :BaseMessage
{
	/** 目标玩家id */
	private long targetPlayerId;

	public GCTeamInvitePlayer ()
	{
	}

	protected override void ReadImpl()
	{
	// 目标玩家id
	long _targetPlayerId = ReadLong();


		this.targetPlayerId = _targetPlayerId;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_TEAM_INVITE_PLAYER;
	}
	
	public override string getEventType()
	{
		return TeamGCHandler.GCTeamInvitePlayerEvent;
	}
	

	public long getTargetPlayerId(){
		return targetPlayerId;
	}
		

}
}