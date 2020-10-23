package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 主将技能镶嵌仙符或更换仙符
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetEmbedSkillEffect extends CGMessage{
	
	/** 技能Id */
	private int skillId;
	/** 镶嵌位置，从1开始计数 */
	private int posId;
	/** 要镶嵌的技能书道具索引 */
	private int itemIndex;
	
	public CGPetEmbedSkillEffect (){
	}
	
	public CGPetEmbedSkillEffect (
			int skillId,
			int posId,
			int itemIndex ){
			this.skillId = skillId;
			this.posId = posId;
			this.itemIndex = itemIndex;
	}
	
	@Override
	protected boolean readImpl() {

	// 技能Id
	int _skillId = readInteger();
	//end


	// 镶嵌位置，从1开始计数
	int _posId = readInteger();
	//end


	// 要镶嵌的技能书道具索引
	int _itemIndex = readInteger();
	//end



			this.skillId = _skillId;
			this.posId = _posId;
			this.itemIndex = _itemIndex;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 技能Id
	writeInteger(skillId);


	// 镶嵌位置，从1开始计数
	writeInteger(posId);


	// 要镶嵌的技能书道具索引
	writeInteger(itemIndex);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_EMBED_SKILL_EFFECT;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_EMBED_SKILL_EFFECT";
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

	public int getItemIndex(){
		return itemIndex;
	}
		
	public void setItemIndex(int itemIndex){
		this.itemIndex = itemIndex;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetEmbedSkillEffect(this.getSession().getPlayer(), this);
	}
}