package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 骑宠灵魂链接宠物
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetHorseSoulLinkPet extends CGMessage{
	
	/** 骑宠Id */
	private long petHorseId;
	/** 宠物Id */
	private long[] petId;
	/** 1增加,0取消 */
	private int[] flag;
	
	public CGPetHorseSoulLinkPet (){
	}
	
	public CGPetHorseSoulLinkPet (
			long petHorseId,
			long[] petId,
			int[] flag ){
			this.petHorseId = petHorseId;
			this.petId = petId;
			this.flag = flag;
	}
	
	@Override
	protected boolean readImpl() {

	// 骑宠Id
	long _petHorseId = readLong();
	//end


	// 宠物Id
	int petIdSize = readUnsignedShort();
	long[] _petId = new long[petIdSize];
	int petIdIndex = 0;
	for(petIdIndex=0; petIdIndex<petIdSize; petIdIndex++){
		_petId[petIdIndex] = readLong();
	}//end


	// 1增加,0取消
	int flagSize = readUnsignedShort();
	int[] _flag = new int[flagSize];
	int flagIndex = 0;
	for(flagIndex=0; flagIndex<flagSize; flagIndex++){
		_flag[flagIndex] = readInteger();
	}//end



			this.petHorseId = _petHorseId;
			this.petId = _petId;
			this.flag = _flag;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 骑宠Id
	writeLong(petHorseId);


	// 宠物Id
	writeShort(petId.length);
	int petIdSize = petId.length;
	int petIdIndex = 0;
	for(petIdIndex=0; petIdIndex<petIdSize; petIdIndex++){
		writeLong(petId [ petIdIndex ]);
	}//end


	// 1增加,0取消
	writeShort(flag.length);
	int flagSize = flag.length;
	int flagIndex = 0;
	for(flagIndex=0; flagIndex<flagSize; flagIndex++){
		writeInteger(flag [ flagIndex ]);
	}//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_HORSE_SOUL_LINK_PET;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_HORSE_SOUL_LINK_PET";
	}

	public long getPetHorseId(){
		return petHorseId;
	}
		
	public void setPetHorseId(long petHorseId){
		this.petHorseId = petHorseId;
	}

	public long[] getPetId(){
		return petId;
	}

	public void setPetId(long[] petId){
		this.petId = petId;
	}	

	public int[] getFlag(){
		return flag;
	}

	public void setFlag(int[] flag){
		this.flag = flag;
	}	


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetHorseSoulLinkPet(this.getSession().getPlayer(), this);
	}
}