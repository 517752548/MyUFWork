package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 主将技能镶嵌仙符信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetSkillEffectUpdate extends GCMessage{
	
	/** 技能Id */
	private int skillId;
	/** 技能镶嵌的效果列表，效果id为0表示空格子 */
	private com.imop.lj.common.model.pet.SkillEffectInfo[] embedSkillEffectList;

	public GCPetSkillEffectUpdate (){
	}
	
	public GCPetSkillEffectUpdate (
			int skillId,
			com.imop.lj.common.model.pet.SkillEffectInfo[] embedSkillEffectList ){
			this.skillId = skillId;
			this.embedSkillEffectList = embedSkillEffectList;
	}

	@Override
	protected boolean readImpl() {

	// 技能Id
	int _skillId = readInteger();
	//end


	// 技能镶嵌的效果列表，效果id为0表示空格子
	int embedSkillEffectListSize = readUnsignedShort();
	com.imop.lj.common.model.pet.SkillEffectInfo[] _embedSkillEffectList = new com.imop.lj.common.model.pet.SkillEffectInfo[embedSkillEffectListSize];
	int embedSkillEffectListIndex = 0;
	for(embedSkillEffectListIndex=0; embedSkillEffectListIndex<embedSkillEffectListSize; embedSkillEffectListIndex++){
		_embedSkillEffectList[embedSkillEffectListIndex] = new com.imop.lj.common.model.pet.SkillEffectInfo();
	// 技能效果道具Id
	int _embedSkillEffectList_effectItemId = readInteger();
	//end
	_embedSkillEffectList[embedSkillEffectListIndex].setEffectItemId (_embedSkillEffectList_effectItemId);

	// 技能效果等级
	int _embedSkillEffectList_level = readInteger();
	//end
	_embedSkillEffectList[embedSkillEffectListIndex].setLevel (_embedSkillEffectList_level);

	// 技能效果经验
	int _embedSkillEffectList_exp = readInteger();
	//end
	_embedSkillEffectList[embedSkillEffectListIndex].setExp (_embedSkillEffectList_exp);
	}
	//end



		this.skillId = _skillId;
		this.embedSkillEffectList = _embedSkillEffectList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 技能Id
	writeInteger(skillId);


	// 技能镶嵌的效果列表，效果id为0表示空格子
	writeShort(embedSkillEffectList.length);
	int embedSkillEffectListIndex = 0;
	int embedSkillEffectListSize = embedSkillEffectList.length;
	for(embedSkillEffectListIndex=0; embedSkillEffectListIndex<embedSkillEffectListSize; embedSkillEffectListIndex++){

	int embedSkillEffectList_effectItemId = embedSkillEffectList[embedSkillEffectListIndex].getEffectItemId();

	// 技能效果道具Id
	writeInteger(embedSkillEffectList_effectItemId);

	int embedSkillEffectList_level = embedSkillEffectList[embedSkillEffectListIndex].getLevel();

	// 技能效果等级
	writeInteger(embedSkillEffectList_level);

	int embedSkillEffectList_exp = embedSkillEffectList[embedSkillEffectListIndex].getExp();

	// 技能效果经验
	writeInteger(embedSkillEffectList_exp);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PET_SKILL_EFFECT_UPDATE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PET_SKILL_EFFECT_UPDATE";
	}

	public int getSkillId(){
		return skillId;
	}
		
	public void setSkillId(int skillId){
		this.skillId = skillId;
	}

	public com.imop.lj.common.model.pet.SkillEffectInfo[] getEmbedSkillEffectList(){
		return embedSkillEffectList;
	}

	public void setEmbedSkillEffectList(com.imop.lj.common.model.pet.SkillEffectInfo[] embedSkillEffectList){
		this.embedSkillEffectList = embedSkillEffectList;
	}	
}