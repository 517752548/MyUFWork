package com.imop.lj.gameserver.team.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 邀请成员加入队伍操作成功
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTeamInvitePlayer extends GCMessage{
	
	/** 目标玩家id */
	private long targetPlayerId;

	public GCTeamInvitePlayer (){
	}
	
	public GCTeamInvitePlayer (
			long targetPlayerId ){
			this.targetPlayerId = targetPlayerId;
	}

	@Override
	protected boolean readImpl() {

	// 目标玩家id
	long _targetPlayerId = readLong();
	//end



		this.targetPlayerId = _targetPlayerId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 目标玩家id
	writeLong(targetPlayerId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_TEAM_INVITE_PLAYER;
	}
	
	@Override
	public String getTypeName() {
		return "GC_TEAM_INVITE_PLAYER";
	}

	public long getTargetPlayerId(){
		return targetPlayerId;
	}
		
	public void setTargetPlayerId(long targetPlayerId){
		this.targetPlayerId = targetPlayerId;
	}
}