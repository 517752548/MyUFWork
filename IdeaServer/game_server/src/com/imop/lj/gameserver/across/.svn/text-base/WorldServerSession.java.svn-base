package com.imop.lj.gameserver.across;

import com.imop.lj.core.client.NIOClient;
import com.imop.lj.core.session.MinaSession;
import com.imop.lj.gameserver.across.msg.GWMessage;

/**
 * GS与WS的会话
 * 
 * @author zhangwh
 * @since 2010-5-15
 */
public class WorldServerSession extends MinaSession {
	/** gs作为ws的client */
	private final NIOClient worldServerClient;

	public WorldServerSession(NIOClient worldServerClient) {
		super(null);
		this.worldServerClient = worldServerClient;
	}

	/**
	 * 向WorldServer发送消息
	 * 
	 * @param message
	 */
	public void sendMessage(GWMessage message) {
		worldServerClient.sendMessage(message);
	}

	@Override
	public boolean isConnected() {
		return worldServerClient.isConnected();
	}
	
	/**
	 * 
	 */
	public void open() {
		this.worldServerClient.open();
	}
	
	public void tryReConnect(){
		this.worldServerClient.tryReConnect();
	}

	/**
	 * 
	 */
	@Override
	public void close(boolean immediately) {
		this.worldServerClient.close();
	}
}
