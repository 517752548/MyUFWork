package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 伙伴上阵
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetFriendPutonArray extends CGMessage{
	
	/** 阵容索引，从0开始计数 */
	private int arrayIndex;
	/** 伙伴模板Id */
	private int tplId;
	/** 目标位置索引，从0开始计数 */
	private int targetPosIndex;
	
	public CGPetFriendPutonArray (){
	}
	
	public CGPetFriendPutonArray (
			int arrayIndex,
			int tplId,
			int targetPosIndex ){
			this.arrayIndex = arrayIndex;
			this.tplId = tplId;
			this.targetPosIndex = targetPosIndex;
	}
	
	@Override
	protected boolean readImpl() {

	// 阵容索引，从0开始计数
	int _arrayIndex = readInteger();
	//end


	// 伙伴模板Id
	int _tplId = readInteger();
	//end


	// 目标位置索引，从0开始计数
	int _targetPosIndex = readInteger();
	//end



			this.arrayIndex = _arrayIndex;
			this.tplId = _tplId;
			this.targetPosIndex = _targetPosIndex;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 阵容索引，从0开始计数
	writeInteger(arrayIndex);


	// 伙伴模板Id
	writeInteger(tplId);


	// 目标位置索引，从0开始计数
	writeInteger(targetPosIndex);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_FRIEND_PUTON_ARRAY;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_FRIEND_PUTON_ARRAY";
	}

	public int getArrayIndex(){
		return arrayIndex;
	}
		
	public void setArrayIndex(int arrayIndex){
		this.arrayIndex = arrayIndex;
	}

	public int getTplId(){
		return tplId;
	}
		
	public void setTplId(int tplId){
		this.tplId = tplId;
	}

	public int getTargetPosIndex(){
		return targetPosIndex;
	}
		
	public void setTargetPosIndex(int targetPosIndex){
		this.targetPosIndex = targetPosIndex;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetFriendPutonArray(this.getSession().getPlayer(), this);
	}
}