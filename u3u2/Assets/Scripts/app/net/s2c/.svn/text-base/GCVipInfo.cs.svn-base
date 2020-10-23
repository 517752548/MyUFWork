
using System;
namespace app.net
{
/**
 * 玩家vip信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCVipInfo :BaseMessage
{
	/** vip等级 */
	private int level;
	/** vip经验 */
	private int exp;
	/** 临时vip等级 */
	private int tmpLevel;
	/** 临时vip剩余有效时间 */
	private long leftTime;
	/** 类型，0普通，1临时 */
	private int vType;
	/** 是否充过钱，0否，1是 */
	private int isCharge;
	/** 今日奖励是否可领取，0否，1是 */
	private int canGetDayReward;

	public GCVipInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// vip等级
	int _level = ReadInt();
	// vip经验
	int _exp = ReadInt();
	// 临时vip等级
	int _tmpLevel = ReadInt();
	// 临时vip剩余有效时间
	long _leftTime = ReadLong();
	// 类型，0普通，1临时
	int _vType = ReadInt();
	// 是否充过钱，0否，1是
	int _isCharge = ReadInt();
	// 今日奖励是否可领取，0否，1是
	int _canGetDayReward = ReadInt();


		this.level = _level;
		this.exp = _exp;
		this.tmpLevel = _tmpLevel;
		this.leftTime = _leftTime;
		this.vType = _vType;
		this.isCharge = _isCharge;
		this.canGetDayReward = _canGetDayReward;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_VIP_INFO;
	}
	
	public override string getEventType()
	{
		return HumanGCHandler.GCVipInfoEvent;
	}
	

	public int getLevel(){
		return level;
	}
		

	public int getExp(){
		return exp;
	}
		

	public int getTmpLevel(){
		return tmpLevel;
	}
		

	public long getLeftTime(){
		return leftTime;
	}
		

	public int getVType(){
		return vType;
	}
		

	public int getIsCharge(){
		return isCharge;
	}
		

	public int getCanGetDayReward(){
		return canGetDayReward;
	}
		

}
}