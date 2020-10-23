using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 应用于 GCSystemMessageListEvent
/// 属于广播
/// </summary>
public enum SystemMessageListType
{
    ////@Comment,//(content = "无 ")
	NONE,//(0),
		
	//@Comment,//(content = "聊天框出现的基本系统提示 ")
	SYSTEM_MESSAGE,//(1),
		
	//@Comment,//(content = "聊天通告类")
	CHAT_MESSAGE,//(2),
		
	//@Comment,//(content = "屏幕中央出现的跑马灯通告,滚屏")
	NOTICE_MESSAGE,//(3),
		
	//@Comment,//(content = "聊天系统+聊天通告")
	SYSTEM_AND_CHAT_MESSAGE,//(4),
		
	//@Comment,//(content = "聊天系统+跑马灯")
	SYSTEM_AND_NOTICE_MESSAGE,//(5),
		
	//@Comment,//(content = "聊天通告+跑马灯")
	CHAT_AND_NOTICE_MESSAGE,//(6),
		
	//@Comment,//(content = "聊天系统+聊天通告+跑马灯 ")
	SYSTEM_AND_CHAT_AND_NOTICE_MESSAGE,//(7),
		
	//@Comment,//(content = "国家通告")
	COUNTRY_MESSAGE,//(8),
		
	//@Comment,//(content = "帮派通告")
	GUILD_MESSAGE,//(9),
		
	//@Comment,//(content = "弹窗确定")
	BOX_MESSAGE,//(10),
		
	//@Comment,//(content = "错误提示，3秒消失")
	ERROR_MESSAGE,//(11),
		
	//@Comment,//(content = "聊天中的系统信息")
	CHAT_SYSTEM_MESSAGE//(12),

}
/// <summary>
/// 应用于 GCSystemMessageEvent
/// 属于 系统给自己的提示
/// </summary>
public enum SystemMessageType
{
        /** 空 */
		NULL,//(0),

		generic,//(1),
		/** 操作错误提示,直接冒出提示 */
		error,//(2),
		/** 聊天框*/
		dialog,//(3),
		/** 显示中间*/
		important,//(4),
		/** 显示中间，及聊天框 */
		very_important,//(5),
		/** 弹框提示 */
		box,//(6),
		/**商会*/
		commerce//(7);
}