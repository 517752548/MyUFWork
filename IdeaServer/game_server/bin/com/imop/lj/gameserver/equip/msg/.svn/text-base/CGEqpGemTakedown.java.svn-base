package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.equip.handler.EquipHandlerFactory;

/**
 * 摘除宝石
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGEqpGemTakedown extends CGMessage{
	
	/** 装备UUID */
	private String equipUuid;
	/** 摘除的孔位置，从1开始计数 */
	private int holeNum;
	/** 摘除符文模板Id */
	private int extraItemId;
	
	public CGEqpGemTakedown (){
	}
	
	public CGEqpGemTakedown (
			String equipUuid,
			int holeNum,
			int extraItemId ){
			this.equipUuid = equipUuid;
			this.holeNum = holeNum;
			this.extraItemId = extraItemId;
	}
	
	@Override
	protected boolean readImpl() {

	// 装备UUID
	String _equipUuid = readString();
	//end


	// 摘除的孔位置，从1开始计数
	int _holeNum = readInteger();
	//end


	// 摘除符文模板Id
	int _extraItemId = readInteger();
	//end



			this.equipUuid = _equipUuid;
			this.holeNum = _holeNum;
			this.extraItemId = _extraItemId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 装备UUID
	writeString(equipUuid);


	// 摘除的孔位置，从1开始计数
	writeInteger(holeNum);


	// 摘除符文模板Id
	writeInteger(extraItemId);


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

	public String getEquipUuid(){
		return equipUuid;
	}
		
	public void setEquipUuid(String equipUuid){
		this.equipUuid = equipUuid;
	}

	public int getHoleNum(){
		return holeNum;
	}
		
	public void setHoleNum(int holeNum){
		this.holeNum = holeNum;
	}

	public int getExtraItemId(){
		return extraItemId;
	}
		
	public void setExtraItemId(int extraItemId){
		this.extraItemId = extraItemId;
	}


	@Override
	public void execute() {
		EquipHandlerFactory.getHandler().handleEqpGemTakedown(this.getSession().getPlayer(), this);
	}
}