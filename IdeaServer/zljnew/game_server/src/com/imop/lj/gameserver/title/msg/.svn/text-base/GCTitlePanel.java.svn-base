package com.imop.lj.gameserver.title.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回称号界面
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTitlePanel extends GCMessage{
	
	/** 称号信息页面 */
	private com.imop.lj.gameserver.title.TitleInfo[] titleList;

	public GCTitlePanel (){
	}
	
	public GCTitlePanel (
			com.imop.lj.gameserver.title.TitleInfo[] titleList ){
			this.titleList = titleList;
	}

	@Override
	protected boolean readImpl() {

	// 称号信息页面
	int titleListSize = readUnsignedShort();
	com.imop.lj.gameserver.title.TitleInfo[] _titleList = new com.imop.lj.gameserver.title.TitleInfo[titleListSize];
	int titleListIndex = 0;
	for(titleListIndex=0; titleListIndex<titleListSize; titleListIndex++){
		_titleList[titleListIndex] = new com.imop.lj.gameserver.title.TitleInfo();
	// 称号名称
	String _titleList_titleName = readString();
	//end
	_titleList[titleListIndex].setTitleName (_titleList_titleName);

	// 称号类型id
	int _titleList_templateId = readInteger();
	//end
	_titleList[titleListIndex].setTemplateId (_titleList_templateId);

	// 称号过期时间
	long _titleList_titleEndTime = readLong();
	//end
	_titleList[titleListIndex].setTitleEndTime (_titleList_titleEndTime);
	}
	//end



		this.titleList = _titleList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 称号信息页面
	writeShort(titleList.length);
	int titleListIndex = 0;
	int titleListSize = titleList.length;
	for(titleListIndex=0; titleListIndex<titleListSize; titleListIndex++){

	String titleList_titleName = titleList[titleListIndex].getTitleName();

	// 称号名称
	writeString(titleList_titleName);

	int titleList_templateId = titleList[titleListIndex].getTemplateId();

	// 称号类型id
	writeInteger(titleList_templateId);

	long titleList_titleEndTime = titleList[titleListIndex].getTitleEndTime();

	// 称号过期时间
	writeLong(titleList_titleEndTime);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_TITLE_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_TITLE_PANEL";
	}

	public com.imop.lj.gameserver.title.TitleInfo[] getTitleList(){
		return titleList;
	}

	public void setTitleList(com.imop.lj.gameserver.title.TitleInfo[] titleList){
		this.titleList = titleList;
	}	
}