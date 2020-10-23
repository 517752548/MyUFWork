using System;
using System.IO;
namespace app.net
{

/**
 * 修改公告
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpsNoticeUpdate :BaseMessage
{
	
	/** 军团QQ */
	private string qq;
	/** 公告内容 */
	private string notice;
	
	public CGCorpsNoticeUpdate ()
	{
	}
	
	public CGCorpsNoticeUpdate (
			string qq,
			string notice )
	{
			this.qq = qq;
			this.notice = notice;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 军团QQ
	WriteString(qq);
	// 公告内容
	WriteString(notice);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CORPS_NOTICE_UPDATE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}