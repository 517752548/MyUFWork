package com.imop.lj.gameserver.broadcast;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;

import com.google.common.collect.Sets;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.SysMsgInfo;
import com.imop.lj.common.model.human.ChatInfo;
import com.imop.lj.gameserver.broadcast.template.BroadcastTemplate;
import com.imop.lj.gameserver.chat.msg.GCChatMsg;
import com.imop.lj.gameserver.chat.msg.GCChatMsgList;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.SysMsgShowTypes.SysMessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
import com.imop.lj.gameserver.common.msg.GCSystemMessage;
import com.imop.lj.gameserver.common.msg.GCSystemMessageList;
import com.imop.lj.gameserver.human.Country;
import com.imop.lj.gameserver.scene.Scene;

/**
 * 广播服务类
 * @author yu.zhao
 *
 */
public class BroadcastService {
	/** 待广播数据集合最大size */
	protected static int BROADCAST_MSG_MAX_SIZE = 100;
	/** 待广播数据集合，可能非场景线程也会发广播，所以使用并发set */
	protected Set<SysMsgInfo> worldBroadcastSet = Sets.newConcurrentHashSet();
	
	/** 服务器人数低于此数，立即发送聊天消息 */
	protected static int CHAT_NUM1 = 500;
	/** 服务器人数低于此数高于CHAT_NUM1，延迟1秒发送聊天消息 */
	protected static int CHAT_NUM2 = 1000;
	
	public static int CHAT_DELAY1 = 1000;
	public static int CHAT_DELAY2 = 3000;
	
	protected List<ChatInfo> worldChatList = new ArrayList<ChatInfo>();
	protected long lastWorldChatTime;

	public BroadcastService() {
		
	}
	
	/**
	 * 广播全局消息
	 * @param broadcastTplId
	 * @param params
	 */
	public void broadcastWorldMessage(int broadcastTplId, Object... params) {
		BroadcastTemplate broadcastTpl = Globals.getTemplateCacheService().get(broadcastTplId, BroadcastTemplate.class);
		if (null == broadcastTpl) {
			return;
		}
		SysMessageType sysMessageType = broadcastTpl.getSysMessageType();
		
		switch (sysMessageType) {
		case NONE:
		case COUNTRY_MESSAGE:
		case GUILD_MESSAGE:
			// 该方法不支持此类型
			return;

		default:
			break;
		}
		
		String contents = MessageFormat.format(broadcastTpl.getContents(), params);
	
		// 如果当前广播数量已经超过最大值，则忽略当前的广播
		if (worldBroadcastSet.size() >= BROADCAST_MSG_MAX_SIZE) {
			// 记录错误日志，当前待发数据超出上限，说明其他模块调用的太频繁，有问题
			Loggers.broadcastLogger.error("#BroadcastService#broadcastWorldMessage#ERROR!worldBroadcastSet.size()>=" + 
					BROADCAST_MSG_MAX_SIZE + ";ignore this broadcast,broadcastTplId=" + broadcastTplId + 
					";contents=" + contents + ";worldBroadcastSet=" + worldBroadcastSet);
			return;
		}
		
		// 加入集合中，待心跳时发送
		worldBroadcastSet.add(new SysMsgInfo(contents, (short)sysMessageType.getIndex()));
	}
	
	/**
	 * 心跳时检测并发广播消息
	 */
	public void checkWorldBroadcast() {
		// 没有广播数据，直接返回
		if (worldBroadcastSet.isEmpty()) {
			return;
		}
		
		// 构建消息参数
		List<SysMsgInfo> msgInfoList = new ArrayList<SysMsgInfo>(worldBroadcastSet);
		// 清除数据
		worldBroadcastSet.clear();
		
		// 发广播消息
		GCSystemMessageList msgList = new GCSystemMessageList(msgInfoList.toArray(new SysMsgInfo[0]));
		Globals.getOnlinePlayerService().broadcastMsg(msgList);
		
		Loggers.broadcastLogger.info("GCSystemMessageList size=" + msgInfoList.size());
	}
	
