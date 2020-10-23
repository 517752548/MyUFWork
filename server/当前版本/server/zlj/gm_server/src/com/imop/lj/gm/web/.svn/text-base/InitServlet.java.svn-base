/**
 *
 */
package com.imop.lj.gm.web;

import javax.servlet.ServletConfig;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;

import com.imop.lj.gm.service.job.ClockFiveEachJob;
import org.quartz.Scheduler;
import org.quartz.impl.StdSchedulerFactory;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.constants.Mask;
import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.job.Clock0Job;
import com.imop.lj.gm.service.job.JobHelper;
import com.imop.lj.gm.service.job.JobManageService;
import com.imop.lj.gm.service.maintenance.UserPrizeService;
import com.imop.lj.gm.utils.LangUtils;
import com.imop.lj.gm.utils.SpringContext;

/**
 *
 */
public class InitServlet extends HttpServlet {

	/**
	 *
	 */
	private static final long serialVersionUID = 1L;

	/** JobService LOG */
	private static final Logger logger = LoggerFactory
			.getLogger(JobManageService.class);

	/** 任务计划调度器 */
	private static Scheduler scheduler = null;

	public static Scheduler getScheduler() {
		return scheduler;
	}

	public static void setScheduler(Scheduler scheduler) {
		InitServlet.scheduler = scheduler;
	}

	private static SpringContext wac = SpringContext.getInstance();

	private static JobManageService jobManageService = (JobManageService) (wac
			.getBean("jobManageService"));

	private static DBFactoryService dbFactoryService = (DBFactoryService) (wac
			.getBean("dbFactoryService"));
	
	private static UserPrizeService userPrizeService = (UserPrizeService) (wac
			.getBean("userPrizeService"));

	/** 初始化Quartz 的基本属性 */

	@Override
	public void init(ServletConfig config) throws ServletException {
		super.init(config);
		System.out.println("initservlet init");
		String rootPath = config.getServletContext().getRealPath("/");
		initData(rootPath);
	}

	@Override
	public void destroy() {

		try {
			if (scheduler != null) {
				scheduler.shutdown();
			}
		} catch (Exception e) {
			log("Quartz Scheduler failed to shutdown cleanly: " + e.toString());
			e.printStackTrace();
		}

		log("Quartz Scheduler successful shutdown.");
	}

	/**
	 * @param rootPath
	 */
	private void initData(String rootPath) {
		System.out.println("initservlet initdata");
		SystemConstants.LOG_DIR_PATH = rootPath + "role_behavior_log/";
		SystemConstants.ROOT_PATH = rootPath;
		SystemConstants.UPLOAD_PATH = rootPath + "/upload/";
		logger
				.info("Quartz Initializer Servlet loaded, initializing Scheduler...");

		String configFile = rootPath + "WEB-INF/classes/quartz.properties";
		Mask.init();
		try {
			userPrizeService.loadCurrencyConfig();
			dbFactoryService.traverseDBconf(dbFactoryService.readDBFile());
			StdSchedulerFactory factory = new StdSchedulerFactory(configFile);
			scheduler = factory.getScheduler();
			//增加定时任务
			scheduler.scheduleJob(JobHelper.createJobDetail(Clock0Job.class), 
					JobHelper.createClock0CronTrigger(Clock0Job.class));
			System.out.println("now add filevedfd");
			scheduler.scheduleJob(JobHelper.createJobDetail(ClockFiveEachJob.class),JobHelper.createFileMinCronTrigger(ClockFiveEachJob.class));
//			scheduler.scheduleJob();
			scheduler.start();
			logger.info("Scheduler has been started...");
			if (SystemConstants.DB_TYPE.equals(LangUtils.getDBType())) {
				jobManageService.loadTimeNotice();
			}
			jobManageService.monitorSvr();
			
			
		} catch (Exception e) {
			logger.error("Quartz Scheduler failed to initialize: "
					+ e.toString());
			e.printStackTrace();
		}
	}

}
