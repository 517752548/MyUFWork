
using System;
namespace app.net
{
/**
 * 返回当前玩家是否有奖励
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPrizeExist :BaseMessage
{
	/** 判断玩家是否有礼包 */
	private bool exist;

	public GCPrizeExist ()
	{
	}

	protected override void ReadImpl()
	{
	// 判断玩家是否有礼包
	bool _exist = ReadBool();


		this.exist = _exist;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PRIZE_EXIST;
	}
	
	public override string getEventType()
	{
		return PrizeGCHandler.GCPrizeExistEvent;
	}
	

	public bool getExist(){
		return exist;
	}
		

}
}