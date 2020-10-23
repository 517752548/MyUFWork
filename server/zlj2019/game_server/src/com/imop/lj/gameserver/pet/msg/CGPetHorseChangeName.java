package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 骑宠改名
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetHorseChangeName extends CGMessage{
	
	/** 骑宠唯一Id */
	private long petId;
	/** 名字 */
	private String newName;
	
	public CGPetHorseChangeName (){
	}
	
	public CGPetHorseChangeName (
			long petId,
			String newName ){
			this.petId = petId;
			this.newName = newName;
	}
	
	@Override
	protected boolean readImpl() {

	// 骑宠唯一Id
	long _petId = readLong();
	//end


	// 名字
	String _newName = readString();
	//end



			this.petId = _petId;
			this.newName = _newName;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 骑宠唯一Id
	writeLong(petId);


	// 名字
	writeString(newName);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_HORSE_CHANGE_NAME;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_HORSE_CHANGE_NAME";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}

	public String getNewName(){
		return newName;
	}
		
	public void setNewName(String newName){
		this.newName = newName;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetHorseChangeName(this.getSession().getPlayer(), this);
	}
}