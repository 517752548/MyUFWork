package com.imop.lj.gameserver.exam.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.exam.handler.ExamHandlerFactory;

/**
 * 使用物品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGExamUseItem extends CGMessage{
	
	/** 申请的科举类型 */
	private int examType;
	/** 使用的特殊道具,1松木令,2玉木令 */
	private int itemId;
	
	public CGExamUseItem (){
	}
	
	public CGExamUseItem (
			int examType,
			int itemId ){
			this.examType = examType;
			this.itemId = itemId;
	}
	
	@Override
	protected boolean readImpl() {

	// 申请的科举类型
	int _examType = readInteger();
	//end


	// 使用的特殊道具,1松木令,2玉木令
	int _itemId = readInteger();
	//end



			this.examType = _examType;
			this.itemId = _itemId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 申请的科举类型
	writeInteger(examType);


	// 使用的特殊道具,1松木令,2玉木令
	writeInteger(itemId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_EXAM_USE_ITEM;
	}
	
	@Override
	public String getTypeName() {
		return "CG_EXAM_USE_ITEM";
	}

	public int getExamType(){
		return examType;
	}
		
	public void setExamType(int examType){
		this.examType = examType;
	}

	public int getItemId(){
		return itemId;
	}
		
	public void setItemId(int itemId){
		this.itemId = itemId;
	}


	@Override
	public void execute() {
		ExamHandlerFactory.getHandler().handleExamUseItem(this.getSession().getPlayer(), this);
	}
}