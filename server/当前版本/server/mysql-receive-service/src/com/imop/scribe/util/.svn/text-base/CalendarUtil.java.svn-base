package com.imop.scribe.util;


import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.TimeZone;

/**
 * @author wenping.jiang
 *	世界时区转换工具
 */
public class CalendarUtil {

	/**
	 * GMT标准时区字符串
	 */
	public static final String TIMEZONE_GMT = "GMT";
	
	/**
	 * 标准输出年月日期的字符串
	 */
	public static final String DEFAULT_DATE_FORMATE = "yyyy-MM-dd";
	
	/**
	 * 一天的时间
	 */
	public static final int DAY_TIME = 24 * 24 * 60 * 1000;
	
	public static final String DEFAULT_STANDED_DATE_FORMATE = "yyyy-MM-dd HH:mm:ss";
	/**
	 * @return
	 * 获取GMT标准时间
	 */
	public static long getGMTTime(){
		Date date = getGMTDate();
		return date.getTime();
	}
	
	/**
	 * @return
	 * 获取GMT日期
	 */
	public static Date getGMTDate(){
		int diffTime = getDiffTImeZoneRawOffest(TIMEZONE_GMT);
		long GMTTime = System.currentTimeMillis() - diffTime;
		Date date = new Date(GMTTime);
		return date;
	}
	
	/**
	 * @param timeZoneId
	 * @return获取系统时间与时区时间误差
	 */
	public static int getDiffTImeZoneRawOffest(String timeZoneId){
		return TimeZone.getDefault().getRawOffset() - TimeZone.getTimeZone(timeZoneId).getRawOffset();
	}
	
	/**
	 * @return获取GMT标准天数字符串
	 */
	public static String getGMTDDay(){
		Date date = getGMTDate();
		return(new SimpleDateFormat(DEFAULT_DATE_FORMATE).format(date));
	}
	
	/**
	 * @return
	 * @return获取GMT标准日期字符串
	 */
	public static String getGMTDefaultDay(){
		Date date = getGMTDate();
		return(new SimpleDateFormat(DEFAULT_STANDED_DATE_FORMATE).format(date));
	}
	/**
	 * @return
	 * 获取昨天的GMT标准天数字符串
	 */
	public static String getLastGMTDay(){
		int diffTime = getDiffTImeZoneRawOffest(TIMEZONE_GMT);
		long GMTTime = System.currentTimeMillis() - diffTime - DAY_TIME;
		Date date = new Date(GMTTime);
		return(new SimpleDateFormat(DEFAULT_DATE_FORMATE).format(date));
	}
	/**
	 * @return
	 * 返回标准GMT的TimeZone
	 */
	public static TimeZone getGTMTimeZone(){
		return TimeZone.getTimeZone(TIMEZONE_GMT);
	}
}
