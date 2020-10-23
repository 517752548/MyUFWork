using System;
using System.IO;
namespace app.net
{

/**
 * 请求打开帮派修炼技能面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOpenCorpsCultivatePanel :BaseMessage
{
	
	
	public CGOpenCorpsCultivatePanel ()
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
		return (short)MessageType.CG_OPEN_CORPS_CULTIVATE_PANEL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}