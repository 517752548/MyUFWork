package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回升星结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEqpUpstar extends GCMessage{
	
	/** 装备位 */
	private int equipPosition;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCEqpUpstar (){
	}
	
	public GCEqpUpstar (
			int equipPosition,
			int result ){
			this.equipPosition = equipPosition;
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 装备位
	int _equipPosition = readInteger();
	//end


	// 操作结果，1成功，2失败
	int _result = readInteger();
	//end



		this.equipPosition = _equipPosition;
		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 装备位
	writeInteger(equipPosition);


	// 操作结果，1成功，2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_EQP_UPSTAR;
	}
	
	@Override
	public String getTypeName() {
		return "GC_EQP_UPSTAR";
	}

	public int getEquipPosition(){
		return equipPosition;
	}
		
	public void setEquipPosition(int equipPosition){
		this.equipPosition = equipPosition;
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}