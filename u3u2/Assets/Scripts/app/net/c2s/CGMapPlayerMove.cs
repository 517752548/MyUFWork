using System;
using System.IO;
namespace app.net
{

/**
 * 玩家移动
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGMapPlayerMove :BaseMessage
{
	
	/** 地图id，校验用 */
	private int mapId;
	/** 目标x坐标(像素) */
	private int x;
	/** 目标y坐标(像素) */
	private int y;
	/** 目标最终x坐标(像素) */
	private int fx;
	/** 目标最终y坐标(像素) */
	private int fy;
	
	public CGMapPlayerMove ()
	{
	}
	
	public CGMapPlayerMove (
			int mapId,
			int x,
			int y,
			int fx,
			int fy )
	{
			this.mapId = mapId;
			this.x = x;
			this.y = y;
			this.fx = fx;
			this.fy = fy;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 地图id，校验用
	WriteInt(mapId);
	// 目标x坐标(像素)
	WriteInt(x);
	// 目标y坐标(像素)
	WriteInt(y);
	// 目标最终x坐标(像素)
	WriteInt(fx);
	// 目标最终y坐标(像素)
	WriteInt(fy);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_MAP_PLAYER_MOVE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}