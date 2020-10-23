
using System;
namespace app.net
{
/**
 * 返回最优击败者战报
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWatchBestKillerReplay :BaseMessage
{
	/** 玩家Id */
	private long charId;
	/** 玩家挑战回合数 */
	private int round;
	/** 玩家等级 */
	private int level;
	/** 玩家挑战持续时间 */
	private long battleDuration;
	/** 最优击败者战报 */
	private string bestKillerInfo;

	public GCWatchBestKillerReplay ()
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
	// 玩家挑战持续时间
	long _battleDuration = ReadLong();
	// 最优击败者战报
	string _bestKillerInfo = ReadString();


		this.charId = _charId;
		this.round = _round;
		this.level = _level;
		this.battleDuration = _battleDuration;
		this.bestKillerInfo = _bestKillerInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_WATCH_BEST_KILLER_REPLAY;
	}
	
	public override string getEventType()
	{
		return TowerGCHandler.GCWatchBestKillerReplayEvent;
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
		

	public long getBattleDuration(){
		return battleDuration;
	}
		

	public string getBestKillerInfo(){
		return bestKillerInfo;
	}
		

	public override bool isCompress() {
		return true;
	}
}
}