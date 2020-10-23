using System;
using System.IO;
namespace app.net
{

/**
 * 请求查看每日剧情副本奖励信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGDailyPlotDungeonInfo :BaseMessage
{
	
	
	public CGDailyPlotDungeonInfo ()
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
		return (short)MessageType.CG_DAILY_PLOT_DUNGEON_INFO;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}