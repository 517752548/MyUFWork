using System;
using System.IO;
namespace app.net
{

/**
 * 打开军团成员列表
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOpenCorpsMemberList :BaseMessage
{
	
	
	public CGOpenCorpsMemberList ()
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
		return (short)MessageType.CG_OPEN_CORPS_MEMBER_LIST;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}