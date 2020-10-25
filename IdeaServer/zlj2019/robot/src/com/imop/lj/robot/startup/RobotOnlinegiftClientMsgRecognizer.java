package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.onlinegift.msg.GCDaliyGiftListApply;
import com.imop.lj.gameserver.onlinegift.msg.GCDaliyGiftPannelApply;
import com.imop.lj.gameserver.onlinegift.msg.GCDaliyGiftSign;
import com.imop.lj.gameserver.onlinegift.msg.GCDaliyGiftRetroactive;
import com.imop.lj.gameserver.onlinegift.msg.GCOnlinegiftInfo;
import com.imop.lj.gameserver.onlinegift.msg.GCSpecOnlineGiftShowInfo;

public class RobotOnlinegiftClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_DALIY_GIFT_LIST_APPLY, GCDaliyGiftListApply.class);
		msgs.put(MessageType.GC_DALIY_GIFT_PANNEL_APPLY, GCDaliyGiftPannelApply.class);
		msgs.put(MessageType.GC_DALIY_GIFT_SIGN, GCDaliyGiftSign.class);
		msgs.put(MessageType.GC_DALIY_GIFT_RETROACTIVE, GCDaliyGiftRetroactive.class);
		msgs.put(MessageType.GC_ONLINEGIFT_INFO, GCOnlinegiftInfo.class);
		msgs.put(MessageType.GC_SPEC_ONLINE_GIFT_SHOW_INFO, GCSpecOnlineGiftShowInfo.class);
		return msgs;
	}
}
