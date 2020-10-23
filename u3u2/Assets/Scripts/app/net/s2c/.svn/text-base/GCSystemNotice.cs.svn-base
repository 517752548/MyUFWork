
using System;
namespace app.net
{
/**
 * 系统公告
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCSystemNotice :BaseMessage
{
	/** 消息内容 */
	private string content;
	/** 速度 */
	private short speed;

	public GCSystemNotice ()
	{
	}

	protected override void ReadImpl()
	{
	// 消息内容
	string _content = ReadString();
	// 速度
	short _speed = ReadShort();


		this.content = _content;
		this.speed = _speed;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_SYSTEM_NOTICE;
	}
	
	public override string getEventType()
	{
		return CommonGCHandler.GCSystemNoticeEvent;
	}
	

	public string getContent(){
		return content;
	}
		

	public short getSpeed(){
		return speed;
	}
		

}
}