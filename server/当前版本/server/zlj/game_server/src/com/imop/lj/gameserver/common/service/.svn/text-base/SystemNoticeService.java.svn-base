package com.imop.lj.gameserver.common.service;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.NoticeTypes;
import com.imop.lj.common.constants.SysMsgShowTypes.MessageType;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.msg.GCSystemMessage;
import com.imop.lj.gameserver.common.msg.GCSystemNotice;

public class SystemNoticeService implements InitializeRequired {

	@Override
	public void init() {

	}

	/**
	 * 全世界发送公告
	 * 
	 * @param noticeType
	 * @param content
	 */
	public void sendNotice(Short noticeType, String content) {
		switch (noticeType) {
		case NoticeTypes.system:
			sendSystemNotice(content, (short) Globals.getGameConstants().getDefaultNoticeSpeed());
			break;
		case NoticeTypes.important:
			sendImportantNotice(content);
			break;
		case NoticeTypes.common:
			sendCommonNotice(content);
			break;
		case NoticeTypes.broadcast:
			sendWorldNotice(content);
			break;
		}
	}

	/**
	 * 
	 * 向本服务器上的玩家发送公告[跑马灯]
	 * 
	 * @param content
	 * @param speed
	 */
	protected static void sendSystemNotice(String content, short speed) {
		 GCSystemNotice msg = new GCSystemNotice(content, speed);
		 Globals.getOnlinePlayerService().broadcastMsg(msg);
	}

	/**
	 * 向全服发送重要系统公告[聊天框]
	 * 
	 * @param content
	 */
	protected static void sendImportantNotice(String content) {
		GCSystemMessage msg = new GCSystemMessage(content, MessageType.important.getShortIndex());
		Globals.getOnlinePlayerService().broadcastMsg(msg);
	}

	/**
	 * 向全服发送系统提示[聊天框]
	 * 
	 * @param content
	 */
	protected static void sendCommonNotice(String content) {
		GCSystemMessage msg = new GCSystemMessage(content, MessageType.generic.getShortIndex());
		Globals.getOnlinePlayerService().broadcastMsg(msg);
	}

	/**
	 * 系统推送
	 * 
	 * @param content
	 */
	protected static void sendWorldNotice(String content) {
		GCSystemMessage msg = new GCSystemMessage(content, MessageType.dialog.getShortIndex());
		Globals.getOnlinePlayerService().broadcastMsg(msg);
	}

	public void sendWorldNotice(String content, MessageType messageType) {
		GCSystemMessage msg = new GCSystemMessage(content, messageType.getShortIndex());
		Globals.getOnlinePlayerService().broadcastMsg(msg);
	}

}
