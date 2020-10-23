package com.imop.lj.gameserver.acrossserver;

import com.imop.lj.core.server.MessageDispatcher;
import com.imop.lj.core.session.OnlineSessionService;
import com.imop.lj.gameserver.GameServer;
import com.imop.lj.gameserver.acrossserver.service.RemoveGameServerService;
import com.imop.lj.gameserver.cdkeygift.CDKeyWorldService;
import com.imop.lj.gameserver.startup.GameMessageProcessor;
//import com.imop.lj.gameserver.ceowarworld.CeoWarWorldAllService;
//import com.imop.lj.gameserver.chatworld.ChatWorldService;
//import com.imop.lj.gameserver.summitpkworld.SummitPKWorldAllService;

/**
 * 各种全局的业务管理器、公共服务实例的持有者，负责各种管理器的初始化和实例的获取
 * 
 */
public class WGlobals {

	private static RemoveGameServerService removeGameServerService;

	/** 跨服主消息处理器，运行在主线程中，处理玩家登陆退出以及服务器内部消息 */
	private static MessageDispatcher<GameMessageProcessor> messageServerProcessor;
	
	/** 会话管理器 */
	private static OnlineSessionService<MinaServerClientSession> sessionService;
	
//	/** qq服务 */
//	private static QQWorldService qqWorldService;
	
	/** cdkeyWorld */
	private static CDKeyWorldService cdKeyWorldService;
	
	public static void init(){
		removeGameServerService = new RemoveGameServerService();
		messageServerProcessor = buildServerMessageProcessor();
		sessionService = new OnlineSessionService<MinaServerClientSession>();
	}

	/**
	 * 跨服服务器初始化
	 * 
	 * @param cfg
	 * @throws Exception
	 * @see GameServer
	 */
	public static void start() throws Exception {
//		/** qq服务 */
//		qqWorldService = new QQWorldService();
//		qqWorldService.init();
		
		// cdkey 
		cdKeyWorldService = new CDKeyWorldService();
		cdKeyWorldService.init();

	}

	public static RemoveGameServerService getRemoveGameServerService() {
		return removeGameServerService;
	}

	public static MessageDispatcher<GameMessageProcessor> getMessageServerProcessor() {
		return messageServerProcessor;
	}
	
	/**
	 * 构建消息处理器,分拆不同类型的消息到不同的消息处理器
	 * 
	 * @return
	 */
	private static MessageDispatcher<GameMessageProcessor> buildServerMessageProcessor() {
		// 主消息处理器，处理登录、聊天等没有IO操作的请求
		GameMessageProcessor mainMessageProcessor = new GameServerMessageProcessor();
		// 消息分发器，将收到的消息转发到不同的消息处理器
		MessageDispatcher<GameMessageProcessor> msgDispatcher = new MessageDispatcher<GameMessageProcessor>(mainMessageProcessor);
		return msgDispatcher;
	}
	
	/**
	 * 获得会话服务器实例
	 */
	public static OnlineSessionService<MinaServerClientSession> getSessionService() {
		return sessionService;
	}

//	public static QQWorldService getQqWorldService() {
//		return qqWorldService;
//	}

	public static CDKeyWorldService getCdKeyWorldService() {
		return cdKeyWorldService;
	}
	
}
