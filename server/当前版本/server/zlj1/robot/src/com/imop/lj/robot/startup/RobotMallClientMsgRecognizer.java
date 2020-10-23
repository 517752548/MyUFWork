package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.mall.msg.GCMallCatalogInfoList;
import com.imop.lj.gameserver.mall.msg.GCMallItemList;
import com.imop.lj.gameserver.mall.msg.GCTimeLimitItemList;
import com.imop.lj.gameserver.mall.msg.GCNextQueueCd;
import com.imop.lj.gameserver.mall.msg.GCBuyItemPanelOperate;

public class RobotMallClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_MALL_CATALOG_INFO_LIST, GCMallCatalogInfoList.class);
		msgs.put(MessageType.GC_MALL_ITEM_LIST, GCMallItemList.class);
		msgs.put(MessageType.GC_TIME_LIMIT_ITEM_LIST, GCTimeLimitItemList.class);
		msgs.put(MessageType.GC_NEXT_QUEUE_CD, GCNextQueueCd.class);
		msgs.put(MessageType.GC_BUY_ITEM_PANEL_OPERATE, GCBuyItemPanelOperate.class);
		return msgs;
	}
}
