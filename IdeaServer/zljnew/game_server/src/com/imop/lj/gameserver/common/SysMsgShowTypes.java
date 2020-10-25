package com.imop.lj.gameserver.common;

import java.util.List;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;
import com.imop.lj.gameserver.common.msg.GCSystemMessage;

/**
 * 系统消息显示类型
 * 
 */
public final class SysMsgShowTypes {

	/**
	 * 推送信息大类
	 * 
	 * @author xinkun.wang
	 * 
	 */
	public static enum SysMessageType implements IndexedEnum {
		@Comment(content = "无 ")
		NONE(0),
		
		@Comment(content = "聊天框出现的基本系统提示 ")
		SYSTEM_MESSAGE(1),
		
		@Comment(content = "聊天通告类")
		CHAT_MESSAGE(2),
		
		@Comment(content = "屏幕中央出现的跑马灯通告,滚屏")
		NOTICE_MESSAGE(3),
		
		@Comment(content = "聊天系统+聊天通告")
		SYSTEM_AND_CHAT_MESSAGE(4),
		
		@Comment(content = "聊天系统+跑马灯")
		SYSTEM_AND_NOTICE_MESSAGE(5),
		
		@Comment(content = "聊天通告+跑马灯")
		CHAT_AND_NOTICE_MESSAGE(6),
		
		@Comment(content = "聊天系统+聊天通告+跑马灯 ")
		SYSTEM_AND_CHAT_AND_NOTICE_MESSAGE(7),
		
		@Comment(content = "国家通告")
		COUNTRY_MESSAGE(8),
		
		@Comment(content = "帮派通告")
		GUILD_MESSAGE(9),
		
		@Comment(content = "弹窗确定")
		BOX_MESSAGE(10),
		
		@Comment(content = "错误提示，3秒消失")
		ERROR_MESSAGE(11),
		
		@Comment(content = "聊天中的系统信息")
		CHAT_SYSTEM_MESSAGE(12),

		
		;

		public final short index;

		@Override
		public int getIndex() {
			return index;
		}

		public short getShortIndex() {
			return index;
		}

		private SysMessageType(int index) {
			this.index = (short) index;
		}

		private static final List<SysMessageType> values = IndexedEnumUtil.toIndexes(SysMessageType.values());

		public static SysMessageType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}

		public GCSystemMessage genSystemMessage(String content) {
			return new GCSystemMessage(content, this.index);
		}
	}

//	/**
//	 * 聊天框出现的基本系统提示
//	 * 
//	 * @param content
//	 * @return
//	 */
//	public static GCSystemMessage genSystemMessage(String content) {
//		return SysMessageType.SYSTEM_MESSAGE.genSystemMessage(content);
//	}
//
//	/**
//	 * 聊天通告类
//	 * 
//	 * @param content
//	 * @return
//	 */
//	public static GCSystemMessage genChatMessage(String content) {
//		return SysMessageType.CHAT_MESSAGE.genSystemMessage(content);
//	}
//
//	/**
//	 * 帮派通告类
//	 * 
//	 * @param content
//	 * @return
//	 */
//	public static GCSystemMessage genGuildMessage(String content) {
//		return SysMessageType.GUILD_MESSAGE.genSystemMessage(content);
//	}
//
//	/**
//	 * 屏幕中央出现的系统通告,滚屏
//	 * 
//	 * @param content
//	 * @return
//	 */
//	public static GCSystemMessage genNoticeMessage(String content) {
//		return SysMessageType.NOTICE_MESSAGE.genSystemMessage(content);
//	}
//
//	/**
//	 * 弹窗确定
//	 * 
//	 * @param content
//	 * @return
//	 */
//	public static GCSystemMessage genBoxMessage(String content) {
//		return SysMessageType.BOX_MESSAGE.genSystemMessage(content);
//	}
//
//	/**
//	 * 错误提示，3秒消失
//	 * 
//	 * @param content
//	 * @return
//	 */
//	public static GCSystemMessage genErrorMessage(String content) {
//		return SysMessageType.ERROR_MESSAGE.genSystemMessage(content);
//	}
}
