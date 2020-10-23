
using System;
namespace app.net
{
/**
 * 申请补签结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCDaliyGiftRetroactive :BaseMessage
{
	/** 申请补签结果 1成功,2失败 */
	private int result;

	public GCDaliyGiftRetroactive ()
	{
	}

	protected override void ReadImpl()
	{
	// 申请补签结果 1成功,2失败
	int _result = ReadInt();


		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_DALIY_GIFT_RETROACTIVE;
	}
	
	public override string getEventType()
	{
		return OnlinegiftGCHandler.GCDaliyGiftRetroactiveEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}