	/**
	 * 广播国家消息
	 * @param broadcastTplId
	 * @param country
	 * @param params
	 */
	public void broadcastCountryMessage(int broadcastTplId, Country country, Object... params) {
		BroadcastTemplate broadcastTpl = Globals.getTemplateCacheService().get(broadcastTplId, BroadcastTemplate.class);
		if (null == broadcastTpl) {
			return;
		}
		SysMessageType sysMessageType = broadcastTpl.getSysMessageType();
		if (sysMessageType != SysMessageType.COUNTRY_MESSAGE) {
			// 类型错误
			return;
		}
		
		String contents = MessageFormat.format(broadcastTpl.getContents(), params);
		GCSystemMessage gcSystemMessage = sysMessageType.genSystemMessage(contents);
		Globals.getOnlinePlayerService().broadcastCountryMessage(country, gcSystemMessage);
	}
	
	/**
	 * 场景内广播消息
	 * 
	 * @param broadcastTplId
	 * @param sceneId
	 * @param params
	 */
	public void broadcastSceneMessage(int broadcastTplId, int sceneId, Object... params){
		BroadcastTemplate broadcastTpl = Globals.getTemplateCacheService().get(broadcastTplId, BroadcastTemplate.class);
		if (null == broadcastTpl) {
			return;
		}
		
		Scene scene = Globals.getSceneService().getScene(sceneId);
		if(scene == null){
			return;
		}
		
		SysMessageType sysMessageType = broadcastTpl.getSysMessageType();
		
		String contents = MessageFormat.format(broadcastTpl.getContents(), params);
		GCSystemMessage gcSystemMessage = sysMessageType.genSystemMessage(contents);
		
		scene.sendScenePlayerMsg(gcSystemMessage);
	}
	
	public void handleWorldChat(GCChatMsg gcChatMsg) {
		int playerNum = Globals.getOnlinePlayerService().getOnlinePlayerCount();
		//小于指定人数，直接发送，超过了放到缓存中一起发送
		if (playerNum <= CHAT_NUM1) {
			//可能这时候列表里面还有，需要放进去一起立即发送
			if (!this.worldChatList.isEmpty()) {
				//构造消息并发送
				this.worldChatList.add(gcChatMsg.getChatInfo());
				GCMessage msg = new GCChatMsgList(this.worldChatList.toArray(new ChatInfo[0]));
				Globals.getOnlinePlayerService().broadcastMsg(msg);
			} else {
				//立即发送
				Globals.getOnlinePlayerService().broadcastMsg(gcChatMsg);
			}
		} else {
			//加到缓存列表
			this.worldChatList.add(gcChatMsg.getChatInfo());
		}
	}
	
	protected int getWorldChatDelayTime() {
		int playerNum = Globals.getOnlinePlayerService().getOnlinePlayerCount();
		if (playerNum > CHAT_NUM1 && playerNum <= CHAT_NUM2) {
			return CHAT_DELAY1;
		} else if (playerNum > CHAT_NUM2) {
			return CHAT_DELAY2;
		}
		return 0;
	}
	
	/**
	 * 定时检测是否需要发送世界聊天消息
	 */
	public void checkWorldChat() {
		//没有数据，直接返回
		if (this.worldChatList == null || this.worldChatList.isEmpty()) {
			return;
		}
		
		long now = Globals.getTimeService().now();
		if (this.lastWorldChatTime + getWorldChatDelayTime() < now) {
			//构造消息并发送
			GCMessage msg = new GCChatMsgList(this.worldChatList.toArray(new ChatInfo[0]));
			Globals.getOnlinePlayerService().broadcastMsg(msg);
			
			//清除数据
			this.worldChatList.clear();
			//更新最后一次发送时间
			this.lastWorldChatTime = now;
		}
		
	}
}
