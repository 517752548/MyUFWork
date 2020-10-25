package com.imop.lj.gameserver.mail;

import java.util.List;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;
import com.imop.lj.core.util.TimeUtils;

public interface MailDef {
	/**
	 * 系统邮件,发件人id为10000
	 */
	public static long SYSTEM_MAIL_SEND_ID = 10000l;

	/**
	 * 军团邮件,发件人id为20000
	 */
	public static long GUILD_MAIL_SEND_ID = 20000l;

	/**
	 * 史实邮件，发件人id为30000
	 */
	public static long STORY_MAIL_SEND_ID = 30000l;
	
	/** 全服邮件最长过期时间为30天 */
	public static long SYS_MAIL_MAX_TIME = 30 * TimeUtils.DAY;
	

	/**
	 * 系统邮件触发原因
	 * 
	 */
	public enum SysMailReasonType implements IndexedEnum {

		/** 军团战 */
		GUILDBATTLE(106, 1), ;

		public final int reasonId;

		public final int[] behaviorIds;

		private SysMailReasonType(int reasonId, int... behaviorIds) {
			this.reasonId = reasonId;
			this.behaviorIds = behaviorIds;
		}

		@Override
		public int getIndex() {
			return reasonId;
		}

		private static final List<SysMailReasonType> values = IndexedEnumUtil.toIndexes(SysMailReasonType.values());

		public static SysMailReasonType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}

	}

	public enum BoxType implements IndexedEnum {

		/** 收件箱邮件 */
		INBOX(1),
		/** 发件箱邮件 */
		SENDED(2),
		/** 保存箱邮件 */
		SAVE(3),
		;

		private final int index;

		private BoxType(int index) {
			this.index = index;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<BoxType> values = IndexedEnumUtil.toIndexes(BoxType.values());

		public static BoxType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}

	}

	/**
	 * 邮件类型
	 * 
	 * @author jiliang.lu
	 * 
	 */
	public enum MailType implements IndexedEnum {

		/** 未知类型 */
		NONE(0, LangConstants.MAIL_TYPE_NONE),
		/** 普通邮件 */
		NORMAL(1, LangConstants.MAIL_TYPE_PRIVATE),
		/** 公会邮件 */
		GROUP(2, LangConstants.MAIL_TYPE_GUILD),
		/** 系统邮件 */
		SYSTEM(4, LangConstants.MAIL_TYPE_SYSTEM),
		;

		private final int index;

		private final Integer nameLangKey;

		private MailType(int index, Integer nameLangKey) {
			this.index = index;
			this.nameLangKey = nameLangKey;
		}

		@Override
		public int getIndex() {
			return index;
		}

		public Integer getNameLangKey() {
			return nameLangKey;
		}

		private static final List<MailType> values = IndexedEnumUtil.toIndexes(MailType.values());

		public static MailType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}

	}

	/**
	 * 邮件状态互斥，邮件只能有一种状态
	 * 
	 * @author jiliang.lu
	 * 
	 */
	public enum MailStatus implements IndexedEnum {
		/** 未读 */
		UNREAD(1, LangConstants.MAIL_STATUS_UNREAD),
		/** 已读 */
		READED(2, LangConstants.MAIL_STATUS_READED),
		/** 已保存 */
		SAVED(4, LangConstants.MAIL_STATUS_SAVED),
		/** 已发送 */
		SENDED(8, LangConstants.MAIL_STATUS_SENDED),

		;
		private int index;
		
		private final Integer nameLangKey;

		private MailStatus(int index, Integer nameLangKey) {
			this.index = index;
			this.nameLangKey = nameLangKey;
		}

		@Override
		public int getIndex() {
			return index;
		}

		public Integer getNameLangKey() {
			return nameLangKey;
		}

		private static final List<MailStatus> values = IndexedEnumUtil.toIndexes(MailStatus.values());

		public static MailStatus valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}

//		/**
//		 * 状态是否正常
//		 * 
//		 * @param mailStatus
//		 * @return
//		 */
//		public static boolean isValidStatus(int mailStatus) {
//			boolean result = true;
//			do {
//				if ((mailStatus & MAX_MAIL_MASK) == 0) {
//					result = false;
//					break;
//				}
//
//				if ((mailStatus & SAVED.mark) != 0 && (mailStatus & SENDED.mark) != 0) {
//					result = false;
//					break;
//				}
//
//			} while (false);
//
//			return result;
//		}
	}
}
