package com.imop.lj.gameserver.chat.handler;

import org.slf4j.Logger;

import com.imop.lj.common.LogReasons;
import com.imop.lj.common.LogReasons.ChatLogReason;
import com.imop.lj.common.ModuleMessageHandler;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.command.ICommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.chat.ChatConstants;
import com.imop.lj.gameserver.chat.WordFilterService;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.command.ClientAdminCmdProcessor;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.util.StringUtil;
/**
 * 聊天消息处理器
 * 
 */
public class ChatMessageHandler implements ModuleMessageHandler {

	private WordFilterService chatInfoFilter;
	private ClientAdminCmdProcessor<ISession> cmdProcessor;
//	/** 聊天信息中的链接信息模式 */
//	private static final Pattern LINK_PATTERN = Pattern.compile("\\[l [0-9a-z]+|\\[.*?\\]|[0-9]|[0-9]+ \\]/g");
	
	//FIXME 这里需要按照新的格式改一下，链接模式和语音模式 可能都需要改
	
//	/** 移动端语音聊天内容正则 样例：[569428275932169197131112105625309.mp3:2188] */
//	private static Pattern MOBILE_VOICE_CHAT_PATTERN = Pattern.compile("^\\[[0-9]+\\.mp3\\|[0-9]+\\]$");
	
	private static String VOICE_SPLIT = "|";
	private static String VOICE_HEAD = "http://";
	private static String VOICE_TAIL = ".spx";
	
	private Logger logger = Loggers.chatLogger;

	public ChatMessageHandler() {
		chatInfoFilter = Globals.getWordFilterService();
		cmdProcessor = new ClientAdminCmdProcessor<ISession>();
		cmdProcessor.register(cmdProcessor);
	}

