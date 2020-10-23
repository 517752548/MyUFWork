package com.imop.lj.gm.web.activity.service;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.config.GmConfig;
import com.imop.lj.gm.utils.SpringContext;

public class GMGlobals {
	public static final Logger logger =  LoggerFactory.getLogger("activityLog");
	//当前系统时间
	private long nowTime =0l;
	public GmConfig gmConfig;
	
	//奖励数限制
//	private int prizeNum = GmConfig.prizeNum;
	/**
	 * 奖励原因编号基底
	 */
//	public static final int resaonNum = GmConfig.resaonNum;
	/***
	 * 活动奖励批量存储 一次存储数
	 */
//	public static final int saveOnceNum = GmConfig.saveOnceNum;
	
	/**
	 * 记录上次心跳检测执行时间
	 */
//	public static final long heartTimeSleepSendMessage = GmConfig.heartTimeSleepSendMessage;
	/**
	 * 发奖结算开始时间 3:00
	 */
//	public static final long givePrizeStartTime = GmConfig.givePrizeStartTime;
	/***
	 * 发奖结算开始时间 4:00
	 */
//	public static final long givePrizeEndTime = GmConfig.givePrizeEndTime;
	/***
	 * 发奖物品礼包解包数
	 */
//	public static final int prizeItemPackNum = GmConfig.prizeItemPackNum;
	
	/***
	 * 延迟心跳时间 初始化 1分钟
	 */
//	public static final int sleepTimeStart = GmConfig.sleepTimeStart;
	
	public void setGmConfig(GmConfig gmConfig) {
		this.gmConfig = gmConfig;
	}

	/**心跳间隔,单位为毫秒 */
//	public static final int heartTimeSleep = GmConfig.heartTimeSleep;
	
	private SpringContext wac = SpringContext.getInstance();
//	private ActivityService activityService = (ActivityService)(wac.getBean("activityService"));
	
	private final static GMGlobals instance = new GMGlobals();
	private GMGlobals(){}
	
	public static GMGlobals getInstance(){
		return instance;
	}
//	public ActivityService getActivityService() {
//		return activityService;
//	}

	public long getNowTime() {
		return nowTime;
	}
	public void setNowTime(long nowTime) {
		this.nowTime = nowTime;
	}

	public int getPrizeNum() {
		return gmConfig.prizeNum;
	}

//	public void setPrizeNum(int prizeNum) {
//		this.prizeNum = prizeNum;
//	}
	
	
}
