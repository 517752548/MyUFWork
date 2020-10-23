
using System;
namespace app.net
{
/**
 * 购买体力tips信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBuyPowerTips :BaseMessage
{
	/** 购买体力tips信息 */
	private string tips;

	public GCBuyPowerTips ()
	{
	}

	protected override void ReadImpl()
	{
	// 购买体力tips信息
	string _tips = ReadString();


		this.tips = _tips;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_BUY_POWER_TIPS;
	}
	
	public override string getEventType()
	{
		return HumanGCHandler.GCBuyPowerTipsEvent;
	}
	

	public string getTips(){
		return tips;
	}
		

}
}