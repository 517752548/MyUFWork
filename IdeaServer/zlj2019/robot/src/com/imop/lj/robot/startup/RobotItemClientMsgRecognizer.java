package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.item.msg.GCBagUpdate;
import com.imop.lj.gameserver.item.msg.GCItemUpdate;
import com.imop.lj.gameserver.item.msg.GCRemoveItem;
import com.imop.lj.gameserver.item.msg.GCSwapItem;
import com.imop.lj.gameserver.item.msg.GCResetCapacity;
import com.imop.lj.gameserver.item.msg.GCUsePoolAddResult;
import com.imop.lj.gameserver.item.msg.GCShowItem;
import com.imop.lj.gameserver.item.msg.GCItemUpdateList;

public class RobotItemClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_BAG_UPDATE, GCBagUpdate.class);
		msgs.put(MessageType.GC_ITEM_UPDATE, GCItemUpdate.class);
		msgs.put(MessageType.GC_REMOVE_ITEM, GCRemoveItem.class);
		msgs.put(MessageType.GC_SWAP_ITEM, GCSwapItem.class);
		msgs.put(MessageType.GC_RESET_CAPACITY, GCResetCapacity.class);
		msgs.put(MessageType.GC_USE_POOL_ADD_RESULT, GCUsePoolAddResult.class);
		msgs.put(MessageType.GC_SHOW_ITEM, GCShowItem.class);
		msgs.put(MessageType.GC_ITEM_UPDATE_LIST, GCItemUpdateList.class);
		return msgs;
	}
}
