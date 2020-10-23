package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 兑换成功
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPlayerChargeDiamond extends GCMessage{
	
	/** 平台币余额 */
	private int mmBalance;

	public GCPlayerChargeDiamond (){
	}
	
	public GCPlayerChargeDiamond (
			int mmBalance ){
			this.mmBalance = mmBalance;
	}

	@Override
	protected boolean readImpl() {

	// 平台币余额
	int _mmBalance = readInteger();
	//end



		this.mmBalance = _mmBalance;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 平台币余额
	writeInteger(mmBalance);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PLAYER_CHARGE_DIAMOND;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PLAYER_CHARGE_DIAMOND";
	}

	public int getMmBalance(){
		return mmBalance;
	}
		
	public void setMmBalance(int mmBalance){
		this.mmBalance = mmBalance;
	}
}