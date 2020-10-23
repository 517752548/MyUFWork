package com.imop.lj.gameserver.time.task;

import java.util.Iterator;
import java.util.List;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.util.ExecutorUtil;
import com.imop.lj.gameserver.common.Globals;

public class TaskThread extends Thread {

	/** 线程池 */
	private final ExecutorService pool;

	/** 是否处于活动状态,默认为true，shutdown后变为false */
	private volatile boolean isLive = true;

	/**
	 * 构建心跳线程
	 *
	 */
	public TaskThread() {
		pool = Executors.newSingleThreadExecutor();
	}

	@Override
	public void run() {
		try {
			while (isLive) {
				List<Task> taskList = Globals.getTaskService().getTaskList();
				Iterator<Task> iterator =  taskList.iterator();
				while(iterator.hasNext()){
					long nowTime = Globals.getTimeService().now();
					Task task = iterator.next();
					if(task.getExeTime() < nowTime){
						task.execute();
						iterator.remove();
						if(task.getNextTask() != null){
							Globals.getTaskService().addTask(task.getNextTask());
						}
					}else{
						break;
					}
				}
				sleep(SharedConstants.GS_HEART_BEAT_INTERVAL);
			}
		} catch (Exception e) {
			Loggers.gameLogger.error("", e);
			shutdown();
		}
	}

	/**
	 * 关闭SceneTaskScheduler
	 */
	public void shutdown() {
		// 关闭SceneTaskScheduler，不再向线程池中提交新的任务
		this.isLive = false;
		// 等待5分钟，尽量保证已提交的任务都tick完，再关闭线程池
		ExecutorUtil.shutdownAndAwaitTermination(this.pool);
	}


}
