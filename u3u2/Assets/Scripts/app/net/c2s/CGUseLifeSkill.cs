using System;
using System.IO;
namespace app.net
{

/**
 * 使用生活技能
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGUseLifeSkill :BaseMessage
{
	
	/** 技能Id */
	private int skillId;
	/** 资源点Id */
	private int resourceId;
	
	public CGUseLifeSkill ()
	{
	}
	
	public CGUseLifeSkill (
			int skillId,
			int resourceId )
	{
			this.skillId = skillId;
			this.resourceId = resourceId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 技能Id
	WriteInt(skillId);
	// 资源点Id
	WriteInt(resourceId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_USE_LIFE_SKILL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}