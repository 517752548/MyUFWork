package com.imop.lj.core.client;

import java.net.InetSocketAddress;
import java.util.concurrent.Executor;

import org.apache.mina.core.future.ConnectFuture;
import org.apache.mina.core.session.IoSession;
import org.apache.mina.filter.codec.ProtocolCodecFilter;
import org.apache.mina.transport.socket.nio.NioSocketConnector;
import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.codec.GameCodecFactory;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.recognizer.IMessageRecognizer;
import com.imop.lj.core.server.AbstractIoHandler;
import com.imop.lj.core.session.MinaSession;

/**
 * NIO Client连接,当需要连接别的服务器时，创建该对象
 * 
 * 
 * 
 */
public class NIOClientConnection {
	/** 日志 */
	private static final Logger logger = Loggers.msgLogger;
	/** 连接目标服务器名字 */
	private final String name;
	/** 连接目标服务器IP地址 */
	private final String host;
	/** 连接目标服务器端口 */
	private final int port;
	/** 超时时间 */
	private final int CONNECT_TIMEOUT = 10; // seconds
	/** 消息识别器 */
	private final IMessageRecognizer messageRecognizer;
	/** 连接会话 */
	private IoSession session;
	/** 消息处理器 */
	private final AbstractIoHandler<? extends MinaSession> messageIoHandler;
	/** 重连标识 */
	private volatile boolean reConnect = false;
	/** 是否启用重连 */
	private volatile boolean reConnectOn = true;
	/** 重连线程池工具 */
	private Executor threadPool;
	
	private NioSocketConnector _connector;

	public NIOClientConnection(String name, String host, int port, IMessageRecognizer messageRecognizer,
			AbstractIoHandler<? extends MinaSession> messageIoHandler, Executor threadPool) {
		if (name == null || host == null || port <= 0 || messageRecognizer == null || messageIoHandler == null || threadPool == null) {
			throw new IllegalArgumentException("All parameters must accurate.");
		}
		this.name = name;
		this.port = port;
		this.host = host;
		this.messageRecognizer = messageRecognizer;
		this.messageIoHandler = messageIoHandler;
		this.threadPool = threadPool;
	}

	/**
	 * 创建打开连接
	 * 
	 * @return
	 */
	public boolean open() {
		// 判断是否已经连接
		if (isConnect()) {
			throw new IllegalStateException("Already connected. Disconnect first.");
		}
		// 创建Socket连接
		try {
			if (logger.isInfoEnabled()) {
				logger.info("Start connect to " + this.name + " host: " + this.host + " port: " + this.port);
			}
			_connector = new NioSocketConnector();
			_connector.setConnectTimeoutMillis(CONNECT_TIMEOUT * 1000);
			_connector.getFilterChain().addLast("codec", new ProtocolCodecFilter(new GameCodecFactory(messageRecognizer)));
			_connector.setHandler(messageIoHandler);
			ConnectFuture _future = _connector.connect(new InetSocketAddress(host, port));
			_future.awaitUninterruptibly();
			// 如果连接操作未结束
			if (!_future.isConnected()) {
				_connector.dispose();
				return false;
			}
			session = _future.getSession();
			
			if (logger.isInfoEnabled()) {
				logger.info("Connect success.");
			}
			return true;
		} catch (Exception e) {
			e.printStackTrace();
			return false;
		}

	}

	/**
	 * 关闭连接
	 */
	public void close() {
		// session关闭
		if (session.isConnected()) {
			session.close(false).awaitUninterruptibly();
			session = null;
		}
		
		// XXX 必须调用，否则出现session leak，导致抛出too many open files的异常
		_connector.dispose();
	}

	/**
	 * 判断是否已经连接
	 * 
	 * @return
	 */
	public boolean isConnect() {
		if (session != null && session.isConnected()) {
			return true;
		}
		return false;
	}

	/**
	 * 返回连接使用的IoSession
	 * 
	 * @return
	 */
	public IoSession getIoSession() {
		return session;
	}

	/**
	 * 发送一条消息
	 * 
	 * @param message
	 * @return
	 */
	public boolean sendMessage(IMessage message) {
		if (!isConnect() && reConnectOn) {
			// 是否正在重连中
			if (!reConnect) {
				// 重新连接
				tryReConnect();
			}
			return false;
		}
		// 发送消息
		if (session != null) {
			if (logger.isDebugEnabled()) {
				logger.debug("【Send】" + message);
			}
			session.write(message);
			return true;
		}
		return false;
	}

	public void tryReConnect() {
		// XXX 为了强制重连
		// if (!reConnectOn) {
		// return;
		// }
		// 设置为正在重连，不允许其他重新连接请求
		reConnect = true;
		try {
			threadPool.execute(new ReConnect());
		} catch (Exception e) {
			reConnect = false;
		}
	}

	@Override
	public String toString() {
		return "Server name:" + this.name + " Host:" + this.host + "Port:" + this.port;
	}

	/**
	 * 启动自动重连
	 */
	public void setReconnectOn() {
		this.reConnectOn = true;
	}

	/**
	 * 关闭自动重连
	 */
	public void setReconnectOff() {
		this.reConnectOn = false;
	}

	/**
	 * 重连线程内部类
	 * 
	 * @author Fancy
	 * 
	 */
	private class ReConnect implements Runnable {

		public void run() {
			try {
				open();
			} catch (Exception e) {
				if (logger.isErrorEnabled()) {
					logger.error("Restart connection error.");
				}
			} finally {
				// 设置为允许重连
				reConnect = false;
			}
		}
	}
}
