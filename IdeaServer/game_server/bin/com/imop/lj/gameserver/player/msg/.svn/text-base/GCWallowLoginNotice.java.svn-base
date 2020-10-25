package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 防沉迷登录提示
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWallowLoginNotice extends GCMessage{
	
	/** 提示内容 */
	private String noticeContent;

	public GCWallowLoginNotice (){
	}
	
	public GCWallowLoginNotice (
			String noticeContent ){
			this.noticeContent = noticeContent;
	}

	@Override
	protected boolean readImpl() {

	// 提示内容
	String _noticeContent = readString();
	//end



		this.noticeContent = _noticeContent;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 提示内容
	writeString(noticeContent);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_WALLOW_LOGIN_NOTICE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_WALLOW_LOGIN_NOTICE";
	}

	public String getNoticeContent(){
		return noticeContent;
	}
		
	public void setNoticeContent(String noticeContent){
		this.noticeContent = noticeContent;
	}
}