using System;
using System.IO;
namespace app.net
{

/**
 * 购买月卡
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBuyMonthCard :BaseMessage
{
	
	/** 月卡模板Id */
	private int tplId;
	
	public CGBuyMonthCard ()
	{
	}
	
	public CGBuyMonthCard (
			int tplId )
	{
			this.tplId = tplId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 月卡模板Id
	WriteInt(tplId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_BUY_MONTH_CARD;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}