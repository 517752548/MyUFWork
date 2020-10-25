package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 伙伴解锁情况列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetFriendUnlockList extends GCMessage{
	
	/** 伙伴解锁情况列表 */
	private com.imop.lj.common.model.pet.PetFriendUnlockInfo[] petFriendUnlockInfoList;

	public GCPetFriendUnlockList (){
	}
	
	public GCPetFriendUnlockList (
			com.imop.lj.common.model.pet.PetFriendUnlockInfo[] petFriendUnlockInfoList ){
			this.petFriendUnlockInfoList = petFriendUnlockInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 伙伴解锁情况列表
	int petFriendUnlockInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.pet.PetFriendUnlockInfo[] _petFriendUnlockInfoList = new com.imop.lj.common.model.pet.PetFriendUnlockInfo[petFriendUnlockInfoListSize];
	int petFriendUnlockInfoListIndex = 0;
	for(petFriendUnlockInfoListIndex=0; petFriendUnlockInfoListIndex<petFriendUnlockInfoListSize; petFriendUnlockInfoListIndex++){
		_petFriendUnlockInfoList[petFriendUnlockInfoListIndex] = new com.imop.lj.common.model.pet.PetFriendUnlockInfo();
	// 伙伴模板Id
	int _petFriendUnlockInfoList_tplId = readInteger();
	//end
	_petFriendUnlockInfoList[petFriendUnlockInfoListIndex].setTplId (_petFriendUnlockInfoList_tplId);

	// 剩余的有效时间， -1表示永久有效，0已过期
	long _petFriendUnlockInfoList_leftTime = readLong();
	//end
	_petFriendUnlockInfoList[petFriendUnlockInfoListIndex].setLeftTime (_petFriendUnlockInfoList_leftTime);
	}
	//end



		this.petFriendUnlockInfoList = _petFriendUnlockInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 伙伴解锁情况列表
	writeShort(petFriendUnlockInfoList.length);
	int petFriendUnlockInfoListIndex = 0;
	int petFriendUnlockInfoListSize = petFriendUnlockInfoList.length;
	for(petFriendUnlockInfoListIndex=0; petFriendUnlockInfoListIndex<petFriendUnlockInfoListSize; petFriendUnlockInfoListIndex++){

	int petFriendUnlockInfoList_tplId = petFriendUnlockInfoList[petFriendUnlockInfoListIndex].getTplId();

	// 伙伴模板Id
	writeInteger(petFriendUnlockInfoList_tplId);

	long petFriendUnlockInfoList_leftTime = petFriendUnlockInfoList[petFriendUnlockInfoListIndex].getLeftTime();

	// 剩余的有效时间， -1表示永久有效，0已过期
	writeLong(petFriendUnlockInfoList_leftTime);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PET_FRIEND_UNLOCK_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PET_FRIEND_UNLOCK_LIST";
	}

	public com.imop.lj.common.model.pet.PetFriendUnlockInfo[] getPetFriendUnlockInfoList(){
		return petFriendUnlockInfoList;
	}

	public void setPetFriendUnlockInfoList(com.imop.lj.common.model.pet.PetFriendUnlockInfo[] petFriendUnlockInfoList){
		this.petFriendUnlockInfoList = petFriendUnlockInfoList;
	}	
}