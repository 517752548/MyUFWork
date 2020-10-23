using System;
using System.IO;
namespace app.net
{

/**
 * 主将技能镶嵌仙符或更换仙符
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetEmbedSkillEffect :BaseMessage
{
	
	/** 技能Id */
	private int skillId;
	/** 镶嵌位置，从1开始计数 */
	private int posId;
	/** 要镶嵌的技能书道具索引 */
	private int itemIndex;
	
	public CGPetEmbedSkillEffect ()
	{
	}
	
	public CGPetEmbedSkillEffect (
			int skillId,
			int posId,
			int itemIndex )
	{
			this.skillId = skillId;
			this.posId = posId;
			this.itemIndex = itemIndex;
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
	// 要镶嵌的技能书道具索引
	WriteInt(itemIndex);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_EMBED_SKILL_EFFECT;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}