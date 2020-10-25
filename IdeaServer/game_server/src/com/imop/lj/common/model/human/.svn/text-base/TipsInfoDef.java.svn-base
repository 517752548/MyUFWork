package com.imop.lj.common.model.human;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public interface TipsInfoDef {
	/**
	 * tips类型定义
	 */
	public static enum TipsInfoType implements IndexedEnum {

		/**系统tips*/
		/**缩小聊天框*/
		CHAT_DLG_OPEN(1001),
		/**放大聊天框*/
		CHAT_DLG_CLOSE(1002),
		
		;

		private TipsInfoType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<TipsInfoType> values = IndexedEnumUtil.toIndexes(TipsInfoType.values());

		public static TipsInfoType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/***
	 * 小信封
	 */
	public static enum MailBoxInfoType implements IndexedEnum {
		//加对方为好友
		ADD_FRIEND(1001),
		//加帮会
		ADD_CORPS(1002),
		;

		private MailBoxInfoType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<MailBoxInfoType> values = IndexedEnumUtil.toIndexes(MailBoxInfoType.values());

		public static MailBoxInfoType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}

	/***
	 * tips播放动画id
	 * @author yukun.ding
	 *
	 */
	public static enum MailBoxInfoPlayFlash implements IndexedEnum {
		/**不播放动画**/
		NOT_PLAY_FLASH(0),
		/**播放鲜花动画1**/
		PLAY_FLASH_FLOWERS_LITTLE(101),
		/**播放鲜花动画2**/
		PLAY_FLASH_FLOWERS_MOST(102),
		;

		private MailBoxInfoPlayFlash(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<MailBoxInfoPlayFlash> values = IndexedEnumUtil.toIndexes(MailBoxInfoPlayFlash.values());

		public static MailBoxInfoPlayFlash valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
}
