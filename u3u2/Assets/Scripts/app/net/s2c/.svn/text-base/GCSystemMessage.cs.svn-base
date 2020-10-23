
using System;
namespace app.net
{
/**
 * 系统提示消息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCSystemMessage :BaseMessage
{
	/** 消息内容 */
	private string content;
	/** 消息显示类型 */
	private short showType;

	public GCSystemMessage ()
	{
	}

	protected override void ReadImpl()
	{
	// 消息内容
	string _content = ReadString();
	// 消息显示类型
	short _showType = ReadShort();


		this.content = _content;
		this.showType = _showType;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_SYSTEM_MESSAGE;
	}
	
	public override string getEventType()
	{
		return CommonGCHandler.GCSystemMessageEvent;
	}
	

	public string getContent(){
		return content;
	}
		

	public short getShowType(){
		return showType;
	}
		

}
}