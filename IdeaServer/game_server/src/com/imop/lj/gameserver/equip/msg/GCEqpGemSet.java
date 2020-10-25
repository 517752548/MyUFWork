package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 镶嵌宝石结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEqpGemSet extends GCMessage{
	
	/** 装备UUID */
	private String equipUuid;
	/** 要镶嵌的宝石模板Id */
	private int gemItemId;
	/** 镶嵌上的宝石模板Id，为0表示失败扣除 */
	private int finalGemItemId;

	public GCEqpGemSet (){
	}
	
	public GCEqpGemSet (
			String equipUuid,
			int gemItemId,
			int finalGemItemId ){
			this.equipUuid = equipUuid;
			this.gemItemId = gemItemId;
			this.finalGemItemId = finalGemItemId;
	}

	@Override
	protected boolean readImpl() {

	// 装备UUID
	String _equipUuid = readString();
	//end


	// 要镶嵌的宝石模板Id
	int _gemItemId = readInteger();
	//end


	// 镶嵌上的宝石模板Id，为0表示失败扣除
	int _finalGemItemId = readInteger();
	//end



		this.equipUuid = _equipUuid;
		this.gemItemId = _gemItemId;
		this.finalGemItemId = _finalGemItemId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 装备UUID
	writeString(equipUuid);


	// 要镶嵌的宝石模板Id
	writeInteger(gemItemId);


	// 镶嵌上的宝石模板Id，为0表示失败扣除
	writeInteger(finalGemItemId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_EQP_GEM_SET;
	}
	
	@Override
	public String getTypeName() {
		return "GC_EQP_GEM_SET";
	}

	public String getEquipUuid(){
		return equipUuid;
	}
		
	public void setEquipUuid(String equipUuid){
		this.equipUuid = equipUuid;
	}

	public int getGemItemId(){
		return gemItemId;
	}
		
	public void setGemItemId(int gemItemId){
		this.gemItemId = gemItemId;
	}

	public int getFinalGemItemId(){
		return finalGemItemId;
	}
		
	public void setFinalGemItemId(int finalGemItemId){
		this.finalGemItemId = finalGemItemId;
	}
}