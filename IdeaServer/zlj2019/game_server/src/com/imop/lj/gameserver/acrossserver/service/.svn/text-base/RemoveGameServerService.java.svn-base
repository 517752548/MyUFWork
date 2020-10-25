package com.imop.lj.gameserver.acrossserver.service;

import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.acrossserver.ServerClient;

/**
 * 管理连接的server
 * @author yuanbo.gao
 *
 */
public class RemoveGameServerService {
	/** 在线玩家的会话管理 */
	private Map<ISession, ServerClient> sessionServerClients;
	/** serverId为key的ServerClient map */
	private Map<Integer, ServerClient> serverClientIdMap;
	
	public RemoveGameServerService(){
		sessionServerClients = Maps.newConcurrentHashMap();
		serverClientIdMap = Maps.newConcurrentHashMap();
	}

	/**
	 * 建立连接时建立Session与Player的对应关系
	 * 
	 * @param session
	 * @param user
	 */
	public void putServerClient(ISession session, ServerClient serverClient) {
		if (!sessionServerClients.containsKey(session)) {
			sessionServerClients.put(session, serverClient);
		}
	}
	
	/**
	 * gs请求注册到ws
	 * @param serverClient
	 * @param serverId
	 */
	public void registerServer(ServerClient serverClient, int serverId) {
		if (sessionServerClients.containsKey(serverClient.getSession())) {
			// 如果没有在serverClientIdMap中，则加入map中
			if (!serverClientIdMap.containsKey(serverId)) {
				// 设置服务器id
				serverClient.setServerId(serverId);
				// 加入map
				serverClientIdMap.put(serverId, serverClient);
				
				Loggers.worldLogger.info("server " + serverId + " is added.");
				
				sendGSServerMessage(serverClient);
			}else{
				// 之前的serverClient可能已经失效了，需要将旧的移除掉。2013-10-23 x30挂了并换了个机器，但是旧的serverClient还在serverClientIdMap中
				if (serverClientIdMap.get(serverId).getSession() != serverClient.getSession()) {
					ServerClient removedClient = serverClientIdMap.remove(serverId);
					removedClient.getSession().close(true);
				}
			}
		} else {
			// 记录错误日志
			Loggers.worldLogger.warn("sessionServerClients not contains " + serverId);
		}
	}
	
	/**
	 * 发送各个gs场景消息
	 * @param serverId
	 * @return
	 */
	public void sendGSServerMessage(ServerClient serverClient){
		// TODO 注册成功，其他模块可能需要监听并处理
		
//		// 给客户端发注册成功  争霸赛场景
//		WGCeowarServerRegister wgCeowarServerRegister = new WGCeowarServerRegister(1);
//		serverClient.sendMessage(wgCeowarServerRegister);
//
//		//发送 巅峰对决场景
//		sendGSServerMessageToSummitPK(serverClient);
	}
	
	public ServerClient getServerClient(int serverId) {
		if (null == serverClientIdMap) {
			return null;
		}
		ServerClient serverClient = serverClientIdMap.get(serverId);
		 if (null == serverClient) {
			 // 记录错误日志
			 Loggers.worldLogger.warn("ERROR! serverClient is null! serverId=" + serverId);
		 }
		return serverClient;
	}
	
	public void onSessionClosed(ISession session) {
		ServerClient removedClient = sessionServerClients.remove(session);
		if (null != removedClient) {
			int serverId = removedClient.getServerId();
			serverClientIdMap.remove(serverId);
			Loggers.worldLogger.info("=========server " + serverId + " is removed.");
		}
	}
	
}
