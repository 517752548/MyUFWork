using System;
using System.IO;
namespace app.net
{

/**
 * 更新自动战斗
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBattleUpdateAutoAction :BaseMessage
{
	
	/** 武将类型，1主将，2宠物 */
	private int petTypeId;
	/** 技能Id */
	private int selSkillId;
	
	public CGBattleUpdateAutoAction ()
	{
	}
	
	public CGBattleUpdateAutoAction (
			int petTypeId,
			int selSkillId )
	{
			this.petTypeId = petTypeId;
			this.selSkillId = selSkillId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 武将类型，1主将，2宠物
	WriteInt(petTypeId);
	// 技能Id
	WriteInt(selSkillId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_BATTLE_UPDATE_AUTO_ACTION;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}