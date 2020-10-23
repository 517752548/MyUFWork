
using System;
namespace app.net
{
/**
 * 战斗外嗑药结果消息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCUsePoolAddResult :BaseMessage
{
	/** 道具模板Id */
	private int itemTplId;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCUsePoolAddResult ()
	{
	}

	protected override void ReadImpl()
	{
	// 道具模板Id
	int _itemTplId = ReadInt();
	// 操作结果，1成功，2失败
	int _result = ReadInt();


		this.itemTplId = _itemTplId;
		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_USE_POOL_ADD_RESULT;
	}
	
	public override string getEventType()
	{
		return ItemGCHandler.GCUsePoolAddResultEvent;
	}
	

	public int getItemTplId(){
		return itemTplId;
	}
		

	public int getResult(){
		return result;
	}
		

}
}