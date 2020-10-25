package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 功能按钮列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCFuncList extends GCMessage{
	
	/** 功能按钮列表 */
	private com.imop.lj.common.model.human.FuncShowInfo[] funcInfoList;

	public GCFuncList (){
	}
	
	public GCFuncList (
			com.imop.lj.common.model.human.FuncShowInfo[] funcInfoList ){
			this.funcInfoList = funcInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 功能按钮列表
	int funcInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.human.FuncShowInfo[] _funcInfoList = new com.imop.lj.common.model.human.FuncShowInfo[funcInfoListSize];
	int funcInfoListIndex = 0;
	for(funcInfoListIndex=0; funcInfoListIndex<funcInfoListSize; funcInfoListIndex++){
		_funcInfoList[funcInfoListIndex] = new com.imop.lj.common.model.human.FuncShowInfo();
	// 功能按钮类型
	int _funcInfoList_funcType = readInteger();
	//end
	_funcInfoList[funcInfoListIndex].setFuncType (_funcInfoList_funcType);

	// 1开启，0关闭
	int _funcInfoList_isOpened = readInteger();
	//end
	_funcInfoList[funcInfoListIndex].setIsOpened (_funcInfoList_isOpened);

	// 所属功能
	int _funcInfoList_ownerFuncType = readInteger();
	//end
	_funcInfoList[funcInfoListIndex].setOwnerFuncType (_funcInfoList_ownerFuncType);

	// 特效
	int _funcInfoList_effect = readInteger();
	//end
	_funcInfoList[funcInfoListIndex].setEffect (_funcInfoList_effect);

	// 名称
	String _funcInfoList_name = readString();
	//end
	_funcInfoList[funcInfoListIndex].setName (_funcInfoList_name);

	// 描述
	String _funcInfoList_desc = readString();
	//end
	_funcInfoList[funcInfoListIndex].setDesc (_funcInfoList_desc);

	// 数字角标，没有则为0
	int _funcInfoList_showNum = readInteger();
	//end
	_funcInfoList[funcInfoListIndex].setShowNum (_funcInfoList_showNum);

	// 倒计时，没有则为0
	long _funcInfoList_countDownTime = readLong();
	//end
	_funcInfoList[funcInfoListIndex].setCountDownTime (_funcInfoList_countDownTime);

	// 按钮位置
	int _funcInfoList_position = readInteger();
	//end
	_funcInfoList[funcInfoListIndex].setPosition (_funcInfoList_position);

	// 顺序
	int _funcInfoList_order = readInteger();
	//end
	_funcInfoList[funcInfoListIndex].setOrder (_funcInfoList_order);

	// 是否首次开启，0否，1是
	int _funcInfoList_isFirstOpen = readInteger();
	//end
	_funcInfoList[funcInfoListIndex].setIsFirstOpen (_funcInfoList_isFirstOpen);

	// 总CD时间
	long _funcInfoList_totalCountDownTime = readLong();
	//end
	_funcInfoList[funcInfoListIndex].setTotalCountDownTime (_funcInfoList_totalCountDownTime);

	// 图片ID
	String _funcInfoList_icon = readString();
	//end
	_funcInfoList[funcInfoListIndex].setIcon (_funcInfoList_icon);

	// 按钮描述
	String _funcInfoList_menuDesc = readString();
	//end
	_funcInfoList[funcInfoListIndex].setMenuDesc (_funcInfoList_menuDesc);

	// 组ID
	int _funcInfoList_groupID = readInteger();
	//end
	_funcInfoList[funcInfoListIndex].setGroupID (_funcInfoList_groupID);
	}
	//end



		this.funcInfoList = _funcInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 功能按钮列表
	writeShort(funcInfoList.length);
	int funcInfoListIndex = 0;
	int funcInfoListSize = funcInfoList.length;
	for(funcInfoListIndex=0; funcInfoListIndex<funcInfoListSize; funcInfoListIndex++){

	int funcInfoList_funcType = funcInfoList[funcInfoListIndex].getFuncType();

	// 功能按钮类型
	writeInteger(funcInfoList_funcType);

	int funcInfoList_isOpened = funcInfoList[funcInfoListIndex].getIsOpened();

	// 1开启，0关闭
	writeInteger(funcInfoList_isOpened);

	int funcInfoList_ownerFuncType = funcInfoList[funcInfoListIndex].getOwnerFuncType();

	// 所属功能
	writeInteger(funcInfoList_ownerFuncType);

	int funcInfoList_effect = funcInfoList[funcInfoListIndex].getEffect();

	// 特效
	writeInteger(funcInfoList_effect);

	String funcInfoList_name = funcInfoList[funcInfoListIndex].getName();

	// 名称
	writeString(funcInfoList_name);

	String funcInfoList_desc = funcInfoList[funcInfoListIndex].getDesc();

	// 描述
	writeString(funcInfoList_desc);

	int funcInfoList_showNum = funcInfoList[funcInfoListIndex].getShowNum();

	// 数字角标，没有则为0
	writeInteger(funcInfoList_showNum);

	long funcInfoList_countDownTime = funcInfoList[funcInfoListIndex].getCountDownTime();

	// 倒计时，没有则为0
	writeLong(funcInfoList_countDownTime);

	int funcInfoList_position = funcInfoList[funcInfoListIndex].getPosition();

	// 按钮位置
	writeInteger(funcInfoList_position);

	int funcInfoList_order = funcInfoList[funcInfoListIndex].getOrder();

	// 顺序
	writeInteger(funcInfoList_order);

	int funcInfoList_isFirstOpen = funcInfoList[funcInfoListIndex].getIsFirstOpen();

	// 是否首次开启，0否，1是
	writeInteger(funcInfoList_isFirstOpen);

	long funcInfoList_totalCountDownTime = funcInfoList[funcInfoListIndex].getTotalCountDownTime();

	// 总CD时间
	writeLong(funcInfoList_totalCountDownTime);

	String funcInfoList_icon = funcInfoList[funcInfoListIndex].getIcon();

	// 图片ID
	writeString(funcInfoList_icon);

	String funcInfoList_menuDesc = funcInfoList[funcInfoListIndex].getMenuDesc();

	// 按钮描述
	writeString(funcInfoList_menuDesc);

	int funcInfoList_groupID = funcInfoList[funcInfoListIndex].getGroupID();

	// 组ID
	writeInteger(funcInfoList_groupID);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_FUNC_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_FUNC_LIST";
	}

	public com.imop.lj.common.model.human.FuncShowInfo[] getFuncInfoList(){
		return funcInfoList;
	}

	public void setFuncInfoList(com.imop.lj.common.model.human.FuncShowInfo[] funcInfoList){
		this.funcInfoList = funcInfoList;
	}	
	public boolean isCompress() {
		return true;
	}
}