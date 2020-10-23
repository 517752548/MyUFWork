
using System;
namespace app.net
{
/**
 * 玩家进入地图
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMapPlayerEnter :BaseMessage
{
	/** 角色id */
	private long uuid;
	/** 地图id */
	private int mapId;
	/** 玩家X坐标(像素) */
	private int x;
	/** 玩家Y坐标(像素) */
	private int y;

	public GCMapPlayerEnter ()
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
		return (short)MessageType.GC_MAP_PLAYER_ENTER;
	}
	
	public override string getEventType()
	{
		return MapGCHandler.GCMapPlayerEnterEvent;
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