using System;
using System.IO;
namespace app.net
{

/**
 * 一键申请
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpsQuickApply :BaseMessage
{
	
	/** 请求的页数 */
	private int page;
	
	public CGCorpsQuickApply ()
	{
	}
	
	public CGCorpsQuickApply (
			int page )
	{
			this.page = page;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 请求的页数
	WriteInt(page);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CORPS_QUICK_APPLY;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}