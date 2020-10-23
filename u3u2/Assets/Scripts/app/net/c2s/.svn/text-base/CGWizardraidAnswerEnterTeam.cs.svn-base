using System;
using System.IO;
namespace app.net
{

/**
 * 应答进入组队副本的请求
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGWizardraidAnswerEnterTeam :BaseMessage
{
	
	/** 是否同意进入，0不同意，1同意 */
	private int agree;
	
	public CGWizardraidAnswerEnterTeam ()
	{
	}
	
	public CGWizardraidAnswerEnterTeam (
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
		return (short)MessageType.CG_WIZARDRAID_ANSWER_ENTER_TEAM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}