package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.common.handler.CommonHandlerFactory;

/**
 * 查看他人主将信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOfflineUserLeaderInfo extends CGMessage{
	
	/** 玩家角色Id */
	private long roleId;
	
	public CGOfflineUserLeaderInfo (){
	}
	
	public CGOfflineUserLeaderInfo (
			long roleId ){
			this.roleId = roleId;
	}
	
	@Override
	protected boolean readImpl() {

	// 玩家角色Id
	long _roleId = readLong();
	//end



			this.roleId = _roleId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 玩家角色Id
	writeLong(roleId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_OFFLINE_USER_LEADER_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "CG_OFFLINE_USER_LEADER_INFO";
	}

	public long getRoleId(){
		return roleId;
	}
		
	public void setRoleId(long roleId){
		this.roleId = roleId;
	}


	@Override
	public void execute() {
		CommonHandlerFactory.getHandler().handleOfflineUserLeaderInfo(this.getSession().getPlayer(), this);
	}
}