package com.imop.lj.gameserver.behavior.bindid;


public interface IBindIdBehavior {
	
	/**
	 * 能否重置
	 */
	boolean canRefresh();
	
	/**
	 * 获取重置周期
	 * @param behaviorType
	 * @param baseTime
	 * @return
	 */
	long getPeriod(BindIdBehaviorTypeEnum behaviorType);

	/**
	 * 构建初始的重置时间
	 * @param behaviorType
	 * @return
	 */
	long buildInitResetTime(BindIdBehaviorTypeEnum behaviorType);
	
}
