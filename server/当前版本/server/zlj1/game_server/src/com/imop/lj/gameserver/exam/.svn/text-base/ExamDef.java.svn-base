package com.imop.lj.gameserver.exam;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;
import com.imop.lj.gameserver.common.Globals;

public class ExamDef {
	/**
	 * 科举类型定义
	 */
	public static enum ExamType implements IndexedEnum {
		NULL(0),
		/**乡试*/
		PROVINCIAL(1),
		/**会试*/
		METROPOLITAN(2),
		/**殿试*/
		IMPERIAL(3),
		/** 限时答题*/
		TIMELIMIT(4),
		;

		private ExamType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<ExamType> values = IndexedEnumUtil.toIndexes(ExamType.values());

		public static ExamType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 科举类型定义
	 */
	public static enum ExamAssistItem implements IndexedEnum {
		NULL(0,0),
		/**松木令*/
		SONGMULING(1,Globals.getGameConstants().getSongmulingItemId()),
		/**玉木令*/
		YUMULING(2,Globals.getGameConstants().getYumulingItemId()),
		/** 宠物培养礼包*/
		CWLIBAO(3, Globals.getGameConstants().getCwLiBaoItemId()),
		;

		private ExamAssistItem(int index,int itemId) {
			this.index = index;
			this.itemId = itemId ;
		}

		public final int index;
		
		/** 对应物品id*/
		private final int itemId;

		@Override
		public int getIndex() {
			return index;
		}
		
		public int getItemId() {
			return itemId;
		}

		private static final List<ExamAssistItem> values = IndexedEnumUtil.toIndexes(ExamAssistItem.values());

		public static ExamAssistItem valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	
	/**
	 * 答题状态定义
	 */
	public static enum ExamState implements IndexedEnum {
		NULL(0),
		/**准备阶段*/
		PREPARE(1),
		/**答题阶段*/
		EXAMING(2),
		/**结束阶段*/
		END(3),
		;

		private ExamState(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<ExamState> values = IndexedEnumUtil.toIndexes(ExamState.values());

		public static ExamState valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
}
