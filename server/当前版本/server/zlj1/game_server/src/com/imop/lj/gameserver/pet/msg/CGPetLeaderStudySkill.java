package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 主将学习技能
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetLeaderStudySkill extends CGMessage{
	
	/** 技能书道具Id */
	private int itemTplId;
	
	public CGPetLeaderStudySkill (){
	}
	
	public CGPetLeaderStudySkill (
			int itemTplId ){
			this.itemTplId = itemTplId;
	}
	
	@Override
	protected boolean readImpl() {

	// 技能书道具Id
	int _itemTplId = readInteger();
	//end



			this.itemTplId = _itemTplId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 技能书道具Id
	writeInteger(itemTplId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_LEADER_STUDY_SKILL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_LEADER_STUDY_SKILL";
	}

	public int getItemTplId(){
		return itemTplId;
	}
		
	public void setItemTplId(int itemTplId){
		this.itemTplId = itemTplId;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetLeaderStudySkill(this.getSession().getPlayer(), this);
	}
}