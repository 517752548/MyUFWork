using System;
using System.IO;
namespace app.net
{

/**
 * 领取每日剧情副本奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGetDailyPlotDungeonReward :BaseMessage
{
	
	/** 剧情副本类型,0-简单,1-精英 */
	private int plotDungeonType;
	/** 剧情副本章数 */
	private int plotDungeonChapter;
	
	public CGGetDailyPlotDungeonReward ()
	{
	}
	
	public CGGetDailyPlotDungeonReward (
			int plotDungeonType,
			int plotDungeonChapter )
	{
			this.plotDungeonType = plotDungeonType;
			this.plotDungeonChapter = plotDungeonChapter;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 剧情副本类型,0-简单,1-精英
	WriteInt(plotDungeonType);
	// 剧情副本章数
	WriteInt(plotDungeonChapter);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_GET_DAILY_PLOT_DUNGEON_REWARD;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}