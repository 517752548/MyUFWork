
using System;
namespace app.net
{
/**
 * 返回单个武将信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetInfo :BaseMessage
{
	/** 返回武将信息 */
	private PetInfo petInfo;

	public GCPetInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 返回武将信息
	PetInfo _petInfo = new PetInfo();
	// 武將ID
	long _petInfo_petId = ReadLong();	_petInfo.petId = _petInfo_petId;
	// 武將模版ID
	int _petInfo_tplId = ReadInt();	_petInfo.tplId = _petInfo_tplId;
	// 武将品质
	int _petInfo_colorId = ReadInt();	_petInfo.colorId = _petInfo_colorId;
	// 武将星级
	int _petInfo_star = ReadInt();	_petInfo.star = _petInfo_star;
	// 武将等级
	int _petInfo_level = ReadInt();	_petInfo.level = _petInfo_level;
	// 武將经验
	long _petInfo_exp = ReadLong();	_petInfo.exp = _petInfo_exp;
	// 武將类型，1主将，2宠物，3伙伴
	int _petInfo_petType = ReadInt();	_petInfo.petType = _petInfo_petType;

	// 武将技能列表
	int petInfo_skillListSize = ReadShort();
	PetSkillInfo[] _petInfo_skillList = new PetSkillInfo[petInfo_skillListSize];
	int petInfo_skillListIndex = 0;
	PetSkillInfo _petInfo_skillListTmp = null;
	for(petInfo_skillListIndex=0; petInfo_skillListIndex<petInfo_skillListSize; petInfo_skillListIndex++){
		_petInfo_skillListTmp = new PetSkillInfo();
		_petInfo_skillList[petInfo_skillListIndex] = _petInfo_skillListTmp;
	// 技能Id
	int _petInfo_skillList_skillId = ReadInt();	_petInfo_skillListTmp.skillId = _petInfo_skillList_skillId;
		// 技能等级
	int _petInfo_skillList_level = ReadInt();	_petInfo_skillListTmp.level = _petInfo_skillList_level;
		// 技能消耗
	int _petInfo_skillList_skillCost = ReadInt();	_petInfo_skillListTmp.skillCost = _petInfo_skillList_skillCost;
	
	// 技能镶嵌的效果列表
	int petInfo_skillList_embedSkillEffectListSize = ReadShort();
	PetSkillEffectInfo[] _petInfo_skillList_embedSkillEffectList = new PetSkillEffectInfo[petInfo_skillList_embedSkillEffectListSize];
	int petInfo_skillList_embedSkillEffectListIndex = 0;
	PetSkillEffectInfo _petInfo_skillList_embedSkillEffectListTmp = null;
	for(petInfo_skillList_embedSkillEffectListIndex=0; petInfo_skillList_embedSkillEffectListIndex<petInfo_skillList_embedSkillEffectListSize; petInfo_skillList_embedSkillEffectListIndex++){
		_petInfo_skillList_embedSkillEffectListTmp = new PetSkillEffectInfo();
		_petInfo_skillList_embedSkillEffectList[petInfo_skillList_embedSkillEffectListIndex] = _petInfo_skillList_embedSkillEffectListTmp;
	// 技能效果道具Id
	int _petInfo_skillList_embedSkillEffectList_effectItemId = ReadInt();	_petInfo_skillList_embedSkillEffectListTmp.effectItemId = _petInfo_skillList_embedSkillEffectList_effectItemId;
		// 技能效果等级
	int _petInfo_skillList_embedSkillEffectList_level = ReadInt();	_petInfo_skillList_embedSkillEffectListTmp.level = _petInfo_skillList_embedSkillEffectList_level;
		// 技能效果经验
	int _petInfo_skillList_embedSkillEffectList_exp = ReadInt();	_petInfo_skillList_embedSkillEffectListTmp.exp = _petInfo_skillList_embedSkillEffectList_exp;
		}
	//end
	_petInfo_skillListTmp.embedSkillEffectList = _petInfo_skillList_embedSkillEffectList;
		// 层数
	int _petInfo_skillList_layer = ReadInt();	_petInfo_skillListTmp.layer = _petInfo_skillList_layer;
		// 熟练度
	long _petInfo_skillList_proficiency = ReadLong();	_petInfo_skillListTmp.proficiency = _petInfo_skillList_proficiency;
		}
	//end
	_petInfo.skillList = _petInfo_skillList;
	// 一级属性附加值
	int petInfo_aPropAddArrSize = ReadShort();
	int[] _petInfo_aPropAddArr = new int[petInfo_aPropAddArrSize];
	int petInfo_aPropAddArrIndex = 0;
	for(petInfo_aPropAddArrIndex=0; petInfo_aPropAddArrIndex<petInfo_aPropAddArrSize; petInfo_aPropAddArrIndex++){
		_petInfo_aPropAddArr[petInfo_aPropAddArrIndex] = ReadInt();
	}//end
		_petInfo.aPropAddArr = _petInfo_aPropAddArr;
	// 装备位星级
	int petInfo_aEquipStarSize = ReadShort();
	int[] _petInfo_aEquipStar = new int[petInfo_aEquipStarSize];
	int petInfo_aEquipStarIndex = 0;
	for(petInfo_aEquipStarIndex=0; petInfo_aEquipStarIndex<petInfo_aEquipStarSize; petInfo_aEquipStarIndex++){
		_petInfo_aEquipStar[petInfo_aEquipStarIndex] = ReadInt();
	}//end
		_petInfo.aEquipStar = _petInfo_aEquipStar;
	// 宠物培养增加属性
	int petInfo_trainPropArrSize = ReadShort();
	int[] _petInfo_trainPropArr = new int[petInfo_trainPropArrSize];
	int petInfo_trainPropArrIndex = 0;
	for(petInfo_trainPropArrIndex=0; petInfo_trainPropArrIndex<petInfo_trainPropArrSize; petInfo_trainPropArrIndex++){
		_petInfo_trainPropArr[petInfo_trainPropArrIndex] = ReadInt();
	}//end
		_petInfo.trainPropArr = _petInfo_trainPropArr;
	// 宠物培养临时属性
	int petInfo_trainTmpPropArrSize = ReadShort();
	int[] _petInfo_trainTmpPropArr = new int[petInfo_trainTmpPropArrSize];
	int petInfo_trainTmpPropArrIndex = 0;
	for(petInfo_trainTmpPropArrIndex=0; petInfo_trainTmpPropArrIndex<petInfo_trainTmpPropArrSize; petInfo_trainTmpPropArrIndex++){
		_petInfo_trainTmpPropArr[petInfo_trainTmpPropArrIndex] = ReadInt();
	}//end
		_petInfo.trainTmpPropArr = _petInfo_trainTmpPropArr;
	// 宠物培养上限值
	int _petInfo_trainMax = ReadInt();	_petInfo.trainMax = _petInfo_trainMax;
	// 宠物培评分
	int _petInfo_petScore = ReadInt();	_petInfo.petScore = _petInfo_petScore;
	// 宠物技能栏数量
	int _petInfo_petSkillBarNum = ReadInt();	_petInfo.petSkillBarNum = _petInfo_petSkillBarNum;
	// 宠物资质丹索引
	int petInfo_propItemIndexSize = ReadShort();
	int[] _petInfo_propItemIndex = new int[petInfo_propItemIndexSize];
	int petInfo_propItemIndexIndex = 0;
	for(petInfo_propItemIndexIndex=0; petInfo_propItemIndexIndex<petInfo_propItemIndexSize; petInfo_propItemIndexIndex++){
		_petInfo_propItemIndex[petInfo_propItemIndexIndex] = ReadInt();
	}//end
		_petInfo.propItemIndex = _petInfo_propItemIndex;

