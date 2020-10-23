using System;
using System.IO;
namespace app.net
{

/**
 * 获取师傅在这个徒弟身上所有奖励的状态
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGetOvermanReward :BaseMessage
{
	
	/** 徒弟的charid */
	private long lowermanCharId;
	
	public CGGetOvermanReward ()
	{
	}
	
	public CGGetOvermanReward (
			long lowermanCharId )
	{
			this.lowermanCharId = lowermanCharId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 徒弟的charid
	WriteLong(lowermanCharId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_GET_OVERMAN_REWARD;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}