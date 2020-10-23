package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.common.handler.CommonHandlerFactory;

/**
 * 设置消费确认提示
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSetConsumeConfirm extends CGMessage{
	
	/** 消费信息 */
	private com.imop.lj.gameserver.human.ConsumeConfirmInfo[] consumeConfirmInfoList;
	
	public CGSetConsumeConfirm (){
	}
	
	public CGSetConsumeConfirm (
			com.imop.lj.gameserver.human.ConsumeConfirmInfo[] consumeConfirmInfoList ){
			this.consumeConfirmInfoList = consumeConfirmInfoList;
	}
	
	@Override
	protected boolean readImpl() {

	// 消费信息
	int consumeConfirmInfoListSize = readUnsignedShort();
	com.imop.lj.gameserver.human.ConsumeConfirmInfo[] _consumeConfirmInfoList = new com.imop.lj.gameserver.human.ConsumeConfirmInfo[consumeConfirmInfoListSize];
	int consumeConfirmInfoListIndex = 0;
	for(consumeConfirmInfoListIndex=0; consumeConfirmInfoListIndex<consumeConfirmInfoListSize; consumeConfirmInfoListIndex++){
		_consumeConfirmInfoList[consumeConfirmInfoListIndex] = new com.imop.lj.gameserver.human.ConsumeConfirmInfo();
	// 提示类型
	int _consumeConfirmInfoList_confirmType = readInteger();
	//end
	_consumeConfirmInfoList[consumeConfirmInfoListIndex].setConfirmType (_consumeConfirmInfoList_confirmType);

	// 是否选中不提示框0 不选择 1选择
	int _consumeConfirmInfoList_isSelected = readInteger();
	//end
	_consumeConfirmInfoList[consumeConfirmInfoListIndex].setIsSelected (_consumeConfirmInfoList_isSelected);
	}
	//end



			this.consumeConfirmInfoList = _consumeConfirmInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 消费信息
	writeShort(consumeConfirmInfoList.length);
	int consumeConfirmInfoListIndex = 0;
	int consumeConfirmInfoListSize = consumeConfirmInfoList.length;
	for(consumeConfirmInfoListIndex=0; consumeConfirmInfoListIndex<consumeConfirmInfoListSize; consumeConfirmInfoListIndex++){

	int consumeConfirmInfoList_confirmType = consumeConfirmInfoList[consumeConfirmInfoListIndex].getConfirmType();

	// 提示类型
	writeInteger(consumeConfirmInfoList_confirmType);

	int consumeConfirmInfoList_isSelected = consumeConfirmInfoList[consumeConfirmInfoListIndex].getIsSelected();

	// 是否选中不提示框0 不选择 1选择
	writeInteger(consumeConfirmInfoList_isSelected);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_SET_CONSUME_CONFIRM;
	}
	
	@Override
	public String getTypeName() {
		return "CG_SET_CONSUME_CONFIRM";
	}

	public com.imop.lj.gameserver.human.ConsumeConfirmInfo[] getConsumeConfirmInfoList(){
		return consumeConfirmInfoList;
	}

	public void setConsumeConfirmInfoList(com.imop.lj.gameserver.human.ConsumeConfirmInfo[] consumeConfirmInfoList){
		this.consumeConfirmInfoList = consumeConfirmInfoList;
	}	


	@Override
	public void execute() {
		CommonHandlerFactory.getHandler().handleSetConsumeConfirm(this.getSession().getPlayer(), this);
	}
}