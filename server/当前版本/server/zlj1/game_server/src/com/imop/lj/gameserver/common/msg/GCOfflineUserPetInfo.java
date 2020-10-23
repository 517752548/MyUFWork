package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 查看他人宠物信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOfflineUserPetInfo extends GCMessage{
	
	/** 玩家角色Id */
	private long roleId;
	/** 宠物Id */
	private long petId;
	/** 宠物信息json */
	private String petInfoJson;

	public GCOfflineUserPetInfo (){
	}
	
	public GCOfflineUserPetInfo (
			long roleId,
			long petId,
			String petInfoJson ){
			this.roleId = roleId;
			this.petId = petId;
			this.petInfoJson = petInfoJson;
	}

	@Override
	protected boolean readImpl() {

	// 玩家角色Id
	long _roleId = readLong();
	//end


	// 宠物Id
	long _petId = readLong();
	//end


	// 宠物信息json
	String _petInfoJson = readString();
	//end



		this.roleId = _roleId;
		this.petId = _petId;
		this.petInfoJson = _petInfoJson;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 玩家角色Id
	writeLong(roleId);


	// 宠物Id
	writeLong(petId);


	// 宠物信息json
	writeString(petInfoJson);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_OFFLINE_USER_PET_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_OFFLINE_USER_PET_INFO";
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

	public String getPetInfoJson(){
		return petInfoJson;
	}
		
	public void setPetInfoJson(String petInfoJson){
		this.petInfoJson = petInfoJson;
	}
}