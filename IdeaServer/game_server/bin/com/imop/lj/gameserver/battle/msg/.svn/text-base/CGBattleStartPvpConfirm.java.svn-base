package com.imop.lj.gameserver.battle.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.battle.handler.BattleHandlerFactory;

/**
 * 应答请求PVP战斗
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBattleStartPvpConfirm extends CGMessage{
	
	/** 是否同意切磋，0不同意，1同意 */
	private int agree;
	/** 发起切磋玩家Id */
	private long sourcePlayerId;
	
	public CGBattleStartPvpConfirm (){
	}
	
	public CGBattleStartPvpConfirm (
			int agree,
			long sourcePlayerId ){
			this.agree = agree;
			this.sourcePlayerId = sourcePlayerId;
	}
	
	@Override
	protected boolean readImpl() {

	// 是否同意切磋，0不同意，1同意
	int _agree = readInteger();
	//end


	// 发起切磋玩家Id
	long _sourcePlayerId = readLong();
	//end



			this.agree = _agree;
			this.sourcePlayerId = _sourcePlayerId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 是否同意切磋，0不同意，1同意
	writeInteger(agree);


	// 发起切磋玩家Id
	writeLong(sourcePlayerId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_BATTLE_START_PVP_CONFIRM;
	}
	
	@Override
	public String getTypeName() {
		return "CG_BATTLE_START_PVP_CONFIRM";
	}

	public int getAgree(){
		return agree;
	}
		
	public void setAgree(int agree){
		this.agree = agree;
	}

	public long getSourcePlayerId(){
		return sourcePlayerId;
	}
		
	public void setSourcePlayerId(long sourcePlayerId){
		this.sourcePlayerId = sourcePlayerId;
	}


	@Override
	public void execute() {
		BattleHandlerFactory.getHandler().handleBattleStartPvpConfirm(this.getSession().getPlayer(), this);
	}
}