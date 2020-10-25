package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.equip.handler.EquipHandlerFactory;

/**
 * 镶嵌宝石
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGEqpGemSet extends CGMessage{
	
	/** 装备UUID */
	private String equipUuid;
	/** 镶嵌的孔位置，从1开始计数 */
	private int holeNum;
	/** 宝石模板Id */
	private int gemItemId;
	/** 镶嵌符文模板Id */
	private int extraItemId;
	
	public CGEqpGemSet (){
	}
	
	public CGEqpGemSet (
			String equipUuid,
			int holeNum,
			int gemItemId,
			int extraItemId ){
			this.equipUuid = equipUuid;
			this.holeNum = holeNum;
			this.gemItemId = gemItemId;
			this.extraItemId = extraItemId;
	}
	
	@Override
	protected boolean readImpl() {

	// 装备UUID
	String _equipUuid = readString();
	//end


	// 镶嵌的孔位置，从1开始计数
	int _holeNum = readInteger();
	//end


	// 宝石模板Id
	int _gemItemId = readInteger();
	//end


	// 镶嵌符文模板Id
	int _extraItemId = readInteger();
	//end



			this.equipUuid = _equipUuid;
			this.holeNum = _holeNum;
			this.gemItemId = _gemItemId;
			this.extraItemId = _extraItemId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 装备UUID
	writeString(equipUuid);


	// 镶嵌的孔位置，从1开始计数
	writeInteger(holeNum);


	// 宝石模板Id
	writeInteger(gemItemId);


	// 镶嵌符文模板Id
	writeInteger(extraItemId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_EQP_GEM_SET;
	}
	
	@Override
	public String getTypeName() {
		return "CG_EQP_GEM_SET";
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

	public int getGemItemId(){
		return gemItemId;
	}
		
	public void setGemItemId(int gemItemId){
		this.gemItemId = gemItemId;
	}

	public int getExtraItemId(){
		return extraItemId;
	}
		
	public void setExtraItemId(int extraItemId){
		this.extraItemId = extraItemId;
	}


	@Override
	public void execute() {
		EquipHandlerFactory.getHandler().handleEqpGemSet(this.getSession().getPlayer(), this);
	}
}