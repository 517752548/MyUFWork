using System;
using System.IO;
namespace app.net
{

/**
 * 查看当前剧情副本情况
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPlotDungeonInfo :BaseMessage
{
	
	/** 剧情副本类型,0-简单,1-精英 */
	private int plotDungeonType;
	
	public CGPlotDungeonInfo ()
	{
	}
	
	public CGPlotDungeonInfo (
			int plotDungeonType )
	{
			this.plotDungeonType = plotDungeonType;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 剧情副本类型,0-简单,1-精英
	WriteInt(plotDungeonType);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PLOT_DUNGEON_INFO;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}