package com.imop.lj.common.constants;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;


/**
 * 系统消息显示类型
 * 
 */
public interface SysMsgShowTypes {
//	/** 普通消息类 */
//	short generic = 1;
//	/** 重要消息类 屏幕中间*/
//	short important = 2;
//	/** 操作错误提示,直接冒出提示 */
//	short error = 3;
//	/** 聊天框*/
//	short dialog = 4;
//	/** 弹框提示 */
//	short box = 5;
//	/** 发送邮件信息 */
//	short email = 7;
//	/** 消息对话框  */
//	short dialog = 8;
	/**
	 * 推送信息大类
	 * @author xinkun.wang
	 *
	 */
	public static enum MessageType implements IndexedEnum {
		/** 空 */
		NULL(0),
		generic(1),
		/** 操作错误提示,直接冒出提示 */
		error(2),
		/** 聊天框*/
		dialog(3),
		/** 显示中间*/
		important(4),
		/** 显示中间，及聊天框 */
		very_important(5),
		/** 弹框提示 */
		box(6),
		/**商会*/
		commerce(7);
//		/** 屏幕上方浮动框 */
//		SCREEN_TOP(7),
//		/** 聊天窗口及屏幕上方浮动框 */
//		DIALOG_SCREEN_TOP(8),
		
		;
		
		public final short index;

		@Override
		public int getIndex() {
			return index;
		}
		public short getShortIndex()
		{
			return index;
		}
		private MessageType(int index) {
			this.index = (short) index;
		}
		
		
		private static final List<MessageType> values = IndexedEnumUtil
				.toIndexes(MessageType.values());

		public static MessageType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
}
