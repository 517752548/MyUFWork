using System;
using System.IO;
namespace app.net
{

/**
 * 生成充值订单Id
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGChargeGenOrderid :BaseMessage
{
	
	/** 渠道号 */
	private string channelCode;
	/** 渠道附加值 */
	private string channelExt;
	
	public CGChargeGenOrderid ()
	{
	}
	
	public CGChargeGenOrderid (
			string channelCode,
			string channelExt )
	{
			this.channelCode = channelCode;
			this.channelExt = channelExt;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 渠道号
	WriteString(channelCode);
	// 渠道附加值
	WriteString(channelExt);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CHARGE_GEN_ORDERID;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}