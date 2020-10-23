package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.player.handler.PlayerHandlerFactory;

/**
 * 选择角色进入游戏场景
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPlayerEnter extends CGMessage{
	
	/** 角色的uuid */
	private long roleUUID;
	
	public CGPlayerEnter (){
	}
	
	public CGPlayerEnter (
			long roleUUID ){
			this.roleUUID = roleUUID;
	}
	
	@Override
	protected boolean readImpl() {

	// 角色的uuid
	long _roleUUID = readLong();
	//end



			this.roleUUID = _roleUUID;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 角色的uuid
	writeLong(roleUUID);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PLAYER_ENTER;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PLAYER_ENTER";
	}

	public long getRoleUUID(){
		return roleUUID;
	}
		
	public void setRoleUUID(long roleUUID){
		this.roleUUID = roleUUID;
	}


	@Override
	public void execute() {
		PlayerHandlerFactory.getHandler().handlePlayerEnter(this.getSession().getPlayer(), this);
	}
}