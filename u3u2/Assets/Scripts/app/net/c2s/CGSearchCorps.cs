using System;
using System.IO;
namespace app.net
{

/**
 * 军团列表搜索
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSearchCorps :BaseMessage
{
	
	/** 国家0:全部，1：蜀，2：魏，3：吴 */
	private int country;
	/** 军团名称 */
	private string name;
	
	public CGSearchCorps ()
	{
	}
	
	public CGSearchCorps (
			int country,
			string name )
	{
			this.country = country;
			this.name = name;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 国家0:全部，1：蜀，2：魏，3：吴
	WriteInt(country);
	// 军团名称
	WriteString(name);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_SEARCH_CORPS;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}