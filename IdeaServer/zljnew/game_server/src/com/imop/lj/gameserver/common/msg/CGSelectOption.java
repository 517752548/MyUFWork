package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.common.handler.CommonHandlerFactory;

/**
 * 选择确认对话框 ok 或 cancel 选项
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSelectOption extends CGMessage{
	
	/** 操作标识 */
	private String tag;
	/** 如果没有提示框默认是0，是否选中不提示框1选中1不选中 */
	private int isSelected;
	/** 选项值,选择确认返回1，选择取消返回0 */
	private int seletctedValue;
	
	public CGSelectOption (){
	}
	
	public CGSelectOption (
			String tag,
			int isSelected,
			int seletctedValue ){
			this.tag = tag;
			this.isSelected = isSelected;
			this.seletctedValue = seletctedValue;
	}
	
	@Override
	protected boolean readImpl() {

	// 操作标识
	String _tag = readString();
	//end


	// 如果没有提示框默认是0，是否选中不提示框1选中1不选中
	int _isSelected = readInteger();
	//end


	// 选项值,选择确认返回1，选择取消返回0
	int _seletctedValue = readInteger();
	//end



			this.tag = _tag;
			this.isSelected = _isSelected;
			this.seletctedValue = _seletctedValue;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 操作标识
	writeString(tag);


	// 如果没有提示框默认是0，是否选中不提示框1选中1不选中
	writeInteger(isSelected);


	// 选项值,选择确认返回1，选择取消返回0
	writeInteger(seletctedValue);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_SELECT_OPTION;
	}
	
	@Override
	public String getTypeName() {
		return "CG_SELECT_OPTION";
	}

	public String getTag(){
		return tag;
	}
		
	public void setTag(String tag){
		this.tag = tag;
	}

	public int getIsSelected(){
		return isSelected;
	}
		
	public void setIsSelected(int isSelected){
		this.isSelected = isSelected;
	}

	public int getSeletctedValue(){
		return seletctedValue;
	}
		
	public void setSeletctedValue(int seletctedValue){
		this.seletctedValue = seletctedValue;
	}


	@Override
	public void execute() {
		CommonHandlerFactory.getHandler().handleSelectOption(this.getSession().getPlayer(), this);
	}
}