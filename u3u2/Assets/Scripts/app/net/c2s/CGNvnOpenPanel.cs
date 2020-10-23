using System;
using System.IO;
namespace app.net
{

/**
 * 请求nvn面板信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGNvnOpenPanel :BaseMessage
{
	
	
	public CGNvnOpenPanel ()
	{
	}
	
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_NVN_OPEN_PANEL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}