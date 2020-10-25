package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.common.handler.CommonHandlerFactory;

/**
 * 查看他人宠物信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOfflineUserPetInfo extends CGMessage{
	
	/** 玩家角色Id */
	private long roleId;
	/** 宠物Id */
	private long petId;
	
	public CGOfflineUserPetInfo (){
	}
	
	public CGOfflineUserPetInfo (
			long roleId,
			long petId ){
			this.roleId = roleId;
			this.petId = petId;
	}
	
	@Override
	protected boolean readImpl() {

	// 玩家角色Id
	long _roleId = readLong();
	//end


	// 宠物Id
	long _petId = readLong();
	//end



			this.roleId = _roleId;
			this.petId = _petId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 玩家角色Id
	writeLong(roleId);


	// 宠物Id
	writeLong(petId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_OFFLINE_USER_PET_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "CG_OFFLINE_USER_PET_INFO";
	}

	public long getRoleId(){
		return roleId;
	}
		
	public void setRoleId(long roleId){
		this.roleId = roleId;
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}


	@Override
	public void execute() {
		CommonHandlerFactory.getHandler().handleOfflineUserPetInfo(this.getSession().getPlayer(), this);
	}
}