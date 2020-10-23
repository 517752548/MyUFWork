
using System;
namespace app.net
{
/**
 * 给玩家发队长位置信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMapTeamLeaderPosition :BaseMessage
{
	/** 队长角色id */
	private long uuid;
	/** 地图id */
	private int mapId;
	/** 玩家X坐标(像素) */
	private int x;
	/** 玩家Y坐标(像素) */
	private int y;

	public GCMapTeamLeaderPosition ()
	{
	}

	protected override void ReadImpl()
	{
	// 队长角色id
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
		return (short)MessageType.GC_MAP_TEAM_LEADER_POSITION;
	}
	
	public override string getEventType()
	{
		return MapGCHandler.GCMapTeamLeaderPositionEvent;
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