
using System;
namespace app.net
{
/**
 * 兑换成功
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPlayerChargeDiamond :BaseMessage
{
	/** 平台币余额 */
	private int mmBalance;

	public GCPlayerChargeDiamond ()
	{
	}

	protected override void ReadImpl()
	{
	// 平台币余额
	int _mmBalance = ReadInt();


		this.mmBalance = _mmBalance;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PLAYER_CHARGE_DIAMOND;
	}
	
	public override string getEventType()
	{
		return PlayerGCHandler.GCPlayerChargeDiamondEvent;
	}
	

	public int getMmBalance(){
		return mmBalance;
	}
		

}
}