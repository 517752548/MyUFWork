
using System;
namespace app.net
{
/**
 * 主将技能镶嵌仙符信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetSkillEffectUpdate :BaseMessage
{
	/** 技能Id */
	private int skillId;
	/** 技能镶嵌的效果列表，效果id为0表示空格子 */
	private PetSkillEffectInfo[] embedSkillEffectList;

	public GCPetSkillEffectUpdate ()
	{
	}

	protected override void ReadImpl()
	{
	// 技能Id
	int _skillId = ReadInt();

	// 技能镶嵌的效果列表，效果id为0表示空格子
	int embedSkillEffectListSize = ReadShort();
	PetSkillEffectInfo[] _embedSkillEffectList = new PetSkillEffectInfo[embedSkillEffectListSize];
	int embedSkillEffectListIndex = 0;
	PetSkillEffectInfo _embedSkillEffectListTmp = null;
	for(embedSkillEffectListIndex=0; embedSkillEffectListIndex<embedSkillEffectListSize; embedSkillEffectListIndex++){
		_embedSkillEffectListTmp = new PetSkillEffectInfo();
		_embedSkillEffectList[embedSkillEffectListIndex] = _embedSkillEffectListTmp;
	// 技能效果道具Id
	int _embedSkillEffectList_effectItemId = ReadInt();	_embedSkillEffectListTmp.effectItemId = _embedSkillEffectList_effectItemId;
		// 技能效果等级
	int _embedSkillEffectList_level = ReadInt();	_embedSkillEffectListTmp.level = _embedSkillEffectList_level;
		// 技能效果经验
	int _embedSkillEffectList_exp = ReadInt();	_embedSkillEffectListTmp.exp = _embedSkillEffectList_exp;
		}
	//end



		this.skillId = _skillId;
		this.embedSkillEffectList = _embedSkillEffectList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PET_SKILL_EFFECT_UPDATE;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetSkillEffectUpdateEvent;
	}
	

	public int getSkillId(){
		return skillId;
	}
		

	public PetSkillEffectInfo[] getEmbedSkillEffectList(){
		return embedSkillEffectList;
	}


}
}