package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 请求单个伙伴的信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetFriendInfo extends CGMessage{
	
	/** 伙伴模板Id */
	private int tplId;
	
	public CGPetFriendInfo (){
	}
	
	public CGPetFriendInfo (
			int tplId ){
			this.tplId = tplId;
	}
	
	@Override
	protected boolean readImpl() {

	// 伙伴模板Id
	int _tplId = readInteger();
	//end



			this.tplId = _tplId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 伙伴模板Id
	writeInteger(tplId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_FRIEND_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_FRIEND_INFO";
	}

	public int getTplId(){
		return tplId;
	}
		
	public void setTplId(int tplId){
		this.tplId = tplId;
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetFriendInfo(this.getSession().getPlayer(), this);
	}
}