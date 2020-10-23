
using System;
namespace app.net
{
/**
 * 返回最先击败者战报
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWatchFirstKillerReplay :BaseMessage
{
	/** 玩家Id */
	private long charId;
	/** 玩家挑战回合数 */
	private int round;
	/** 玩家等级 */
	private int level;
	/** 玩家挑战结束时间 */
	private long battleEndTime;
	/** 最先击败者战报 */
	private string firstKillerInfo;

	public GCWatchFirstKillerReplay ()
	{
	}

	protected override void ReadImpl()
	{
	// 玩家Id
	long _charId = ReadLong();
	// 玩家挑战回合数
	int _round = ReadInt();
	// 玩家等级
	int _level = ReadInt();
	// 玩家挑战结束时间
	long _battleEndTime = ReadLong();
	// 最先击败者战报
	string _firstKillerInfo = ReadString();


		this.charId = _charId;
		this.round = _round;
		this.level = _level;
		this.battleEndTime = _battleEndTime;
		this.firstKillerInfo = _firstKillerInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_WATCH_FIRST_KILLER_REPLAY;
	}
	
	public override string getEventType()
	{
		return TowerGCHandler.GCWatchFirstKillerReplayEvent;
	}
	

	public long getCharId(){
		return charId;
	}
		

	public int getRound(){
		return round;
	}
		

	public int getLevel(){
		return level;
	}
		

	public long getBattleEndTime(){
		return battleEndTime;
	}
		

	public string getFirstKillerInfo(){
		return firstKillerInfo;
	}
		

	public override bool isCompress() {
		return true;
	}
}
}