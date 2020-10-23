
using System;
namespace app.net
{
/**
 * 申请签到结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCDaliyGiftSign :BaseMessage
{
	/** 申请签到结果 1成功,2失败 */
	private int result;

	public GCDaliyGiftSign ()
	{
	}

	protected override void ReadImpl()
	{
	// 申请签到结果 1成功,2失败
	int _result = ReadInt();


		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_DALIY_GIFT_SIGN;
	}
	
	public override string getEventType()
	{
		return OnlinegiftGCHandler.GCDaliyGiftSignEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}