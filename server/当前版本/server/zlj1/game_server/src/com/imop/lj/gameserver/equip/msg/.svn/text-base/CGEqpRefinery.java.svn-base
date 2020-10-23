package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.equip.handler.EquipHandlerFactory;

/**
 * 洗炼装备
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGEqpRefinery extends CGMessage{
	
	/** 装备UUID */
	private String equipUuid;
	
	public CGEqpRefinery (){
	}
	
	public CGEqpRefinery (
			String equipUuid ){
			this.equipUuid = equipUuid;
	}
	
	@Override
	protected boolean readImpl() {

	// 装备UUID
	String _equipUuid = readString();
	//end



			this.equipUuid = _equipUuid;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 装备UUID
	writeString(equipUuid);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_EQP_REFINERY;
	}
	
	@Override
	public String getTypeName() {
		return "CG_EQP_REFINERY";
	}

	public String getEquipUuid(){
		return equipUuid;
	}
		
	public void setEquipUuid(String equipUuid){
		this.equipUuid = equipUuid;
	}


	@Override
	public void execute() {
		EquipHandlerFactory.getHandler().handleEqpRefinery(this.getSession().getPlayer(), this);
	}
}