package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.equip.handler.EquipHandlerFactory;

/**
 * 取下宝石
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGEqpGemTakedown extends CGMessage{
	
	/** 装备位 */
	private int equipPosition;
	/** 宝石位 */
	private int gemPosition;
	
	public CGEqpGemTakedown (){
	}
	
	public CGEqpGemTakedown (
			int equipPosition,
			int gemPosition ){
			this.equipPosition = equipPosition;
			this.gemPosition = gemPosition;
	}
	
	@Override
	protected boolean readImpl() {

	// 装备位
	int _equipPosition = readInteger();
	//end


	// 宝石位
	int _gemPosition = readInteger();
	//end



			this.equipPosition = _equipPosition;
			this.gemPosition = _gemPosition;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 装备位
	writeInteger(equipPosition);


	// 宝石位
	writeInteger(gemPosition);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_EQP_GEM_TAKEDOWN;
	}
	
	@Override
	public String getTypeName() {
		return "CG_EQP_GEM_TAKEDOWN";
	}

	public int getEquipPosition(){
		return equipPosition;
	}
		
	public void setEquipPosition(int equipPosition){
		this.equipPosition = equipPosition;
	}

	public int getGemPosition(){
		return gemPosition;
	}
		
	public void setGemPosition(int gemPosition){
		this.gemPosition = gemPosition;
	}


	@Override
	public void execute() {
		EquipHandlerFactory.getHandler().handleEqpGemTakedown(this.getSession().getPlayer(), this);
	}
}