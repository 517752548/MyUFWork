using System;
using System.IO;
namespace app.net
{

/**
 * 应答挑战帮派boss的请求
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpsbossAnswerEnterTeam :BaseMessage
{
	
	/** 是否同意进入，0不同意，1同意 */
	private int agree;
	
	public CGCorpsbossAnswerEnterTeam ()
	{
	}
	
	public CGCorpsbossAnswerEnterTeam (
			int agree )
	{
			this.agree = agree;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 是否同意进入，0不同意，1同意
	WriteInt(agree);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CORPSBOSS_ANSWER_ENTER_TEAM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}