
using System;
namespace app.net
{
/**
 * 返回每日剧情副本奖励信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCDailyPlotDungeonInfo :BaseMessage
{
	/** 每日剧情副本奖励信息 */
	private PlotDungeonInfo[] plotDungeonInfoList;

	public GCDailyPlotDungeonInfo ()
	{
	}

	protected override void ReadImpl()
	{

	// 每日剧情副本奖励信息
	int plotDungeonInfoListSize = ReadShort();
	PlotDungeonInfo[] _plotDungeonInfoList = new PlotDungeonInfo[plotDungeonInfoListSize];
	int plotDungeonInfoListIndex = 0;
	PlotDungeonInfo _plotDungeonInfoListTmp = null;
	for(plotDungeonInfoListIndex=0; plotDungeonInfoListIndex<plotDungeonInfoListSize; plotDungeonInfoListIndex++){
		_plotDungeonInfoListTmp = new PlotDungeonInfo();
		_plotDungeonInfoList[plotDungeonInfoListIndex] = _plotDungeonInfoListTmp;
	// 剧情副本类型,0-简单,1-精英
	int _plotDungeonInfoList_plotDungeonType = ReadInt();	_plotDungeonInfoListTmp.plotDungeonType = _plotDungeonInfoList_plotDungeonType;
		// 剧情副本章数
	int _plotDungeonInfoList_plotDungeonChapter = ReadInt();	_plotDungeonInfoListTmp.plotDungeonChapter = _plotDungeonInfoList_plotDungeonChapter;
		// 剧情副本状态,0-不可领取,1-可领取但未领取,2-已领取
	int _plotDungeonInfoList_plotDungeonStatus = ReadInt();	_plotDungeonInfoListTmp.plotDungeonStatus = _plotDungeonInfoList_plotDungeonStatus;
		}
	//end



		this.plotDungeonInfoList = _plotDungeonInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_DAILY_PLOT_DUNGEON_INFO;
	}
	
	public override string getEventType()
	{
		return PlotdungeonGCHandler.GCDailyPlotDungeonInfoEvent;
	}
	

	public PlotDungeonInfo[] getPlotDungeonInfoList(){
		return plotDungeonInfoList;
	}


}
}