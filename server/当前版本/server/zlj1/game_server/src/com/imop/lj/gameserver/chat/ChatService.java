package com.imop.lj.gameserver.chat;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.model.human.ChatInfo;
import com.imop.lj.common.model.human.QQInfo;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.chat.msg.GCChatMsg;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.player.Player;

/**
 * 处理聊天
 * 
 */
public class ChatService implements InitializeRequired {

	public ChatService() {

	}

	@Override
	public void init() {

	}

	/**
	 * 处理私聊
	 * 
	 * @param player
	 *            发送聊天信息的玩家
	 * @param msg
	 */
	public void handlePrivateChat(Human human, CGChatMsg msg) {
		String _destRoleName = msg.getDestRoleName();
		boolean flag = privateChat(human, _destRoleName, msg.getContent(), msg.getChatType());
		if (flag) {
//			// 如果目标玩家正在演武，则自动回复
//			long destCharId = Globals.getOfflineDataService().getUserIdByName(_destRoleName);
//			Player destPlayer = Globals.getOnlinePlayerService().getPlayer(destCharId);
//			if (destPlayer != null &&
//					destPlayer.getHuman() != null &&
//							destPlayer.getHuman().getPracticeManager() != null &&
//					destPlayer.getHuman().getPracticeManager().isOnPractice()) {
//				String content = Globals.getLangService().readSysLang(LangConstants.CHAT_PLAYER_NOT_ONLINE);
//				privateChat(destPlayer.getHuman(), human.getName(), content);
//			}
		}
	}
	
	protected boolean privateChat(Human human, String _destRoleName, String content, int chatType) {
		/* 消息接收的玩家ID */
		if ((_destRoleName == null) || (_destRoleName = _destRoleName.trim()).isEmpty()) {
			return false;
		}
		if (_destRoleName.equals(human.getName())) {
			return false;
		}
		// 找目标玩家
		long destCharId = Globals.getOfflineDataService().getUserIdByName(_destRoleName);
		if (destCharId <= 0) {
			// 目标玩家不存在
			human.sendSystemMessage(LangConstants.CHAT_PLAYER_NOT_EXIST);
			return false;
		}
		
		// 目标玩家是否在自己的黑名单中
		if (Globals.getRelationService().isTargetInBlackList(human, destCharId)) {
			human.sendSystemMessage(LangConstants.CHAT_PLAYER_IN_BLACK_LIST);
			return false;
		}
		
		if(!this.checkPrivateChatCondition(human, destCharId)){
			return false;
		}

		// 发送给玩家本身
		GCChatMsg gcChatMsg = buildInitGCChatMsg();
		gcChatMsg.getChatInfo().setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
		gcChatMsg.getChatInfo().setChatType(chatType);
		gcChatMsg.getChatInfo().setContent(content);
		gcChatMsg.getChatInfo().setFromRoleUUID(human.getUUID() + "");
		gcChatMsg.getChatInfo().setFromRoleName(human.getName());
		gcChatMsg.getChatInfo().setFromRoleCountry(human.getCountry());
		gcChatMsg.getChatInfo().setFromRoleLevel(human.getLevel());
		gcChatMsg.getChatInfo().setFromRoleTplId(human.getTplId());
		gcChatMsg.getChatInfo().setFromRoleVipLevel(Globals.getVipService().getCurVipLevel(human.getUUID()));
		gcChatMsg.getChatInfo().setChatTime(Globals.getTimeService().now());
		gcChatMsg.getChatInfo().setToRoleUUID(destCharId + "");
		gcChatMsg.getChatInfo().setToRoleName(_destRoleName);
		gcChatMsg.getChatInfo().setToRoleTplId(Globals.getOfflineDataService().getUserTplId(destCharId));
		gcChatMsg.getChatInfo().setToRoleVipLevel(Globals.getVipService().getCurVipLevel(destCharId));
//		// qq信息
//		QQInfo fromQQInfo = human.buildQQInfo();
//		if (null != fromQQInfo) {
//			gcChatMsg.setFromQQInfo(fromQQInfo);
//		}
		
		// 获取目标玩家
		Player destPlayer = Globals.getOnlinePlayerService().getPlayer(destCharId);
		if (destPlayer != null) {
			// 发送者是否接收者的好友
			boolean isFriendOfToRole = Globals.getRelationService().isTargetInFriendList(destPlayer.getHuman(), human.getUUID());
			gcChatMsg.getChatInfo().setIsFriendOfToRole(isFriendOfToRole ? 1 : 0);
//			QQInfo toQQInfo = destPlayer.getHuman().buildQQInfo();
//			if (null != toQQInfo) {
//				gcChatMsg.setToQQInfo(toQQInfo);
//			}
			
			human.sendMessage(gcChatMsg);
			destPlayer.sendMessage(gcChatMsg);
		} else {
			// 目标玩家不在线，给私聊的系统提示
//			GCChatMsg gcChatMsgNotOnline = buildInitGCChatMsg();
//			gcChatMsgNotOnline.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
//			gcChatMsgNotOnline.setContent(Globals.getLangService().readSysLang(LangConstants.CHAT_PLAYER_NOT_ONLINE));
//			gcChatMsgNotOnline.setFromRoleUUID("");// 表示是系统提示，私聊用
//			human.sendMessage(gcChatMsgNotOnline);
			
			//TODO 
			gcChatMsg.getChatInfo().setIsFriendOfToRole(0);
			human.sendMessage(gcChatMsg);
			//如果玩家不在线，则发送小信封 
			UserSnap us = Globals.getOfflineDataService().getUserSnap(destCharId);
			if(us != null){
				Globals.getNoticeTipsInfoService().sendNoticeTipsByPlayer(human.getUUID(), destCharId, content);
			}
		}
		return true;
	}

