package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.trade.msg.GCTradeBoothinfo;
import com.imop.lj.gameserver.trade.msg.GCTradeCommodityList;
import com.imop.lj.gameserver.trade.msg.GCTradeSellResult;

public class RobotTradeClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_TRADE_BOOTHINFO, GCTradeBoothinfo.class);
		msgs.put(MessageType.GC_TRADE_COMMODITY_LIST, GCTradeCommodityList.class);
		msgs.put(MessageType.GC_TRADE_SELL_RESULT, GCTradeSellResult.class);
		return msgs;
	}
}
