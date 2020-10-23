package com.imop.lj.gameserver.battle.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 武将准备中状态已完毕team
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBattleReadyChangedTeam extends GCMessage{
	
	/** 主将唯一id */
	private long leaderPetUUId;
	/** 宠物唯一id */
	private long petPetUUId;

	public GCBattleReadyChangedTeam (){
	}
	
	public GCBattleReadyChangedTeam (
			long leaderPetUUId,
			long petPetUUId ){
			this.leaderPetUUId = leaderPetUUId;
			this.petPetUUId = petPetUUId;
	}

	@Override
	protected boolean readImpl() {

	// 主将唯一id
	long _leaderPetUUId = readLong();
	//end


	// 宠物唯一id
	long _petPetUUId = readLong();
	//end



		this.leaderPetUUId = _leaderPetUUId;
		this.petPetUUId = _petPetUUId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 主将唯一id
	writeLong(leaderPetUUId);


	// 宠物唯一id
	writeLong(petPetUUId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_BATTLE_READY_CHANGED_TEAM;
	}
	
	@Override
	public String getTypeName() {
		return "GC_BATTLE_READY_CHANGED_TEAM";
	}

	public long getLeaderPetUUId(){
		return leaderPetUUId;
	}
		
	public void setLeaderPetUUId(long leaderPetUUId){
		this.leaderPetUUId = leaderPetUUId;
	}

	public long getPetPetUUId(){
		return petPetUUId;
	}
		
	public void setPetPetUUId(long petPetUUId){
		this.petPetUUId = petPetUUId;
	}
}