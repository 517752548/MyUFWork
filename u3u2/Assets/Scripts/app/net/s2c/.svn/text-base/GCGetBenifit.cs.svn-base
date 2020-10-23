
using System;
namespace app.net
{
/**
 * 返回领取帮派福利结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGetBenifit :BaseMessage
{
	/** 1成功,2失败 */
	private int result;

	public GCGetBenifit ()
	{
	}

	protected override void ReadImpl()
	{
	// 1成功,2失败
	int _result = ReadInt();


		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_GET_BENIFIT;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCGetBenifitEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}