package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 查看他人基础信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOfflineUserBaseInfo extends GCMessage{
	
	/** 玩家角色Id */
	private long roleId;
	/** 玩家角色基础信息json */
	private String roleBaseInfoJson;

	public GCOfflineUserBaseInfo (){
	}
	
	public GCOfflineUserBaseInfo (
			long roleId,
			String roleBaseInfoJson ){
			this.roleId = roleId;
			this.roleBaseInfoJson = roleBaseInfoJson;
	}

	@Override
	protected boolean readImpl() {

	// 玩家角色Id
	long _roleId = readLong();
	//end


	// 玩家角色基础信息json
	String _roleBaseInfoJson = readString();
	//end



		this.roleId = _roleId;
		this.roleBaseInfoJson = _roleBaseInfoJson;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 玩家角色Id
	writeLong(roleId);


	// 玩家角色基础信息json
	writeString(roleBaseInfoJson);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_OFFLINE_USER_BASE_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_OFFLINE_USER_BASE_INFO";
	}

	public long getRoleId(){
		return roleId;
	}
		
	public void setRoleId(long roleId){
		this.roleId = roleId;
	}

	public String getRoleBaseInfoJson(){
		return roleBaseInfoJson;
	}
		
	public void setRoleBaseInfoJson(String roleBaseInfoJson){
		this.roleBaseInfoJson = roleBaseInfoJson;
	}
}