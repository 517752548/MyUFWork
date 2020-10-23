package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 主将技能仙符升级
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetSkillEffectUplevel extends CGMessage{
	
	/** 技能Id */
	private int skillId;
	/** 要升级的位置，从1开始计数 */
	private int posId;
	/** 选择的技能书道具索引列表 */
	private int[] itemIndexList;
	
	public CGPetSkillEffectUplevel (){
	}
	
	public CGPetSkillEffectUplevel (
			int skillId,
			int posId,
			int[] itemIndexList ){
			this.skillId = skillId;
			this.posId = posId;
			this.itemIndexList = itemIndexList;
	}
	
	@Override
	protected boolean readImpl() {

	// 技能Id
	int _skillId = readInteger();
	//end


	// 要升级的位置，从1开始计数
	int _posId = readInteger();
	//end


	// 选择的技能书道具索引列表
	int itemIndexListSize = readUnsignedShort();
	int[] _itemIndexList = new int[itemIndexListSize];
	int itemIndexListIndex = 0;
	for(itemIndexListIndex=0; itemIndexListIndex<itemIndexListSize; itemIndexListIndex++){
		_itemIndexList[itemIndexListIndex] = readInteger();
	}//end



			this.skillId = _skillId;
			this.posId = _posId;
			this.itemIndexList = _itemIndexList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 技能Id
	writeInteger(skillId);


	// 要升级的位置，从1开始计数
	writeInteger(posId);


	// 选择的技能书道具索引列表
	writeShort(itemIndexList.length);
	int itemIndexListSize = itemIndexList.length;
	int itemIndexListIndex = 0;
	for(itemIndexListIndex=0; itemIndexListIndex<itemIndexListSize; itemIndexListIndex++){
		writeInteger(itemIndexList [ itemIndexListIndex ]);
	}//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_SKILL_EFFECT_UPLEVEL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_SKILL_EFFECT_UPLEVEL";
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

	public int[] getItemIndexList(){
		return itemIndexList;
	}

	public void setItemIndexList(int[] itemIndexList){
		this.itemIndexList = itemIndexList;
	}	


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetSkillEffectUplevel(this.getSession().getPlayer(), this);
	}
}