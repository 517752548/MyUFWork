
using System;
namespace app.net
{
/**
 * 返回武将列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetList :BaseMessage
{
	/** 返回武将列表 */
	private PetInfo[] petInfoList;

	public GCPetList ()
	{
	}

	protected override void ReadImpl()
	{

	// 返回武将列表
	int petInfoListSize = ReadShort();
	PetInfo[] _petInfoList = new PetInfo[petInfoListSize];
	int petInfoListIndex = 0;
	PetInfo _petInfoListTmp = null;
	for(petInfoListIndex=0; petInfoListIndex<petInfoListSize; petInfoListIndex++){
		_petInfoListTmp = new PetInfo();
		_petInfoList[petInfoListIndex] = _petInfoListTmp;
	// 武將ID
	long _petInfoList_petId = ReadLong();	_petInfoListTmp.petId = _petInfoList_petId;
		// 武將模版ID
	int _petInfoList_tplId = ReadInt();	_petInfoListTmp.tplId = _petInfoList_tplId;
		// 武将品质
	int _petInfoList_colorId = ReadInt();	_petInfoListTmp.colorId = _petInfoList_colorId;
		// 武将星级
	int _petInfoList_star = ReadInt();	_petInfoListTmp.star = _petInfoList_star;
		// 武将等级
	int _petInfoList_level = ReadInt();	_petInfoListTmp.level = _petInfoList_level;
		// 武將经验
	long _petInfoList_exp = ReadLong();	_petInfoListTmp.exp = _petInfoList_exp;
		// 武將类型，1主将，2宠物，3伙伴
	int _petInfoList_petType = ReadInt();	_petInfoListTmp.petType = _petInfoList_petType;
	
	// 武将技能列表
	int petInfoList_skillListSize = ReadShort();
	PetSkillInfo[] _petInfoList_skillList = new PetSkillInfo[petInfoList_skillListSize];
	int petInfoList_skillListIndex = 0;
	PetSkillInfo _petInfoList_skillListTmp = null;
	for(petInfoList_skillListIndex=0; petInfoList_skillListIndex<petInfoList_skillListSize; petInfoList_skillListIndex++){
		_petInfoList_skillListTmp = new PetSkillInfo();
		_petInfoList_skillList[petInfoList_skillListIndex] = _petInfoList_skillListTmp;
	// 技能Id
	int _petInfoList_skillList_skillId = ReadInt();	_petInfoList_skillListTmp.skillId = _petInfoList_skillList_skillId;
		// 技能等级
	int _petInfoList_skillList_level = ReadInt();	_petInfoList_skillListTmp.level = _petInfoList_skillList_level;
		// 技能消耗
	int _petInfoList_skillList_skillCost = ReadInt();	_petInfoList_skillListTmp.skillCost = _petInfoList_skillList_skillCost;
	
	// 技能镶嵌的效果列表
	int petInfoList_skillList_embedSkillEffectListSize = ReadShort();
	PetSkillEffectInfo[] _petInfoList_skillList_embedSkillEffectList = new PetSkillEffectInfo[petInfoList_skillList_embedSkillEffectListSize];
	int petInfoList_skillList_embedSkillEffectListIndex = 0;
	PetSkillEffectInfo _petInfoList_skillList_embedSkillEffectListTmp = null;
	for(petInfoList_skillList_embedSkillEffectListIndex=0; petInfoList_skillList_embedSkillEffectListIndex<petInfoList_skillList_embedSkillEffectListSize; petInfoList_skillList_embedSkillEffectListIndex++){
		_petInfoList_skillList_embedSkillEffectListTmp = new PetSkillEffectInfo();
		_petInfoList_skillList_embedSkillEffectList[petInfoList_skillList_embedSkillEffectListIndex] = _petInfoList_skillList_embedSkillEffectListTmp;
	// 技能效果道具Id
	int _petInfoList_skillList_embedSkillEffectList_effectItemId = ReadInt();	_petInfoList_skillList_embedSkillEffectListTmp.effectItemId = _petInfoList_skillList_embedSkillEffectList_effectItemId;
		// 技能效果等级
	int _petInfoList_skillList_embedSkillEffectList_level = ReadInt();	_petInfoList_skillList_embedSkillEffectListTmp.level = _petInfoList_skillList_embedSkillEffectList_level;
		// 技能效果经验
	int _petInfoList_skillList_embedSkillEffectList_exp = ReadInt();	_petInfoList_skillList_embedSkillEffectListTmp.exp = _petInfoList_skillList_embedSkillEffectList_exp;
		}
	//end
	_petInfoList_skillListTmp.embedSkillEffectList = _petInfoList_skillList_embedSkillEffectList;
		// 层数
	int _petInfoList_skillList_layer = ReadInt();	_petInfoList_skillListTmp.layer = _petInfoList_skillList_layer;
		// 熟练度
	long _petInfoList_skillList_proficiency = ReadLong();	_petInfoList_skillListTmp.proficiency = _petInfoList_skillList_proficiency;
		}
	//end
	_petInfoListTmp.skillList = _petInfoList_skillList;
		// 一级属性附加值
	int petInfoList_aPropAddArrSize = ReadShort();
	int[] _petInfoList_aPropAddArr = new int[petInfoList_aPropAddArrSize];
	int petInfoList_aPropAddArrIndex = 0;
	for(petInfoList_aPropAddArrIndex=0; petInfoList_aPropAddArrIndex<petInfoList_aPropAddArrSize; petInfoList_aPropAddArrIndex++){
		_petInfoList_aPropAddArr[petInfoList_aPropAddArrIndex] = ReadInt();
	}//end
		_petInfoListTmp.aPropAddArr = _petInfoList_aPropAddArr;
		// 装备位星级
	int petInfoList_aEquipStarSize = ReadShort();
	int[] _petInfoList_aEquipStar = new int[petInfoList_aEquipStarSize];
	int petInfoList_aEquipStarIndex = 0;
	for(petInfoList_aEquipStarIndex=0; petInfoList_aEquipStarIndex<petInfoList_aEquipStarSize; petInfoList_aEquipStarIndex++){
		_petInfoList_aEquipStar[petInfoList_aEquipStarIndex] = ReadInt();
	}//end
		_petInfoListTmp.aEquipStar = _petInfoList_aEquipStar;
		// 宠物培养增加属性
	int petInfoList_trainPropArrSize = ReadShort();
	int[] _petInfoList_trainPropArr = new int[petInfoList_trainPropArrSize];
	int petInfoList_trainPropArrIndex = 0;
	for(petInfoList_trainPropArrIndex=0; petInfoList_trainPropArrIndex<petInfoList_trainPropArrSize; petInfoList_trainPropArrIndex++){
		_petInfoList_trainPropArr[petInfoList_trainPropArrIndex] = ReadInt();
	}//end
		_petInfoListTmp.trainPropArr = _petInfoList_trainPropArr;
		// 宠物培养临时属性
	int petInfoList_trainTmpPropArrSize = ReadShort();
	int[] _petInfoList_trainTmpPropArr = new int[petInfoList_trainTmpPropArrSize];
	int petInfoList_trainTmpPropArrIndex = 0;
	for(petInfoList_trainTmpPropArrIndex=0; petInfoList_trainTmpPropArrIndex<petInfoList_trainTmpPropArrSize; petInfoList_trainTmpPropArrIndex++){
		_petInfoList_trainTmpPropArr[petInfoList_trainTmpPropArrIndex] = ReadInt();
	}//end
		_petInfoListTmp.trainTmpPropArr = _petInfoList_trainTmpPropArr;
		// 宠物培养上限值
	int _petInfoList_trainMax = ReadInt();	_petInfoListTmp.trainMax = _petInfoList_trainMax;
		// 宠物培评分
	int _petInfoList_petScore = ReadInt();	_petInfoListTmp.petScore = _petInfoList_petScore;
		// 宠物技能栏数量
	int _petInfoList_petSkillBarNum = ReadInt();	_petInfoListTmp.petSkillBarNum = _petInfoList_petSkillBarNum;
		// 宠物资质丹索引
	int petInfoList_propItemIndexSize = ReadShort();
	int[] _petInfoList_propItemIndex = new int[petInfoList_propItemIndexSize];
	int petInfoList_propItemIndexIndex = 0;
	for(petInfoList_propItemIndexIndex=0; petInfoList_propItemIndexIndex<petInfoList_propItemIndexSize; petInfoList_propItemIndexIndex++){
		_petInfoList_propItemIndex[petInfoList_propItemIndexIndex] = ReadInt();
	}//end
		_petInfoListTmp.propItemIndex = _petInfoList_propItemIndex;
	
	// 技能快捷栏信息
	int petInfoList_shortcutListSize = ReadShort();
	PetSkillShortcutInfo[] _petInfoList_shortcutList = new PetSkillShortcutInfo[petInfoList_shortcutListSize];
	int petInfoList_shortcutListIndex = 0;
	PetSkillShortcutInfo _petInfoList_shortcutListTmp = null;
	for(petInfoList_shortcutListIndex=0; petInfoList_shortcutListIndex<petInfoList_shortcutListSize; petInfoList_shortcutListIndex++){
		_petInfoList_shortcutListTmp = new PetSkillShortcutInfo();
		_petInfoList_shortcutList[petInfoList_shortcutListIndex] = _petInfoList_shortcutListTmp;
	// 快捷栏索引, 默认为-1
	int _petInfoList_shortcutList_shortcutIndex = ReadInt();	_petInfoList_shortcutListTmp.shortcutIndex = _petInfoList_shortcutList_shortcutIndex;
		// 技能Id
	int _petInfoList_shortcutList_skillId = ReadInt();	_petInfoList_shortcutListTmp.skillId = _petInfoList_shortcutList_skillId;
		}
	//end
	_petInfoListTmp.shortcutList = _petInfoList_shortcutList;
		// 灵魂链接骑宠ID, 0-无灵魂链接
	long _petInfoList_soulLinkPetHorseId = ReadLong();	_petInfoListTmp.soulLinkPetHorseId = _petInfoList_soulLinkPetHorseId;
		}
	//end



		this.petInfoList = _petInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PET_LIST;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetListEvent;
	}
	

	public PetInfo[] getPetInfoList(){
		return petInfoList;
	}


}
}