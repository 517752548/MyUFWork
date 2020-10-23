using System;
using System.IO;
namespace app.net
{

/**
 * 请求帮派竞赛排行榜
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpswarRankList :BaseMessage
{
	
	
	public CGCorpswarRankList ()
	{
	}
	
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CORPSWAR_RANK_LIST;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}