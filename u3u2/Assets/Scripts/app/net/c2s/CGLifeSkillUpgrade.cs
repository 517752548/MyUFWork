using System;
using System.IO;
namespace app.net
{

/**
 * 生活技能升级
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGLifeSkillUpgrade :BaseMessage
{
	
	/** 技能书道具Id */
	private int itemId;
	
	public CGLifeSkillUpgrade ()
	{
	}
	
	public CGLifeSkillUpgrade (
			int itemId )
	{
			this.itemId = itemId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 技能书道具Id
	WriteInt(itemId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_LIFE_SKILL_UPGRADE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}