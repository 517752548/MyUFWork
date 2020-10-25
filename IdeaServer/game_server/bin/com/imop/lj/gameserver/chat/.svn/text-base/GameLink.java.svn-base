package com.imop.lj.gameserver.chat;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.gameserver.chat.msg.GCChatMsg;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;

public class GameLink {
	
	private static String genItemLink(String itemId,String itemName,String color){
		String linkContent = Globals.getLangService().readSysLang(LangConstants.ITEM_LINK,itemId, itemName,color);
		return linkContent;
	}
	
	/**
	 * 生成物品链接
	 * @description: 
	 * @author: kai.shi 
	 * @param item
	 * @return
	 */
	public static String genItemLink(Item item){
		saveItemCache(item);
		return genItemLink(item.getDbId(), item.getName(),item.getTemplate().getRarity().getColor());
	}
	
	/** 
	 * 添加到物品缓存
	 * @description: 
	 * @author: kai.shi 
	 * @param item
	 */ 
	private static void saveItemCache(Item item) {
		Globals.getItemService().addItemInfoCache(item);
	}

	/**
	 * 之前判断过item是否为空
	 */
	public static GCChatMsg genItemLinkMsg(Item item,Human human){
		GCChatMsg gcChatMsg = Globals.getChatService().buildGCChatMsg(human, SharedConstants.CHAT_SCOPE_WORLD, genItemLink(item), 0);
		return gcChatMsg;
	}
}
