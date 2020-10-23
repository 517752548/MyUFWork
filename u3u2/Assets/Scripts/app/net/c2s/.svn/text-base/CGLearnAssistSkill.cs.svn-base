using System;
using System.IO;
namespace app.net
{

/**
 * 请求学习辅助技能
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGLearnAssistSkill :BaseMessage
{
	
	/** 技能Id */
	private int skillId;
	
	public CGLearnAssistSkill ()
	{
	}
	
	public CGLearnAssistSkill (
			int skillId )
	{
			this.skillId = skillId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 技能Id
	WriteInt(skillId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_LEARN_ASSIST_SKILL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}