package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 骑宠学习普通技能
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetHorseStudyNormalSkill extends CGMessage{
	
	/** 武将唯一Id */
	private long petId;
	/** 技能书道具Id */
	private int itemTplId;
	
	public CGPetHorseStudyNormalSkill (){
	}
	
	public CGPetHorseStudyNormalSkill (
			long petId,
			int itemTplId ){
			this.petId = petId;
			this.itemTplId = itemTplId;
	}
	
	@Override
	protected boolean readImpl() {

	// 武将唯一Id
	long _petId = readLong();
	//end


	// 技能书道具Id
	int _itemTplId = readInteger();
	//end



			this.petId = _petId;
			this.itemTplId = _itemTplId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 武将唯一Id
	writeLong(petId);


	// 技能书道具Id
	writeInteger(itemTplId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_HORSE_STUDY_NORMAL_SKILL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_HORSE_STUDY_NORMAL_SKILL";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}

	public int getItemTplId(){
		return itemTplId;
	}
		
	public void setItemTplId(int itemTplId){
		this.itemTplId = itemTplId;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetHorseStudyNormalSkill(this.getSession().getPlayer(), this);
	}
}