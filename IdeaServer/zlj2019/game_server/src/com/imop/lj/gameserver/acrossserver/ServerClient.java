package com.imop.lj.gameserver.acrossserver;

import java.util.Map;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.session.ISession;
import com.imop.lj.core.util.Assert;

public class ServerClient {

	private ServerClientSession session;

	/** 远程服务器ip地址 */
	private String clientIp;

	/** 在线玩家的会话管理 */
	private Map<ISession, ServerClient> sessionServerClients;
	
	private int serverId;

	public ServerClient(ServerClientSession session) {
		this.session = session;
		session.setServerClient(this);
	}

	public ServerClientSession getSession() {
		return session;
	}

	public void setSession(ServerClientSession session) {
		this.session = session;
	}

	public void setClientIp(String clientIp) {
		this.clientIp = clientIp;
	}

	public String getClientIp() {
		return clientIp;
	}
	
	public int getServerId() {
		return serverId;
	}

	public void setServerId(int serverId) {
		this.serverId = serverId;
	}

	/**
	 * 建立连接时建立Session与Player的对应关系
	 * 
	 * @param session
	 * @param user
	 */
	public void putServerClient(ISession session, ServerClient client) {
		sessionServerClients.put(session, client);
	}
	
	/**
	 * 将消息发送给Player
	 * 
	 * @param msg
	 */
	public void sendMessage(IMessage msg) {
		Assert.notNull(msg);
		if (session != null && session.isConnected()) {
			session.write(msg);
		}
	}
	
//	public void sendPlayerNoticeMessage(long uuid, String contents) {
//		WGPlayerNoticeContents wgPlayerNoticeContents = new WGPlayerNoticeContents(uuid, contents);
//		sendMessage(wgPlayerNoticeContents);
//	}
//	
//	public void sendPlayerNoticeMessage(long uuid, Integer key) {
//		String contents = Globals.getLangService().readSysLang(key);
//		sendPlayerNoticeMessage(uuid, contents);
//	}

	@Override
	public String toString() {
		return "ServerClient [session=" + session + ", clientIp=" + clientIp
				+ ", serverId=" + serverId + "]";
	}
	
}
