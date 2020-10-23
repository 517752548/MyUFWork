
using System;
namespace app.net
{
/**
 * 打开防沉迷填写面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWallowOpenPanel :BaseMessage
{

	public GCWallowOpenPanel ()
	{
	}

	protected override void ReadImpl()
	{


	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_WALLOW_OPEN_PANEL;
	}
	
	public override string getEventType()
	{
		return WallowGCHandler.GCWallowOpenPanelEvent;
	}
	

}
}