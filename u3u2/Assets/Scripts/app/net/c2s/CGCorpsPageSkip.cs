using System;
using System.IO;
namespace app.net
{

/**
 * 页面跳转
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpsPageSkip :BaseMessage
{
	
	/** 国家0:全部，1：蜀，2：魏，3：吴 */
	private int country;
	/** 跳转页 */
	private int page;
	
	public CGCorpsPageSkip ()
	{
	}
	
	public CGCorpsPageSkip (
			int country,
			int page )
	{
			this.country = country;
			this.page = page;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 国家0:全部，1：蜀，2：魏，3：吴
	WriteInt(country);
	// 跳转页
	WriteInt(page);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CORPS_PAGE_SKIP;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}