package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.player.handler.PlayerHandlerFactory;

/**
 * 玩家充值平台币
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPlayerChargeDiamond extends CGMessage{
	
	/** 兑换的平台币数量 */
	private int mmCost;
	
	public CGPlayerChargeDiamond (){
	}
	
	public CGPlayerChargeDiamond (
			int mmCost ){
			this.mmCost = mmCost;
	}
	
	@Override
	protected boolean readImpl() {

	// 兑换的平台币数量
	int _mmCost = readInteger();
	//end



			this.mmCost = _mmCost;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 兑换的平台币数量
	writeInteger(mmCost);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PLAYER_CHARGE_DIAMOND;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PLAYER_CHARGE_DIAMOND";
	}

	public int getMmCost(){
		return mmCost;
	}
		
	public void setMmCost(int mmCost){
		this.mmCost = mmCost;
	}


	@Override
	public void execute() {
		PlayerHandlerFactory.getHandler().handlePlayerChargeDiamond(this.getSession().getPlayer(), this);
	}
}