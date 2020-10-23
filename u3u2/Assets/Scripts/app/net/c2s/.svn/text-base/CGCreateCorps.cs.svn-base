using System;
using System.IO;
namespace app.net
{

/**
 * 创建军团
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCreateCorps :BaseMessage
{
	
	/** 军团名称 */
	private string name;
	/** 军团公告 */
	private string notice;
	
	public CGCreateCorps ()
	{
	}
	
	public CGCreateCorps (
			string name,
			string notice )
	{
			this.name = name;
			this.notice = notice;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 军团名称
	WriteString(name);
	// 军团公告
	WriteString(notice);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CREATE_CORPS;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}