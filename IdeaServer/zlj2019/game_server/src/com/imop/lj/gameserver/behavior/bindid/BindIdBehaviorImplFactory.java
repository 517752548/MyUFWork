package com.imop.lj.gameserver.behavior.bindid;

import java.util.Calendar;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.behavior.template.BindIdBehaviorTemplate;
import com.imop.lj.gameserver.common.Globals;

public class BindIdBehaviorImplFactory {

	/**
	 * 不刷新
	 */
	public static final IBindIdBehavior REFRESH_ONCE_TIME = new IBindIdBehavior() {
		
		@Override
		public long getPeriod(BindIdBehaviorTypeEnum behaviorType) {
			return 0;
		}
		
		@Override
		public boolean canRefresh() {
			return false;
		}
		
		@Override
		public long buildInitResetTime(BindIdBehaviorTypeEnum behaviorType) {
			return 0;
		}
	};
	
	/**
	 * 每天刷新
	 */
	public static final IBindIdBehavior REFRESH_ONCE_DAY = new IBindIdBehavior() {
		
		@Override
		public long getPeriod(BindIdBehaviorTypeEnum behaviorType) {
			return TimeUtils.DAY;
		}
		
		@Override
		public boolean canRefresh() {
			return true;
		}
		
		@Override
		public long buildInitResetTime(BindIdBehaviorTypeEnum behaviorType) {
			BindIdBehaviorTemplate behaviorTpl = Globals.getTemplateCacheService().get(behaviorType.getIndex(), BindIdBehaviorTemplate.class);
			int resetHour = behaviorTpl.getResetTime();
			
			// 按照今天的时间设置重置时间
			long baseTime = Globals.getTimeService().now();
			long resetTime = 0L;
			Calendar calendar = Calendar.getInstance();
			calendar.setTimeInMillis(baseTime);
			calendar.set(Calendar.HOUR_OF_DAY, resetHour);
			calendar.set(Calendar.MINUTE, 0);
			calendar.set(Calendar.SECOND, 0);
			calendar.set(Calendar.MILLISECOND, 0);
			resetTime = calendar.getTimeInMillis();
			
			return resetTime;
		}
	};
	
	/**
	 * 每周刷新
	 */
	public static final IBindIdBehavior REFRESH_ONCE_WEEK = new IBindIdBehavior() {
		
		@Override
		public long getPeriod(BindIdBehaviorTypeEnum behaviorType) {
			return TimeUtils.DAY * 7;
		}
		
		@Override
		public boolean canRefresh() {
			return true;
		}
		
		@Override
		public long buildInitResetTime(BindIdBehaviorTypeEnum behaviorType) {
			BindIdBehaviorTemplate behaviorTpl = Globals.getTemplateCacheService().get(behaviorType.getIndex(), BindIdBehaviorTemplate.class);
			int resetHour = behaviorTpl.getResetTime();
			int periodDay = behaviorTpl.getPeriodDay();
			if (periodDay <= 0) {
				// 如果策划没填，则默认为周一
				periodDay = 1;
			}
			// 每周的周几，因为是从周日开始算的，所以需要+1
			int dayOfWeek = (periodDay + 1) % 7;
			
			// 按照今天的时间设置重置时间
			long baseTime = Globals.getTimeService().now();
			long resetTime = 0L;
			Calendar calendar = Calendar.getInstance();
			calendar.setTimeInMillis(baseTime);
			calendar.set(Calendar.DAY_OF_WEEK, dayOfWeek);
			calendar.set(Calendar.HOUR_OF_DAY, resetHour);
			calendar.set(Calendar.MINUTE, 0);
			calendar.set(Calendar.SECOND, 0);
			calendar.set(Calendar.MILLISECOND, 0);
			resetTime = calendar.getTimeInMillis();
			
			return resetTime;
		}
	};
	
	/**
	 * 每n天刷新
	 */
	public static final IBindIdBehavior REFRESH_SOME_DAY = new IBindIdBehavior() {
		
		@Override
		public long getPeriod(BindIdBehaviorTypeEnum behaviorType) {
			BindIdBehaviorTemplate behaviorTpl = Globals.getTemplateCacheService().get(behaviorType.getIndex(), BindIdBehaviorTemplate.class);
			int dayCount = 1;
			// 如果策划没填，则默认周期为每天
			if (behaviorTpl.getPeriodDay() > 0) {
				dayCount = behaviorTpl.getPeriodDay();
			}
			return TimeUtils.DAY * dayCount;
		}
		
		@Override
		public boolean canRefresh() {
			return true;
		}
		
		@Override
		public long buildInitResetTime(BindIdBehaviorTypeEnum behaviorType) {
			return REFRESH_ONCE_DAY.buildInitResetTime(behaviorType);
		}
	};
	
}
