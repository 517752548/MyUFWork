using System;
using System.IO;
namespace app.net
{

/**
 * 玩家充值平台币
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPlayerChargeDiamond :BaseMessage
{
	
	/** 兑换的平台币数量 */
	private int mmCost;
	
	public CGPlayerChargeDiamond ()
	{
	}
	
	public CGPlayerChargeDiamond (
			int mmCost )
	{
			this.mmCost = mmCost;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 兑换的平台币数量
	WriteInt(mmCost);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PLAYER_CHARGE_DIAMOND;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}