package com.imop.lj.gameserver.common.heartbeat;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.util.ExecutorUtil;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.scene.SceneRunner;
import com.imop.lj.gameserver.scene.SceneService;

public class HeartbeatThread extends Thread {

	/** 线程池 */
	private final ExecutorService pool;
	
	/** 新增争军团战线程，防止军团战时影响玩家正常的操作，所以新建一个线程来处理 */
	private final ExecutorService corpsWarPool;

	/** 是否繁忙 */
	private volatile boolean isBusy;

	/** 地图id */
	private List<Future<Integer>> futures;

	/** 还在执行中没有完成的任务对应场景id的集合 */
	private Set<Integer> undoneTasks;

	/** 是否处于活动状态,默认为true，shutdown后变为false */
	private volatile boolean isLive = true;

	/**
	 * 构建心跳线程
	 *
	 */
	public HeartbeatThread() {
		pool = Executors.newSingleThreadExecutor();
		corpsWarPool = Executors.newSingleThreadExecutor();
		futures = new ArrayList<Future<Integer>>(20);// TODO 如果场景数量超过20个了，这里需要修改
		undoneTasks = new HashSet<Integer>();
	}

	@Override
	public void run() {
		try {
			while (isLive) {
				Globals.getTimeService().update();// 更新缓存的时间为当前系统时间
				futures.clear();
				List<SceneRunner> sceneRunners = Globals.getSceneService().getAllSceneRunners();
				for (int i = 0; i < sceneRunners.size(); i++) {
					SceneRunner runner = sceneRunners.get(i);
					int sceneId = runner.getSceneId();
					if (!undoneTasks.contains(runner.getSceneId())) {
						// 根据场景不同处理，一些特殊的活动可能会在单独的线程中处理
						switch (sceneId) {
						case SceneService.CORPS_WAR_SCENE_ID:
							// 军团战线程任务
							corpsWarPool.submit(runner);
							break;
	
						default:
							// 公共场景线程任务
							futures.add(pool.submit(runner));
							break;
						}
					}
				}
				sleep(SharedConstants.GS_HEART_BEAT_INTERVAL);
				checkUndoneTasks();
				if (undoneTasks.isEmpty()) {
					isBusy = false;
				} else {
					isBusy = true;
					if (undoneTasks != null) {
						for (int sceneId : undoneTasks) {
							Loggers.gameLogger.error("scene:" + sceneId + " is busy");
						}
					}
				}


			}
		} catch (Exception e) {
			Loggers.gameLogger.error("", e);
			shutdown();
		}
	}

	/**
	 * 检查每个场景任务的状态，重新构造未完成的任务列表
	 *
	 * @return
	 * @throws InterruptedException
	 * @throws ExecutionException
	 */
	private void checkUndoneTasks() throws InterruptedException,
			ExecutionException {
		undoneTasks.clear();
		for (int i = 0; i < futures.size(); i++) {
			Future<Integer> future = futures.get(i);
			if (!future.isDone()) {
				undoneTasks.add(future.get());
			}
		}
	}

	/**
	 * 调度器是否繁忙
	 *
	 * @return
	 */
	public boolean isBusy() {
		return isBusy;
	}

	/**
	 * 关闭SceneTaskScheduler
	 */
	public void shutdown() {
		// 关闭SceneTaskScheduler，不再向线程池中提交新的任务
		this.isLive = false;
		// 等待5分钟，尽量保证已提交的任务都tick完，再关闭线程池
		ExecutorUtil.shutdownAndAwaitTermination(this.pool);
		ExecutorUtil.shutdownAndAwaitTermination(this.corpsWarPool);
	}


}
