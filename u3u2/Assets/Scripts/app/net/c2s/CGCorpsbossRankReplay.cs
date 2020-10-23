using System;
using System.IO;
namespace app.net
{

/**
 * 请求查看帮派boss单一排行榜的录像
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpsbossRankReplay :BaseMessage
{
	
	/** 排名 */
	private int rank;
	
	public CGCorpsbossRankReplay ()
	{
	}
	
	public CGCorpsbossRankReplay (
			int rank )
	{
			this.rank = rank;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 排名
	WriteInt(rank);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CORPSBOSS_RANK_REPLAY;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}