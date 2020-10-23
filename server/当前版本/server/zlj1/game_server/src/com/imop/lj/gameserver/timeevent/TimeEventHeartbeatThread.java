package com.imop.lj.gameserver.timeevent;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.Iterator;
import java.util.List;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

import com.google.common.collect.ArrayListMultimap;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.util.ExecutorUtil;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;

/**
 * 时间队列
 * 
 * @author yuanbo.gao
 *
 */
public class TimeEventHeartbeatThread extends Thread {
	/** 线程池 */
	protected final ExecutorService pool;
	
	/** 是否处于活动状态,默认为true，shutdown后变为false */
	protected volatile boolean isLive = true;
	
	protected volatile boolean beginOfDay = false;
	
	protected final ArrayListMultimap<Long, Runnable> eventMap;
	
	public final Comparator<TimeEventTask> timeEventTaskSorter = new TimeEventTaskSorter();
	
	protected final List <TimeEventTask>  timeEventTasks = Collections.synchronizedList(new ArrayList<TimeEventTask>());
	
	public TimeEventHeartbeatThread(ArrayListMultimap<Long, Runnable> eventMap) {
		this.eventMap = eventMap;
		this.pool = Executors.newSingleThreadExecutor();
	}
	
	/**
	 * 线程启动
	 */
	@Override
	public void run() {		
		try {
			while (isLive) {
				long now = Globals.getTimeService().now();
				//使用迭代器
				Iterator<TimeEventTask> it = timeEventTasks.iterator();
				int submitCount = 0;
				boolean isSubmit = false;
				while(it.hasNext()){
					TimeEventTask task = it.next();
					long submitTime = task.getSubmitTime();
					if(now > submitTime){
						it.remove();
						pool.submit(task.getTask());
						isSubmit = true;
						submitCount++;
					}
				}
				//是否需要初始化每天定时任务
				if(beginOfDay){
					this.prepareTaskByBeginOfDay();
				}
				if(isSubmit){
					Loggers.timeEventTaskLogger.warn("共有" + submitCount +  "个定时任务在此心跳任务执行");
				}
				sleep(SharedConstants.TIME_EVENT_HEART_BEAT_INTERVAL);
			}
		} catch (Exception e) {
			Loggers.gameLogger.error("", e);
//			shutdown();
		}
	}
	
	/**
	 * 0点执行创建当日定时任务列表
	 * @author yuanbo.gao
	 *
	 */
	protected class ResetZeroTask implements Runnable{
		@Override
		public void run() {
			beginOfDay = true;
		}
	}
	
	/**
	 * 任务包装对象
	 * 
	 *
	 */
	protected class TimeEventTask {
		final protected long submitTime;
		final protected Runnable task;
		protected TimeEventTask(long submitTime,Runnable task){
			this.submitTime = submitTime;
			this.task = task;
		}
		
		public long getSubmitTime() {
			return submitTime;
		}
		
		public Runnable getTask() {
			return task;
		}
	}
	
	protected void prepareTaskByBeginOfDay(){
		int submitCount = 0;
		long now = Globals.getTimeService().now();
		Iterator<Long> it = eventMap.asMap().keySet().iterator();
		while (it.hasNext()) {
			long diff = it.next();
			List<Runnable> tasks = eventMap.get(diff);
			long taskTime = TimeUtils.getBeginOfDay(now) + diff;
			for (Runnable task : tasks) {
				TimeEventTask timeEventTask = new TimeEventTask(taskTime,task);
				timeEventTasks.add(timeEventTask);
				submitCount++;
				String content = "任务：{0}:加入队列中";
				Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,task.getClass().getSimpleName()));
			}
		}
		
		// 加0点任务
		long zeroTime = TimeUtils.getBeginOfDay(now) + TimeUtils.DAY;
		Runnable zeroTask = new ResetZeroTask();
		timeEventTasks.add( new TimeEventTask(zeroTime,zeroTask));
		String content = "任务：{0}:加入队列中";
		Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,zeroTask.getClass().getSimpleName()));
//		Collections.sort(timeEventTasks, timeEventTaskSorter);
//		Loggers.timeEventTaskLogger.warn("共有" + timeEventTasks.size() +  "个定时任务加入时间队列中");
		
		Collections.sort(timeEventTasks, timeEventTaskSorter);
		this.beginOfDay = false;
		Loggers.timeEventTaskLogger.warn("共有" + (submitCount + 1) +  "个定时任务加入时间队列中");
	}

	/**
	 * 启动时间队列前创建时间队列列表
	 * 
	 */
	protected void startPrepare(){
		long now = Globals.getTimeService().now();
		Iterator<Long> it = eventMap.asMap().keySet().iterator();
		while (it.hasNext()) {
			long diff = it.next();
			List<Runnable> tasks = eventMap.get(diff);
			long taskTime = TimeUtils.getBeginOfDay(now) + diff;
			long delay = taskTime - now;
			for (Runnable task : tasks) {
				TimeEventTask timeEventTask = new TimeEventTask(taskTime,task);
				if (delay < 0) {
					String content = "任务：{0}:delay<0";
					Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,task.getClass().getSimpleName()));
				}else{
					this.timeEventTasks.add(timeEventTask);
					String content = "任务：{0}:加入队列中";
					Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,task.getClass().getSimpleName()));
				}
			}
		}
		long zeroTime = TimeUtils.getBeginOfDay(now) + TimeUtils.DAY;
		Runnable zeroTask = new ResetZeroTask();
		timeEventTasks.add( new TimeEventTask(zeroTime,zeroTask));
		String content = "任务：{0}:加入队列中";
		Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,zeroTask.getClass().getSimpleName()));
		Collections.sort(timeEventTasks, timeEventTaskSorter);
		Loggers.timeEventTaskLogger.warn("共有" + timeEventTasks.size() +  "个定时任务加入时间队列中");
	}
	
	@Override
	public void start(){
		this.startPrepare();
		super.start();
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
	
	/**
	 * 重新启动
	 */
	public void restart(){
		timeEventTasks.clear();
		this.startPrepare();
	}
	
	/**
	 * 提交任务
	 * 
	 * @param task
	 */
	public void submit(Runnable task){
		if(task == null){
			return;
		}
		this.pool.submit(task);
	}
	
	/**
	 * 按照时间排序
	 * 
	 * @author yuanbo.gao
	 *
	 */
	protected class TimeEventTaskSorter implements Comparator<TimeEventTask> {
		@Override
		public int compare(TimeEventTask o1, TimeEventTask o2) {
			if (o1.getSubmitTime() > o2.getSubmitTime()) {
				return 1;
			} else if (o1.getSubmitTime() < o2.getSubmitTime()) {
				return -1;
			}
			return 0;
		}
	}
}


