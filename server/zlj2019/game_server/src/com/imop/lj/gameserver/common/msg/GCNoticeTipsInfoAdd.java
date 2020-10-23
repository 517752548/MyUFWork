package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 增加小信封信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCNoticeTipsInfoAdd extends GCMessage{
	
	/** 增加小信封信息 */
	private com.imop.lj.common.model.human.NoticeTipsInfo noticeTipsInfo;

	public GCNoticeTipsInfoAdd (){
	}
	
	public GCNoticeTipsInfoAdd (
			com.imop.lj.common.model.human.NoticeTipsInfo noticeTipsInfo ){
			this.noticeTipsInfo = noticeTipsInfo;
	}

	@Override
	protected boolean readImpl() {
	// 增加小信封信息
	com.imop.lj.common.model.human.NoticeTipsInfo _noticeTipsInfo = new com.imop.lj.common.model.human.NoticeTipsInfo();

	// 窗口内容
	String _noticeTipsInfo_content = readString();
	//end
	_noticeTipsInfo.setContent (_noticeTipsInfo_content);

	// 操作标识
	String _noticeTipsInfo_tag = readString();
	//end
	_noticeTipsInfo.setTag (_noticeTipsInfo_tag);

	// 小信封1无选择项2有选择框
	int _noticeTipsInfo_type = readInteger();
	//end
	_noticeTipsInfo.setType (_noticeTipsInfo_type);

	// 小信封icon
	int _noticeTipsInfo_icon = readInteger();
	//end
	_noticeTipsInfo.setIcon (_noticeTipsInfo_icon);

	// 点完确定之后播放的动画类型，暂留
	int _noticeTipsInfo_showAnimation = readInteger();
	//end
	_noticeTipsInfo.setShowAnimation (_noticeTipsInfo_showAnimation);

	// 来源角色ID
	long _noticeTipsInfo_fromRoleId = readLong();
	//end
	_noticeTipsInfo.setFromRoleId (_noticeTipsInfo_fromRoleId);

	// 来源名称
	String _noticeTipsInfo_fromRoleName = readString();
	//end
	_noticeTipsInfo.setFromRoleName (_noticeTipsInfo_fromRoleName);

	// 等级
	int _noticeTipsInfo_fromRoleLevel = readInteger();
	//end
	_noticeTipsInfo.setFromRoleLevel (_noticeTipsInfo_fromRoleLevel);

	// 角色职业
	int _noticeTipsInfo_fromRoleJobType = readInteger();
	//end
	_noticeTipsInfo.setFromRoleJobType (_noticeTipsInfo_fromRoleJobType);

	// 角色模板Id
	int _noticeTipsInfo_fromRoleTplId = readInteger();
	//end
	_noticeTipsInfo.setFromRoleTplId (_noticeTipsInfo_fromRoleTplId);

	// 聊天时间
	long _noticeTipsInfo_chatTime = readLong();
	//end
	_noticeTipsInfo.setChatTime (_noticeTipsInfo_chatTime);



		this.noticeTipsInfo = _noticeTipsInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	String noticeTipsInfo_content = noticeTipsInfo.getContent ();

	// 窗口内容
	writeString(noticeTipsInfo_content);

	String noticeTipsInfo_tag = noticeTipsInfo.getTag ();

	// 操作标识
	writeString(noticeTipsInfo_tag);

	int noticeTipsInfo_type = noticeTipsInfo.getType ();

	// 小信封1无选择项2有选择框
	writeInteger(noticeTipsInfo_type);

	int noticeTipsInfo_icon = noticeTipsInfo.getIcon ();

	// 小信封icon
	writeInteger(noticeTipsInfo_icon);

	int noticeTipsInfo_showAnimation = noticeTipsInfo.getShowAnimation ();

	// 点完确定之后播放的动画类型，暂留
	writeInteger(noticeTipsInfo_showAnimation);

	long noticeTipsInfo_fromRoleId = noticeTipsInfo.getFromRoleId ();

	// 来源角色ID
	writeLong(noticeTipsInfo_fromRoleId);

	String noticeTipsInfo_fromRoleName = noticeTipsInfo.getFromRoleName ();

	// 来源名称
	writeString(noticeTipsInfo_fromRoleName);

	int noticeTipsInfo_fromRoleLevel = noticeTipsInfo.getFromRoleLevel ();

	// 等级
	writeInteger(noticeTipsInfo_fromRoleLevel);

	int noticeTipsInfo_fromRoleJobType = noticeTipsInfo.getFromRoleJobType ();

	// 角色职业
	writeInteger(noticeTipsInfo_fromRoleJobType);

	int noticeTipsInfo_fromRoleTplId = noticeTipsInfo.getFromRoleTplId ();

	// 角色模板Id
	writeInteger(noticeTipsInfo_fromRoleTplId);

	long noticeTipsInfo_chatTime = noticeTipsInfo.getChatTime ();

	// 聊天时间
	writeLong(noticeTipsInfo_chatTime);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_NOTICE_TIPS_INFO_ADD;
	}
	
	@Override
	public String getTypeName() {
		return "GC_NOTICE_TIPS_INFO_ADD";
	}

	public com.imop.lj.common.model.human.NoticeTipsInfo getNoticeTipsInfo(){
		return noticeTipsInfo;
	}
		
	public void setNoticeTipsInfo(com.imop.lj.common.model.human.NoticeTipsInfo noticeTipsInfo){
		this.noticeTipsInfo = noticeTipsInfo;
	}
}