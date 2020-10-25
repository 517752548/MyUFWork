package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 骑宠灵魂链接宠物
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetHorseSoulLinkPet extends GCMessage{
	
	/** 宠物灵魂链接信息 */
	private com.imop.lj.common.model.pet.PetSoulLinkInfo[] petSoulLinkInfoList;

	public GCPetHorseSoulLinkPet (){
	}
	
	public GCPetHorseSoulLinkPet (
			com.imop.lj.common.model.pet.PetSoulLinkInfo[] petSoulLinkInfoList ){
			this.petSoulLinkInfoList = petSoulLinkInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 宠物灵魂链接信息
	int petSoulLinkInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.pet.PetSoulLinkInfo[] _petSoulLinkInfoList = new com.imop.lj.common.model.pet.PetSoulLinkInfo[petSoulLinkInfoListSize];
	int petSoulLinkInfoListIndex = 0;
	for(petSoulLinkInfoListIndex=0; petSoulLinkInfoListIndex<petSoulLinkInfoListSize; petSoulLinkInfoListIndex++){
		_petSoulLinkInfoList[petSoulLinkInfoListIndex] = new com.imop.lj.common.model.pet.PetSoulLinkInfo();
	// petId
	long _petSoulLinkInfoList_petId = readLong();
	//end
	_petSoulLinkInfoList[petSoulLinkInfoListIndex].setPetId (_petSoulLinkInfoList_petId);

	// 灵魂链接骑宠ID, 0-无灵魂链接
	long _petSoulLinkInfoList_soulLinkPetHorseId = readLong();
	//end
	_petSoulLinkInfoList[petSoulLinkInfoListIndex].setSoulLinkPetHorseId (_petSoulLinkInfoList_soulLinkPetHorseId);
	}
	//end



		this.petSoulLinkInfoList = _petSoulLinkInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 宠物灵魂链接信息
	writeShort(petSoulLinkInfoList.length);
	int petSoulLinkInfoListIndex = 0;
	int petSoulLinkInfoListSize = petSoulLinkInfoList.length;
	for(petSoulLinkInfoListIndex=0; petSoulLinkInfoListIndex<petSoulLinkInfoListSize; petSoulLinkInfoListIndex++){

	long petSoulLinkInfoList_petId = petSoulLinkInfoList[petSoulLinkInfoListIndex].getPetId();

	// petId
	writeLong(petSoulLinkInfoList_petId);

	long petSoulLinkInfoList_soulLinkPetHorseId = petSoulLinkInfoList[petSoulLinkInfoListIndex].getSoulLinkPetHorseId();

	// 灵魂链接骑宠ID, 0-无灵魂链接
	writeLong(petSoulLinkInfoList_soulLinkPetHorseId);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PET_HORSE_SOUL_LINK_PET;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PET_HORSE_SOUL_LINK_PET";
	}

	public com.imop.lj.common.model.pet.PetSoulLinkInfo[] getPetSoulLinkInfoList(){
		return petSoulLinkInfoList;
	}

	public void setPetSoulLinkInfoList(com.imop.lj.common.model.pet.PetSoulLinkInfo[] petSoulLinkInfoList){
		this.petSoulLinkInfoList = petSoulLinkInfoList;
	}	
}