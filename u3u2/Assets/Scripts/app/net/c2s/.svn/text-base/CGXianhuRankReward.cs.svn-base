using System;
using System.IO;
namespace app.net
{

/**
 * 领取仙葫排名奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGXianhuRankReward :BaseMessage
{
	
	/** 排行类型 */
	private int rankType;
	
	public CGXianhuRankReward ()
	{
	}
	
	public CGXianhuRankReward (
			int rankType )
	{
			this.rankType = rankType;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 排行类型
	WriteInt(rankType);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_XIANHU_RANK_REWARD;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}