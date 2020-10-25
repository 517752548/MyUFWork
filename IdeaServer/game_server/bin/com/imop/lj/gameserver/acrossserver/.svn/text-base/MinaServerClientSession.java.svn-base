package com.imop.lj.gameserver.acrossserver;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.common.StatisticsLoggerHelper;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.session.MinaSession;
import com.imop.lj.core.util.IpUtils;
import com.imop.lj.gameserver.startup.GameServerRuntime;

public class MinaServerClientSession extends MinaSession implements ServerClientSession {
	
	private ServerClient serverClient;

	public MinaServerClientSession(IoSession session) {
		super(session);
	}

	@Override
	public void setServerClient(ServerClient serverClient) {
		this.serverClient = serverClient;
	}

	@Override
	public ServerClient getServerClient() {
		return this.serverClient;
	}
	
	@Override
	public void write(IMessage msg) {
		if (session == null || !session.isConnected()) {
			return;
		}
		final IoSession _session = this.session;
		if (_session != null) {
			if (GameServerRuntime.isWriteTrafficControl()) {
				// 检查玩家的输出缓存是否达到上限,如果已经达到,则关闭连接,以此避免那些
				// 较慢连接对服务器的影响
				final long _sessionWriteSize = session.getScheduledWriteBytes();
				if (_sessionWriteSize > GameServerRuntime.MAX_WRITE_BYTES_INQUEUE) {
//					Loggers.msgLogger.warn("SessionBufferSize" + msg + ";passportId=" + (player != null ? player.getPassportId() : ""));
					session.close(true);
					return;
				}
			}
//			if (Loggers.msgLogger.isDebugEnabled()) {
//				if (player.getHuman() != null) {
//					Loggers.msgLogger.debug(this.getIp() + "【Send】" + msg
//							+ "RN:"+ player.getHuman().getName() 
//							+ ",RId:" + player.getHuman().getUUID() 
//							+ ",SId:" + player.getHuman().getId()
//							+ ",PN:" + player.getPassportName()
//							+ ",PId:" + player.getPassportId());
//				} else {
//					Loggers.msgLogger.debug(this.getIp() + "【Send】" + msg
//							+ "PN:" + player.getPassportName()
//							+ ",PId:" + player.getPassportId());
//				}
//			}
			StatisticsLoggerHelper.logMessageSent(msg);
			_session.write(msg);
		}
	}

	@Override
	public String getIp() {
		return IpUtils.getIp(this.getIoSession());
	}
}
