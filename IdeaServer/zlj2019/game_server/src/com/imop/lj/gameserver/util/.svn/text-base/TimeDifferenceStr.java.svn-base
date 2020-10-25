package com.imop.lj.gameserver.util;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;

public class TimeDifferenceStr {
	private static final TimeDifferenceStr timeDifferenceStr = new TimeDifferenceStr();
	private TimeDifferenceStr(){}
	public static TimeDifferenceStr getTimeDifferenceStrInstance(){
		return timeDifferenceStr;
	}
	/**
	 * 时间差显示
	 * 按分钟计算判断显示字符串发给前台
	 * time 时间
	 */
	public String timeDifferenceStr(Long time){
		long timeNow = Globals.getTimeService().now();
		long times = timeNow - time;
		long timeDifference = times/60000;
		if(timeDifference < 60){
			// 0-60
			return Globals.getLangService().readSysLang(LangConstants.TIME_ONHOUR_DIR_STR);
		}else if(timeDifference < 180){
			return Globals.getLangService().readSysLang(LangConstants.TIME_THREEHOUR_DIR_STR);
		}else{
			int days = TimeUtils.getSoFarWentDays(time, timeNow);
			if(days < 1){
				return Globals.getLangService().readSysLang(LangConstants.TIME_ONEDAY_DIR_STR);
			}else if(days < 2){
				return Globals.getLangService().readSysLang(LangConstants.TIME_TWODAY_DIR_STR);
			}else if(days < 3){
				return Globals.getLangService().readSysLang(LangConstants.TIME_THREEDAY_DIR_STR);
			}else{
				return Globals.getLangService().readSysLang(LangConstants.TIME_OUTTHREEDAY_DIR_STR);
			}
		}
//		if(timeDifference < 11){
//			//0-10
//			return Globals.getLangService().readSysLang(LangConstants.TIME_CURRENT_DIR_STR);
//		}else if(timeDifference < 31){
//			//11-30
//			return Globals.getLangService().readSysLang(LangConstants.TIME_HALFHOUR_DIR_STR);
//		}else if(timeDifference < 61){
//			//31-60
//			return Globals.getLangService().readSysLang(LangConstants.TIME_ONHOUR_DIR_STR);
//		}else if(timeDifference < 181){
//			//61-180
//			return Globals.getLangService().readSysLang(LangConstants.TIME_THREEHOUR_DIR_STR);
//		}else if(timeDifference < 721){
//			//181-720
//			return Globals.getLangService().readSysLang(LangConstants.TIME_HALFDAY_DIR_STR);
//		}else if(timeDifference < 1441){
//			//721-1440
//			return Globals.getLangService().readSysLang(LangConstants.TIME_ONEDAY_DIR_STR);
//		}else if(timeDifference < 2881){
//			//1441-2880
//			return Globals.getLangService().readSysLang(LangConstants.TIME_TWODAY_DIR_STR);
//		}else if(timeDifference < 4321){
//			//2881-4320
//			return Globals.getLangService().readSysLang(LangConstants.TIME_THREEDAY_DIR_STR);
//		}else if(timeDifference < 10081){
//			//4321-10080
//			return Globals.getLangService().readSysLang(LangConstants.TIME_OUTTHREEDAY_DIR_STR);
//		}else{
//			//超过10080
//			return Globals.getLangService().readSysLang(LangConstants.TIME_UTSEVENDAY_DIR_STR);
//		}
	}
	/**
	 * 获得多语言 小时,分钟,秒钟字符串
	 * @param time 毫秒单位的时间
	 * @return 时间值+单位字符串
	 */
	public String getTimeUnitsStr(long time) {
		int dissolveGuilTime = 0;
		int dissolveGuilTimeStr = 0;
		if ((time / (60 * 60 * 1000)) > 0) {
			dissolveGuilTime = (int) (time / (60 * 60 * 1000));
			dissolveGuilTimeStr = LangConstants.HOUR_TIME_STR;
		} else if ((time / (60 * 1000)) > 0) {
			dissolveGuilTime = (int) time / (60 * 1000);
			dissolveGuilTimeStr = LangConstants.MINUTE_TIME_STR;
		} else {
			dissolveGuilTime = (int) time / 1000;
			dissolveGuilTimeStr = LangConstants.SECOND_TIME_STR;
		}
		String str = dissolveGuilTime + "" + Globals.getLangService().readSysLang(dissolveGuilTimeStr);
		return str;
	}
//	/***
//	 * 判断是否是隔天了true 隔天false未隔天
//	 * time 毫秒单位的时间
//	 */
//	public boolean checkIntevalDay(long time){
//		long dayTime = 24*3600*1000;
//		long dayOne = time/dayTime;
//		long dayTwo = Globals.getTimeService().now()/dayTime;
//		if((dayTwo-dayOne) > 0){
//			return true;
//		}else{
//			return false;
//		}
//	}
}
