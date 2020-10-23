package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 主将技能开启仙符格子
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetSkillEffectOpenPosition extends CGMessage{
	
	/** 技能Id */
	private int skillId;
	
	public CGPetSkillEffectOpenPosition (){
	}
	
	public CGPetSkillEffectOpenPosition (
			int skillId ){
			this.skillId = skillId;
	}
	
	@Override
	protected boolean readImpl() {

	// 技能Id
	int _skillId = readInteger();
	//end



			this.skillId = _skillId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 技能Id
	writeInteger(skillId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_SKILL_EFFECT_OPEN_POSITION;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_SKILL_EFFECT_OPEN_POSITION";
	}

	public int getSkillId(){
		return skillId;
	}
		
	public void setSkillId(int skillId){
		this.skillId = skillId;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetSkillEffectOpenPosition(this.getSession().getPlayer(), this);
	}
}