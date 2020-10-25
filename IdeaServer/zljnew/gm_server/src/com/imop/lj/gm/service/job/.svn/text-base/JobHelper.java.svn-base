package com.imop.lj.gm.service.job;

import java.text.ParseException;

import org.quartz.CronTrigger;
import org.quartz.JobDetail;
import org.quartz.Scheduler;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2013年12月11日 下午5:45:32
 * @version 1.0
 */

public class JobHelper {

	private final static String Clock0CronExp = "0 0 0 * * ?";
	private final static String FiveClockCronExp = "0 */10 * * * ?";
	public static JobDetail createJobDetail(Class<?> clazz) {
		JobDetail jobDetail = new JobDetail(clazz.getName(), Scheduler.DEFAULT_GROUP, clazz);
		return jobDetail;
	}

	public static CronTrigger createFileMinCronTrigger(Class<?> clazz) throws ParseException{
		return createCronTrigger(clazz,FiveClockCronExp);
	}

	public static CronTrigger createClock0CronTrigger(Class<?> clazz) throws ParseException {
		return createCronTrigger(clazz, Clock0CronExp);
	}
	
	public static CronTrigger createCronTrigger(Class<?> clazz, String cronTimeStr) throws ParseException {
		CronTrigger trigger = new CronTrigger(clazz.getName(), null);
		trigger.setJobName(clazz.getName());
		trigger.setCronExpression(cronTimeStr);
		return trigger;
	}
}
