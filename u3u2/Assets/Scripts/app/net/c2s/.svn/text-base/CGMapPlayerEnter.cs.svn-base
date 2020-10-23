using System;
using System.IO;
namespace app.net
{

/**
 * 玩家进入地图
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGMapPlayerEnter :BaseMessage
{
	
	/** 地图id */
	private int mapId;
	
	public CGMapPlayerEnter ()
	{
	}
	
	public CGMapPlayerEnter (
			int mapId )
	{
			this.mapId = mapId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 地图id
	WriteInt(mapId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_MAP_PLAYER_ENTER;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}