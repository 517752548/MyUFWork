
using System;
namespace app.net
{
/**
 * 删除结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCDelMail :BaseMessage
{
	/** 删除结果，1成功，2失败 */
	private int result;

	public GCDelMail ()
	{
	}

	protected override void ReadImpl()
	{
	// 删除结果，1成功，2失败
	int _result = ReadInt();


		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_DEL_MAIL;
	}
	
	public override string getEventType()
	{
		return MailGCHandler.GCDelMailEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}