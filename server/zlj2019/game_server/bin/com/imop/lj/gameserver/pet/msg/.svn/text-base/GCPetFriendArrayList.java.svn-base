package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 伙伴阵容列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetFriendArrayList extends GCMessage{
	
	/** 当前使用的阵容索引，从0开始计数 */
	private int curArrayIndex;
	/** 伙伴阵容列表 */
	private com.imop.lj.common.model.pet.PetFriendArrayInfo[] petFriendArrayInfoList;

	public GCPetFriendArrayList (){
	}
	
	public GCPetFriendArrayList (
			int curArrayIndex,
			com.imop.lj.common.model.pet.PetFriendArrayInfo[] petFriendArrayInfoList ){
			this.curArrayIndex = curArrayIndex;
			this.petFriendArrayInfoList = petFriendArrayInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 当前使用的阵容索引，从0开始计数
	int _curArrayIndex = readInteger();
	//end


	// 伙伴阵容列表
	int petFriendArrayInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.pet.PetFriendArrayInfo[] _petFriendArrayInfoList = new com.imop.lj.common.model.pet.PetFriendArrayInfo[petFriendArrayInfoListSize];
	int petFriendArrayInfoListIndex = 0;
	for(petFriendArrayInfoListIndex=0; petFriendArrayInfoListIndex<petFriendArrayInfoListSize; petFriendArrayInfoListIndex++){
		_petFriendArrayInfoList[petFriendArrayInfoListIndex] = new com.imop.lj.common.model.pet.PetFriendArrayInfo();
	// 伙伴模板Id列表
	int petFriendArrayInfoList_tplIdListSize = readUnsignedShort();
	int[] _petFriendArrayInfoList_tplIdList = new int[petFriendArrayInfoList_tplIdListSize];
	int petFriendArrayInfoList_tplIdListIndex = 0;
	for(petFriendArrayInfoList_tplIdListIndex=0; petFriendArrayInfoList_tplIdListIndex<petFriendArrayInfoList_tplIdListSize; petFriendArrayInfoList_tplIdListIndex++){
		_petFriendArrayInfoList_tplIdList[petFriendArrayInfoList_tplIdListIndex] = readInteger();
	}//end
	_petFriendArrayInfoList[petFriendArrayInfoListIndex].setTplIdList (_petFriendArrayInfoList_tplIdList);

	// 阵法等级
	int _petFriendArrayInfoList_arrLevel = readInteger();
	//end
	_petFriendArrayInfoList[petFriendArrayInfoListIndex].setArrLevel (_petFriendArrayInfoList_arrLevel);

	// 阵法id
	int _petFriendArrayInfoList_arrId = readInteger();
	//end
	_petFriendArrayInfoList[petFriendArrayInfoListIndex].setArrId (_petFriendArrayInfoList_arrId);
	}
	//end



		this.curArrayIndex = _curArrayIndex;
		this.petFriendArrayInfoList = _petFriendArrayInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 当前使用的阵容索引，从0开始计数
	writeInteger(curArrayIndex);


	// 伙伴阵容列表
	writeShort(petFriendArrayInfoList.length);
	int petFriendArrayInfoListIndex = 0;
	int petFriendArrayInfoListSize = petFriendArrayInfoList.length;
	for(petFriendArrayInfoListIndex=0; petFriendArrayInfoListIndex<petFriendArrayInfoListSize; petFriendArrayInfoListIndex++){

	int[] petFriendArrayInfoList_tplIdList = petFriendArrayInfoList[petFriendArrayInfoListIndex].getTplIdList();

	// 伙伴模板Id列表
	writeShort(petFriendArrayInfoList_tplIdList.length);
	int petFriendArrayInfoList_tplIdListSize = petFriendArrayInfoList_tplIdList.length;
	int petFriendArrayInfoList_tplIdListIndex = 0;
	for(petFriendArrayInfoList_tplIdListIndex=0; petFriendArrayInfoList_tplIdListIndex<petFriendArrayInfoList_tplIdListSize; petFriendArrayInfoList_tplIdListIndex++){
		writeInteger(petFriendArrayInfoList_tplIdList [ petFriendArrayInfoList_tplIdListIndex ]);
	}//end

	int petFriendArrayInfoList_arrLevel = petFriendArrayInfoList[petFriendArrayInfoListIndex].getArrLevel();

	// 阵法等级
	writeInteger(petFriendArrayInfoList_arrLevel);

	int petFriendArrayInfoList_arrId = petFriendArrayInfoList[petFriendArrayInfoListIndex].getArrId();

	// 阵法id
	writeInteger(petFriendArrayInfoList_arrId);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PET_FRIEND_ARRAY_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PET_FRIEND_ARRAY_LIST";
	}

	public int getCurArrayIndex(){
		return curArrayIndex;
	}
		
	public void setCurArrayIndex(int curArrayIndex){
		this.curArrayIndex = curArrayIndex;
	}

	public com.imop.lj.common.model.pet.PetFriendArrayInfo[] getPetFriendArrayInfoList(){
		return petFriendArrayInfoList;
	}

	public void setPetFriendArrayInfoList(com.imop.lj.common.model.pet.PetFriendArrayInfo[] petFriendArrayInfoList){
		this.petFriendArrayInfoList = petFriendArrayInfoList;
	}	
}