
using System;
namespace app.net
{
/**
 * 查询账户余额的结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPlayerQueryAccount :BaseMessage
{
	/** MM余额 */
	private int mmBalance;

	public GCPlayerQueryAccount ()
	{
	}

	protected override void ReadImpl()
	{
	// MM余额
	int _mmBalance = ReadInt();


		this.mmBalance = _mmBalance;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PLAYER_QUERY_ACCOUNT;
	}
	
	public override string getEventType()
	{
		return PlayerGCHandler.GCPlayerQueryAccountEvent;
	}
	

	public int getMmBalance(){
		return mmBalance;
	}
		

}
}