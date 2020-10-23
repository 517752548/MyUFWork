package com.imop.lj.core.server;

import org.apache.mina.core.session.IoSession;
import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.constants.SessionAttrKey;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.SessionMessage;
import com.imop.lj.core.msg.sys.SessionClosedMessage;
import com.imop.lj.core.msg.sys.SessionOpenedMessage;
import com.imop.lj.core.session.ISession;
import com.imop.lj.core.session.MinaSession;
import com.imop.lj.core.util.IpUtils;

/**
 *
 * 从Socket接收到的消息处理器,处理以下操作:
 *
 * <pre>
 * 1.新连接 向MessageProcess队列中增加一个状态为SESSION_OPENED的SessionMessage消息,由IMessageHandler处理新连接的逻辑
 * 2.收到消息 只处理类型为ISenderMessage的消息,将收到的消息增加到MessageProcessor队列中
 * 3.连接断开 向MessageProcess队列中增加一个SESSION_CLOSED的SessionMessage消息,由IMessageHandler处理连接断开的逻辑
 * </pre>
 *
 * @author jackflit
 *
 *
 */

public abstract class AbstractIoHandler<T extends ISession> extends	BaseIoHandler {

	protected static final Logger log = Loggers.msgLogger;

	protected volatile int curSessionCount;

	/**
	 * 处理流程:
	 *
	 * <pre>
	 * 1.为新连接创建一个Sender实例,并将Sender与session绑定
	 * 2.创建一个系统消息SessionMessage实例,将其放入MessageProcessor的消息队列中等待处理
	 * </pre>
	 *
	 */
	@SuppressWarnings("unchecked")
	@Override
	public void sessionOpened(IoSession session) {
		log.info("sessionOpened");
		curSessionCount++;
		ISession ms = createSession(session);
		session.setAttribute(SessionAttrKey.ISESSION, ms);
		IMessage msg = new SessionOpenedMessage(ms);
		msgProcessor.put(msg);
	}

	@SuppressWarnings("unchecked")
	@Override
	public void messageReceived(IoSession session, Object obj) {
		if (!(obj instanceof SessionMessage)) {
			return;
		}
		SessionMessage msg = (SessionMessage) obj;
		MinaSession minaSession = (MinaSession) session.getAttribute(SessionAttrKey.ISESSION);

		if (minaSession == null) {
			if (log.isWarnEnabled()) {
				log.warn("No sender");
			}
			// 可能，脱离关系的Session收到了消息，正好关闭之
			session.close(true);
			return;
		}

		// 设置消息的Sender对象
		msg.setSession(minaSession);
		msgProcessor.put(msg);
	}

	@SuppressWarnings("unchecked")
	@Override
	public void sessionClosed(IoSession session) {
		curSessionCount--;
		MinaSession ms = (MinaSession) session.getAttribute(SessionAttrKey.ISESSION);
		if (ms != null) {
			session.setAttribute(SessionAttrKey.ISESSION, null);
		}
		IMessage msg = new SessionClosedMessage(ms);
		// if (log.isInfoEnabled() && ms != null) {
		// log.info(String.format("#CLOSE.SESSION.PASSIVE:%s;%s;%s", IpUtils
		// .getIp(session), "Connection disconnect", ms.toString()));
		// }
		msgProcessor.put(msg);
	}

	@Override
	public void exceptionCaught(IoSession session, Throwable arg1) {
		String exceptMsg = arg1.getMessage();
		if (exceptMsg != null
				&& (exceptMsg.indexOf("reset by peer") > 0
						|| exceptMsg.indexOf("Connection timed out") > 0
						|| exceptMsg.indexOf("Broken pipe") > 0 || exceptMsg
						.indexOf("远程主机强迫关闭了") > -1)) {
			log.debug("#CLOSED.SESSION:" + IpUtils.getIp(session));
			log.error("#CLOSE.SESSION.EXCEPTION:" + exceptMsg + "--", arg1);
		} else {
			// 这个日志很重要，一定要输出
			log.error("#CLOSE.SESSION.EXCEPTION:" + IpUtils.getIp(session),
					arg1);
			log.error("#CLOSE.SESSION.EXCEPTION:" + exceptMsg + "++", arg1);
		}
		session.close(true);
	}

	/**
	 * 由子类实现的
	 *
	 * @return
	 */
	abstract protected T createSession(IoSession session);
}
