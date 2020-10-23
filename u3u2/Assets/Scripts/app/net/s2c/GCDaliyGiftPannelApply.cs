
using System;
namespace app.net
{
/**
 * 申请每日签到面板信息结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCDaliyGiftPannelApply :BaseMessage
{
	/** 本月累计签到天数 */
	private int signedNum;
	/** 剩余补签次数 */
	private int restRetroactiveNum;
	/** 是否可用补签(1是2否) */
	private int canUseRetroacte;
	/** 今天是否已经签到(1是2否) */
	private int isAlreadySign;
	/** 本月应该有多少天 */
	private int daysOfMonth;

	public GCDaliyGiftPannelApply ()
	{
	}

	protected override void ReadImpl()
	{
	// 本月累计签到天数
	int _signedNum = ReadInt();
	// 剩余补签次数
	int _restRetroactiveNum = ReadInt();
	// 是否可用补签(1是2否)
	int _canUseRetroacte = ReadInt();
	// 今天是否已经签到(1是2否)
	int _isAlreadySign = ReadInt();
	// 本月应该有多少天
	int _daysOfMonth = ReadInt();


		this.signedNum = _signedNum;
		this.restRetroactiveNum = _restRetroactiveNum;
		this.canUseRetroacte = _canUseRetroacte;
		this.isAlreadySign = _isAlreadySign;
		this.daysOfMonth = _daysOfMonth;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_DALIY_GIFT_PANNEL_APPLY;
	}
	
	public override string getEventType()
	{
		return OnlinegiftGCHandler.GCDaliyGiftPannelApplyEvent;
	}
	

	public int getSignedNum(){
		return signedNum;
	}
		

	public int getRestRetroactiveNum(){
		return restRetroactiveNum;
	}
		

	public int getCanUseRetroacte(){
		return canUseRetroacte;
	}
		

	public int getIsAlreadySign(){
		return isAlreadySign;
	}
		

	public int getDaysOfMonth(){
		return daysOfMonth;
	}
		

}
}