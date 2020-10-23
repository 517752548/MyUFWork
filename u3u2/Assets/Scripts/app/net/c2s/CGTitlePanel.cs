using System;
using System.IO;
namespace app.net
{

/**
 * 申请称号界面
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTitlePanel :BaseMessage
{
	
	
	public CGTitlePanel ()
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
		return (short)MessageType.CG_TITLE_PANEL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}