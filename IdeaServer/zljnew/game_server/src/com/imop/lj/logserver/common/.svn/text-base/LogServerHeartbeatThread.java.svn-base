package com.imop.lj.logserver.common;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

import org.slf4j.Logger;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.MessageQueue;
import com.imop.lj.core.util.ExecutorUtil;
import com.imop.lj.logserver.BaseLogMessage;
import com.imop.lj.logserver.dao.LogDao;

/**
 * 定时处理消息线程
 * @author yu.zhao
 *
 */
public class LogServerHeartbeatThread extends Thread {
	/** 心跳间隔，毫秒 */
	protected static int LS_HEART_BEAT_INTERVAL = 200;
	/** 每次心跳处理的最大消息条数 */
	protected static int PROCESS_NUM_MAX = 50;
	
	/** 消息队列最大堆叠数量（按10分钟最多处理的数量算），即3w条 */
	protected static long DELAY_NUM_NAX = PROCESS_NUM_MAX * 600;

	/** 日志 */
	private Logger logger;
	
	/** 消息队列的引用 */
	private MessageQueue msgQueue;
	
	/** 线程池 */
	private final ExecutorService pool;

	/** 是否处于活动状态,默认为true，shutdown后变为false */
	private volatile boolean isLive = true;

	/**
	 * 构建心跳线程
	 *
	 */
	public LogServerHeartbeatThread(MessageQueue msgQueue, Logger logger) {
		pool = Executors.newFixedThreadPool(1);
		this.msgQueue = msgQueue;
		
		if (null != logger) {
			this.logger = logger;
		} else {
			this.logger = org.slf4j.LoggerFactory.getLogger(LogServerHeartbeatThread.class);
		}
	}
	
	@Override
	public void run() {
		try {
			while (isLive) {
				// 检查延迟
				checkDelay();
				
				// 处理消息
				processMessage(false);
				
				sleep(LS_HEART_BEAT_INTERVAL);
			}
		} catch (Exception e) {
			e.printStackTrace();
			logger.error("#LogServerHeartbeatThread#run#Exception!", e);
		}
	}
	
	/**
	 * 处理消息，即将日志插库
	 * 正常情况每次处理PROCESS_NUM_MAX条，停服时处理所有剩余的
	 * @param isShutdown 是否停服操作
	 */
	protected void processMessage(boolean isShutdown) {
		int maxNum = PROCESS_NUM_MAX;
		if (isShutdown) {
			maxNum = this.msgQueue.getSize();
		}
		
		int count = 0;
		// 每次处理maxNum条消息
		for (int i = 0; i < maxNum; i++) {
			if (this.msgQueue.isEmpty()) {
				break;
			}
			IMessage iMsg = this.msgQueue.get();
			if (iMsg == null || 
					!(iMsg instanceof BaseLogMessage)) {
				logger.error("#LogServerHeartbeatThread#processMessage#ERROR!iMsg is null or not an instance of BaseLogMessage");
				continue;
			}
			
			count++;
			final BaseLogMessage msg = (BaseLogMessage)iMsg;
			
			pool.execute(new Runnable() {
				@Override
				public void run() {
					try {
						// 插入库操作
						LogDao.insert(LogDao.getLogNameByBeanClass(msg.getClass()), msg);
					} catch (Exception e) {
						e.printStackTrace();
						logger.error("#LogServerHeartbeatThread#processMessage#pool.execute", e);
					}
				}
			});
		}
		
		// 单次处理超过100条，记录一下日志
		if (count >= 100) {
			logger.info("#LogServerHeartbeatThread#processMessage#isShutdown=" + isShutdown + ";count=" + count);
			// 达到上限，记录下日志
			if (count >= PROCESS_NUM_MAX) {
				logger.warn("#LogServerHeartbeatThread#processMessage#isShutdown=" + 
						isShutdown + ";count=" + count + ";msg queue left=" + this.msgQueue.getSize());
			}
		}
	}
	
	/**
	 * 每n秒钟检查一次堆积的未处理消息数量，如果超过上限，则记录错误日志
	 */
	protected void checkDelay() {
		long now = System.currentTimeMillis() / 1000;
		// 10秒一次
		if (now % 10 == 0) {
			if (this.msgQueue.getSize() >= DELAY_NUM_NAX) {
				logger.error("#LogServerHeartbeatThread#checkDelay#ERROR!msg queue size is too big!size=" + 
						this.msgQueue.getSize());
			}
		}
	}
	
	/**
	 * 关闭SceneTaskScheduler
	 */
	public void shutdown() {
		// 关闭SceneTaskScheduler，不再向线程池中提交新的任务
		this.isLive = false;
		// 记录日志
		logger.warn("#LogServerHeartbeatThread#shutdown#msg queue!size=" + 
				this.msgQueue.getSize());
		// 剩余的消息都丢到pool中
		processMessage(true);
		// 等待5分钟，尽量保证已提交的任务都tick完，再关闭线程池
		ExecutorUtil.shutdownAndAwaitTermination(this.pool);
	}

	public boolean isLive() {
		return isLive;
	}

}
