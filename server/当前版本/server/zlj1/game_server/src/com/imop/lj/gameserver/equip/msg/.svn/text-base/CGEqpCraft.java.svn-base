package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.equip.handler.EquipHandlerFactory;

/**
 * 打造装备
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGEqpCraft extends CGMessage{
	
	/** 装备ID */
	private int equipmentID;
	
	public CGEqpCraft (){
	}
	
	public CGEqpCraft (
			int equipmentID ){
			this.equipmentID = equipmentID;
	}
	
	@Override
	protected boolean readImpl() {

	// 装备ID
	int _equipmentID = readInteger();
	//end



			this.equipmentID = _equipmentID;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 装备ID
	writeInteger(equipmentID);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_EQP_CRAFT;
	}
	
	@Override
	public String getTypeName() {
		return "CG_EQP_CRAFT";
	}

	public int getEquipmentID(){
		return equipmentID;
	}
		
	public void setEquipmentID(int equipmentID){
		this.equipmentID = equipmentID;
	}


	@Override
	public void execute() {
		EquipHandlerFactory.getHandler().handleEqpCraft(this.getSession().getPlayer(), this);
	}
}