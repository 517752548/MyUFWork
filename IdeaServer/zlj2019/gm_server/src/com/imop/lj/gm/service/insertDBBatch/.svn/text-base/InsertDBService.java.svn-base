package com.imop.lj.gm.service.insertDBBatch;

import java.util.List;
import java.util.concurrent.Executors;
import java.util.concurrent.ScheduledExecutorService;
import java.util.concurrent.TimeUnit;

import com.imop.lj.gm.dao.ParamGenericDAO;
import com.imop.lj.gm.web.activity.service.GMGlobals;

/**
 * 
 * 分配插入数据库
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月20日 上午11:22:52
 * @version 1.0
 */

public class InsertDBService {

	private static final ScheduledExecutorService scheduledExecutorService = Executors.newScheduledThreadPool(2);
	
	public static void scheduleTask(Runnable task) {
		GMGlobals.logger.info("InsertDBService#scheduleTask, taskName=" + task.toString());
		scheduledExecutorService.schedule(task, 100, TimeUnit.MILLISECONDS);
	}
	
	public static void insertDBBatch(ParamGenericDAO dao, List<Object> list) {
		GMGlobals.logger.info("InsertDBService#insertDBBatch, dao=" + dao.getClass().getName() + ", list size =" + list.size());
		InsertDBThread insertDBThread = new InsertDBThread(dao, list);
		scheduleTask(insertDBThread);
	}
	
	
}