	/**
	 * 处理世界聊天
	 * 
	 * @param player
	 * @param msg
	 */
	public void handleWorldChat(Human human, CGChatMsg msg) {
		// 获取世界聊天最小级别
		int worldChatMinLevel = 1;
		// Globals
		// .getGameConstants().getWorldChatMinLevel();

		//XXX 玩家小于世界聊天最小允许级别
		if (human.getLevel() < worldChatMinLevel) {
			 human.sendSystemMessage(LangConstants.CHAT_WORLD_MIN_LEVEL,worldChatMinLevel);
			return;
		}

		// 向玩家所在的GS发送消息
		GCChatMsg gcChatMsg = buildGCChatMsg(human, SharedConstants.CHAT_SCOPE_WORLD, msg.getContent(), msg.getChatType());
		
//		// 获取本 GS 的所有在线玩家
//		Globals.getOnlinePlayerService().broadcastMessage(gcChatMsg);
		Globals.getBroadcastService().handleWorldChat(gcChatMsg);
	}

	/**
	 * 向军团内玩家发送聊天信息
	 * 
	 * @param player
	 * @param msg
	 */
	public void handleGuildChat(Human human, CGChatMsg msg) {
		if (msg == null) {
			return;
		}

		//XXX 向玩家所在的GS发送消息
		GCChatMsg gcChatMsg = buildGCChatMsg(human, SharedConstants.CHAT_SCOPE_GUILD, msg.getContent(), msg.getChatType());
		Globals.getCorpsService().broadcastInCorps(human, gcChatMsg);
	}

	/**
	 * 向同一阵营的玩家发送聊天消息
	 * 
	 * @param player
	 * @param msg
	 */
	public void handleAllianceChat(Human human, CGChatMsg msg) {
		if (msg == null) {
			return;
		}
		if (human == null || human.getPlayer() == null) {
			return;
		}

		// 向玩家所在的GS发送消息
		GCChatMsg gcChatMsg = buildGCChatMsg(human, SharedConstants.CHAT_SCOPE_MAP, msg.getContent(), msg.getChatType());
		if (Globals.getMapService().getGameMap(human.getMapId(), human.getCharId()) != null) {
			Globals.getMapService().getGameMap(human.getMapId(), human.getCharId()).broadcastToMap(gcChatMsg);
		}
	}
	
	/**
	 * 组队频道，公告队伍频道，没有输入框，只能通过按钮发送消息
	 * @param human
	 * @param msg
	 */
	public void handleCommonTeamChat(Human human, String content) {
		// 向玩家所在的GS发送消息
		GCChatMsg gcChatMsg = buildGCChatMsg(human, SharedConstants.CHAT_SCOPE_COMMON_TEAM, content, 0);
		
		//设置玩家最后一次该频道聊天时间
		human.getPlayer().setLastChatTime(SharedConstants.CHAT_SCOPE_COMMON_TEAM, Globals.getTimeService().now());
		
		// 获取本 GS 的所有在线玩家
		Globals.getOnlinePlayerService().broadcastMsg(gcChatMsg);
	}
	
