package com.imop.lj.gameserver.wing.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回翅膀列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWingPanel extends GCMessage{
	
	/** 翅膀信息页面 */
	private com.imop.lj.gameserver.wing.WingInfo[] wingList;

	public GCWingPanel (){
	}
	
	public GCWingPanel (
			com.imop.lj.gameserver.wing.WingInfo[] wingList ){
			this.wingList = wingList;
	}

	@Override
	protected boolean readImpl() {

	// 翅膀信息页面
	int wingListSize = readUnsignedShort();
	com.imop.lj.gameserver.wing.WingInfo[] _wingList = new com.imop.lj.gameserver.wing.WingInfo[wingListSize];
	int wingListIndex = 0;
	for(wingListIndex=0; wingListIndex<wingListSize; wingListIndex++){
		_wingList[wingListIndex] = new com.imop.lj.gameserver.wing.WingInfo();
	// 翅膀类型id
	int _wingList_templateId = readInteger();
	//end
	_wingList[wingListIndex].setTemplateId (_wingList_templateId);

	// 是否已装备
	int _wingList_isEquip = readInteger();
	//end
	_wingList[wingListIndex].setIsEquip (_wingList_isEquip);

	// 翅膀阶数
	int _wingList_wingLevel = readInteger();
	//end
	_wingList[wingListIndex].setWingLevel (_wingList_wingLevel);

	// 翅膀祝福值
	int _wingList_wingBless = readInteger();
	//end
	_wingList[wingListIndex].setWingBless (_wingList_wingBless);

	// 翅膀战斗力
	int _wingList_wingPower = readInteger();
	//end
	_wingList[wingListIndex].setWingPower (_wingList_wingPower);
	}
	//end



		this.wingList = _wingList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 翅膀信息页面
	writeShort(wingList.length);
	int wingListIndex = 0;
	int wingListSize = wingList.length;
	for(wingListIndex=0; wingListIndex<wingListSize; wingListIndex++){

	int wingList_templateId = wingList[wingListIndex].getTemplateId();

	// 翅膀类型id
	writeInteger(wingList_templateId);

	int wingList_isEquip = wingList[wingListIndex].getIsEquip();

	// 是否已装备
	writeInteger(wingList_isEquip);

	int wingList_wingLevel = wingList[wingListIndex].getWingLevel();

	// 翅膀阶数
	writeInteger(wingList_wingLevel);

	int wingList_wingBless = wingList[wingListIndex].getWingBless();

	// 翅膀祝福值
	writeInteger(wingList_wingBless);

	int wingList_wingPower = wingList[wingListIndex].getWingPower();

	// 翅膀战斗力
	writeInteger(wingList_wingPower);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_WING_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_WING_PANEL";
	}

	public com.imop.lj.gameserver.wing.WingInfo[] getWingList(){
		return wingList;
	}

	public void setWingList(com.imop.lj.gameserver.wing.WingInfo[] wingList){
		this.wingList = wingList;
	}	
}