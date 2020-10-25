package com.imop.lj.gameserver.behavior;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.behavior.BehaviorManager.BehaviorRecord;

public class BehaviorRefreshCheckFactory {
	
	
	/** 
	 * 不刷新
	 */
	public static final BehaviorRefreshCheck<BehaviorRecord> REFRESH_ONCE_TIME = new BehaviorRefreshCheck<BehaviorRecord>() {

		@Override
		public boolean check(BehaviorRecord br,long now) {
			return false;
		}
	};
	
	/** 
	 * 每天刷新
	 */
	public static final BehaviorRefreshCheck<BehaviorRecord> REFRESH_ONCE_DAY = new BehaviorRefreshCheck<BehaviorRecord>() {

		@Override
		public boolean check(BehaviorRecord br,long now) {
			long lastOpTime = br.getLastOpTime();
			if(now < lastOpTime){
				return false;
			}
			return !TimeUtils.isSameDay(lastOpTime, now);
		}
	};
	
	/** 
	 * 每周刷新
	 */
	public static final BehaviorRefreshCheck<BehaviorRecord> REFRESH_ONCE_WEEK = new BehaviorRefreshCheck<BehaviorRecord>() {

		@Override
		public boolean check(BehaviorRecord br,long now) {
			long lastOpTime = br.getLastOpTime();
			if(now < lastOpTime){
				return false;
			}
			return !TimeUtils.isInSameWeek(lastOpTime, now);
		}
	};
	
	/** 
	 * 每月刷新
	 */
	public static final BehaviorRefreshCheck<BehaviorRecord> REFRESH_ONCE_MONTH = new BehaviorRefreshCheck<BehaviorRecord>() {

		@Override
		public boolean check(BehaviorRecord br,long now) {
			long lastOpTime = br.getLastOpTime();
			if(now < lastOpTime){
				return false;
			}
			return !TimeUtils.isInSameMonth(lastOpTime, now);
		}
	};
}
