package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.equip.handler.EquipHandlerFactory;

/**
 * 重铸装备
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGEqpRecast extends CGMessage{
	
	/** 装备UUID */
	private String equipUuid;
	/** 重铸时锁定装备列表 */
	private int[] EquipRecastInfo;
	
	public CGEqpRecast (){
	}
	
	public CGEqpRecast (
			String equipUuid,
			int[] EquipRecastInfo ){
			this.equipUuid = equipUuid;
			this.EquipRecastInfo = EquipRecastInfo;
	}
	
	@Override
	protected boolean readImpl() {

	// 装备UUID
	String _equipUuid = readString();
	//end


	// 重铸时锁定装备列表
	int EquipRecastInfoSize = readUnsignedShort();
	int[] _EquipRecastInfo = new int[EquipRecastInfoSize];
	int EquipRecastInfoIndex = 0;
	for(EquipRecastInfoIndex=0; EquipRecastInfoIndex<EquipRecastInfoSize; EquipRecastInfoIndex++){
		_EquipRecastInfo[EquipRecastInfoIndex] = readInteger();
	}//end



			this.equipUuid = _equipUuid;
			this.EquipRecastInfo = _EquipRecastInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 装备UUID
	writeString(equipUuid);


	// 重铸时锁定装备列表
	writeShort(EquipRecastInfo.length);
	int EquipRecastInfoSize = EquipRecastInfo.length;
	int EquipRecastInfoIndex = 0;
	for(EquipRecastInfoIndex=0; EquipRecastInfoIndex<EquipRecastInfoSize; EquipRecastInfoIndex++){
		writeInteger(EquipRecastInfo [ EquipRecastInfoIndex ]);
	}//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_EQP_RECAST;
	}
	
	@Override
	public String getTypeName() {
		return "CG_EQP_RECAST";
	}

	public String getEquipUuid(){
		return equipUuid;
	}
		
	public void setEquipUuid(String equipUuid){
		this.equipUuid = equipUuid;
	}

	public int[] getEquipRecastInfo(){
		return EquipRecastInfo;
	}

	public void setEquipRecastInfo(int[] EquipRecastInfo){
		this.EquipRecastInfo = EquipRecastInfo;
	}	


	@Override
	public void execute() {
		EquipHandlerFactory.getHandler().handleEqpRecast(this.getSession().getPlayer(), this);
	}
}