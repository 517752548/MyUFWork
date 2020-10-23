package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 查看他人主将信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOfflineUserLeaderInfo extends GCMessage{
	
	/** 玩家角色Id */
	private long roleId;
	/** 主将信息json */
	private String roleInfoJson;

	public GCOfflineUserLeaderInfo (){
	}
	
	public GCOfflineUserLeaderInfo (
			long roleId,
			String roleInfoJson ){
			this.roleId = roleId;
			this.roleInfoJson = roleInfoJson;
	}

	@Override
	protected boolean readImpl() {

	// 玩家角色Id
	long _roleId = readLong();
	//end


	// 主将信息json
	String _roleInfoJson = readString();
	//end



		this.roleId = _roleId;
		this.roleInfoJson = _roleInfoJson;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 玩家角色Id
	writeLong(roleId);


	// 主将信息json
	writeString(roleInfoJson);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_OFFLINE_USER_LEADER_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_OFFLINE_USER_LEADER_INFO";
	}

	public long getRoleId(){
		return roleId;
	}
		
	public void setRoleId(long roleId){
		this.roleId = roleId;
	}

	public String getRoleInfoJson(){
		return roleInfoJson;
	}
		
	public void setRoleInfoJson(String roleInfoJson){
		this.roleInfoJson = roleInfoJson;
	}
}