
using System;
namespace app.net
{
/**
 * 返回当前剧情副本情况
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPlotDungeonInfo :BaseMessage
{
	/** 剧情副本可开启的章节数 */
	private int plotDungeonChapter;
	/** 剧情副本类型,0-简单,1-精英 */
	private int plotDungeonType;
	/** 当前挑战剧情副本进度 */
	private int curPlotDungeonLevel;

	public GCPlotDungeonInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 剧情副本可开启的章节数
	int _plotDungeonChapter = ReadInt();
	// 剧情副本类型,0-简单,1-精英
	int _plotDungeonType = ReadInt();
	// 当前挑战剧情副本进度
	int _curPlotDungeonLevel = ReadInt();


		this.plotDungeonChapter = _plotDungeonChapter;
		this.plotDungeonType = _plotDungeonType;
		this.curPlotDungeonLevel = _curPlotDungeonLevel;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PLOT_DUNGEON_INFO;
	}
	
	public override string getEventType()
	{
		return PlotdungeonGCHandler.GCPlotDungeonInfoEvent;
	}
	

	public int getPlotDungeonChapter(){
		return plotDungeonChapter;
	}
		

	public int getPlotDungeonType(){
		return plotDungeonType;
	}
		

	public int getCurPlotDungeonLevel(){
		return curPlotDungeonLevel;
	}
		

}
}