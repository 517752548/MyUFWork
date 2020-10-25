package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 常量列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCConstantList extends GCMessage{
	
	/** 常量信息 */
	private com.imop.lj.common.model.constant.ConstantInfo[] constantInfoList;

	public GCConstantList (){
	}
	
	public GCConstantList (
			com.imop.lj.common.model.constant.ConstantInfo[] constantInfoList ){
			this.constantInfoList = constantInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 常量信息
	int constantInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.constant.ConstantInfo[] _constantInfoList = new com.imop.lj.common.model.constant.ConstantInfo[constantInfoListSize];
	int constantInfoListIndex = 0;
	for(constantInfoListIndex=0; constantInfoListIndex<constantInfoListSize; constantInfoListIndex++){
		_constantInfoList[constantInfoListIndex] = new com.imop.lj.common.model.constant.ConstantInfo();
	// 常量的键
	String _constantInfoList_key = readString();
	//end
	_constantInfoList[constantInfoListIndex].setKey (_constantInfoList_key);

	// 常量的值
	String _constantInfoList_value = readString();
	//end
	_constantInfoList[constantInfoListIndex].setValue (_constantInfoList_value);
	}
	//end



		this.constantInfoList = _constantInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 常量信息
	writeShort(constantInfoList.length);
	int constantInfoListIndex = 0;
	int constantInfoListSize = constantInfoList.length;
	for(constantInfoListIndex=0; constantInfoListIndex<constantInfoListSize; constantInfoListIndex++){

	String constantInfoList_key = constantInfoList[constantInfoListIndex].getKey();

	// 常量的键
	writeString(constantInfoList_key);

	String constantInfoList_value = constantInfoList[constantInfoListIndex].getValue();

	// 常量的值
	writeString(constantInfoList_value);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_CONSTANT_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_CONSTANT_LIST";
	}

	public com.imop.lj.common.model.constant.ConstantInfo[] getConstantInfoList(){
		return constantInfoList;
	}

	public void setConstantInfoList(com.imop.lj.common.model.constant.ConstantInfo[] constantInfoList){
		this.constantInfoList = constantInfoList;
	}	
}