package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 功能按钮更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCFuncUpdate extends GCMessage{
	
	/** 功能按钮 */
	private com.imop.lj.common.model.human.FuncShowInfo funcInfo;

	public GCFuncUpdate (){
	}
	
	public GCFuncUpdate (
			com.imop.lj.common.model.human.FuncShowInfo funcInfo ){
			this.funcInfo = funcInfo;
	}

	@Override
	protected boolean readImpl() {
	// 功能按钮
	com.imop.lj.common.model.human.FuncShowInfo _funcInfo = new com.imop.lj.common.model.human.FuncShowInfo();

	// 功能按钮类型
	int _funcInfo_funcType = readInteger();
	//end
	_funcInfo.setFuncType (_funcInfo_funcType);

	// 1开启，0关闭
	int _funcInfo_isOpened = readInteger();
	//end
	_funcInfo.setIsOpened (_funcInfo_isOpened);

	// 所属功能
	int _funcInfo_ownerFuncType = readInteger();
	//end
	_funcInfo.setOwnerFuncType (_funcInfo_ownerFuncType);

	// 特效
	int _funcInfo_effect = readInteger();
	//end
	_funcInfo.setEffect (_funcInfo_effect);

	// 名称
	String _funcInfo_name = readString();
	//end
	_funcInfo.setName (_funcInfo_name);

	// 描述
	String _funcInfo_desc = readString();
	//end
	_funcInfo.setDesc (_funcInfo_desc);

	// 数字角标，没有则为0
	int _funcInfo_showNum = readInteger();
	//end
	_funcInfo.setShowNum (_funcInfo_showNum);

	// 倒计时，没有则为0
	long _funcInfo_countDownTime = readLong();
	//end
	_funcInfo.setCountDownTime (_funcInfo_countDownTime);

	// 按钮位置
	int _funcInfo_position = readInteger();
	//end
	_funcInfo.setPosition (_funcInfo_position);

	// 顺序
	int _funcInfo_order = readInteger();
	//end
	_funcInfo.setOrder (_funcInfo_order);

	// 是否首次开启，0否，1是
	int _funcInfo_isFirstOpen = readInteger();
	//end
	_funcInfo.setIsFirstOpen (_funcInfo_isFirstOpen);

	// 总CD时间
	long _funcInfo_totalCountDownTime = readLong();
	//end
	_funcInfo.setTotalCountDownTime (_funcInfo_totalCountDownTime);

	// 图片ID
	String _funcInfo_icon = readString();
	//end
	_funcInfo.setIcon (_funcInfo_icon);

	// 按钮描述
	String _funcInfo_menuDesc = readString();
	//end
	_funcInfo.setMenuDesc (_funcInfo_menuDesc);

	// 组ID
	int _funcInfo_groupID = readInteger();
	//end
	_funcInfo.setGroupID (_funcInfo_groupID);



		this.funcInfo = _funcInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	int funcInfo_funcType = funcInfo.getFuncType ();

	// 功能按钮类型
	writeInteger(funcInfo_funcType);

	int funcInfo_isOpened = funcInfo.getIsOpened ();

	// 1开启，0关闭
	writeInteger(funcInfo_isOpened);

	int funcInfo_ownerFuncType = funcInfo.getOwnerFuncType ();

	// 所属功能
	writeInteger(funcInfo_ownerFuncType);

	int funcInfo_effect = funcInfo.getEffect ();

	// 特效
	writeInteger(funcInfo_effect);

	String funcInfo_name = funcInfo.getName ();

	// 名称
	writeString(funcInfo_name);

	String funcInfo_desc = funcInfo.getDesc ();

	// 描述
	writeString(funcInfo_desc);

	int funcInfo_showNum = funcInfo.getShowNum ();

	// 数字角标，没有则为0
	writeInteger(funcInfo_showNum);

	long funcInfo_countDownTime = funcInfo.getCountDownTime ();

	// 倒计时，没有则为0
	writeLong(funcInfo_countDownTime);

	int funcInfo_position = funcInfo.getPosition ();

	// 按钮位置
	writeInteger(funcInfo_position);

	int funcInfo_order = funcInfo.getOrder ();

	// 顺序
	writeInteger(funcInfo_order);

	int funcInfo_isFirstOpen = funcInfo.getIsFirstOpen ();

	// 是否首次开启，0否，1是
	writeInteger(funcInfo_isFirstOpen);

	long funcInfo_totalCountDownTime = funcInfo.getTotalCountDownTime ();

	// 总CD时间
	writeLong(funcInfo_totalCountDownTime);

	String funcInfo_icon = funcInfo.getIcon ();

	// 图片ID
	writeString(funcInfo_icon);

	String funcInfo_menuDesc = funcInfo.getMenuDesc ();

	// 按钮描述
	writeString(funcInfo_menuDesc);

	int funcInfo_groupID = funcInfo.getGroupID ();

	// 组ID
	writeInteger(funcInfo_groupID);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_FUNC_UPDATE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_FUNC_UPDATE";
	}

	public com.imop.lj.common.model.human.FuncShowInfo getFuncInfo(){
		return funcInfo;
	}
		
	public void setFuncInfo(com.imop.lj.common.model.human.FuncShowInfo funcInfo){
		this.funcInfo = funcInfo;
	}
}