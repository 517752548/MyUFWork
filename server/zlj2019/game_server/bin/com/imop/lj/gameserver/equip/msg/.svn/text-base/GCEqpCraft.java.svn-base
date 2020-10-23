package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回打造结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEqpCraft extends GCMessage{
	
	/** 装备模板ID */
	private int equipmentID;
	/** 道具唯一ID */
	private String itemUUId;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCEqpCraft (){
	}
	
	public GCEqpCraft (
			int equipmentID,
			String itemUUId,
			int result ){
			this.equipmentID = equipmentID;
			this.itemUUId = itemUUId;
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 装备模板ID
	int _equipmentID = readInteger();
	//end


	// 道具唯一ID
	String _itemUUId = readString();
	//end


	// 操作结果，1成功，2失败
	int _result = readInteger();
	//end



		this.equipmentID = _equipmentID;
		this.itemUUId = _itemUUId;
		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 装备模板ID
	writeInteger(equipmentID);


	// 道具唯一ID
	writeString(itemUUId);


	// 操作结果，1成功，2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_EQP_CRAFT;
	}
	
	@Override
	public String getTypeName() {
		return "GC_EQP_CRAFT";
	}

	public int getEquipmentID(){
		return equipmentID;
	}
		
	public void setEquipmentID(int equipmentID){
		this.equipmentID = equipmentID;
	}

	public String getItemUUId(){
		return itemUUId;
	}
		
	public void setItemUUId(String itemUUId){
		this.itemUUId = itemUUId;
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}