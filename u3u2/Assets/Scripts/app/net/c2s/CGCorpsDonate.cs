using System;
using System.IO;
namespace app.net
{

/**
 * 军团捐献
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpsDonate :BaseMessage
{
	
	/** 捐献数量 */
	private int num;
	
	public CGCorpsDonate ()
	{
	}
	
	public CGCorpsDonate (
			int num )
	{
			this.num = num;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 捐献数量
	WriteInt(num);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CORPS_DONATE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}