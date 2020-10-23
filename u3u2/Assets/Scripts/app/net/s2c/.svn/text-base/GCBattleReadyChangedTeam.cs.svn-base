
using System;
namespace app.net
{
/**
 * 武将准备中状态已完毕team
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBattleReadyChangedTeam :BaseMessage
{
	/** 主将唯一id */
	private long leaderPetUUId;
	/** 宠物唯一id */
	private long petPetUUId;

	public GCBattleReadyChangedTeam ()
	{
	}

	protected override void ReadImpl()
	{
	// 主将唯一id
	long _leaderPetUUId = ReadLong();
	// 宠物唯一id
	long _petPetUUId = ReadLong();


		this.leaderPetUUId = _leaderPetUUId;
		this.petPetUUId = _petPetUUId;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_BATTLE_READY_CHANGED_TEAM;
	}
	
	public override string getEventType()
	{
		return BattleGCHandler.GCBattleReadyChangedTeamEvent;
	}
	

	public long getLeaderPetUUId(){
		return leaderPetUUId;
	}
		

	public long getPetPetUUId(){
		return petPetUUId;
	}
		

}
}