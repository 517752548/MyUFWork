
using System;
namespace app.net
{
/**
 * 领取奖励成功
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPrizeSuccess :BaseMessage
{
	/** 平台奖励唯一编号 */
	private int uniqueId;
	/** 奖励类型  1 平台奖励还是 2 gm奖励  */
	private int prizeType;
	/** 奖励编号 */
	private string prizeId;

	public GCPrizeSuccess ()
	{
	}

	protected override void ReadImpl()
	{
	// 平台奖励唯一编号
	int _uniqueId = ReadInt();
	// 奖励类型  1 平台奖励还是 2 gm奖励 
	int _prizeType = ReadInt();
	// 奖励编号
	string _prizeId = ReadString();


		this.uniqueId = _uniqueId;
		this.prizeType = _prizeType;
		this.prizeId = _prizeId;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PRIZE_SUCCESS;
	}
	
	public override string getEventType()
	{
		return PrizeGCHandler.GCPrizeSuccessEvent;
	}
	

	public int getUniqueId(){
		return uniqueId;
	}
		

	public int getPrizeType(){
		return prizeType;
	}
		

	public string getPrizeId(){
		return prizeId;
	}
		

}
}