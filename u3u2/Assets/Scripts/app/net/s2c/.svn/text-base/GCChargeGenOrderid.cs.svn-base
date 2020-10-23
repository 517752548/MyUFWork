
using System;
namespace app.net
{
/**
 * 生成充值订单Id
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCChargeGenOrderid :BaseMessage
{
	/** 充值订单Id */
	private string orderId;

	public GCChargeGenOrderid ()
	{
	}

	protected override void ReadImpl()
	{
	// 充值订单Id
	string _orderId = ReadString();


		this.orderId = _orderId;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_CHARGE_GEN_ORDERID;
	}
	
	public override string getEventType()
	{
		return PlayerGCHandler.GCChargeGenOrderidEvent;
	}
	

	public string getOrderId(){
		return orderId;
	}
		

}
}