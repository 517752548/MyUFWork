package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 伙伴解锁
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetFriendUnlock extends CGMessage{
	
	/** 伙伴模板Id */
	private int tplId;
	/** 解锁方式，分别为1(7d)，2(30d)，3(forever) */
	private int unlockId;
	
	public CGPetFriendUnlock (){
	}
	
	public CGPetFriendUnlock (
			int tplId,
			int unlockId ){
			this.tplId = tplId;
			this.unlockId = unlockId;
	}
	
	@Override
	protected boolean readImpl() {

	// 伙伴模板Id
	int _tplId = readInteger();
	//end


	// 解锁方式，分别为1(7d)，2(30d)，3(forever)
	int _unlockId = readInteger();
	//end



			this.tplId = _tplId;
			this.unlockId = _unlockId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 伙伴模板Id
	writeInteger(tplId);


	// 解锁方式，分别为1(7d)，2(30d)，3(forever)
	writeInteger(unlockId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_FRIEND_UNLOCK;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_FRIEND_UNLOCK";
	}

	public int getTplId(){
		return tplId;
	}
		
	public void setTplId(int tplId){
		this.tplId = tplId;
	}

	public int getUnlockId(){
		return unlockId;
	}
		
	public void setUnlockId(int unlockId){
		this.unlockId = unlockId;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetFriendUnlock(this.getSession().getPlayer(), this);
	}
}