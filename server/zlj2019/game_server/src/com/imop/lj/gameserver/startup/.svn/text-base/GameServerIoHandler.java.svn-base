package com.imop.lj.gameserver.startup;

import java.util.Iterator;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.atomic.AtomicBoolean;

import org.apache.mina.core.session.IdleStatus;
import org.apache.mina.core.session.IoSession;
import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.constants.SessionAttrKey;
import com.imop.lj.core.handler.BaseFlashIoHandler;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.session.OnlineSessionService;
import com.imop.lj.core.util.IpUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.msg.GameClientSessionOpenedMsg;
import com.imop.lj.gameserver.player.sys.GameClientSessionClosedMsg;

/**
 * Game Server的网络消息接收器
 * 
 * 
 * 
 */
public class GameServerIoHandler extends
		BaseFlashIoHandler<MinaGameClientSession> {
	private Logger logoutLogger = Loggers.logoutLogger;

	private static final Logger log = Loggers.gameLogger;

	private final GameExecutorService executor;

	private volatile AtomicBoolean isChecking = new AtomicBoolean(false);

	private volatile ConcurrentHashMap<IoSession, IoSession> suspendReadSessions = new ConcurrentHashMap<IoSession, IoSession>();

	protected OnlineSessionService<MinaGameClientSession> sessionService;

	/**
	 * 
	 * @param flashSocketPolicy
	 *            Flash客户端建立socket连接时发送的policy请求的响应
	 * @param executor
	 */
	public GameServerIoHandler(String flashSocketPolicy,
			GameExecutorService executor,
			OnlineSessionService<MinaGameClientSession> sessionService) {
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
					log.warn("[#GS.GameServerIoHandler.messageReceived] [suspen read from session "
							+ session + "]");
				}
			}
		}
	}

	@Override
	public void sessionOpened(IoSession session) {
		MinaGameClientSession minaSession = this.createSession(session);
		if (sessionService.addSession(minaSession)) {
			if (log.isDebugEnabled()) {
				log.debug("Session opened");
			}
			curSessionCount++;
			session.setAttribute(SessionAttrKey.ISESSION, minaSession);
			IMessage msg = new GameClientSessionOpenedMsg(minaSession);
			msgProcessor.put(msg);
			
			// 非debug版本才设置idle时间，worldServer不需要
			if (!Globals.getServerConfig().getIsDebug() && !Globals.isWorldServer()) {
				// 设置idle的时间，这样会调到sessionIdle方法
				session.getConfig().setIdleTime(IdleStatus.READER_IDLE, Globals.getGameConstants().getSessionIdleTime());
			}
			
		} else {
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
		MinaGameClientSession ms = (MinaGameClientSession) session
				.getAttribute(SessionAttrKey.ISESSION);
		sessionService.removeSession(ms);
		if (ms == null) {
			logoutLogger
					.info(IpUtils.getIp(session)
							+ " 3、Player logout GameServerIoHandler.sessionClosed MinaGameClientSession is null");
			return;
		}
		session.setAttribute(SessionAttrKey.ISESSION, null);
		IMessage msg = new GameClientSessionClosedMsg(ms, null);
		if (log.isInfoEnabled() && ms != null) {
			log.info(String.format("#CLOSE.SESSION.PASSIVE:%s;",
					IpUtils.getIp(session)));
		}
		logoutLogger
				.info(IpUtils.getIp(session)
						+ " 4、Player logout GameServerIoHandler.sessionClosed msgProcessor.put(msg):"
						+ IpUtils.getIp(session));
		msgProcessor.put(msg);
	}

	@Override
	public void sessionIdle(IoSession iosession, IdleStatus idlestatus)
			throws Exception {
		// debug版本idle不做断线处理
		if (Globals.getServerConfig().getIsDebug()) {
			return;
		}
		// 跨服服务器不做断线处理
		if (Globals.isWorldServer()) {
			return;
		}
		
		Loggers.logoutLogger.warn("#GameServerIoHandler#sessionIdle#call.idlestatus=" + idlestatus + ";iosession=" + iosession);
		// 客户端死了，立即断开连接
		if (idlestatus == IdleStatus.READER_IDLE) {
			iosession.close(true);
			Loggers.logoutLogger.warn("#GameServerIoHandler#sessionIdle#iosession.close.sessionIdle.idlestatus:" + idlestatus + ";iosession=" + iosession);
		}
	}

	/**
	 * 检查被挂起的session,如果session还处于连接状态,则将其恢复读取
	 */
	private void checkSuspenReadSessions() {
		if (!this.isChecking.compareAndSet(false, true)) {
			return;
		}
		try {
			Iterator<IoSession> _sessionsSet = this.suspendReadSessions
					.keySet().iterator();
			while (_sessionsSet.hasNext()) {
				IoSession _session = _sessionsSet.next();
				_sessionsSet.remove();
				if (_session.isConnected()) {
					_session.resumeRead();
					if (log.isWarnEnabled()) {
						log.warn("[#GS.GameServerIoHandler.messageReceived] [resume read from session "
								+ _session + "]");
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
	protected MinaGameClientSession createSession(IoSession session) {
		MinaGameClientSession clientSession = new MinaGameClientSession(session);
		Player connectClient = new Player(clientSession);
		clientSession.setPlayer(connectClient);
		connectClient.setClientIp(clientSession.getIp());
		Globals.getOnlinePlayerService()
				.putPlayer(clientSession, connectClient);
		return clientSession;
	}

}
