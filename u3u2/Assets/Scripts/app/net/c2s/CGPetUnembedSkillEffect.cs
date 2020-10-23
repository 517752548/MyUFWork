using System;
using System.IO;
namespace app.net
{

/**
 * 主将技能卸下仙符
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetUnembedSkillEffect :BaseMessage
{
	
	/** 技能Id */
	private int skillId;
	/** 镶嵌位置，从1开始计数 */
	private int posId;
	
	public CGPetUnembedSkillEffect ()
	{
	}
	
	public CGPetUnembedSkillEffect (
			int skillId,
			int posId )
	{
			this.skillId = skillId;
			this.posId = posId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 技能Id
	WriteInt(skillId);
	// 镶嵌位置，从1开始计数
	WriteInt(posId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_UNEMBED_SKILL_EFFECT;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}