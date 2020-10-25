package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 伙伴下阵
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetFriendOffArray extends CGMessage{
	
	/** 阵容索引，从0开始计数 */
	private int arrayIndex;
	/** 目标位置索引，从0开始计数 */
	private int targetPosIndex;
	
	public CGPetFriendOffArray (){
	}
	
	public CGPetFriendOffArray (
			int arrayIndex,
			int targetPosIndex ){
			this.arrayIndex = arrayIndex;
			this.targetPosIndex = targetPosIndex;
	}
	
	@Override
	protected boolean readImpl() {

	// 阵容索引，从0开始计数
	int _arrayIndex = readInteger();
	//end


	// 目标位置索引，从0开始计数
	int _targetPosIndex = readInteger();
	//end



			this.arrayIndex = _arrayIndex;
			this.targetPosIndex = _targetPosIndex;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 阵容索引，从0开始计数
	writeInteger(arrayIndex);


	// 目标位置索引，从0开始计数
	writeInteger(targetPosIndex);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_FRIEND_OFF_ARRAY;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_FRIEND_OFF_ARRAY";
	}

	public int getArrayIndex(){
		return arrayIndex;
	}
		
	public void setArrayIndex(int arrayIndex){
		this.arrayIndex = arrayIndex;
	}

	public int getTargetPosIndex(){
		return targetPosIndex;
	}
		
	public void setTargetPosIndex(int targetPosIndex){
		this.targetPosIndex = targetPosIndex;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetFriendOffArray(this.getSession().getPlayer(), this);
	}
}