using System;
using System.IO;
namespace app.net
{

/**
 * 请求下一轮战斗
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBattleNextRound :BaseMessage
{
	
	/** 是否自动战斗，0否，1是 */
	private int isAuto;
	/** 玩家选择的技能Id */
	private int selSkillId;
	/** 玩家选择的技能目标 */
	private int selTarget;
	/** 玩家选择的道具Id */
	private int selItemId;
	/** 宠物选择的技能Id */
	private int petSelSkillId;
	/** 宠物选择的技能目标 */
	private int petSelTarget;
	/** 宠物选择的道具Id */
	private int petSelItemId;
	/** 召唤宠物Id */
	private long summonPetId;
	
	public CGBattleNextRound ()
	{
	}
	
	public CGBattleNextRound (
			int isAuto,
			int selSkillId,
			int selTarget,
			int selItemId,
			int petSelSkillId,
			int petSelTarget,
			int petSelItemId,
			long summonPetId )
	{
			this.isAuto = isAuto;
			this.selSkillId = selSkillId;
			this.selTarget = selTarget;
			this.selItemId = selItemId;
			this.petSelSkillId = petSelSkillId;
			this.petSelTarget = petSelTarget;
			this.petSelItemId = petSelItemId;
			this.summonPetId = summonPetId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 是否自动战斗，0否，1是
	WriteInt(isAuto);
	// 玩家选择的技能Id
	WriteInt(selSkillId);
	// 玩家选择的技能目标
	WriteInt(selTarget);
	// 玩家选择的道具Id
	WriteInt(selItemId);
	// 宠物选择的技能Id
	WriteInt(petSelSkillId);
	// 宠物选择的技能目标
	WriteInt(petSelTarget);
	// 宠物选择的道具Id
	WriteInt(petSelItemId);
	// 召唤宠物Id
	WriteLong(summonPetId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_BATTLE_NEXT_ROUND;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}