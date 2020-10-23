using System;
using System.IO;
namespace app.net
{

/**
 * 徒弟获取升级的奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAddLowermanReward :BaseMessage
{
	
	/** 奖励id */
	private int rewardId;
	
	public CGAddLowermanReward ()
	{
	}
	
	public CGAddLowermanReward (
			int rewardId )
	{
			this.rewardId = rewardId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 奖励id
	WriteInt(rewardId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_ADD_LOWERMAN_REWARD;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}