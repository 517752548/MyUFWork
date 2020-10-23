using System;
using System.IO;
namespace app.net
{

/**
 * 请求挂机
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGuaji :BaseMessage
{
	
	/** 玩家所在地图Id */
	private int mapId;
	
	public CGGuaji ()
	{
	}
	
	public CGGuaji (
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
	// 玩家所在地图Id
	WriteInt(mapId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_GUAJI;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}