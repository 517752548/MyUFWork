using System;
using System.IO;
namespace app.net
{

/**
 * 请求成长任务列表
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCommonQuestList :BaseMessage
{
	
	
	public CGCommonQuestList ()
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
		return (short)MessageType.CG_COMMON_QUEST_LIST;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}