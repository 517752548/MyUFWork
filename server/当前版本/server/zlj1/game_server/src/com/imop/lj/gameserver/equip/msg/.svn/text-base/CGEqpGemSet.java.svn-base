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
	
	/** 装备位 */
	private int equipPosition;
	/** 宝石位 */
	private int gemPosition;
	/** 在主背包的index */
	private int gemIndex;
	
	public CGEqpGemSet (){
	}
	
	public CGEqpGemSet (
			int equipPosition,
			int gemPosition,
			int gemIndex ){
			this.equipPosition = equipPosition;
			this.gemPosition = gemPosition;
			this.gemIndex = gemIndex;
	}
	
	@Override
	protected boolean readImpl() {

	// 装备位
	int _equipPosition = readInteger();
	//end


	// 宝石位
	int _gemPosition = readInteger();
	//end


	// 在主背包的index
	int _gemIndex = readInteger();
	//end



			this.equipPosition = _equipPosition;
			this.gemPosition = _gemPosition;
			this.gemIndex = _gemIndex;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 装备位
	writeInteger(equipPosition);


	// 宝石位
	writeInteger(gemPosition);


	// 在主背包的index
	writeInteger(gemIndex);


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

	public int getEquipPosition(){
		return equipPosition;
	}
		
	public void setEquipPosition(int equipPosition){
		this.equipPosition = equipPosition;
	}

	public int getGemPosition(){
		return gemPosition;
	}
		
	public void setGemPosition(int gemPosition){
		this.gemPosition = gemPosition;
	}

	public int getGemIndex(){
		return gemIndex;
	}
		
	public void setGemIndex(int gemIndex){
		this.gemIndex = gemIndex;
	}


	@Override
	public void execute() {
		EquipHandlerFactory.getHandler().handleEqpGemSet(this.getSession().getPlayer(), this);
	}
}