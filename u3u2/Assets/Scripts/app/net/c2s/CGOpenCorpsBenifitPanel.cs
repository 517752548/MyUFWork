using System;
using System.IO;
namespace app.net
{

/**
 * 打开帮派福利面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOpenCorpsBenifitPanel :BaseMessage
{
	
	
	public CGOpenCorpsBenifitPanel ()
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
		return (short)MessageType.CG_OPEN_CORPS_BENIFIT_PANEL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}