package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 单个伙伴的信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetFriendInfo extends GCMessage{
	
	/** 伙伴模板Id */
	private int tplId;
	/** 伙伴等级 */
	private int level;
	/** 属性json */
	private String props;
	/** 技能列表 */
	private com.imop.lj.common.model.pet.SkillInfo[] skillList;

	public GCPetFriendInfo (){
	}
	
	public GCPetFriendInfo (
			int tplId,
			int level,
			String props,
			com.imop.lj.common.model.pet.SkillInfo[] skillList ){
			this.tplId = tplId;
			this.level = level;
			this.props = props;
			this.skillList = skillList;
	}

	@Override
	protected boolean readImpl() {

	// 伙伴模板Id
	int _tplId = readInteger();
	//end


	// 伙伴等级
	int _level = readInteger();
	//end


	// 属性json
	String _props = readString();
	//end


	// 技能列表
	int skillListSize = readUnsignedShort();
	com.imop.lj.common.model.pet.SkillInfo[] _skillList = new com.imop.lj.common.model.pet.SkillInfo[skillListSize];
	int skillListIndex = 0;
	for(skillListIndex=0; skillListIndex<skillListSize; skillListIndex++){
		_skillList[skillListIndex] = new com.imop.lj.common.model.pet.SkillInfo();
	// 技能Id
	int _skillList_skillId = readInteger();
	//end
	_skillList[skillListIndex].setSkillId (_skillList_skillId);

	// 技能等级
	int _skillList_level = readInteger();
	//end
	_skillList[skillListIndex].setLevel (_skillList_level);

	// 技能消耗
	int _skillList_skillCost = readInteger();
	//end
	_skillList[skillListIndex].setSkillCost (_skillList_skillCost);

	// 技能镶嵌的效果列表
	int skillList_embedSkillEffectListSize = readUnsignedShort();
	com.imop.lj.common.model.pet.SkillEffectInfo[] _skillList_embedSkillEffectList = new com.imop.lj.common.model.pet.SkillEffectInfo[skillList_embedSkillEffectListSize];
	int skillList_embedSkillEffectListIndex = 0;
	for(skillList_embedSkillEffectListIndex=0; skillList_embedSkillEffectListIndex<skillList_embedSkillEffectListSize; skillList_embedSkillEffectListIndex++){
		_skillList_embedSkillEffectList[skillList_embedSkillEffectListIndex] = new com.imop.lj.common.model.pet.SkillEffectInfo();
	// 技能效果道具Id
	int _skillList_embedSkillEffectList_effectItemId = readInteger();
	//end
	_skillList_embedSkillEffectList[skillList_embedSkillEffectListIndex].setEffectItemId (_skillList_embedSkillEffectList_effectItemId);

	// 技能效果等级
	int _skillList_embedSkillEffectList_level = readInteger();
	//end
	_skillList_embedSkillEffectList[skillList_embedSkillEffectListIndex].setLevel (_skillList_embedSkillEffectList_level);

	// 技能效果经验
	int _skillList_embedSkillEffectList_exp = readInteger();
	//end
	_skillList_embedSkillEffectList[skillList_embedSkillEffectListIndex].setExp (_skillList_embedSkillEffectList_exp);
	}
	//end
	_skillList[skillListIndex].setEmbedSkillEffectList (_skillList_embedSkillEffectList);
	}
	//end



		this.tplId = _tplId;
		this.level = _level;
		this.props = _props;
		this.skillList = _skillList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 伙伴模板Id
	writeInteger(tplId);


	// 伙伴等级
	writeInteger(level);


	// 属性json
	writeString(props);


	// 技能列表
	writeShort(skillList.length);
	int skillListIndex = 0;
	int skillListSize = skillList.length;
	for(skillListIndex=0; skillListIndex<skillListSize; skillListIndex++){

	int skillList_skillId = skillList[skillListIndex].getSkillId();

	// 技能Id
	writeInteger(skillList_skillId);

	int skillList_level = skillList[skillListIndex].getLevel();

	// 技能等级
	writeInteger(skillList_level);

	int skillList_skillCost = skillList[skillListIndex].getSkillCost();

	// 技能消耗
	writeInteger(skillList_skillCost);

	com.imop.lj.common.model.pet.SkillEffectInfo[] skillList_embedSkillEffectList = skillList[skillListIndex].getEmbedSkillEffectList();

	// 技能镶嵌的效果列表
	writeShort(skillList_embedSkillEffectList.length);
	int skillList_embedSkillEffectListIndex = 0;
	int skillList_embedSkillEffectListSize = skillList_embedSkillEffectList.length;
	for(skillList_embedSkillEffectListIndex=0; skillList_embedSkillEffectListIndex<skillList_embedSkillEffectListSize; skillList_embedSkillEffectListIndex++){

	int skillList_embedSkillEffectList_effectItemId = skillList_embedSkillEffectList[skillList_embedSkillEffectListIndex].getEffectItemId();

	// 技能效果道具Id
	writeInteger(skillList_embedSkillEffectList_effectItemId);

	int skillList_embedSkillEffectList_level = skillList_embedSkillEffectList[skillList_embedSkillEffectListIndex].getLevel();

	// 技能效果等级
	writeInteger(skillList_embedSkillEffectList_level);

	int skillList_embedSkillEffectList_exp = skillList_embedSkillEffectList[skillList_embedSkillEffectListIndex].getExp();

	// 技能效果经验
	writeInteger(skillList_embedSkillEffectList_exp);
	}
	//end
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PET_FRIEND_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PET_FRIEND_INFO";
	}

	public int getTplId(){
		return tplId;
	}
		
	public void setTplId(int tplId){
		this.tplId = tplId;
	}

	public int getLevel(){
		return level;
	}
		
	public void setLevel(int level){
		this.level = level;
	}

	public String getProps(){
		return props;
	}
		
	public void setProps(String props){
		this.props = props;
	}

	public com.imop.lj.common.model.pet.SkillInfo[] getSkillList(){
		return skillList;
	}

	public void setSkillList(com.imop.lj.common.model.pet.SkillInfo[] skillList){
		this.skillList = skillList;
	}	
}