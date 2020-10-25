package com.imop.lj.gameserver.acrossserver;

import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.core.msg.sys.ScheduledMessage;
import com.imop.lj.core.server.ExecutableMessageHandler;
import com.imop.lj.core.server.QueueMessageProcessor;
import com.imop.lj.gameserver.acrossserver.msg.GWMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.startup.GameMessageProcessor;
import com.imop.lj.gameserver.startup.GameServerRuntime;

/**
 * 游戏服务器消息处理器
 *
 */
public class GameServerMessageProcessor extends GameMessageProcessor {
	protected static final Logger log = Loggers.msgLogger;

	/** 主消息处理器，处理服务器内部消息、玩家不属于任何场景时发送的消息 */
	private QueueMessageProcessor mainMessageProcessor;

	public GameServerMessageProcessor() {
		mainMessageProcessor = new QueueMessageProcessor(new ExecutableMessageHandler());
	}

	@Override
	public boolean isFull() {
		return mainMessageProcessor.isFull();
	}

	/**
	 * <pre>
	 * 1、服务器内部消息、玩家不属于任何场景时发送的消息，单独一个消息队列进行处理
	 * 2、玩家在场景中发送过来的消息，添加到玩家的消息队列中，在场景的线程中进行处理
	 * </pre>
	 */
	@Override
	public void put(IMessage msg) {
		if (!GameServerRuntime.isOpen() && !(msg instanceof SysInternalMessage) && !(msg instanceof ScheduledMessage)) {
			log.info("【Receive but will not process because server not open】" + msg);
			return;
		}
		if (msg instanceof GWMessage) {
			Loggers.gameLogger.debug("【Receive】" + "aaaaaaaa" + msg);
			// TODO 不同消息模块的不同处理
			// 如果是qq相关的，放入公共场景中处理
			if (msg.getClass().getSimpleName().startsWith("GWQqworld")) {
				Globals.getSceneService().getCommonScene().putMessage(msg);
				return;
			}
			
			mainMessageProcessor.put(msg);
		} else {
			if (log.isDebugEnabled() && !(msg instanceof ScheduledMessage)) {
				log.debug("【Receive】" + msg);
			}
			Loggers.gameLogger.debug("【Receive】" + "bbbbbbbb" + msg);
			mainMessageProcessor.put(msg);
			return;
		}
	}

	@Override
	public void start() {
		mainMessageProcessor.start();
	}

	@Override
	public void stop() {
		mainMessageProcessor.stop();
	}

	/**
	 * 获得主消息处理线程Id
	 *
	 * @return
	 */
	public long getThreadId() {
		return mainMessageProcessor.getThreadId();
	}

	/**
	 * @return
	 */
	public boolean isStop() {
		return mainMessageProcessor.isStop();
	}
}
