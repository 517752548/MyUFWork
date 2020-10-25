package com.imop.lj.gameserver.treasuremap.msg;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;

/**
 *  Generated by MessageCodeGenerator,don't modify please.
 *  Need to register in<code>GameMessageRecognizer#init</code>
 */
public class TreasuremapMsgMappingProvider implements MessageMappingProvider {

	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> map = new HashMap<Short, Class<?>>();
		map.put(MessageType.CG_TREASUREMAP_ACCEPT, CGTreasuremapAccept.class);
		map.put(MessageType.CG_GIVE_UP_TREASUREMAP, CGGiveUpTreasuremap.class);
		map.put(MessageType.CG_FINISH_TREASUREMAP, CGFinishTreasuremap.class);
		return map;
	}

}