	/**
	 * 处理聊天消息
	 * 
	 * @param player
	 * @param msg
	 */
	public void handleChatMsg(Player player, CGChatMsg msg) {
		if (player == null) {
			return;
		}
		Human human = player.getHuman();
		if (human == null) {
			return;
		}

		String _msgContent = msg.getContent();
		if (null == _msgContent || (_msgContent = _msgContent.trim()).length() == 0) {
			Loggers.chatLogger.info("CG_CHAT_MSG ChatMessageHandler handleChatMsg _msgContent is null playerId=" + player.getRoleUUID());
			return;
		}
		
		// DEBUG命令
		if (player.getPermission() == SharedConstants.ACCOUNT_ROLE_DEBUG) {
			if (_msgContent.startsWith(ICommand.CMD_PREFIX)) {// 命令方式
				if (logger.isDebugEnabled()) {
					logger.debug("Client message :" + _msgContent + " is command!");
				}

				if (this.cmdProcessor != null) {
					this.cmdProcessor.execute(player.getSession(), _msgContent);

					// 获取空格字符索引
					int spaceCharIndex = _msgContent.indexOf(" ");

					String cmdName = "";
					String cmdParams = "";

					if (spaceCharIndex == -1) {
						cmdName = _msgContent;
					} else {
						// 命令名称和命令参数
						cmdName = _msgContent.substring(0, spaceCharIndex);
						cmdParams = _msgContent.substring(spaceCharIndex);
					}

					try {
						// 记录 GM 命令日志
						Globals.getLogService().sendGmCommandLog(human, LogReasons.GmCommandLogReason.REASON_VALID_USE_GMCMD, _msgContent,
								human.getName(), player.getClientIp(), cmdName, null, cmdParams, null);
					} catch (Exception ex) {
						Loggers.gmcmdLogger.error(LogUtils.buildLogInfoStr(player.getRoleUUID() + "", "记录角色基本日志时出错"), ex);
					}
				}
				return;
			}
		}
		
//		// 是否到达可以聊天的最小战力
//		if(human.getFightPower() < Globals.getGameConstants().getTheMinPowerForChat()){
//			if(Loggers.chatLogger.isInfoEnabled()){
//				Loggers.chargeLogger.info("#ChatMessageHandler.handleChatMsg player power is not enough!! playerId = " + player.getRoleUUID() + ", power = " + human.getPower());
//			}
//			human.sendSystemMessage(LangConstants.POWER_IS_NOT_ENOUGH);
//			return;
//		}
		
		// 判断用户是否被禁言
		if (player.getForibedTime() > System.currentTimeMillis()) {
			Loggers.chatLogger.info("CG_CHAT_MSG ChatMessageHandler handleChatMsg player is foribedTalk playerId=" + player.getRoleUUID());
			human.sendSystemMessage(LangConstants.CHAT_FORIBED_TALK);
			return;
		}

		// 判断是不是私聊
		String[] privateChat = null;
		if (_msgContent.startsWith(ChatConstants.PRIVATE_CHAT_PRFIX)) {
			privateChat = parsePrivateChat(_msgContent);
			if (null == privateChat) {
				return;
			}
			_msgContent = privateChat[1];
		}

		int scope = msg.getScope();
		if (privateChat != null) {
			scope = SharedConstants.CHAT_SCOPE_PRIVATE;
		}
		
		//聊天的一些条件判断
		if (!this.checkChatCondition(human, scope)) {
			return;
		}

		// 检查聊天的时间间隔
		if (Globals.getTimeService().now() - player.getLastChatTime(scope) < Globals.getChatService().getSnapTime(scope)) {
			String channel = "";
			switch (scope) {
			case SharedConstants.CHAT_SCOPE_WORLD:
				channel = Globals.getLangService().readSysLang(LangConstants.CHAT_WORLD_CHANNEL);
				human.sendSystemMessage(LangConstants.CHAT_WORLD_TOO_FAST, channel, Globals.getGameConstants().getWorldChat());
				break;
			case SharedConstants.CHAT_SCOPE_MAP:
				channel = Globals.getLangService().readSysLang(LangConstants.CHAT_MAP_CHANNEL);
				human.sendSystemMessage(LangConstants.CHAT_WORLD_TOO_FAST, channel, Globals.getGameConstants().getMapChat());
				break;
			case SharedConstants.CHAT_SCOPE_GUILD:
				channel = Globals.getLangService().readSysLang(LangConstants.CHAT_GUILD_CHANNEL);
				human.sendSystemMessage(LangConstants.CHAT_WORLD_TOO_FAST, channel, Globals.getGameConstants().getGuildChat());
				break;
			case SharedConstants.CHAT_SCOPE_COMMON_TEAM:
				channel = Globals.getLangService().readSysLang(LangConstants.CHAT_COMMON_TEAM_CHANNEL);
				human.sendSystemMessage(LangConstants.CHAT_WORLD_TOO_FAST, channel, Globals.getGameConstants().getCommonTeamChat());
				break;
			case SharedConstants.CHAT_SCOPE_TEAM:
				channel = Globals.getLangService().readSysLang(LangConstants.CHAT_TEAM_CHANNEL);
				human.sendSystemMessage(LangConstants.CHAT_WORLD_TOO_FAST, channel, Globals.getGameConstants().getTeamChat());
				break;
				
			default:
				human.sendSystemMessage(LangConstants.CHAT_TOO_FAST);
				break;
			}
			return;
		}
		
		/** 聊天信息长度需要控制在允许范围内 */
		int _permitLen = getMaxContentLen(_msgContent);
		if (_permitLen < _msgContent.length()) {
			if (logger.isDebugEnabled()) {
				logger.debug("[Chat message length is ： " + _msgContent.length() + ", more than " + _permitLen + " characters , delete over info!]");
			}
			_msgContent = _msgContent.substring(0, _permitLen);
		}

		// 记录过滤之前的话
		String _srcContent = _msgContent;

		boolean hasDirtyWords = false;
		// 如果不是移动端的语音聊天，则需要过滤
		if (!isMobileVoiceChat(msg)) {
			/* 过滤聊天中的不良信息 */
			_msgContent = chatInfoFilter.filterHtmlTag(_msgContent);
			hasDirtyWords = chatInfoFilter.containKeywords(_msgContent);
			if (hasDirtyWords) {
				// 记录玩家发表不良信息的日志
				try {
					Globals.getLogService().sendChatLog(human, LogReasons.ChatLogReason.REASON_CHAT_DIRTY_WORD,
							privateChat == null ? "" : privateChat[0], scope, privateChat == null ? "" : privateChat[0], _srcContent);
					// 发送LocalScribeService 信息
					if (scope == SharedConstants.CHAT_SCOPE_PRIVATE) {
						Globals.getLocalScribeService().sendScribeGamePropChatReport(human, ChatLogReason.REASON_CHAT_DIRTY_WORD, "", 0, "",
								SharedConstants.CHAT_SCOPE_PRIVATE, StringUtil.parseStringTOLong(msg.getDestRoleUUID()), msg.getContent());
					} else if (scope == SharedConstants.CHAT_SCOPE_WORLD) {
						Globals.getLocalScribeService().sendScribeGamePropChatReport(human, ChatLogReason.REASON_CHAT_DIRTY_WORD, "", 0, "",
								SharedConstants.CHAT_SCOPE_WORLD, SharedConstants.CHAT_SCOPE_WORLD, msg.getContent());
					} else if (scope == SharedConstants.CHAT_SCOPE_GUILD) {
						Globals.getLocalScribeService().sendScribeGamePropChatReport(human, ChatLogReason.REASON_CHAT_DIRTY_WORD, "", 0, "",
								SharedConstants.CHAT_SCOPE_GUILD, StringUtil.parseStringTOLong(msg.getDestRoleUUID()), msg.getContent());
					} else {
						Globals.getLocalScribeService().sendScribeGamePropChatReport(human, ChatLogReason.REASON_CHAT_DIRTY_WORD, "", 0, "",
								SharedConstants.CHAT_SCOPE_WORLD, SharedConstants.CHAT_SCOPE_WORLD, msg.getContent());
					}
				} catch (Exception ex) {
					logger.error(LogUtils.buildLogInfoStr(player.getRoleUUID() + "", String.format("记录玩家聊天时发送不良信息的日志时出现错误！scope = %d", scope)), ex);
				}
				_msgContent = chatInfoFilter.filter(_msgContent);
			}
		} else {
			// 当是移动端的语音聊天时，|前面的不用过滤，后边的需要
			if (!_msgContent.contains(VOICE_SPLIT) || 
					!_msgContent.contains(VOICE_HEAD) || 
					!_msgContent.contains(VOICE_TAIL)) {
				//错误，语音聊天，未含有必需的字符
				logger.error("ERROR!voice chat not contains needed char!" + human.getCharId() + ";content=" + _msgContent);
				return;
			}
			String[] sArr = _msgContent.split("\\|");
			String wordStr = sArr[1];
			wordStr = chatInfoFilter.filterHtmlTag(wordStr);
			wordStr = chatInfoFilter.filter(wordStr);
			_msgContent = sArr[0] + VOICE_SPLIT + wordStr;
			if (sArr.length > 2) {
				for (int i = 2; i < sArr.length; i++) {
					_msgContent += VOICE_SPLIT + sArr[i];
				}
			}
		}
		
		if (_msgContent.isEmpty()) {
			return;
		}
		
		msg.setContent(_msgContent);
		
		//聊天中展示相关的，服务器加展示数据到内存中
		Globals.getShowService().handleShowContent(player.getHuman(), _msgContent);

		if (privateChat != null) {
			msg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
			msg.setDestRoleName(privateChat[0]);
		}
		
		doTerminalFilterAndSend(player, msg);

		// 发送LocalScribeService 信息
		if (scope == SharedConstants.CHAT_SCOPE_PRIVATE) {
			Globals.getLocalScribeService().sendScribeGamePropChatReport(human, ChatLogReason.REASON_CHAT_COMMON, "", 1, "",
					SharedConstants.CHAT_SCOPE_PRIVATE, StringUtil.parseStringTOLong(msg.getDestRoleUUID()), _msgContent);
		} else if (scope == SharedConstants.CHAT_SCOPE_WORLD) {
			Globals.getLocalScribeService().sendScribeGamePropChatReport(human, ChatLogReason.REASON_CHAT_COMMON, "", 1, "",
					SharedConstants.CHAT_SCOPE_WORLD, SharedConstants.CHAT_SCOPE_WORLD, _msgContent);
		} else if (scope == SharedConstants.CHAT_SCOPE_GUILD) {
			Globals.getLocalScribeService().sendScribeGamePropChatReport(human, ChatLogReason.REASON_CHAT_COMMON, "", 1, "",
					SharedConstants.CHAT_SCOPE_GUILD, StringUtil.parseStringTOLong(msg.getDestRoleUUID()), _msgContent);
		} else {
			Globals.getLocalScribeService().sendScribeGamePropChatReport(human, ChatLogReason.REASON_CHAT_COMMON, "", 1, "",
					SharedConstants.CHAT_SCOPE_WORLD, SharedConstants.CHAT_SCOPE_WORLD, _msgContent);
		}

		player.setLastChatTime(scope, Globals.getTimeService().now());

		// 记录玩家所说的话，如果包含脏话就不要记了，前面已经记过了
		try {
			if (!hasDirtyWords) {
				Globals.getLogService().sendChatLog(human, LogReasons.ChatLogReason.REASON_CHAT_COMMON, privateChat == null ? "" : privateChat[0],
						scope, privateChat == null ? "" : privateChat[0], _srcContent);
			}
		} catch (Exception ex) {
			logger.error(LogUtils.buildLogInfoStr(player.getRoleUUID() + "", String.format("记录玩家聊天时日志出现错误！scope = %d", scope)), ex);
		}

	}