	// 技能快捷栏信息
	int petInfo_shortcutListSize = ReadShort();
	PetSkillShortcutInfo[] _petInfo_shortcutList = new PetSkillShortcutInfo[petInfo_shortcutListSize];
	int petInfo_shortcutListIndex = 0;
	PetSkillShortcutInfo _petInfo_shortcutListTmp = null;
	for(petInfo_shortcutListIndex=0; petInfo_shortcutListIndex<petInfo_shortcutListSize; petInfo_shortcutListIndex++){
		_petInfo_shortcutListTmp = new PetSkillShortcutInfo();
		_petInfo_shortcutList[petInfo_shortcutListIndex] = _petInfo_shortcutListTmp;
	// 快捷栏索引, 默认为-1
	int _petInfo_shortcutList_shortcutIndex = ReadInt();	_petInfo_shortcutListTmp.shortcutIndex = _petInfo_shortcutList_shortcutIndex;
		// 技能Id
	int _petInfo_shortcutList_skillId = ReadInt();	_petInfo_shortcutListTmp.skillId = _petInfo_shortcutList_skillId;
		}
	//end
	_petInfo.shortcutList = _petInfo_shortcutList;
	// 灵魂链接骑宠ID, 0-无灵魂链接
	long _petInfo_soulLinkPetHorseId = ReadLong();	_petInfo.soulLinkPetHorseId = _petInfo_soulLinkPetHorseId;



		this.petInfo = _petInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PET_INFO;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetInfoEvent;
	}
	

	public PetInfo getPetInfo(){
		return petInfo;
	}
		

}
}