
using System;
namespace app.net
{
/**
 * 返回请求制作物品
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMakeItem :BaseMessage
{
	/** 制作结果,1成功,2失败 */
	private int result;

	public GCMakeItem ()
	{
	}

	protected override void ReadImpl()
	{
	// 制作结果,1成功,2失败
	int _result = ReadInt();


		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_MAKE_ITEM;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCMakeItemEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}