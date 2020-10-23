package com.imop.lj.gameserver.common;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public interface NoticeTipsDef {

	public static enum NoticeState implements IndexedEnum {

		/** 未发送 */
		NOT_SEND(0),
		/** 已经发送 */
		SENDED(1), ;

		private NoticeState(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<NoticeState> values = IndexedEnumUtil.toIndexes(NoticeState.values());

		public static NoticeState valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}

	public static enum NoticeType implements IndexedEnum {

		/** 只是通知 */
		NOTICE(1),
		/** 需要进行操作 */
		HANDLE(2), 
		;

		private NoticeType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<NoticeType> values = IndexedEnumUtil.toIndexes(NoticeType.values());

		public static NoticeType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/** 系统角色*/
	public static enum SysRoleType implements IndexedEnum {

		/** 系统 */
		SYS(1),
		/** 开发团队 */
		DEVELOP_GROUP(2), 
		/** 帮派 */
		CORPS(3), 
		;

		private SysRoleType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<SysRoleType> values = IndexedEnumUtil.toIndexes(SysRoleType.values());

		public static SysRoleType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
}
