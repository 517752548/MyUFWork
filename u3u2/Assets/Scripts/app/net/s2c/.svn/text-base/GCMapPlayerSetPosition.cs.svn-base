
using System;
namespace app.net
{
/**
 * 直接设置玩家位置，用于非法时拉回玩家
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMapPlayerSetPosition :BaseMessage
{
	/** 角色id */
	private long uuid;
	/** 地图id */
	private int mapId;
	/** 玩家X坐标(像素) */
	private int x;
	/** 玩家Y坐标(像素) */
	private int y;

	public GCMapPlayerSetPosition ()
	{
	}

	protected override void ReadImpl()
	{
	// 角色id
	long _uuid = ReadLong();
	// 地图id
	int _mapId = ReadInt();
	// 玩家X坐标(像素)
	int _x = ReadInt();
	// 玩家Y坐标(像素)
	int _y = ReadInt();


		this.uuid = _uuid;
		this.mapId = _mapId;
		this.x = _x;
		this.y = _y;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_MAP_PLAYER_SET_POSITION;
	}
	
	public override string getEventType()
	{
		return MapGCHandler.GCMapPlayerSetPositionEvent;
	}
	

	public long getUuid(){
		return uuid;
	}
		

	public int getMapId(){
		return mapId;
	}
		

	public int getX(){
		return x;
	}
		

	public int getY(){
		return y;
	}
		

}
}