
using System;
namespace app.net
{
/**
 * 防沉迷登录提示
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWallowLoginNotice :BaseMessage
{
	/** 提示内容 */
	private string noticeContent;

	public GCWallowLoginNotice ()
	{
	}

	protected override void ReadImpl()
	{
	// 提示内容
	string _noticeContent = ReadString();


		this.noticeContent = _noticeContent;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_WALLOW_LOGIN_NOTICE;
	}
	
	public override string getEventType()
	{
		return PlayerGCHandler.GCWallowLoginNoticeEvent;
	}
	

	public string getNoticeContent(){
		return noticeContent;
	}
		

}
}