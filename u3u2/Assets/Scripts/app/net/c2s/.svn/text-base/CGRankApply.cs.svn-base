using System;
using System.IO;
namespace app.net
{

/**
 * 申请排行榜信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGRankApply :BaseMessage
{
	
	/** 申请的排行榜信息类型(1等级排行,2战力排行,3宠物评分排行,4职业战力排行) */
	private int rankType;
	/** 申请对应排行榜信息的时间戳 */
	private long timeId;
	
	public CGRankApply ()
	{
	}
	
	public CGRankApply (
			int rankType,
			long timeId )
	{
			this.rankType = rankType;
			this.timeId = timeId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 申请的排行榜信息类型(1等级排行,2战力排行,3宠物评分排行,4职业战力排行)
	WriteInt(rankType);
	// 申请对应排行榜信息的时间戳
	WriteLong(timeId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_RANK_APPLY;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}