package com.imop.lj.gameserver.battle.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 目标玩家收到的请求PVP战斗
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBattleStartPvpInvite extends GCMessage{
	
	/** 发起切磋玩家Id */
	private long sourcePlayerId;
	/** 发起切磋玩家名字 */
	private String sourcePlayerName;

	public GCBattleStartPvpInvite (){
	}
	
	public GCBattleStartPvpInvite (
			long sourcePlayerId,
			String sourcePlayerName ){
			this.sourcePlayerId = sourcePlayerId;
			this.sourcePlayerName = sourcePlayerName;
	}

	@Override
	protected boolean readImpl() {

	// 发起切磋玩家Id
	long _sourcePlayerId = readLong();
	//end


	// 发起切磋玩家名字
	String _sourcePlayerName = readString();
	//end



		this.sourcePlayerId = _sourcePlayerId;
		this.sourcePlayerName = _sourcePlayerName;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 发起切磋玩家Id
	writeLong(sourcePlayerId);


	// 发起切磋玩家名字
	writeString(sourcePlayerName);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_BATTLE_START_PVP_INVITE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_BATTLE_START_PVP_INVITE";
	}

	public long getSourcePlayerId(){
		return sourcePlayerId;
	}
		
	public void setSourcePlayerId(long sourcePlayerId){
		this.sourcePlayerId = sourcePlayerId;
	}

	public String getSourcePlayerName(){
		return sourcePlayerName;
	}
		
	public void setSourcePlayerName(String sourcePlayerName){
		this.sourcePlayerName = sourcePlayerName;
	}
}