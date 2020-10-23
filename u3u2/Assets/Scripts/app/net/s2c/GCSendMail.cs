
using System;
namespace app.net
{
/**
 * 发送邮件结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCSendMail :BaseMessage
{
	/** 发送结果，1成功，2失败 */
	private int result;
	/** 错误结果 */
	private string errorMsg;
	/** 邮件标题 */
	private string title;
	/** 邮件内容 */
	private string content;

	public GCSendMail ()
	{
	}

	protected override void ReadImpl()
	{
	// 发送结果，1成功，2失败
	int _result = ReadInt();
	// 错误结果
	string _errorMsg = ReadString();
	// 邮件标题
	string _title = ReadString();
	// 邮件内容
	string _content = ReadString();


		this.result = _result;
		this.errorMsg = _errorMsg;
		this.title = _title;
		this.content = _content;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_SEND_MAIL;
	}
	
	public override string getEventType()
	{
		return MailGCHandler.GCSendMailEvent;
	}
	

	public int getResult(){
		return result;
	}
		

	public string getErrorMsg(){
		return errorMsg;
	}
		

	public string getTitle(){
		return title;
	}
		

	public string getContent(){
		return content;
	}
		

}
}