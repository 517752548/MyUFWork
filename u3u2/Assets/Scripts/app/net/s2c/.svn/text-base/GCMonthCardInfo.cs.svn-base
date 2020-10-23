
using System;
namespace app.net
{
/**
 * 返回月卡信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMonthCardInfo :BaseMessage
{
	/** 是否已购买月卡 */
	private bool monthFlag;
	/** 是否已领取返利 */
	private bool giftFlag;
	/** 剩余天数 */
	private int leftDay;

	public GCMonthCardInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 是否已购买月卡
	bool _monthFlag = ReadBool();
	// 是否已领取返利
	bool _giftFlag = ReadBool();
	// 剩余天数
	int _leftDay = ReadInt();


		this.monthFlag = _monthFlag;
		this.giftFlag = _giftFlag;
		this.leftDay = _leftDay;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_MONTH_CARD_INFO;
	}
	
	public override string getEventType()
	{
		return HumanGCHandler.GCMonthCardInfoEvent;
	}
	

	public bool getMonthFlag(){
		return monthFlag;
	}
		

	public bool getGiftFlag(){
		return giftFlag;
	}
		

	public int getLeftDay(){
		return leftDay;
	}
		

}
}