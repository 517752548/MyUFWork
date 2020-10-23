package com.imop.lj.gm.utils;

import java.sql.Timestamp;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

/**
 * GM 游戏系统<br>
 * 日期工具类
 *
 * @author lin fan
 */
public class DateUtil {
   private static Log log = LogFactory.getLog(DateUtil.class);

   public final static String DATE_FORMAT = "yyyy-MM-dd";

   public final static String DATE_HOUR_FORMAT = "yyyy-MM-dd HH:mm:ss";

   public final static String TIME_FORMAT = "HH:mm:ss";

   /**
    * 由字符串转换为日期类型xxxx-xx-xx
    *
    * @param date
    *           日期字符串
    * @return 转换后的日期xxxx-xx-xx
    */
   public static Date parseDate(String date) {
      SimpleDateFormat format = new SimpleDateFormat(DATE_FORMAT);
      try {
         return format.parse(date);
      } catch (ParseException e) {
         log.error(e);
      }
      return null;
   }

   /**
    * 由字符串转换为日期类型xxxx-xx-xx xx:xx:xx
    *
    * @param date
    *           日期字符串
    * @return 转换后的日期毫秒
    */
   public static long parseDateHour(String date) {
      try {
         return Timestamp.valueOf(date).getTime();
      } catch (Exception e) {
         log.error(e);
      }
      return 0;
   }


   /**
    * 由日期转换为字符串
    *
    * @param date
    *           日期
    * @return 字符串xxxx-xx-xx xx:xx:xx
    */
   public static String formatDateHour(Date date) {
      SimpleDateFormat format = new SimpleDateFormat(DATE_HOUR_FORMAT);
      return format.format(date);
   }

   /**
    * 由日期转换为字符串
    *
    * @param date
    *           日期
    * @return 字符串xxxx-xx-xx
    */
   public static String formatDate(Date date) {
      SimpleDateFormat format = new SimpleDateFormat(DATE_FORMAT);
      return format.format(date);
   }
   
   /**
    * 由日期转换为字符串
    * 
    * @param date
    *           日期
    * @return 字符串xxxx-xx-xx
    */
   public static String formatDate(long time) {
      SimpleDateFormat format = new SimpleDateFormat(DATE_FORMAT);
      return format.format(time);
   }

   /**
    * 由时间戳转换为字符串xxxx-xx-xx xx:xx:xx
    *
    * @param timestamp
    *           时间戳
    * @return 字符串xxxx-xx-xx xx:xx:xx
    */
   public static String formatTimestamp(Timestamp timestamp) {
      SimpleDateFormat format = new SimpleDateFormat(DATE_HOUR_FORMAT);
      return format.format(timestamp);
   }

   /**
	 * 把ms格式的时间装换为系统语言相关格式
	 *
	 * @param time
	 * @return HH:mm:ss
	 */
	public static String formateTimeLong(long time) {
		if (time <= 0) {
			return "";
		}
		Date _dead = new Date(time);
		SimpleDateFormat _sdf = new SimpleDateFormat(TIME_FORMAT);
		return _sdf.format(_dead);
	}

	/**
	 * 把ms格式的时间装换为系统语言相关格式
	 *
	 * @param time
	 * @return yyyy-MM-dd HH:mm:ss
	 */
	public static String formateDateLong(long time) {
		if (time <= 0) {
			return "";
		}
		Date _dead = new Date(time);
		SimpleDateFormat _sdf = new SimpleDateFormat(DATE_HOUR_FORMAT);
		return _sdf.format(_dead);
	}

	/**
	    * 判断日期是否在今天之后
	    *
	    * @param date
	    *           当天日期
	    * @return 昨天日期
	    */
	   public static boolean isAfterToday(String date) {
		   Date day = parseDate(date);
		   if(day!=null&&day.getTime()>(new Date().getTime())){
			    return true;
		   }else{
	    	  return false;
	      }
	   }

	   /**
	    * 由字符串转换为时间
	    * 
	    * @param date
	    *           日期
	    * @return 字符串xxxx-xx-xx xx:xx:xx
	 * @throws ParseException 
	    */
	   public static long formatDateHourToLong(String dateStr) throws ParseException {
		  DateFormat format = new SimpleDateFormat(DATE_HOUR_FORMAT);
	  	  Date date = format.parse(dateStr);
	      return date.getTime();
	   }

	   /**
	    * 由日期转换为字符串
	    * 
	    * @param date
	    *           日期
	    * @return 字符串xxxx-xx-xx xx:xx:xx
	    */
	   public static String formatDateHour(long date) {
	      SimpleDateFormat format = new SimpleDateFormat(DATE_HOUR_FORMAT);
	      return format.format(date);
	   }




}
