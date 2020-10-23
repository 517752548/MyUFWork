
using System;
namespace app.net
{
/**
 * PVP战斗的战报
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBattleReportPvp :BaseMessage
{
	/** 0战斗开始，1每轮战报 */
	private int playType;
	/** 战报数据包 */
	private string reportPack;
	/** 攻击方玩家Id */
	private long attackerId;
	/** 防守方玩家Id */
	private long defenderId;
	/** 该轮开始时间 */
	private long roundStartTime;
	/** 当前时间 */
	private long curTime;
	/** 最近一次战斗是否自动，0否，1是 */
	private int lastAutoFlag;

	public GCBattleReportPvp ()
	{
	}

	protected override void ReadImpl()
	{
	// 0战斗开始，1每轮战报
	int _playType = ReadInt();
	// 战报数据包
	string _reportPack = ReadString();
	// 攻击方玩家Id
	long _attackerId = ReadLong();
	// 防守方玩家Id
	long _defenderId = ReadLong();
	// 该轮开始时间
	long _roundStartTime = ReadLong();
	// 当前时间
	long _curTime = ReadLong();
	// 最近一次战斗是否自动，0否，1是
	int _lastAutoFlag = ReadInt();


		this.playType = _playType;
		this.reportPack = _reportPack;
		this.attackerId = _attackerId;
		this.defenderId = _defenderId;
		this.roundStartTime = _roundStartTime;
		this.curTime = _curTime;
		this.lastAutoFlag = _lastAutoFlag;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_BATTLE_REPORT_PVP;
	}
	
	public override string getEventType()
	{
		return BattleGCHandler.GCBattleReportPvpEvent;
	}
	

	public int getPlayType(){
		return playType;
	}
		

	public string getReportPack(){
		return reportPack;
	}
		

	public long getAttackerId(){
		return attackerId;
	}
		

	public long getDefenderId(){
		return defenderId;
	}
		

	public long getRoundStartTime(){
		return roundStartTime;
	}
		

	public long getCurTime(){
		return curTime;
	}
		

	public int getLastAutoFlag(){
		return lastAutoFlag;
	}
		

	public override bool isCompress() {
		return true;
	}
}
}