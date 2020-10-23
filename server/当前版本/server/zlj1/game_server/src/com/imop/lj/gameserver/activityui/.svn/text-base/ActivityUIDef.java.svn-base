package com.imop.lj.gameserver.activityui;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public class ActivityUIDef {
	/**
	 * 活动子标签定义
	 */
	public static enum ActivityUIType implements IndexedEnum {
		/**空*/
		NULL(0),
		/**日常*/
		USUAL(1),
		/**限时开启*/
		TIMELIMIT(2),
		/**尚未开启*/
		NOTABLE(3),
		;

		private ActivityUIType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<ActivityUIType> values = IndexedEnumUtil.toIndexes(ActivityUIType.values());

		public static ActivityUIType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 活动特殊类型定义
	 */
	public static enum ActivitySpecialType implements IndexedEnum {
		/**普通*/
		NORMAL(0),
		/**日常*/
		RECOMMEND(1),
		/**节日*/
		FESTIVAL(2),
		;

		private ActivitySpecialType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<ActivitySpecialType> values = IndexedEnumUtil.toIndexes(ActivitySpecialType.values());

		public static ActivitySpecialType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 任务形式
	 */
	public static enum TaskMemeberType implements IndexedEnum {
		/**不限制*/
		NO_LIMIT(0),
		/**单人*/
		SINGLE(1),
		/**组队*/
		GRUOP(2),
		;

		private TaskMemeberType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<TaskMemeberType> values = IndexedEnumUtil.toIndexes(TaskMemeberType.values());

		public static TaskMemeberType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 完成情况
	 */
	public static enum FinishStatue implements IndexedEnum {
		/**未完成*/
		UN_FINISH(0),
		/**已完成*/
		FINISH(1),
		;

		private FinishStatue(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<FinishStatue> values = IndexedEnumUtil.toIndexes(FinishStatue.values());

		public static FinishStatue valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
}
