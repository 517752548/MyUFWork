using System;
using System.IO;
namespace app.net
{

/**
 * 请求仙葫排行数据
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGXianhuRankList :BaseMessage
{
	
	/** 排行类型 */
	private int rankType;
	
	public CGXianhuRankList ()
	{
	}
	
	public CGXianhuRankList (
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
		return (short)MessageType.CG_XIANHU_RANK_LIST;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}