
using System;
namespace app.net
{
/**
 * 卖出商品结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTradeSellResult :BaseMessage
{
	/** 1成功，2失败 */
	private int result;

	public GCTradeSellResult ()
	{
	}

	protected override void ReadImpl()
	{
	// 1成功，2失败
	int _result = ReadInt();


		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_TRADE_SELL_RESULT;
	}
	
	public override string getEventType()
	{
		return TradeGCHandler.GCTradeSellResultEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}