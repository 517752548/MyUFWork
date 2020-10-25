package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 设置骑宠资质丹
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPutonPetHorsePropItem extends CGMessage{
	
	/** 武将唯一Id */
	private long petId;
	/** 6强壮,7敏捷,8智力,9信仰,10耐力 */
	private int targetIndex;
	/** 资质丹索引 */
	private int propItemIndex;
	
	public CGPutonPetHorsePropItem (){
	}
	
	public CGPutonPetHorsePropItem (
			long petId,
			int targetIndex,
			int propItemIndex ){
			this.petId = petId;
			this.targetIndex = targetIndex;
			this.propItemIndex = propItemIndex;
	}
	
	@Override
	protected boolean readImpl() {

	// 武将唯一Id
	long _petId = readLong();
	//end


	// 6强壮,7敏捷,8智力,9信仰,10耐力
	int _targetIndex = readInteger();
	//end


	// 资质丹索引
	int _propItemIndex = readInteger();
	//end



			this.petId = _petId;
			this.targetIndex = _targetIndex;
			this.propItemIndex = _propItemIndex;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 武将唯一Id
	writeLong(petId);


	// 6强壮,7敏捷,8智力,9信仰,10耐力
	writeInteger(targetIndex);


	// 资质丹索引
	writeInteger(propItemIndex);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PUTON_PET_HORSE_PROP_ITEM;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PUTON_PET_HORSE_PROP_ITEM";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}

	public int getTargetIndex(){
		return targetIndex;
	}
		
	public void setTargetIndex(int targetIndex){
		this.targetIndex = targetIndex;
	}

	public int getPropItemIndex(){
		return propItemIndex;
	}
		
	public void setPropItemIndex(int propItemIndex){
		this.propItemIndex = propItemIndex;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePutonPetHorsePropItem(this.getSession().getPlayer(), this);
	}
}