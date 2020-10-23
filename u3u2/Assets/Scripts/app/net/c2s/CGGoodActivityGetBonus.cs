using System;
using System.IO;
namespace app.net
{

/**
 * 领取活动奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGoodActivityGetBonus :BaseMessage
{
	
	/** 活动id */
	private long activityId;
	/** 奖励id */
	private int bonusId;
	
	public CGGoodActivityGetBonus ()
	{
	}
	
	public CGGoodActivityGetBonus (
			long activityId,
			int bonusId )
	{
			this.activityId = activityId;
			this.bonusId = bonusId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 活动id
	WriteLong(activityId);
	// 奖励id
	WriteInt(bonusId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_GOOD_ACTIVITY_GET_BONUS;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}