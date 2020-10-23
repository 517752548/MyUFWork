package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 人物技能快捷栏调整位置
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetSkillShortcutChangePosition extends CGMessage{
	
	/** 武将唯一Id */
	private long petId;
	/** 技能ID */
	private int skillId;
	/** 目标位置索引，从0开始计数 */
	private int targetPosIndex;
	
	public CGPetSkillShortcutChangePosition (){
	}
	
	public CGPetSkillShortcutChangePosition (
			long petId,
			int skillId,
			int targetPosIndex ){
			this.petId = petId;
			this.skillId = skillId;
			this.targetPosIndex = targetPosIndex;
	}
	
	@Override
	protected boolean readImpl() {

	// 武将唯一Id
	long _petId = readLong();
	//end


	// 技能ID
	int _skillId = readInteger();
	//end


	// 目标位置索引，从0开始计数
	int _targetPosIndex = readInteger();
	//end



			this.petId = _petId;
			this.skillId = _skillId;
			this.targetPosIndex = _targetPosIndex;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 武将唯一Id
	writeLong(petId);


	// 技能ID
	writeInteger(skillId);


	// 目标位置索引，从0开始计数
	writeInteger(targetPosIndex);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_SKILL_SHORTCUT_CHANGE_POSITION;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_SKILL_SHORTCUT_CHANGE_POSITION";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}

	public int getSkillId(){
		return skillId;
	}
		
	public void setSkillId(int skillId){
		this.skillId = skillId;
	}

	public int getTargetPosIndex(){
		return targetPosIndex;
	}
		
	public void setTargetPosIndex(int targetPosIndex){
		this.targetPosIndex = targetPosIndex;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetSkillShortcutChangePosition(this.getSession().getPlayer(), this);
	}
}