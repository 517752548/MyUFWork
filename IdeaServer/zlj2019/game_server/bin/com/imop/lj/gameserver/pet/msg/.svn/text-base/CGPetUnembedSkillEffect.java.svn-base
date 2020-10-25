package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 主将技能卸下仙符
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetUnembedSkillEffect extends CGMessage{
	
	/** 技能Id */
	private int skillId;
	/** 镶嵌位置，从1开始计数 */
	private int posId;
	
	public CGPetUnembedSkillEffect (){
	}
	
	public CGPetUnembedSkillEffect (
			int skillId,
			int posId ){
			this.skillId = skillId;
			this.posId = posId;
	}
	
	@Override
	protected boolean readImpl() {

	// 技能Id
	int _skillId = readInteger();
	//end


	// 镶嵌位置，从1开始计数
	int _posId = readInteger();
	//end



			this.skillId = _skillId;
			this.posId = _posId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 技能Id
	writeInteger(skillId);


	// 镶嵌位置，从1开始计数
	writeInteger(posId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_UNEMBED_SKILL_EFFECT;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_UNEMBED_SKILL_EFFECT";
	}

	public int getSkillId(){
		return skillId;
	}
		
	public void setSkillId(int skillId){
		this.skillId = skillId;
	}

	public int getPosId(){
		return posId;
	}
		
	public void setPosId(int posId){
		this.posId = posId;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetUnembedSkillEffect(this.getSession().getPlayer(), this);
	}
}