package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回单个武将信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetInfo extends GCMessage{
	
	/** 返回武将信息 */
	private com.imop.lj.common.model.pet.PetInfo petInfo;

	public GCPetInfo (){
	}
	
	public GCPetInfo (
			com.imop.lj.common.model.pet.PetInfo petInfo ){
			this.petInfo = petInfo;
	}

	@Override
	protected boolean readImpl() {
	// 返回武将信息
	com.imop.lj.common.model.pet.PetInfo _petInfo = new com.imop.lj.common.model.pet.PetInfo();

	// 武將ID
	long _petInfo_petId = readLong();
	//end
	_petInfo.setPetId (_petInfo_petId);

	// 武將模版ID
	int _petInfo_tplId = readInteger();
	//end
	_petInfo.setTplId (_petInfo_tplId);

	// 武将品质
	int _petInfo_colorId = readInteger();
	//end
	_petInfo.setColorId (_petInfo_colorId);

	// 武将星级
	int _petInfo_star = readInteger();
	//end
	_petInfo.setStar (_petInfo_star);

	// 武将等级
	int _petInfo_level = readInteger();
	//end
	_petInfo.setLevel (_petInfo_level);

	// 武將经验
	long _petInfo_exp = readLong();
	//end
	_petInfo.setExp (_petInfo_exp);

	// 武將类型，1主将，2宠物，3伙伴
	int _petInfo_petType = readInteger();
	//end
	_petInfo.setPetType (_petInfo_petType);

	// 武将技能列表
	int petInfo_skillListSize = readUnsignedShort();
	com.imop.lj.common.model.pet.SkillInfo[] _petInfo_skillList = new com.imop.lj.common.model.pet.SkillInfo[petInfo_skillListSize];
	int petInfo_skillListIndex = 0;
	for(petInfo_skillListIndex=0; petInfo_skillListIndex<petInfo_skillListSize; petInfo_skillListIndex++){
		_petInfo_skillList[petInfo_skillListIndex] = new com.imop.lj.common.model.pet.SkillInfo();
	// 技能Id
	int _petInfo_skillList_skillId = readInteger();
	//end
	_petInfo_skillList[petInfo_skillListIndex].setSkillId (_petInfo_skillList_skillId);

	// 技能等级
	int _petInfo_skillList_level = readInteger();
	//end
	_petInfo_skillList[petInfo_skillListIndex].setLevel (_petInfo_skillList_level);

	// 技能消耗
	int _petInfo_skillList_skillCost = readInteger();
	//end
	_petInfo_skillList[petInfo_skillListIndex].setSkillCost (_petInfo_skillList_skillCost);

	// 技能镶嵌的效果列表
	int petInfo_skillList_embedSkillEffectListSize = readUnsignedShort();
	com.imop.lj.common.model.pet.SkillEffectInfo[] _petInfo_skillList_embedSkillEffectList = new com.imop.lj.common.model.pet.SkillEffectInfo[petInfo_skillList_embedSkillEffectListSize];
	int petInfo_skillList_embedSkillEffectListIndex = 0;
	for(petInfo_skillList_embedSkillEffectListIndex=0; petInfo_skillList_embedSkillEffectListIndex<petInfo_skillList_embedSkillEffectListSize; petInfo_skillList_embedSkillEffectListIndex++){
		_petInfo_skillList_embedSkillEffectList[petInfo_skillList_embedSkillEffectListIndex] = new com.imop.lj.common.model.pet.SkillEffectInfo();
	// 技能效果道具Id
	int _petInfo_skillList_embedSkillEffectList_effectItemId = readInteger();
	//end
	_petInfo_skillList_embedSkillEffectList[petInfo_skillList_embedSkillEffectListIndex].setEffectItemId (_petInfo_skillList_embedSkillEffectList_effectItemId);

	// 技能效果等级
	int _petInfo_skillList_embedSkillEffectList_level = readInteger();
	//end
	_petInfo_skillList_embedSkillEffectList[petInfo_skillList_embedSkillEffectListIndex].setLevel (_petInfo_skillList_embedSkillEffectList_level);

	// 技能效果经验
	int _petInfo_skillList_embedSkillEffectList_exp = readInteger();
	//end
	_petInfo_skillList_embedSkillEffectList[petInfo_skillList_embedSkillEffectListIndex].setExp (_petInfo_skillList_embedSkillEffectList_exp);
	}
	//end
	_petInfo_skillList[petInfo_skillListIndex].setEmbedSkillEffectList (_petInfo_skillList_embedSkillEffectList);

	// 层数
	int _petInfo_skillList_layer = readInteger();
	//end
	_petInfo_skillList[petInfo_skillListIndex].setLayer (_petInfo_skillList_layer);

	// 熟练度
	long _petInfo_skillList_proficiency = readLong();
	//end
	_petInfo_skillList[petInfo_skillListIndex].setProficiency (_petInfo_skillList_proficiency);
	}
	//end
	_petInfo.setSkillList (_petInfo_skillList);

	// 一级属性附加值
	int petInfo_aPropAddArrSize = readUnsignedShort();
	int[] _petInfo_aPropAddArr = new int[petInfo_aPropAddArrSize];
	int petInfo_aPropAddArrIndex = 0;
	for(petInfo_aPropAddArrIndex=0; petInfo_aPropAddArrIndex<petInfo_aPropAddArrSize; petInfo_aPropAddArrIndex++){
		_petInfo_aPropAddArr[petInfo_aPropAddArrIndex] = readInteger();
	}//end
	_petInfo.setAPropAddArr (_petInfo_aPropAddArr);

	// 装备位星级
	int petInfo_aEquipStarSize = readUnsignedShort();
	int[] _petInfo_aEquipStar = new int[petInfo_aEquipStarSize];
	int petInfo_aEquipStarIndex = 0;
	for(petInfo_aEquipStarIndex=0; petInfo_aEquipStarIndex<petInfo_aEquipStarSize; petInfo_aEquipStarIndex++){
		_petInfo_aEquipStar[petInfo_aEquipStarIndex] = readInteger();
	}//end
	_petInfo.setAEquipStar (_petInfo_aEquipStar);

	// 宠物培养增加属性
	int petInfo_trainPropArrSize = readUnsignedShort();
	int[] _petInfo_trainPropArr = new int[petInfo_trainPropArrSize];
	int petInfo_trainPropArrIndex = 0;
	for(petInfo_trainPropArrIndex=0; petInfo_trainPropArrIndex<petInfo_trainPropArrSize; petInfo_trainPropArrIndex++){
		_petInfo_trainPropArr[petInfo_trainPropArrIndex] = readInteger();
	}//end
	_petInfo.setTrainPropArr (_petInfo_trainPropArr);

	// 宠物培养临时属性
	int petInfo_trainTmpPropArrSize = readUnsignedShort();
	int[] _petInfo_trainTmpPropArr = new int[petInfo_trainTmpPropArrSize];
	int petInfo_trainTmpPropArrIndex = 0;
	for(petInfo_trainTmpPropArrIndex=0; petInfo_trainTmpPropArrIndex<petInfo_trainTmpPropArrSize; petInfo_trainTmpPropArrIndex++){
		_petInfo_trainTmpPropArr[petInfo_trainTmpPropArrIndex] = readInteger();
	}//end
	_petInfo.setTrainTmpPropArr (_petInfo_trainTmpPropArr);

	// 宠物培养上限值
	int _petInfo_trainMax = readInteger();
	//end
	_petInfo.setTrainMax (_petInfo_trainMax);

	// 宠物培评分
	int _petInfo_petScore = readInteger();
	//end
	_petInfo.setPetScore (_petInfo_petScore);

	// 宠物技能栏数量
	int _petInfo_petSkillBarNum = readInteger();
	//end
	_petInfo.setPetSkillBarNum (_petInfo_petSkillBarNum);

	// 宠物资质丹索引
	int petInfo_propItemIndexSize = readUnsignedShort();
	int[] _petInfo_propItemIndex = new int[petInfo_propItemIndexSize];
	int petInfo_propItemIndexIndex = 0;
	for(petInfo_propItemIndexIndex=0; petInfo_propItemIndexIndex<petInfo_propItemIndexSize; petInfo_propItemIndexIndex++){
		_petInfo_propItemIndex[petInfo_propItemIndexIndex] = readInteger();
	}//end
	_petInfo.setPropItemIndex (_petInfo_propItemIndex);

	// 技能快捷栏信息
	int petInfo_shortcutListSize = readUnsignedShort();
	com.imop.lj.common.model.pet.ShortcutInfo[] _petInfo_shortcutList = new com.imop.lj.common.model.pet.ShortcutInfo[petInfo_shortcutListSize];
	int petInfo_shortcutListIndex = 0;
	for(petInfo_shortcutListIndex=0; petInfo_shortcutListIndex<petInfo_shortcutListSize; petInfo_shortcutListIndex++){
		_petInfo_shortcutList[petInfo_shortcutListIndex] = new com.imop.lj.common.model.pet.ShortcutInfo();
	// 快捷栏索引, 默认为-1
	int _petInfo_shortcutList_shortcutIndex = readInteger();
	//end
	_petInfo_shortcutList[petInfo_shortcutListIndex].setShortcutIndex (_petInfo_shortcutList_shortcutIndex);

	// 技能Id
	int _petInfo_shortcutList_skillId = readInteger();
	//end
	_petInfo_shortcutList[petInfo_shortcutListIndex].setSkillId (_petInfo_shortcutList_skillId);
	}
	//end
	_petInfo.setShortcutList (_petInfo_shortcutList);

	// 灵魂链接骑宠ID, 0-无灵魂链接
	long _petInfo_soulLinkPetHorseId = readLong();
	//end
	_petInfo.setSoulLinkPetHorseId (_petInfo_soulLinkPetHorseId);



		this.petInfo = _petInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	long petInfo_petId = petInfo.getPetId ();

	// 武將ID
	writeLong(petInfo_petId);

	int petInfo_tplId = petInfo.getTplId ();

	// 武將模版ID
	writeInteger(petInfo_tplId);

	int petInfo_colorId = petInfo.getColorId ();

	// 武将品质
	writeInteger(petInfo_colorId);

	int petInfo_star = petInfo.getStar ();

	// 武将星级
	writeInteger(petInfo_star);

	int petInfo_level = petInfo.getLevel ();

	// 武将等级
	writeInteger(petInfo_level);

	long petInfo_exp = petInfo.getExp ();

	// 武將经验
	writeLong(petInfo_exp);

	int petInfo_petType = petInfo.getPetType ();

	// 武將类型，1主将，2宠物，3伙伴
	writeInteger(petInfo_petType);

	com.imop.lj.common.model.pet.SkillInfo[] petInfo_skillList = petInfo.getSkillList ();

	// 武将技能列表
	writeShort(petInfo_skillList.length);
	int petInfo_skillListIndex = 0;
	int petInfo_skillListSize = petInfo_skillList.length;
	for(petInfo_skillListIndex=0; petInfo_skillListIndex<petInfo_skillListSize; petInfo_skillListIndex++){

	int petInfo_skillList_skillId = petInfo_skillList[petInfo_skillListIndex].getSkillId();

	// 技能Id
	writeInteger(petInfo_skillList_skillId);

	int petInfo_skillList_level = petInfo_skillList[petInfo_skillListIndex].getLevel();

	// 技能等级
	writeInteger(petInfo_skillList_level);

	int petInfo_skillList_skillCost = petInfo_skillList[petInfo_skillListIndex].getSkillCost();

	// 技能消耗
	writeInteger(petInfo_skillList_skillCost);

	com.imop.lj.common.model.pet.SkillEffectInfo[] petInfo_skillList_embedSkillEffectList = petInfo_skillList[petInfo_skillListIndex].getEmbedSkillEffectList();

	// 技能镶嵌的效果列表
	writeShort(petInfo_skillList_embedSkillEffectList.length);
	int petInfo_skillList_embedSkillEffectListIndex = 0;
	int petInfo_skillList_embedSkillEffectListSize = petInfo_skillList_embedSkillEffectList.length;
	for(petInfo_skillList_embedSkillEffectListIndex=0; petInfo_skillList_embedSkillEffectListIndex<petInfo_skillList_embedSkillEffectListSize; petInfo_skillList_embedSkillEffectListIndex++){

	int petInfo_skillList_embedSkillEffectList_effectItemId = petInfo_skillList_embedSkillEffectList[petInfo_skillList_embedSkillEffectListIndex].getEffectItemId();

	// 技能效果道具Id
	writeInteger(petInfo_skillList_embedSkillEffectList_effectItemId);

	int petInfo_skillList_embedSkillEffectList_level = petInfo_skillList_embedSkillEffectList[petInfo_skillList_embedSkillEffectListIndex].getLevel();

	// 技能效果等级
	writeInteger(petInfo_skillList_embedSkillEffectList_level);

	int petInfo_skillList_embedSkillEffectList_exp = petInfo_skillList_embedSkillEffectList[petInfo_skillList_embedSkillEffectListIndex].getExp();

	// 技能效果经验
	writeInteger(petInfo_skillList_embedSkillEffectList_exp);
	}
	//end

	int petInfo_skillList_layer = petInfo_skillList[petInfo_skillListIndex].getLayer();

	// 层数
	writeInteger(petInfo_skillList_layer);

	long petInfo_skillList_proficiency = petInfo_skillList[petInfo_skillListIndex].getProficiency();

	// 熟练度
	writeLong(petInfo_skillList_proficiency);
	}
	//end

	int[] petInfo_aPropAddArr = petInfo.getAPropAddArr ();

	// 一级属性附加值
	writeShort(petInfo_aPropAddArr.length);
	int petInfo_aPropAddArrSize = petInfo_aPropAddArr.length;
	int petInfo_aPropAddArrIndex = 0;
	for(petInfo_aPropAddArrIndex=0; petInfo_aPropAddArrIndex<petInfo_aPropAddArrSize; petInfo_aPropAddArrIndex++){
		writeInteger(petInfo_aPropAddArr [ petInfo_aPropAddArrIndex ]);
	}//end

	int[] petInfo_aEquipStar = petInfo.getAEquipStar ();

	// 装备位星级
	writeShort(petInfo_aEquipStar.length);
	int petInfo_aEquipStarSize = petInfo_aEquipStar.length;
	int petInfo_aEquipStarIndex = 0;
	for(petInfo_aEquipStarIndex=0; petInfo_aEquipStarIndex<petInfo_aEquipStarSize; petInfo_aEquipStarIndex++){
		writeInteger(petInfo_aEquipStar [ petInfo_aEquipStarIndex ]);
	}//end

	int[] petInfo_trainPropArr = petInfo.getTrainPropArr ();

	// 宠物培养增加属性
	writeShort(petInfo_trainPropArr.length);
	int petInfo_trainPropArrSize = petInfo_trainPropArr.length;
	int petInfo_trainPropArrIndex = 0;
	for(petInfo_trainPropArrIndex=0; petInfo_trainPropArrIndex<petInfo_trainPropArrSize; petInfo_trainPropArrIndex++){
		writeInteger(petInfo_trainPropArr [ petInfo_trainPropArrIndex ]);
	}//end

	int[] petInfo_trainTmpPropArr = petInfo.getTrainTmpPropArr ();

	// 宠物培养临时属性
	writeShort(petInfo_trainTmpPropArr.length);
	int petInfo_trainTmpPropArrSize = petInfo_trainTmpPropArr.length;
	int petInfo_trainTmpPropArrIndex = 0;
	for(petInfo_trainTmpPropArrIndex=0; petInfo_trainTmpPropArrIndex<petInfo_trainTmpPropArrSize; petInfo_trainTmpPropArrIndex++){
		writeInteger(petInfo_trainTmpPropArr [ petInfo_trainTmpPropArrIndex ]);
	}//end

	int petInfo_trainMax = petInfo.getTrainMax ();

	// 宠物培养上限值
	writeInteger(petInfo_trainMax);

	int petInfo_petScore = petInfo.getPetScore ();

	// 宠物培评分
	writeInteger(petInfo_petScore);

	int petInfo_petSkillBarNum = petInfo.getPetSkillBarNum ();

	// 宠物技能栏数量
	writeInteger(petInfo_petSkillBarNum);

	int[] petInfo_propItemIndex = petInfo.getPropItemIndex ();

	// 宠物资质丹索引
	writeShort(petInfo_propItemIndex.length);
	int petInfo_propItemIndexSize = petInfo_propItemIndex.length;
	int petInfo_propItemIndexIndex = 0;
	for(petInfo_propItemIndexIndex=0; petInfo_propItemIndexIndex<petInfo_propItemIndexSize; petInfo_propItemIndexIndex++){
		writeInteger(petInfo_propItemIndex [ petInfo_propItemIndexIndex ]);
	}//end

	com.imop.lj.common.model.pet.ShortcutInfo[] petInfo_shortcutList = petInfo.getShortcutList ();

	// 技能快捷栏信息
	writeShort(petInfo_shortcutList.length);
	int petInfo_shortcutListIndex = 0;
	int petInfo_shortcutListSize = petInfo_shortcutList.length;
	for(petInfo_shortcutListIndex=0; petInfo_shortcutListIndex<petInfo_shortcutListSize; petInfo_shortcutListIndex++){

	int petInfo_shortcutList_shortcutIndex = petInfo_shortcutList[petInfo_shortcutListIndex].getShortcutIndex();

	// 快捷栏索引, 默认为-1
	writeInteger(petInfo_shortcutList_shortcutIndex);

	int petInfo_shortcutList_skillId = petInfo_shortcutList[petInfo_shortcutListIndex].getSkillId();

	// 技能Id
	writeInteger(petInfo_shortcutList_skillId);
	}
	//end

	long petInfo_soulLinkPetHorseId = petInfo.getSoulLinkPetHorseId ();

	// 灵魂链接骑宠ID, 0-无灵魂链接
	writeLong(petInfo_soulLinkPetHorseId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PET_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PET_INFO";
	}

	public com.imop.lj.common.model.pet.PetInfo getPetInfo(){
		return petInfo;
	}
		
	public void setPetInfo(com.imop.lj.common.model.pet.PetInfo petInfo){
		this.petInfo = petInfo;
	}
}