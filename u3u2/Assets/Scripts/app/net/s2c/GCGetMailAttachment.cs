
using System;
namespace app.net
{
/**
 * 领取邮件附件结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGetMailAttachment :BaseMessage
{
	/** 结果 */
	private int result;

	public GCGetMailAttachment ()
	{
	}

	protected override void ReadImpl()
	{
	// 结果
	int _result = ReadInt();


		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_GET_MAIL_ATTACHMENT;
	}
	
	public override string getEventType()
	{
		return MailGCHandler.GCGetMailAttachmentEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}