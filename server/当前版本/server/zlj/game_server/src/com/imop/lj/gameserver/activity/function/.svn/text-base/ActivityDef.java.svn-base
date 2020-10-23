package com.imop.lj.gameserver.activity.function;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

/**
 * 活动相关类型
 * 
 * 
 */
public interface ActivityDef {
	
	/**
	 * 活动类型
	 * 
	 */
	public static enum ActivityType implements IndexedEnum {
		/** 科举答题 */
		EXAM(1),
		/** 宠物岛 */
		PET_ISLAND(2),
		/** 帮派竞赛 */
		CORPS_WAR(3),
		/** nvn联赛 */
		NVN(4),
		;

		private ActivityFunction function;
		
		private ActivityType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		public ActivityFunction getFunction() {
			return function;
		}

		public void setFunction(ActivityFunction function) {
			this.function = function;
		}

		private static final List<ActivityType> values = IndexedEnumUtil
				.toIndexes(ActivityType.values());

		public static ActivityType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	

	/**
	 * 活动函数，用于各个时间段功能触发
	 * 
	 */
	public static enum ActivitySysMessageType implements IndexedEnum {
		/** 空 */
		NULL(0),
		
		/** 科举答题提醒阶段 */
		EXAM_NOTICE_FUNC(1000),
		/** 科举答题准备阶段 */
		EXAM_READY_FUNC(1001),
		/** 科举答题开始阶段 */
		EXAM_START_FUNC(1002),
		/** 科举答题结束阶段 */
		EXAM_END_FUNC(1003),
		
		/** 宠物岛提醒阶段 */
		PETISLAND_NOTICE_FUNC(2000),
		/** 宠物岛准备阶段 */
		PETISLAND_READY_FUNC(2001),
		/** 宠物岛开始阶段 */
		PETISLAND_START_FUNC(2002),
		/** 宠物岛结束阶段 */
		PETISLAND_END_FUNC(2003),
		
		/** 帮派战提醒阶段 */
		CORPSWAR_NOTICE_FUNC(3000),
		/** 帮派战准备阶段 */
		CORPSWAR_READY_FUNC(3001),
		/** 帮派战开始阶段 */
		CORPSWAR_START_FUNC(3002),
		/** 帮派战结束阶段 */
		CORPSWAR_END_FUNC(3003),
		
		/** nvn联赛提醒阶段 */
		NVN_NOTICE_FUNC(4000),
		/** nvn联赛准备阶段 */
		NVN_READY_FUNC(4001),
		/** nvn联赛开始阶段 */
		NVN_START_FUNC(4002),
		/** nvn联赛结束阶段 */
		NVN_END_FUNC(4003),
		
		;

		private ActivitySysMessageType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<ActivitySysMessageType> values = IndexedEnumUtil
				.toIndexes(ActivitySysMessageType.values());

		public static ActivitySysMessageType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 活动状态
	 * 
	 */
	public static enum ActivityState implements IndexedEnum {
		/** 活动还未开启，默认状态*/
		NOT_OPEN(0),
		/** 活动准备阶段 */
		READY(1),
		/** 活动开始阶段 */
		OPENING(2),
		/** 活动结束 */
		FINISHED(3),
		/** 活动已关闭 */
		CLOSE(4),
		;

		private ActivityState(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<ActivityState> values = IndexedEnumUtil
				.toIndexes(ActivityState.values());

		public static ActivityState valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 限时类型
	 * 
	 */
	public enum TimeLimitType implements IndexedEnum{
		/** 无*/
		NULL(0),
		/** 限时答题*/
		DT(1),
		/** 限时杀怪*/
		SG(2),
		/** 限时挑战npc*/
		NPC(3),
		;

		public final int index;
		
		private static final List<TimeLimitType> values = IndexedEnumUtil.toIndexes(TimeLimitType.values());
		
		TimeLimitType(int index){
			this.index = index;
		}

		public static TimeLimitType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}

	
		@Override
		public int getIndex() {
			return this.index;
		}
	}
}
