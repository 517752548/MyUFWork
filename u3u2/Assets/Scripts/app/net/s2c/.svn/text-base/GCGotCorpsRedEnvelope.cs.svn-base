
using System;
namespace app.net
{
/**
 * 返回请求领取帮派红包
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGotCorpsRedEnvelope :BaseMessage
{
	/** 要领取红包的uuid */
	private string uuid;
	/** 结果,1成功,2失败 */
	private int result;
	/** 领取的金额 */
	private int gotBonus;

	public GCGotCorpsRedEnvelope ()
	{
	}

	protected override void ReadImpl()
	{
	// 要领取红包的uuid
	string _uuid = ReadString();
	// 结果,1成功,2失败
	int _result = ReadInt();
	// 领取的金额
	int _gotBonus = ReadInt();


		this.uuid = _uuid;
		this.result = _result;
		this.gotBonus = _gotBonus;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_GOT_CORPS_RED_ENVELOPE;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCGotCorpsRedEnvelopeEvent;
	}
	

	public string getUuid(){
		return uuid;
	}
		

	public int getResult(){
		return result;
	}
		

	public int getGotBonus(){
		return gotBonus;
	}
		

}
}