package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 取消技能快捷栏
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetSkillOffShortcut extends CGMessage{
	
	/** 武将唯一Id */
	private long petId;
	/** 目标位置索引，从0开始计数 */
	private int targetPosIndex;
	
	public CGPetSkillOffShortcut (){
	}
	
	public CGPetSkillOffShortcut (
			long petId,
			int targetPosIndex ){
			this.petId = petId;
			this.targetPosIndex = targetPosIndex;
	}
	
	@Override
	protected boolean readImpl() {

	// 武将唯一Id
	long _petId = readLong();
	//end


	// 目标位置索引，从0开始计数
	int _targetPosIndex = readInteger();
	//end



			this.petId = _petId;
			this.targetPosIndex = _targetPosIndex;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 武将唯一Id
	writeLong(petId);


	// 目标位置索引，从0开始计数
	writeInteger(targetPosIndex);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_SKILL_OFF_SHORTCUT;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_SKILL_OFF_SHORTCUT";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}

	public int getTargetPosIndex(){
		return targetPosIndex;
	}
		
	public void setTargetPosIndex(int targetPosIndex){
		this.targetPosIndex = targetPosIndex;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetSkillOffShortcut(this.getSession().getPlayer(), this);
	}
}