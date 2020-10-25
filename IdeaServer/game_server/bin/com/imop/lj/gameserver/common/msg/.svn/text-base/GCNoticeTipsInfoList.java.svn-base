package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 小信封功能信息列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCNoticeTipsInfoList extends GCMessage{
	
	/** 小信封功能信息列表 */
	private com.imop.lj.common.model.human.NoticeTipsInfo[] noticeTipsInfoList;

	public GCNoticeTipsInfoList (){
	}
	
	public GCNoticeTipsInfoList (
			com.imop.lj.common.model.human.NoticeTipsInfo[] noticeTipsInfoList ){
			this.noticeTipsInfoList = noticeTipsInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 小信封功能信息列表
	int noticeTipsInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.human.NoticeTipsInfo[] _noticeTipsInfoList = new com.imop.lj.common.model.human.NoticeTipsInfo[noticeTipsInfoListSize];
	int noticeTipsInfoListIndex = 0;
	for(noticeTipsInfoListIndex=0; noticeTipsInfoListIndex<noticeTipsInfoListSize; noticeTipsInfoListIndex++){
		_noticeTipsInfoList[noticeTipsInfoListIndex] = new com.imop.lj.common.model.human.NoticeTipsInfo();
	// 窗口内容
	String _noticeTipsInfoList_content = readString();
	//end
	_noticeTipsInfoList[noticeTipsInfoListIndex].setContent (_noticeTipsInfoList_content);

	// 操作标识
	String _noticeTipsInfoList_tag = readString();
	//end
	_noticeTipsInfoList[noticeTipsInfoListIndex].setTag (_noticeTipsInfoList_tag);

	// 小信封1无选择项2有选择框
	int _noticeTipsInfoList_type = readInteger();
	//end
	_noticeTipsInfoList[noticeTipsInfoListIndex].setType (_noticeTipsInfoList_type);

	// 小信封icon
	int _noticeTipsInfoList_icon = readInteger();
	//end
	_noticeTipsInfoList[noticeTipsInfoListIndex].setIcon (_noticeTipsInfoList_icon);

	// 点完确定之后播放的动画类型，暂留
	int _noticeTipsInfoList_showAnimation = readInteger();
	//end
	_noticeTipsInfoList[noticeTipsInfoListIndex].setShowAnimation (_noticeTipsInfoList_showAnimation);

	// 来源角色ID
	long _noticeTipsInfoList_fromRoleId = readLong();
	//end
	_noticeTipsInfoList[noticeTipsInfoListIndex].setFromRoleId (_noticeTipsInfoList_fromRoleId);

	// 来源名称
	String _noticeTipsInfoList_fromRoleName = readString();
	//end
	_noticeTipsInfoList[noticeTipsInfoListIndex].setFromRoleName (_noticeTipsInfoList_fromRoleName);

	// 等级
	int _noticeTipsInfoList_fromRoleLevel = readInteger();
	//end
	_noticeTipsInfoList[noticeTipsInfoListIndex].setFromRoleLevel (_noticeTipsInfoList_fromRoleLevel);

	// 角色职业
	int _noticeTipsInfoList_fromRoleJobType = readInteger();
	//end
	_noticeTipsInfoList[noticeTipsInfoListIndex].setFromRoleJobType (_noticeTipsInfoList_fromRoleJobType);

	// 角色模板Id
	int _noticeTipsInfoList_fromRoleTplId = readInteger();
	//end
	_noticeTipsInfoList[noticeTipsInfoListIndex].setFromRoleTplId (_noticeTipsInfoList_fromRoleTplId);

	// 聊天时间
	long _noticeTipsInfoList_chatTime = readLong();
	//end
	_noticeTipsInfoList[noticeTipsInfoListIndex].setChatTime (_noticeTipsInfoList_chatTime);
	}
	//end



		this.noticeTipsInfoList = _noticeTipsInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 小信封功能信息列表
	writeShort(noticeTipsInfoList.length);
	int noticeTipsInfoListIndex = 0;
	int noticeTipsInfoListSize = noticeTipsInfoList.length;
	for(noticeTipsInfoListIndex=0; noticeTipsInfoListIndex<noticeTipsInfoListSize; noticeTipsInfoListIndex++){

	String noticeTipsInfoList_content = noticeTipsInfoList[noticeTipsInfoListIndex].getContent();

	// 窗口内容
	writeString(noticeTipsInfoList_content);

	String noticeTipsInfoList_tag = noticeTipsInfoList[noticeTipsInfoListIndex].getTag();

	// 操作标识
	writeString(noticeTipsInfoList_tag);

	int noticeTipsInfoList_type = noticeTipsInfoList[noticeTipsInfoListIndex].getType();

	// 小信封1无选择项2有选择框
	writeInteger(noticeTipsInfoList_type);

	int noticeTipsInfoList_icon = noticeTipsInfoList[noticeTipsInfoListIndex].getIcon();

	// 小信封icon
	writeInteger(noticeTipsInfoList_icon);

	int noticeTipsInfoList_showAnimation = noticeTipsInfoList[noticeTipsInfoListIndex].getShowAnimation();

	// 点完确定之后播放的动画类型，暂留
	writeInteger(noticeTipsInfoList_showAnimation);

	long noticeTipsInfoList_fromRoleId = noticeTipsInfoList[noticeTipsInfoListIndex].getFromRoleId();

	// 来源角色ID
	writeLong(noticeTipsInfoList_fromRoleId);

	String noticeTipsInfoList_fromRoleName = noticeTipsInfoList[noticeTipsInfoListIndex].getFromRoleName();

	// 来源名称
	writeString(noticeTipsInfoList_fromRoleName);

	int noticeTipsInfoList_fromRoleLevel = noticeTipsInfoList[noticeTipsInfoListIndex].getFromRoleLevel();

	// 等级
	writeInteger(noticeTipsInfoList_fromRoleLevel);

	int noticeTipsInfoList_fromRoleJobType = noticeTipsInfoList[noticeTipsInfoListIndex].getFromRoleJobType();

	// 角色职业
	writeInteger(noticeTipsInfoList_fromRoleJobType);

	int noticeTipsInfoList_fromRoleTplId = noticeTipsInfoList[noticeTipsInfoListIndex].getFromRoleTplId();

	// 角色模板Id
	writeInteger(noticeTipsInfoList_fromRoleTplId);

	long noticeTipsInfoList_chatTime = noticeTipsInfoList[noticeTipsInfoListIndex].getChatTime();

	// 聊天时间
	writeLong(noticeTipsInfoList_chatTime);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_NOTICE_TIPS_INFO_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_NOTICE_TIPS_INFO_LIST";
	}

	public com.imop.lj.common.model.human.NoticeTipsInfo[] getNoticeTipsInfoList(){
		return noticeTipsInfoList;
	}

	public void setNoticeTipsInfoList(com.imop.lj.common.model.human.NoticeTipsInfo[] noticeTipsInfoList){
		this.noticeTipsInfoList = noticeTipsInfoList;
	}	
}