package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.equip.handler.EquipHandlerFactory;

/**
 * 分解装备
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGEqpDecompose extends CGMessage{
	
	/** 装备UUIDList */
	private String[] equipList;
	
	public CGEqpDecompose (){
	}
	
	public CGEqpDecompose (
			String[] equipList ){
			this.equipList = equipList;
	}
	
	@Override
	protected boolean readImpl() {

	// 装备UUIDList
	int equipListSize = readUnsignedShort();
	String[] _equipList = new String[equipListSize];
	int equipListIndex = 0;
	for(equipListIndex=0; equipListIndex<equipListSize; equipListIndex++){
		_equipList[equipListIndex] = readString();
	}//end



			this.equipList = _equipList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 装备UUIDList
	writeShort(equipList.length);
	int equipListSize = equipList.length;
	int equipListIndex = 0;
	for(equipListIndex=0; equipListIndex<equipListSize; equipListIndex++){
		writeString(equipList [ equipListIndex ]);
	}//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_EQP_DECOMPOSE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_EQP_DECOMPOSE";
	}

	public String[] getEquipList(){
		return equipList;
	}

	public void setEquipList(String[] equipList){
		this.equipList = equipList;
	}	


	@Override
	public void execute() {
		EquipHandlerFactory.getHandler().handleEqpDecompose(this.getSession().getPlayer(), this);
	}
}