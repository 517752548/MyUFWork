using System;
using System.IO;
namespace app.net
{

/**
 * 师傅获取徒弟升级的奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAddOvermanReward :BaseMessage
{
	
	/** 奖励id */
	private int rewardId;
	/** 徒弟的id */
	private long lowermanCharId;
	
	public CGAddOvermanReward ()
	{
	}
	
	public CGAddOvermanReward (
			int rewardId,
			long lowermanCharId )
	{
			this.rewardId = rewardId;
			this.lowermanCharId = lowermanCharId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 奖励id
	WriteInt(rewardId);
	// 徒弟的id
	WriteLong(lowermanCharId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_ADD_OVERMAN_REWARD;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}