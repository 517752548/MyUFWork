using System;
using System.IO;
namespace app.net
{

/**
 * 选择确认小信封
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGClickNoticeTipsInfo :BaseMessage
{
	
	/** 操作标识 */
	private string tag;
	/** 选项值 */
	private string value;
	
	public CGClickNoticeTipsInfo ()
	{
	}
	
	public CGClickNoticeTipsInfo (
			string tag,
			string value )
	{
			this.tag = tag;
			this.value = value;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 操作标识
	WriteString(tag);
	// 选项值
	WriteString(value);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CLICK_NOTICE_TIPS_INFO;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}