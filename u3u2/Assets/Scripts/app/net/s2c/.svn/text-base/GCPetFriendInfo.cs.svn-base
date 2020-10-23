
using System;
namespace app.net
{
/**
 * 单个伙伴的信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetFriendInfo :BaseMessage
{
	/** 伙伴模板Id */
	private int tplId;
	/** 伙伴等级 */
	private int level;
	/** 属性json */
	private string props;
	/** 技能列表 */
	private PetSkillInfo[] skillList;

	public GCPetFriendInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 伙伴模板Id
	int _tplId = ReadInt();
	// 伙伴等级
	int _level = ReadInt();
	// 属性json
	string _props = ReadString();

	// 技能列表
	int skillListSize = ReadShort();
	PetSkillInfo[] _skillList = new PetSkillInfo[skillListSize];
	int skillListIndex = 0;
	PetSkillInfo _skillListTmp = null;
	for(skillListIndex=0; skillListIndex<skillListSize; skillListIndex++){
		_skillListTmp = new PetSkillInfo();
		_skillList[skillListIndex] = _skillListTmp;
	// 技能Id
	int _skillList_skillId = ReadInt();	_skillListTmp.skillId = _skillList_skillId;
		// 技能等级
	int _skillList_level = ReadInt();	_skillListTmp.level = _skillList_level;
		// 技能消耗
	int _skillList_skillCost = ReadInt();	_skillListTmp.skillCost = _skillList_skillCost;
	
	// 技能镶嵌的效果列表
	int skillList_embedSkillEffectListSize = ReadShort();
	PetSkillEffectInfo[] _skillList_embedSkillEffectList = new PetSkillEffectInfo[skillList_embedSkillEffectListSize];
	int skillList_embedSkillEffectListIndex = 0;
	PetSkillEffectInfo _skillList_embedSkillEffectListTmp = null;
	for(skillList_embedSkillEffectListIndex=0; skillList_embedSkillEffectListIndex<skillList_embedSkillEffectListSize; skillList_embedSkillEffectListIndex++){
		_skillList_embedSkillEffectListTmp = new PetSkillEffectInfo();
		_skillList_embedSkillEffectList[skillList_embedSkillEffectListIndex] = _skillList_embedSkillEffectListTmp;
	// 技能效果道具Id
	int _skillList_embedSkillEffectList_effectItemId = ReadInt();	_skillList_embedSkillEffectListTmp.effectItemId = _skillList_embedSkillEffectList_effectItemId;
		// 技能效果等级
	int _skillList_embedSkillEffectList_level = ReadInt();	_skillList_embedSkillEffectListTmp.level = _skillList_embedSkillEffectList_level;
		// 技能效果经验
	int _skillList_embedSkillEffectList_exp = ReadInt();	_skillList_embedSkillEffectListTmp.exp = _skillList_embedSkillEffectList_exp;
		}
	//end
	_skillListTmp.embedSkillEffectList = _skillList_embedSkillEffectList;
		// 层数
	int _skillList_layer = ReadInt();	_skillListTmp.layer = _skillList_layer;
		// 熟练度
	long _skillList_proficiency = ReadLong();	_skillListTmp.proficiency = _skillList_proficiency;
		}
	//end



		this.tplId = _tplId;
		this.level = _level;
		this.props = _props;
		this.skillList = _skillList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PET_FRIEND_INFO;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetFriendInfoEvent;
	}
	

	public int getTplId(){
		return tplId;
	}
		

	public int getLevel(){
		return level;
	}
		

	public string getProps(){
		return props;
	}
		

	public PetSkillInfo[] getSkillList(){
		return skillList;
	}


}
}