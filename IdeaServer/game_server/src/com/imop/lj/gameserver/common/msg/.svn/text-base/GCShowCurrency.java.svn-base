package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 货币显示配置
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCShowCurrency extends GCMessage{
	
	/** 显示货币信息 */
	private com.imop.lj.common.model.constant.ShowCurrencyInfo[] showCurrencyInfoList;

	public GCShowCurrency (){
	}
	
	public GCShowCurrency (
			com.imop.lj.common.model.constant.ShowCurrencyInfo[] showCurrencyInfoList ){
			this.showCurrencyInfoList = showCurrencyInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 显示货币信息
	int showCurrencyInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.constant.ShowCurrencyInfo[] _showCurrencyInfoList = new com.imop.lj.common.model.constant.ShowCurrencyInfo[showCurrencyInfoListSize];
	int showCurrencyInfoListIndex = 0;
	for(showCurrencyInfoListIndex=0; showCurrencyInfoListIndex<showCurrencyInfoListSize; showCurrencyInfoListIndex++){
		_showCurrencyInfoList[showCurrencyInfoListIndex] = new com.imop.lj.common.model.constant.ShowCurrencyInfo();
	// 类型
	int _showCurrencyInfoList_showType = readInteger();
	//end
	_showCurrencyInfoList[showCurrencyInfoListIndex].setShowType (_showCurrencyInfoList_showType);

	// 类别名称
	String _showCurrencyInfoList_typeName = readString();
	//end
	_showCurrencyInfoList[showCurrencyInfoListIndex].setTypeName (_showCurrencyInfoList_typeName);

	// 名称
	String _showCurrencyInfoList_name = readString();
	//end
	_showCurrencyInfoList[showCurrencyInfoListIndex].setName (_showCurrencyInfoList_name);

	// 描述
	String _showCurrencyInfoList_desc = readString();
	//end
	_showCurrencyInfoList[showCurrencyInfoListIndex].setDesc (_showCurrencyInfoList_desc);

	// 图标
	int _showCurrencyInfoList_icon = readInteger();
	//end
	_showCurrencyInfoList[showCurrencyInfoListIndex].setIcon (_showCurrencyInfoList_icon);

	// 最小值
	long _showCurrencyInfoList_min = readLong();
	//end
	_showCurrencyInfoList[showCurrencyInfoListIndex].setMin (_showCurrencyInfoList_min);

	// 最大值
	long _showCurrencyInfoList_max = readLong();
	//end
	_showCurrencyInfoList[showCurrencyInfoListIndex].setMax (_showCurrencyInfoList_max);
	}
	//end



		this.showCurrencyInfoList = _showCurrencyInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 显示货币信息
	writeShort(showCurrencyInfoList.length);
	int showCurrencyInfoListIndex = 0;
	int showCurrencyInfoListSize = showCurrencyInfoList.length;
	for(showCurrencyInfoListIndex=0; showCurrencyInfoListIndex<showCurrencyInfoListSize; showCurrencyInfoListIndex++){

	int showCurrencyInfoList_showType = showCurrencyInfoList[showCurrencyInfoListIndex].getShowType();

	// 类型
	writeInteger(showCurrencyInfoList_showType);

	String showCurrencyInfoList_typeName = showCurrencyInfoList[showCurrencyInfoListIndex].getTypeName();

	// 类别名称
	writeString(showCurrencyInfoList_typeName);

	String showCurrencyInfoList_name = showCurrencyInfoList[showCurrencyInfoListIndex].getName();

	// 名称
	writeString(showCurrencyInfoList_name);

	String showCurrencyInfoList_desc = showCurrencyInfoList[showCurrencyInfoListIndex].getDesc();

	// 描述
	writeString(showCurrencyInfoList_desc);

	int showCurrencyInfoList_icon = showCurrencyInfoList[showCurrencyInfoListIndex].getIcon();

	// 图标
	writeInteger(showCurrencyInfoList_icon);

	long showCurrencyInfoList_min = showCurrencyInfoList[showCurrencyInfoListIndex].getMin();

	// 最小值
	writeLong(showCurrencyInfoList_min);

	long showCurrencyInfoList_max = showCurrencyInfoList[showCurrencyInfoListIndex].getMax();

	// 最大值
	writeLong(showCurrencyInfoList_max);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_SHOW_CURRENCY;
	}
	
	@Override
	public String getTypeName() {
		return "GC_SHOW_CURRENCY";
	}

	public com.imop.lj.common.model.constant.ShowCurrencyInfo[] getShowCurrencyInfoList(){
		return showCurrencyInfoList;
	}

	public void setShowCurrencyInfoList(com.imop.lj.common.model.constant.ShowCurrencyInfo[] showCurrencyInfoList){
		this.showCurrencyInfoList = showCurrencyInfoList;
	}	
}