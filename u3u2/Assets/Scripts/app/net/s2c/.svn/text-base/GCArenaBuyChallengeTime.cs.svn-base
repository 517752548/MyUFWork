
using System;
namespace app.net
{
/**
 * 购买挑战次数结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCArenaBuyChallengeTime :BaseMessage
{
	/** 当前可以挑战挑战次数 */
	private int challengeTimes;
	/** 购买竞技场次数消耗金票数 */
	private int buyChallengeTimesCost;

	public GCArenaBuyChallengeTime ()
	{
	}

	protected override void ReadImpl()
	{
	// 当前可以挑战挑战次数
	int _challengeTimes = ReadInt();
	// 购买竞技场次数消耗金票数
	int _buyChallengeTimesCost = ReadInt();


		this.challengeTimes = _challengeTimes;
		this.buyChallengeTimesCost = _buyChallengeTimesCost;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_ARENA_BUY_CHALLENGE_TIME;
	}
	
	public override string getEventType()
	{
		return ArenaGCHandler.GCArenaBuyChallengeTimeEvent;
	}
	

	public int getChallengeTimes(){
		return challengeTimes;
	}
		

	public int getBuyChallengeTimesCost(){
		return buyChallengeTimesCost;
	}
		

}
}