package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 切换正在使用的阵容
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetFriendChangeArray extends CGMessage{
	
	/** 切换的阵容索引，从0开始计数 */
	private int arrayIndex;
	
	public CGPetFriendChangeArray (){
	}
	
	public CGPetFriendChangeArray (
			int arrayIndex ){
			this.arrayIndex = arrayIndex;
	}
	
	@Override
	protected boolean readImpl() {

	// 切换的阵容索引，从0开始计数
	int _arrayIndex = readInteger();
	//end



			this.arrayIndex = _arrayIndex;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 切换的阵容索引，从0开始计数
	writeInteger(arrayIndex);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_FRIEND_CHANGE_ARRAY;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_FRIEND_CHANGE_ARRAY";
	}

	public int getArrayIndex(){
		return arrayIndex;
	}
		
	public void setArrayIndex(int arrayIndex){
		this.arrayIndex = arrayIndex;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetFriendChangeArray(this.getSession().getPlayer(), this);
	}
}