	/**
	 * 队伍聊天消息处理
	 * @param human
	 * @param msg
	 */
	public void handleTeamChat(Human human, CGChatMsg msg) {
		GCChatMsg gcChatMsg = buildGCChatMsg(human, SharedConstants.CHAT_SCOPE_TEAM, msg.getContent(), msg.getChatType());
		Globals.getTeamService().sendTeamChatMsg(human, gcChatMsg);
	}
	
	public GCChatMsg buildGCChatMsg(Human human, int scope, String content, int chatType) {
		GCChatMsg gcChatMsg = buildInitGCChatMsg();
		gcChatMsg.getChatInfo().setScope(scope);
		gcChatMsg.getChatInfo().setContent(content);
		gcChatMsg.getChatInfo().setFromRoleName(human.getName());
		gcChatMsg.getChatInfo().setFromRoleUUID(human.getUUID() +"");
		gcChatMsg.getChatInfo().setFromRoleCountry(human.getCountry());
		gcChatMsg.getChatInfo().setFromRoleLevel(human.getLevel());
		gcChatMsg.getChatInfo().setFromRoleTplId(human.getTplId());
		gcChatMsg.getChatInfo().setFromRoleVipLevel(Globals.getVipService().getCurVipLevel(human.getUUID()));
		gcChatMsg.getChatInfo().setChatTime(Globals.getTimeService().now());
		gcChatMsg.getChatInfo().setChatType(chatType);
//		// qq信息
//		QQInfo fromQQInfo = human.buildQQInfo();
//		if (null != fromQQInfo) {
//			gcChatMsg.setFromQQInfo(fromQQInfo);
//		}
		return gcChatMsg;
	}
	
	/**
	 * 构建有默认值的聊天消息，避免没有默认值报空指针的错误
	 * @return
	 */
	public GCChatMsg buildInitGCChatMsg() {
		GCChatMsg gcChatMsg = new GCChatMsg();
		ChatInfo info = new ChatInfo();
		info.setContent("");
		info.setFromRoleName("");
		info.setFromRoleUUID("");
		info.setFromQQInfo(new QQInfo());
		info.setToQQInfo(new QQInfo());
		info.setToRoleName("");
		info.setToRoleUUID("");
		info.setExt("");
		gcChatMsg.setChatInfo(info);
		return gcChatMsg;
	}
	
	/**
	 * 检查私聊条件是否满足
	 * 
	 * @param human
	 * @param targetId
	 * @return
	 */
	public boolean checkPrivateChatCondition(Human human, long targetId){
		if(Globals.getGameConstants().getMaxPrivateChatRoleNumPerDay() == -1){
			return true;
		}
		ChatManager chatManager = human.getChatManager();
		// 刷新聊天情况
		chatManager.flush();

		// 当天聊过，则可以继续聊
		if(chatManager.getChatRoleSet().contains(targetId)){
			return true;
		}
		
		// 超过指定人数则不可以再进行私聊
		if(chatManager.getChatRoleSet().size() >= Globals.getGameConstants().getMaxPrivateChatRoleNumPerDay()){
			human.sendErrorMessage(LangConstants.PRIVATE_CHAT_ROLE_NUM_REACH_UPPER);
			return false;
		}
		
		chatManager.setLastChatTime(Globals.getTimeService().now());
		chatManager.getChatRoleSet().add(targetId);
		
		human.setModified();
		return true;
	}
	
	public long getSnapTime(int scope) {
		long time = Globals.getGameConstants().getGeneralChat();
		switch (scope) {
		case SharedConstants.CHAT_SCOPE_WORLD:
			time = Globals.getGameConstants().getWorldChat();
			break;
		case SharedConstants.CHAT_SCOPE_MAP:
			time = Globals.getGameConstants().getMapChat();
			break;
		case SharedConstants.CHAT_SCOPE_GUILD:
			time = Globals.getGameConstants().getGuildChat();
			break;
		case SharedConstants.CHAT_SCOPE_COMMON_TEAM:
			time = Globals.getGameConstants().getCommonTeamChat();
			break;
		case SharedConstants.CHAT_SCOPE_TEAM:
			time = Globals.getGameConstants().getTeamChat();
			break;
		default:
			break;
		}
		return time * TimeUtils.SECOND;
	}
	
}
