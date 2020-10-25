package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 装备打孔/洗孔结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEqpHole extends GCMessage{
	
	/** 装备UUID */
	private String equipUUId;
	/** 0打孔，1洗孔 */
	private int isRefresh;
	/** 1成功2失败 */
	private int result;

	public GCEqpHole (){
	}
	
	public GCEqpHole (
			String equipUUId,
			int isRefresh,
			int result ){
			this.equipUUId = equipUUId;
			this.isRefresh = isRefresh;
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 装备UUID
	String _equipUUId = readString();
	//end


	// 0打孔，1洗孔
	int _isRefresh = readInteger();
	//end


	// 1成功2失败
	int _result = readInteger();
	//end



		this.equipUUId = _equipUUId;
		this.isRefresh = _isRefresh;
		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 装备UUID
	writeString(equipUUId);


	// 0打孔，1洗孔
	writeInteger(isRefresh);


	// 1成功2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_EQP_HOLE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_EQP_HOLE";
	}

	public String getEquipUUId(){
		return equipUUId;
	}
		
	public void setEquipUUId(String equipUUId){
		this.equipUUId = equipUUId;
	}

	public int getIsRefresh(){
		return isRefresh;
	}
		
	public void setIsRefresh(int isRefresh){
		this.isRefresh = isRefresh;
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}