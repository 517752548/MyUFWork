
using System;
namespace app.net
{
/**
 * 正在使用称号
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCUsrTitle :BaseMessage
{
	/** 称号的模版id */
	private int titleTemplateId;

	public GCUsrTitle ()
	{
	}

	protected override void ReadImpl()
	{
	// 称号的模版id
	int _titleTemplateId = ReadInt();


		this.titleTemplateId = _titleTemplateId;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_USR_TITLE;
	}
	
	public override string getEventType()
	{
		return TitleGCHandler.GCUsrTitleEvent;
	}
	

	public int getTitleTemplateId(){
		return titleTemplateId;
	}
		

}
}