package com.imop.lj.gm.constants;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;

/**
 * 公告相关的常量
 *
 * @author <a href="mailto:yong.fang@opi-corp.com">fang yong</a>
 * @version 2010-8-26
 *
 */
public class NoticeConstants {
	/**
	 * 系统公告类型
	 *
	 * @author <a href="mailto:yong.fang@opi-corp.com">fang yong</a>
	 * @version 2010-8-26
	 *
	 */
	public static enum NoticeType {
		/** 系统公告 */
		SYS_NOTICE(0, 1),
		/** 聊天公告 */
		CHAT_NOTICE(1, 3),
		/** 登录公告 */
		LOGIN_NOTICE(2, 2);

		/** 类型索引 */
		private int intex;
		/** 显示类型 */
		private int showType;

		private NoticeType(int index, int showType) {
			this.intex = index;
			this.showType = showType;
		}

		public int getShowType() {
			return showType;
		}

		public int getIndex() {
			return intex;
		}
	}

	/**
	 * 聊天公告子类型
	 *
	 * @author <a href="mailto:yong.fang@opi-corp.com">fang yong</a>
	 * @version 2010-8-26
	 *
	 */
	public static enum ChatNoticeSubType implements IndexedEnum {
		/** 默认公告 */
		DEFAULT_NOTICE(0, GMLangConstants.NOTICE_TYPE_NOTICE_SHOW),
		/** GM喊话 */
		GM_NOTICE(1, GMLangConstants.NOTICE_TYPE_GM_SHOW),
		/** NPC喊话 */
		NPC_NOTICE(2, GMLangConstants.NOTICE_TYPE_NPC_SHOW),
		/** 其他 */
		OTHER_NOTICE(3, GMLangConstants.NOTICE_TYPE_OTHER_SHOW);

		private final int index;

		/** 子类型多语言ID */
		private final int langId;

		/** 按索引顺序存放的枚举数组 */
		private static final List<ChatNoticeSubType> indexes = IndexedEnum.IndexedEnumUtil.toIndexes(ChatNoticeSubType.values());

		private ChatNoticeSubType(int index, int langId) {
			this.index = index;
			this.langId = langId;
		}

		public int getIndex() {
			return index;
		}

		public int getLangId() {
			return langId;
		}

		/**
		 * 根据指定的索引获取枚举的定义
		 *
		 * @param index
		 * @return
		 */
		public static ChatNoticeSubType indexOf(final int index) {
			return indexes.get(index);
		}

	}
}
