package com.opi.gibp.tools.performance.utils;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
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
	 * 年月日期的字符串
	 */
	public static final String DEFAULT_DATE_FORMATE = "yyyy-MM-dd";
	
	/**
	 * 输出年月日期的字符串
	 */
	public static final String SQL_DATE_FORMATE = "yyyyMM";
	
	/**
	 * 年月日小时分钟毫秒的字符串
	 */
	public static final String DATE_FORMATE = "yyyy-MM-dd HH:mm:ss";
	
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
	 * @param dateString
	 * @return
	 * @throws ParseException
	 * 获得月份
	 */
	public static String getDateMonthString(String dateString) throws ParseException{
		Date date = (new SimpleDateFormat(DATE_FORMATE)).parse(dateString);
		return getDateMonthString(date);
	}
	
	/**
	 * @param date
	 * @return 由日期获得字符串
	 * @throws ParseException
	 */
	public static String getDateMonthString(Date date) throws ParseException{
		return new SimpleDateFormat(SQL_DATE_FORMATE).format(date);
	}
	
	/**
	 * @param queryDataValue
	 * @return list.size()<=2的list,list.get(0)为最小时间，list.get(1)为最大时间
	 */
	public static List<String> getTimeCond(String queryDataValue){
		
		List<String> resultList = new ArrayList<String>();
		//###时间处理 value ###beginDate###endDate
		try{
			
			String[] dateRange = queryDataValue.split("###");
			if(dateRange != null && dateRange.length > 0 ){
				// 获得第一个时间，作为时间戳的开始
				String begin = dateRange[0];
				//获得list中的最后一个时间，作为时间戳的结束
				String end = dateRange[dateRange.length - 1];
				
				resultList.add(begin);
				resultList.add(end);
			}
			
			
		}catch (Exception e) {
			e.printStackTrace();
		}
		
		
		return resultList;
	}
	
	/**
	 * 通过传入的b_yyyyMMdd,e_yyyyMMdd时间值,以及formatter 来获取这两个时间值之间的月份List
	 * @param begin
	 * @param end
	 * @return
	 */
	public static List<String> fromMonths(String b_yyyyMMdd , String e_yyyyMMdd,SimpleDateFormat formatter){
		SimpleDateFormat yearMonthFormatter = new SimpleDateFormat("yyyyMM");
		List<String> monthList = new ArrayList<String>();
		Calendar beginCal = Calendar.getInstance();
		Calendar endCal = Calendar.getInstance();
		
		try {
			beginCal.setTime(formatter.parse(b_yyyyMMdd));
			endCal.setTime(formatter.parse(e_yyyyMMdd));
		} catch (ParseException e) {
			System.err.println("the formatter or the String parameters are not properly! " +
					"[b_yyyyMMdd:" + b_yyyyMMdd + "][e_yyyyMMdd:" + e_yyyyMMdd + "][formatter:"+ formatter );
			e.printStackTrace();
			return null;
		}
		
		while(beginCal.before(endCal)){
			Date duringDate = beginCal.getTime();
			String month = yearMonthFormatter.format(duringDate);
			
			monthList.add(month);

			// add a month
			beginCal.set(Calendar.MONTH, beginCal.get(Calendar.MONTH) + 1);
		}
		
		//将末尾加入到月份里
		Date date = endCal.getTime();
		String month = yearMonthFormatter.format(date);
		if(!monthList.contains(month)){
			monthList.add(month);
		}
		
		return monthList;
	}
}
