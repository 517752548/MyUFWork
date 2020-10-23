
using System;
namespace app.net
{
/**
 * 物品购买数量选择面板操作
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBuyItemPanelOperate :BaseMessage
{
	/** 1:关闭2：刷新 */
	private int opeType;

	public GCBuyItemPanelOperate ()
	{
	}

	protected override void ReadImpl()
	{
	// 1:关闭2：刷新
	int _opeType = ReadInt();


		this.opeType = _opeType;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_BUY_ITEM_PANEL_OPERATE;
	}
	
	public override string getEventType()
	{
		return MallGCHandler.GCBuyItemPanelOperateEvent;
	}
	

	public int getOpeType(){
		return opeType;
	}
		

}
}