	private boolean checkChatCondition(Human human, int scope) {
		// 世界聊天需要活力值 FIXME 暂时取消，以后再加
		if (scope == SharedConstants.CHAT_SCOPE_WORLD) {
			boolean flag = human.hasEnoughMoney(Globals.getGameConstants().getWorldChatCostEnergy(), Currency.ENERGY, false);
			if (!flag) {
				//FIXME 暂时取消，以后再加
//				human.sendErrorMessage(LangConstants.CHAT_NOT_ENOUGH_ENERGY);
//				return false;
			}
		}
		
		//公共组队频道不能发言，只能点按钮发
		if (scope == SharedConstants.CHAT_SCOPE_COMMON_TEAM) {
			return false;
		}
		
		return true;
	}

	/**
	 * 根据终端类型对消息内容进行过滤,并且发送消息
	 * 
	 * @param player
	 *            当前玩家
	 * @param msg
	 *            CGChatMsg
	 */
	private void doTerminalFilterAndSend(Player player, CGChatMsg msg) {
//		StringBuilder msgContentSb = new StringBuilder();
//		String chatPostFix = "";
//		switch (player.getCurrTerminalType()) {
//		case IPHONE:
//		case IPAD:
//		case ANDROID:
//			chatPostFix = Globals.getLangService().readSysLang(LangConstants.TERMINAL_MSG_SOURCE, player.getCurrTerminalType().getSource());
//			break;
//		default:
//			break;
//		}
//
//		msgContentSb.append(msg.getContent()).append(" ").append(chatPostFix);
//		msg.setContent(msgContentSb.toString());
		sendChatMsg(player.getHuman(), msg);
	}

