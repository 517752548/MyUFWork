
using System;
namespace app.net
{
/**
 * 停止挂机
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCStopGuaji :BaseMessage
{
	/** 玩家所在地图Id */
	private int mapId;

	public GCStopGuaji ()
	{
	}

	protected override void ReadImpl()
	{
	// 玩家所在地图Id
	int _mapId = ReadInt();


		this.mapId = _mapId;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_STOP_GUAJI;
	}
	
	public override string getEventType()
	{
		return TowerGCHandler.GCStopGuajiEvent;
	}
	

	public int getMapId(){
		return mapId;
	}
		

}
}