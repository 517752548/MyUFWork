package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.equip.handler.EquipHandlerFactory;

/**
 * 装备打孔/洗孔
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGEqpHole extends CGMessage{
	
	/** 装备UUID */
	private String equipUUId;
	/** 孔数 */
	private int holeNum;
	/** 打孔道具Id */
	private int holeItemId;
	/** 0打孔，1洗孔 */
	private int isRefresh;
	
	public CGEqpHole (){
	}
	
	public CGEqpHole (
			String equipUUId,
			int holeNum,
			int holeItemId,
			int isRefresh ){
			this.equipUUId = equipUUId;
			this.holeNum = holeNum;
			this.holeItemId = holeItemId;
			this.isRefresh = isRefresh;
	}
	
	@Override
	protected boolean readImpl() {

	// 装备UUID
	String _equipUUId = readString();
	//end


	// 孔数
	int _holeNum = readInteger();
	//end


	// 打孔道具Id
	int _holeItemId = readInteger();
	//end


	// 0打孔，1洗孔
	int _isRefresh = readInteger();
	//end



			this.equipUUId = _equipUUId;
			this.holeNum = _holeNum;
			this.holeItemId = _holeItemId;
			this.isRefresh = _isRefresh;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 装备UUID
	writeString(equipUUId);


	// 孔数
	writeInteger(holeNum);


	// 打孔道具Id
	writeInteger(holeItemId);


	// 0打孔，1洗孔
	writeInteger(isRefresh);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_EQP_HOLE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_EQP_HOLE";
	}

	public String getEquipUUId(){
		return equipUUId;
	}
		
	public void setEquipUUId(String equipUUId){
		this.equipUUId = equipUUId;
	}

	public int getHoleNum(){
		return holeNum;
	}
		
	public void setHoleNum(int holeNum){
		this.holeNum = holeNum;
	}

	public int getHoleItemId(){
		return holeItemId;
	}
		
	public void setHoleItemId(int holeItemId){
		this.holeItemId = holeItemId;
	}

	public int getIsRefresh(){
		return isRefresh;
	}
		
	public void setIsRefresh(int isRefresh){
		this.isRefresh = isRefresh;
	}


	@Override
	public void execute() {
		EquipHandlerFactory.getHandler().handleEqpHole(this.getSession().getPlayer(), this);
	}
}