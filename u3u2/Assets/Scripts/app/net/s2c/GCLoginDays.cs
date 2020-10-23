
using System;
namespace app.net
{
/**
 * 玩家登录天数
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCLoginDays :BaseMessage
{
	/** 天数 */
	private int day;

	public GCLoginDays ()
	{
	}

	protected override void ReadImpl()
	{
	// 天数
	int _day = ReadInt();


		this.day = _day;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_LOGIN_DAYS;
	}
	
	public override string getEventType()
	{
		return HumanGCHandler.GCLoginDaysEvent;
	}
	

	public int getDay(){
		return day;
	}
		

}
}