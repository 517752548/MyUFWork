
using System;
namespace app.net
{
/**
 * 通知客户端登录需要弹出的面板已经都发完了，前台可以开始处理了
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPopupPanelEnd :BaseMessage
{

	public GCPopupPanelEnd ()
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
		return (short)MessageType.GC_POPUP_PANEL_END;
	}
	
	public override string getEventType()
	{
		return PlayerGCHandler.GCPopupPanelEndEvent;
	}
	

}
}