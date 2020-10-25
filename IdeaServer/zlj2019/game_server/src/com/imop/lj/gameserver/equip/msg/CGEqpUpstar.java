package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.equip.handler.EquipHandlerFactory;

/**
 * 升星装备位
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGEqpUpstar extends CGMessage{
	
	/** 装备位 */
	private int equipPosition;
	/** 是否使用物品提升概率，1使用，2不使用 */
	private int useExtraItem;
	
	public CGEqpUpstar (){
	}
	
	public CGEqpUpstar (
			int equipPosition,
			int useExtraItem ){
			this.equipPosition = equipPosition;
			this.useExtraItem = useExtraItem;
	}
	
	@Override
	protected boolean readImpl() {

	// 装备位
	int _equipPosition = readInteger();
	//end


	// 是否使用物品提升概率，1使用，2不使用
	int _useExtraItem = readInteger();
	//end



			this.equipPosition = _equipPosition;
			this.useExtraItem = _useExtraItem;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 装备位
	writeInteger(equipPosition);


	// 是否使用物品提升概率，1使用，2不使用
	writeInteger(useExtraItem);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_EQP_UPSTAR;
	}
	
	@Override
	public String getTypeName() {
		return "CG_EQP_UPSTAR";
	}

	public int getEquipPosition(){
		return equipPosition;
	}
		
	public void setEquipPosition(int equipPosition){
		this.equipPosition = equipPosition;
	}

	public int getUseExtraItem(){
		return useExtraItem;
	}
		
	public void setUseExtraItem(int useExtraItem){
		this.useExtraItem = useExtraItem;
	}


	@Override
	public void execute() {
		EquipHandlerFactory.getHandler().handleEqpUpstar(this.getSession().getPlayer(), this);
	}
}