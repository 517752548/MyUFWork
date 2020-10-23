
using System;
namespace app.net
{
/**
 * 组队战斗的战报
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBattleReportTeam :BaseMessage
{
	/** 0战斗开始，1每轮战报 */
	private int playType;
	/** 战报数据包 */
	private string reportPack;
	/** 队伍Id */
	private int teamId;
	/** 该轮开始时间 */
	private long roundStartTime;
	/** 当前时间 */
	private long curTime;
	/** 最近一次战斗是否自动，0否，1是 */
	private int lastAutoFlag;
	/** 攻击方1，防守方2 */
	private int isAttacker;
	/** 战斗附加json串，存储funcId等信息 */
	private string additionPack;

	public GCBattleReportTeam ()
	{
	}

	protected override void ReadImpl()
	{
	// 0战斗开始，1每轮战报
	int _playType = ReadInt();
	// 战报数据包
	string _reportPack = ReadString();
	// 队伍Id
	int _teamId = ReadInt();
	// 该轮开始时间
	long _roundStartTime = ReadLong();
	// 当前时间
	long _curTime = ReadLong();
	// 最近一次战斗是否自动，0否，1是
	int _lastAutoFlag = ReadInt();
	// 攻击方1，防守方2
	int _isAttacker = ReadInt();
	// 战斗附加json串，存储funcId等信息
	string _additionPack = ReadString();


		this.playType = _playType;
		this.reportPack = _reportPack;
		this.teamId = _teamId;
		this.roundStartTime = _roundStartTime;
		this.curTime = _curTime;
		this.lastAutoFlag = _lastAutoFlag;
		this.isAttacker = _isAttacker;
		this.additionPack = _additionPack;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_BATTLE_REPORT_TEAM;
	}
	
	public override string getEventType()
	{
		return BattleGCHandler.GCBattleReportTeamEvent;
	}
	

	public int getPlayType(){
		return playType;
	}
		

	public string getReportPack(){
		return reportPack;
	}
		

	public int getTeamId(){
		return teamId;
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
		

	public int getIsAttacker(){
		return isAttacker;
	}
		

	public string getAdditionPack(){
		return additionPack;
	}
		

	public override bool isCompress() {
		return true;
	}
}
}