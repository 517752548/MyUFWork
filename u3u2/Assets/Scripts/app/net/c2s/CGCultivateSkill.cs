using System;
using System.IO;
namespace app.net
{

/**
 * 请求修炼技能
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCultivateSkill :BaseMessage
{
	
	/** 技能Id */
	private int skillId;
	/** 修炼方式是否批量,0-否,1-是 */
	private int isBatch;
	
	public CGCultivateSkill ()
	{
	}
	
	public CGCultivateSkill (
			int skillId,
			int isBatch )
	{
			this.skillId = skillId;
			this.isBatch = isBatch;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 技能Id
	WriteInt(skillId);
	// 修炼方式是否批量,0-否,1-是
	WriteInt(isBatch);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CULTIVATE_SKILL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}