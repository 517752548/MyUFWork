
using System;
namespace app.net
{
/**
 * 结婚相关信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMarryInfo :BaseMessage
{
	/** 丈夫 */
	private long husband;
	/** 丈夫 */
	private string husbandName;
	/** 妻子 */
	private long wife;
	/** 妻子 */
	private string wifeName;

	public GCMarryInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 丈夫
	long _husband = ReadLong();
	// 丈夫
	string _husbandName = ReadString();
	// 妻子
	long _wife = ReadLong();
	// 妻子
	string _wifeName = ReadString();


		this.husband = _husband;
		this.husbandName = _husbandName;
		this.wife = _wife;
		this.wifeName = _wifeName;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_MARRY_INFO;
	}
	
	public override string getEventType()
	{
		return MarryGCHandler.GCMarryInfoEvent;
	}
	

	public long getHusband(){
		return husband;
	}
		

	public string getHusbandName(){
		return husbandName;
	}
		

	public long getWife(){
		return wife;
	}
		

	public string getWifeName(){
		return wifeName;
	}
		

}
}