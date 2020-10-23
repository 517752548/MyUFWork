using System;
using System.IO;
namespace app.net
{

/**
 * 领取奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPrizeGet :BaseMessage
{
	
	/** 平台奖励唯一编号 */
	private int uniqueId;
	/** 奖励类型  1 平台奖励; 2 gm奖励  */
	private int prizeType;
	/** 奖励编号 */
	private string prizeId;
	
	public CGPrizeGet ()
	{
	}
	
	public CGPrizeGet (
			int uniqueId,
			int prizeType,
			string prizeId )
	{
			this.uniqueId = uniqueId;
			this.prizeType = prizeType;
			this.prizeId = prizeId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 平台奖励唯一编号
	WriteInt(uniqueId);
	// 奖励类型  1 平台奖励; 2 gm奖励 
	WriteInt(prizeType);
	// 奖励编号
	WriteString(prizeId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PRIZE_GET;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}