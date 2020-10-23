package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回武将列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetList extends GCMessage{
	
	/** 返回武将列表 */
	private com.imop.lj.common.model.pet.PetInfo[] petInfoList;

	public GCPetList (){
	}
	
	public GCPetList (
			com.imop.lj.common.model.pet.PetInfo[] petInfoList ){
			this.petInfoList = petInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 返回武将列表
	int petInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.pet.PetInfo[] _petInfoList = new com.imop.lj.common.model.pet.PetInfo[petInfoListSize];
	int petInfoListIndex = 0;
	for(petInfoListIndex=0; petInfoListIndex<petInfoListSize; petInfoListIndex++){
		_petInfoList[petInfoListIndex] = new com.imop.lj.common.model.pet.PetInfo();
	// 武將ID
	long _petInfoList_petId = readLong();
	//end
	_petInfoList[petInfoListIndex].setPetId (_petInfoList_petId);

	// 武將模版ID
	int _petInfoList_tplId = readInteger();
	//end
	_petInfoList[petInfoListIndex].setTplId (_petInfoList_tplId);

	// 武将品质
	int _petInfoList_colorId = readInteger();
	//end
	_petInfoList[petInfoListIndex].setColorId (_petInfoList_colorId);

	// 武将星级
	int _petInfoList_star = readInteger();
	//end
	_petInfoList[petInfoListIndex].setStar (_petInfoList_star);

	// 武将等级
	int _petInfoList_level = readInteger();
	//end
	_petInfoList[petInfoListIndex].setLevel (_petInfoList_level);

	// 武將经验
	long _petInfoList_exp = readLong();
	//end
	_petInfoList[petInfoListIndex].setExp (_petInfoList_exp);

	// 武將类型，1主将，2宠物，3伙伴
	int _petInfoList_petType = readInteger();
	//end
	_petInfoList[petInfoListIndex].setPetType (_petInfoList_petType);

	// 武将技能列表
	int petInfoList_skillListSize = readUnsignedShort();
	com.imop.lj.common.model.pet.SkillInfo[] _petInfoList_skillList = new com.imop.lj.common.model.pet.SkillInfo[petInfoList_skillListSize];
	int petInfoList_skillListIndex = 0;
	for(petInfoList_skillListIndex=0; petInfoList_skillListIndex<petInfoList_skillListSize; petInfoList_skillListIndex++){
		_petInfoList_skillList[petInfoList_skillListIndex] = new com.imop.lj.common.model.pet.SkillInfo();
	// 技能Id
	int _petInfoList_skillList_skillId = readInteger();
	//end
	_petInfoList_skillList[petInfoList_skillListIndex].setSkillId (_petInfoList_skillList_skillId);

	// 技能等级
	int _petInfoList_skillList_level = readInteger();
	//end
	_petInfoList_skillList[petInfoList_skillListIndex].setLevel (_petInfoList_skillList_level);

	// 技能消耗
	int _petInfoList_skillList_skillCost = readInteger();
	//end
	_petInfoList_skillList[petInfoList_skillListIndex].setSkillCost (_petInfoList_skillList_skillCost);

	// 技能镶嵌的效果列表
	int petInfoList_skillList_embedSkillEffectListSize = readUnsignedShort();
	com.imop.lj.common.model.pet.SkillEffectInfo[] _petInfoList_skillList_embedSkillEffectList = new com.imop.lj.common.model.pet.SkillEffectInfo[petInfoList_skillList_embedSkillEffectListSize];
	int petInfoList_skillList_embedSkillEffectListIndex = 0;
	for(petInfoList_skillList_embedSkillEffectListIndex=0; petInfoList_skillList_embedSkillEffectListIndex<petInfoList_skillList_embedSkillEffectListSize; petInfoList_skillList_embedSkillEffectListIndex++){
		_petInfoList_skillList_embedSkillEffectList[petInfoList_skillList_embedSkillEffectListIndex] = new com.imop.lj.common.model.pet.SkillEffectInfo();
	// 技能效果道具Id
	int _petInfoList_skillList_embedSkillEffectList_effectItemId = readInteger();
	//end
	_petInfoList_skillList_embedSkillEffectList[petInfoList_skillList_embedSkillEffectListIndex].setEffectItemId (_petInfoList_skillList_embedSkillEffectList_effectItemId);

	// 技能效果等级
	int _petInfoList_skillList_embedSkillEffectList_level = readInteger();
	//end
	_petInfoList_skillList_embedSkillEffectList[petInfoList_skillList_embedSkillEffectListIndex].setLevel (_petInfoList_skillList_embedSkillEffectList_level);

	// 技能效果经验
	int _petInfoList_skillList_embedSkillEffectList_exp = readInteger();
	//end
	_petInfoList_skillList_embedSkillEffectList[petInfoList_skillList_embedSkillEffectListIndex].setExp (_petInfoList_skillList_embedSkillEffectList_exp);
	}
	//end
	_petInfoList_skillList[petInfoList_skillListIndex].setEmbedSkillEffectList (_petInfoList_skillList_embedSkillEffectList);
	}
	//end
	_petInfoList[petInfoListIndex].setSkillList (_petInfoList_skillList);

	// 一级属性附加值
	int petInfoList_aPropAddArrSize = readUnsignedShort();
	int[] _petInfoList_aPropAddArr = new int[petInfoList_aPropAddArrSize];
	int petInfoList_aPropAddArrIndex = 0;
	for(petInfoList_aPropAddArrIndex=0; petInfoList_aPropAddArrIndex<petInfoList_aPropAddArrSize; petInfoList_aPropAddArrIndex++){
		_petInfoList_aPropAddArr[petInfoList_aPropAddArrIndex] = readInteger();
	}//end
	_petInfoList[petInfoListIndex].setAPropAddArr (_petInfoList_aPropAddArr);

	// 装备位星级
	int petInfoList_aEquipStarSize = readUnsignedShort();
	int[] _petInfoList_aEquipStar = new int[petInfoList_aEquipStarSize];
	int petInfoList_aEquipStarIndex = 0;
	for(petInfoList_aEquipStarIndex=0; petInfoList_aEquipStarIndex<petInfoList_aEquipStarSize; petInfoList_aEquipStarIndex++){
		_petInfoList_aEquipStar[petInfoList_aEquipStarIndex] = readInteger();
	}//end
	_petInfoList[petInfoListIndex].setAEquipStar (_petInfoList_aEquipStar);

	// 宠物培养增加属性
	int petInfoList_trainPropArrSize = readUnsignedShort();
	int[] _petInfoList_trainPropArr = new int[petInfoList_trainPropArrSize];
	int petInfoList_trainPropArrIndex = 0;
	for(petInfoList_trainPropArrIndex=0; petInfoList_trainPropArrIndex<petInfoList_trainPropArrSize; petInfoList_trainPropArrIndex++){
		_petInfoList_trainPropArr[petInfoList_trainPropArrIndex] = readInteger();
	}//end
	_petInfoList[petInfoListIndex].setTrainPropArr (_petInfoList_trainPropArr);

	// 宠物培养临时属性
	int petInfoList_trainTmpPropArrSize = readUnsignedShort();
	int[] _petInfoList_trainTmpPropArr = new int[petInfoList_trainTmpPropArrSize];
	int petInfoList_trainTmpPropArrIndex = 0;
	for(petInfoList_trainTmpPropArrIndex=0; petInfoList_trainTmpPropArrIndex<petInfoList_trainTmpPropArrSize; petInfoList_trainTmpPropArrIndex++){
		_petInfoList_trainTmpPropArr[petInfoList_trainTmpPropArrIndex] = readInteger();
	}//end
	_petInfoList[petInfoListIndex].setTrainTmpPropArr (_petInfoList_trainTmpPropArr);

	// 宠物培养上限值
	int _petInfoList_trainMax = readInteger();
	//end
	_petInfoList[petInfoListIndex].setTrainMax (_petInfoList_trainMax);

	// 宠物培评分
	int _petInfoList_petScore = readInteger();
	//end
	_petInfoList[petInfoListIndex].setPetScore (_petInfoList_petScore);
	}
	//end



		this.petInfoList = _petInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 返回武将列表
	writeShort(petInfoList.length);
	int petInfoListIndex = 0;
	int petInfoListSize = petInfoList.length;
	for(petInfoListIndex=0; petInfoListIndex<petInfoListSize; petInfoListIndex++){

	long petInfoList_petId = petInfoList[petInfoListIndex].getPetId();

	// 武將ID
	writeLong(petInfoList_petId);

	int petInfoList_tplId = petInfoList[petInfoListIndex].getTplId();

	// 武將模版ID
	writeInteger(petInfoList_tplId);

	int petInfoList_colorId = petInfoList[petInfoListIndex].getColorId();

	// 武将品质
	writeInteger(petInfoList_colorId);

	int petInfoList_star = petInfoList[petInfoListIndex].getStar();

	// 武将星级
	writeInteger(petInfoList_star);

	int petInfoList_level = petInfoList[petInfoListIndex].getLevel();

	// 武将等级
	writeInteger(petInfoList_level);

	long petInfoList_exp = petInfoList[petInfoListIndex].getExp();

	// 武將经验
	writeLong(petInfoList_exp);

	int petInfoList_petType = petInfoList[petInfoListIndex].getPetType();

	// 武將类型，1主将，2宠物，3伙伴
	writeInteger(petInfoList_petType);

	com.imop.lj.common.model.pet.SkillInfo[] petInfoList_skillList = petInfoList[petInfoListIndex].getSkillList();

	// 武将技能列表
	writeShort(petInfoList_skillList.length);
	int petInfoList_skillListIndex = 0;
	int petInfoList_skillListSize = petInfoList_skillList.length;
	for(petInfoList_skillListIndex=0; petInfoList_skillListIndex<petInfoList_skillListSize; petInfoList_skillListIndex++){

	int petInfoList_skillList_skillId = petInfoList_skillList[petInfoList_skillListIndex].getSkillId();

	// 技能Id
	writeInteger(petInfoList_skillList_skillId);

	int petInfoList_skillList_level = petInfoList_skillList[petInfoList_skillListIndex].getLevel();

	// 技能等级
	writeInteger(petInfoList_skillList_level);

	int petInfoList_skillList_skillCost = petInfoList_skillList[petInfoList_skillListIndex].getSkillCost();

	// 技能消耗
	writeInteger(petInfoList_skillList_skillCost);

	com.imop.lj.common.model.pet.SkillEffectInfo[] petInfoList_skillList_embedSkillEffectList = petInfoList_skillList[petInfoList_skillListIndex].getEmbedSkillEffectList();

	// 技能镶嵌的效果列表
	writeShort(petInfoList_skillList_embedSkillEffectList.length);
	int petInfoList_skillList_embedSkillEffectListIndex = 0;
	int petInfoList_skillList_embedSkillEffectListSize = petInfoList_skillList_embedSkillEffectList.length;
	for(petInfoList_skillList_embedSkillEffectListIndex=0; petInfoList_skillList_embedSkillEffectListIndex<petInfoList_skillList_embedSkillEffectListSize; petInfoList_skillList_embedSkillEffectListIndex++){

	int petInfoList_skillList_embedSkillEffectList_effectItemId = petInfoList_skillList_embedSkillEffectList[petInfoList_skillList_embedSkillEffectListIndex].getEffectItemId();

	// 技能效果道具Id
	writeInteger(petInfoList_skillList_embedSkillEffectList_effectItemId);

	int petInfoList_skillList_embedSkillEffectList_level = petInfoList_skillList_embedSkillEffectList[petInfoList_skillList_embedSkillEffectListIndex].getLevel();

	// 技能效果等级
	writeInteger(petInfoList_skillList_embedSkillEffectList_level);

	int petInfoList_skillList_embedSkillEffectList_exp = petInfoList_skillList_embedSkillEffectList[petInfoList_skillList_embedSkillEffectListIndex].getExp();

	// 技能效果经验
	writeInteger(petInfoList_skillList_embedSkillEffectList_exp);
	}
	//end
	}
	//end

	int[] petInfoList_aPropAddArr = petInfoList[petInfoListIndex].getAPropAddArr();

	// 一级属性附加值
	writeShort(petInfoList_aPropAddArr.length);
	int petInfoList_aPropAddArrSize = petInfoList_aPropAddArr.length;
	int petInfoList_aPropAddArrIndex = 0;
	for(petInfoList_aPropAddArrIndex=0; petInfoList_aPropAddArrIndex<petInfoList_aPropAddArrSize; petInfoList_aPropAddArrIndex++){
		writeInteger(petInfoList_aPropAddArr [ petInfoList_aPropAddArrIndex ]);
	}//end

	int[] petInfoList_aEquipStar = petInfoList[petInfoListIndex].getAEquipStar();

	// 装备位星级
	writeShort(petInfoList_aEquipStar.length);
	int petInfoList_aEquipStarSize = petInfoList_aEquipStar.length;
	int petInfoList_aEquipStarIndex = 0;
	for(petInfoList_aEquipStarIndex=0; petInfoList_aEquipStarIndex<petInfoList_aEquipStarSize; petInfoList_aEquipStarIndex++){
		writeInteger(petInfoList_aEquipStar [ petInfoList_aEquipStarIndex ]);
	}//end

	int[] petInfoList_trainPropArr = petInfoList[petInfoListIndex].getTrainPropArr();

	// 宠物培养增加属性
	writeShort(petInfoList_trainPropArr.length);
	int petInfoList_trainPropArrSize = petInfoList_trainPropArr.length;
	int petInfoList_trainPropArrIndex = 0;
	for(petInfoList_trainPropArrIndex=0; petInfoList_trainPropArrIndex<petInfoList_trainPropArrSize; petInfoList_trainPropArrIndex++){
		writeInteger(petInfoList_trainPropArr [ petInfoList_trainPropArrIndex ]);
	}//end

	int[] petInfoList_trainTmpPropArr = petInfoList[petInfoListIndex].getTrainTmpPropArr();

	// 宠物培养临时属性
	writeShort(petInfoList_trainTmpPropArr.length);
	int petInfoList_trainTmpPropArrSize = petInfoList_trainTmpPropArr.length;
	int petInfoList_trainTmpPropArrIndex = 0;
	for(petInfoList_trainTmpPropArrIndex=0; petInfoList_trainTmpPropArrIndex<petInfoList_trainTmpPropArrSize; petInfoList_trainTmpPropArrIndex++){
		writeInteger(petInfoList_trainTmpPropArr [ petInfoList_trainTmpPropArrIndex ]);
	}//end

	int petInfoList_trainMax = petInfoList[petInfoListIndex].getTrainMax();

	// 宠物培养上限值
	writeInteger(petInfoList_trainMax);

	int petInfoList_petScore = petInfoList[petInfoListIndex].getPetScore();

	// 宠物培评分
	writeInteger(petInfoList_petScore);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PET_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PET_LIST";
	}

	public com.imop.lj.common.model.pet.PetInfo[] getPetInfoList(){
		return petInfoList;
	}

	public void setPetInfoList(com.imop.lj.common.model.pet.PetInfo[] petInfoList){
		this.petInfoList = petInfoList;
	}	
}