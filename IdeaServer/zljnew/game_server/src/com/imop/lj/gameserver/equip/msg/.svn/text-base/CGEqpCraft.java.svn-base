package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.equip.handler.EquipHandlerFactory;

/**
 * 打造装备
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGEqpCraft extends CGMessage{
	
	/** 打造花费模板Id */
	private int costTplId;
	/** 阶数 */
	private int gradeId;
	/** 材料数量列表 */
	private int[] itemNumList;
	/** 是否模拟，0否，1是 */
	private int isSimulate;
	
	public CGEqpCraft (){
	}
	
	public CGEqpCraft (
			int costTplId,
			int gradeId,
			int[] itemNumList,
			int isSimulate ){
			this.costTplId = costTplId;
			this.gradeId = gradeId;
			this.itemNumList = itemNumList;
			this.isSimulate = isSimulate;
	}
	
	@Override
	protected boolean readImpl() {

	// 打造花费模板Id
	int _costTplId = readInteger();
	//end


	// 阶数
	int _gradeId = readInteger();
	//end


	// 材料数量列表
	int itemNumListSize = readUnsignedShort();
	int[] _itemNumList = new int[itemNumListSize];
	int itemNumListIndex = 0;
	for(itemNumListIndex=0; itemNumListIndex<itemNumListSize; itemNumListIndex++){
		_itemNumList[itemNumListIndex] = readInteger();
	}//end


	// 是否模拟，0否，1是
	int _isSimulate = readInteger();
	//end



			this.costTplId = _costTplId;
			this.gradeId = _gradeId;
			this.itemNumList = _itemNumList;
			this.isSimulate = _isSimulate;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 打造花费模板Id
	writeInteger(costTplId);


	// 阶数
	writeInteger(gradeId);


	// 材料数量列表
	writeShort(itemNumList.length);
	int itemNumListSize = itemNumList.length;
	int itemNumListIndex = 0;
	for(itemNumListIndex=0; itemNumListIndex<itemNumListSize; itemNumListIndex++){
		writeInteger(itemNumList [ itemNumListIndex ]);
	}//end


	// 是否模拟，0否，1是
	writeInteger(isSimulate);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_EQP_CRAFT;
	}
	
	@Override
	public String getTypeName() {
		return "CG_EQP_CRAFT";
	}

	public int getCostTplId(){
		return costTplId;
	}
		
	public void setCostTplId(int costTplId){
		this.costTplId = costTplId;
	}

	public int getGradeId(){
		return gradeId;
	}
		
	public void setGradeId(int gradeId){
		this.gradeId = gradeId;
	}

	public int[] getItemNumList(){
		return itemNumList;
	}

	public void setItemNumList(int[] itemNumList){
		this.itemNumList = itemNumList;
	}	

	public int getIsSimulate(){
		return isSimulate;
	}
		
	public void setIsSimulate(int isSimulate){
		this.isSimulate = isSimulate;
	}


	@Override
	public void execute() {
		EquipHandlerFactory.getHandler().handleEqpCraft(this.getSession().getPlayer(), this);
	}
}