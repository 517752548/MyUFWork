package com.imop.lj.gameserver.acrossserver;

import java.util.Iterator;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.atomic.AtomicBoolean;

import org.apache.mina.core.session.IoSession;
import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.constants.SessionAttrKey;
import com.imop.lj.core.handler.BaseFlashIoHandler;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.session.OnlineSessionService;
import com.imop.lj.core.util.IpUtils;
import com.imop.lj.gameserver.acrossserver.msg.GameServerClientSessionClosedMsg;
import com.imop.lj.gameserver.acrossserver.msg.GameServerClientSessionOpenedMsg;
import com.imop.lj.gameserver.startup.GameExecutorService;
import com.imop.lj.gameserver.startup.GameServerRuntime;

/**
 * Game Server的网络消息接收器
 * 
  *
 * 
 */
public class WorldServerIoHandler extends BaseFlashIoHandler<MinaServerClientSession> {
	private Logger logoutLogger = Loggers.logoutLogger;
	
	private static final Logger log = Loggers.gameLogger;
	
	private final GameExecutorService executor;
	
	private volatile AtomicBoolean isChecking = new AtomicBoolean(false);
	
	private volatile ConcurrentHashMap<IoSession, IoSession> suspendReadSessions = new ConcurrentHashMap<IoSession, IoSession>();
	
	protected OnlineSessionService<MinaServerClientSession> sessionService;

	/**
	 * 
	 * @param flashSocketPolicy Flash客户端建立socket连接时发送的policy请求的响应
	 * @param executor
	 */
	public WorldServerIoHandler(String flashSocketPolicy, GameExecutorService executor, OnlineSessionService<MinaServerClientSession> sessionService) {
		super(flashSocketPolicy);
		this.sessionService = sessionService;
		this.executor = executor;
		this.executor.scheduleTask(createCheckSuspendTask(), 2000);
	}

	@Override
	public void messageReceived(IoSession session, Object obj) {
		super.messageReceived(session, obj);
		if (GameServerRuntime.isReadTrafficControl()) {
			if (msgProcessor.isFull()) {
				// 队列已经满了,停止session的读取
				session.suspendRead();
				suspendReadSessions.putIfAbsent(session, session);
				if (log.isWarnEnabled()) {
					log.warn("[#GS.GameServerIoHandler.messageReceived] [suspen read from session "	+ session + "]");
				}
			}
		}
	}

	@Override
	public void sessionOpened(IoSession session) {
		MinaServerClientSession minaSession = this.createSession(session);
		if (sessionService.addSession(minaSession)) {
			if (log.isDebugEnabled()) {
				log.debug("Session opened");
			}
			curSessionCount++;			
			session.setAttribute(SessionAttrKey.ISESSION, minaSession);
			IMessage msg = new GameServerClientSessionOpenedMsg(minaSession);
			msgProcessor.put(msg);
		}	
		else {
			log.warn("Another AgentServer already connected");
			minaSession.close(true);
		}
		
	}

	@Override
	public void sessionClosed(IoSession session) {
		if (log.isDebugEnabled()) {
			log.debug("Session closed");
		}
		curSessionCount--;
		MinaServerClientSession ms = (MinaServerClientSession) session.getAttribute(SessionAttrKey.ISESSION);
		sessionService.removeSession(ms);
		if (ms == null) {
			logoutLogger.info("3、Player logout GameServerIoHandler.sessionClosed MinaGameClientSession is null");
			return;
		}	
		session.setAttribute(SessionAttrKey.ISESSION, null);
		IMessage msg = new GameServerClientSessionClosedMsg(ms);
		if (log.isInfoEnabled() && ms != null) {
			log.info(String.format("#CLOSE.SESSION.PASSIVE:%s;", IpUtils.getIp(session)));
		}
		logoutLogger.info("4、Player logout GameServerIoHandler.sessionClosed msgProcessor.put(msg):" + IpUtils.getIp(session));
		msgProcessor.put(msg);
	}

	/**
	 * 检查被挂起的session,如果session还处于连接状态,则将其恢复读取
	 */
	private void checkSuspenReadSessions() {
		if (!this.isChecking.compareAndSet(false, true)) {
			return;
		}
		try {
			Iterator<IoSession> _sessionsSet = this.suspendReadSessions.keySet().iterator();
			while (_sessionsSet.hasNext()) {
				IoSession _session = _sessionsSet.next();
				_sessionsSet.remove();
				if (_session.isConnected()) {
					_session.resumeRead();
					if (log.isWarnEnabled()) {
						log.warn("[#GS.GameServerIoHandler.messageReceived] [resume read from session "	+ _session + "]");
					}
				}
			}
		} finally {
			this.isChecking.set(false);
		}
	}

	/**
	 * 创建一个用于检查读取挂起的任务
	 * 
	 * @return
	 */
	private Runnable createCheckSuspendTask() {
		return new Runnable() {
			@Override
			public void run() {
				if (suspendReadSessions.isEmpty()) {
					return;
				}
				if (msgProcessor.isFull()) {
					return;
				} else {
					checkSuspenReadSessions();
				}
			}
		};
	}

	@Override
	protected MinaServerClientSession createSession(IoSession session) {
		return new MinaServerClientSession(session);
	}

}
