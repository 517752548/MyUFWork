
using System;
namespace app.net
{
/**
 * 通过码兑换奖励结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCChannelExchange :BaseMessage
{
	/** 兑换结果，1成功，2失败 */
	private int result;

	public GCChannelExchange ()
	{
	}

	protected override void ReadImpl()
	{
	// 兑换结果，1成功，2失败
	int _result = ReadInt();


		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_CHANNEL_EXCHANGE;
	}
	
	public override string getEventType()
	{
		return HumanGCHandler.GCChannelExchangeEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}