	/**
	 * 向玩家发送消息
	 * 
	 * @param player
	 *            发送消息的玩家
	 * @param msg
	 *            消息
	 */
	private void sendChatMsg(Human human, CGChatMsg msg) {
		final int _chatScope = msg.getScope();
		switch (_chatScope) {
		case SharedConstants.CHAT_SCOPE_PRIVATE:
			Globals.getChatService().handlePrivateChat(human, msg);
			break;
		case SharedConstants.CHAT_SCOPE_GUILD:
			Globals.getChatService().handleGuildChat(human, msg);
			break;
		case SharedConstants.CHAT_SCOPE_WORLD:
			Globals.getChatService().handleWorldChat(human, msg);
			break;
		case SharedConstants.CHAT_SCOPE_MAP:
			Globals.getChatService().handleAllianceChat(human, msg);
			break;
		case SharedConstants.CHAT_SCOPE_COMMON_TEAM:
			//这里不能发公告组队的聊天
			break;
		case SharedConstants.CHAT_SCOPE_TEAM:
			Globals.getChatService().handleTeamChat(human, msg);
			break;
		default:
			break;
		}
	}

	/**
	 * 得到聊天允许的最大长度
	 * 
	 * @param content
	 * @return
	 */
	public static int getMaxContentLen(String content) {
//		Matcher _matcher = LINK_PATTERN.matcher(content);
//		if (_matcher.find()) {
//			return ChatConstants.CHAT_LINK_MSG_MAX_LENGTH;
//		}
		return ChatConstants.CHAT_NOLINK_MSG_MAX_LENGTH;
	}
	
	/**
	 * 判断聊天内容是否移动端的语音聊天
	 * @param content
	 * @return
	 */
	public static boolean isMobileVoiceChat(CGChatMsg msg) {
		return msg.getChatType() == ChatConstants.VOICE_CHAT_TYPE;
	}

	/**
	 * 从私聊的内容中解析出聊天的目标和内容
	 * 
	 * @param chatContent
	 * @return null,格式错误;String[0] 聊天的目标,String[1] 聊天的内容
	 */
	private static String[] parsePrivateChat(final String chatContent) {
		// 检查命令的前缀
		final String _content = chatContent.startsWith(ChatConstants.PRIVATE_CHAT_PRFIX) ? chatContent.substring(ChatConstants.PRIVATE_CHAT_PRFIX
				.length()) : null;
		if (_content == null) {
			return null;
		}

		final int _size = _content.length();
		int _index = -1;
		for (int i = 0; i < _size; i++) {
			final char _c = _content.charAt(i);
			if (_c == ' ' || _c == '　') {
				// 当遇到半角空格或者全角空格时,私聊的第一段已经解析到了
				_index = i;
				break;
			}
		}

		if (_index < 0) {
			// 未找到私聊的目标名称
			return null;
		}

		final String _toName = _content.substring(0, _index);

		// 继续忽略所有的前导空格
		for (int i = _index + 1; i < _size; i++) {
			final char _c = _content.charAt(i);
			if (_c != ' ' && _c != '　') {
				_index = i;
				break;
			}
		}

		final String _toContent = _content.substring(Math.min(_index, _content.length())).trim();

		if (_toName.isEmpty()) {
			return null;
		}
		if (_toContent.isEmpty()) {
			return null;
		}
		return new String[] { _toName, _toContent };
	}

}
