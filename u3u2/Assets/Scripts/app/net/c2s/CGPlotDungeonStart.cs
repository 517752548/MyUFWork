using System;
using System.IO;
namespace app.net
{

/**
 * 请求挑战剧情副本
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPlotDungeonStart :BaseMessage
{
	
	/** 剧情副本类型,0-简单,1-精英 */
	private int plotDungeonType;
	/** 剧情副本进度 */
	private int plotDungeonLevel;
	
	public CGPlotDungeonStart ()
	{
	}
	
	public CGPlotDungeonStart (
			int plotDungeonType,
			int plotDungeonLevel )
	{
			this.plotDungeonType = plotDungeonType;
			this.plotDungeonLevel = plotDungeonLevel;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 剧情副本类型,0-简单,1-精英
	WriteInt(plotDungeonType);
	// 剧情副本进度
	WriteInt(plotDungeonLevel);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PLOT_DUNGEON_START;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}