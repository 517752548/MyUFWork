
using System;
namespace app.net
{
/**
 * 主将技能仙符升级结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetSkillEffectUplevel :BaseMessage
{
	/** 技能Id */
	private int skillId;
	/** 要升级的位置，从1开始计数 */
	private int posId;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCPetSkillEffectUplevel ()
	{
	}

	protected override void ReadImpl()
	{
	// 技能Id
	int _skillId = ReadInt();
	// 要升级的位置，从1开始计数
	int _posId = ReadInt();
	// 操作结果，1成功，2失败
	int _result = ReadInt();


		this.skillId = _skillId;
		this.posId = _posId;
		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PET_SKILL_EFFECT_UPLEVEL;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetSkillEffectUplevelEvent;
	}
	

	public int getSkillId(){
		return skillId;
	}
		

	public int getPosId(){
		return posId;
	}
		

	public int getResult(){
		return result;
	}
		

}
}