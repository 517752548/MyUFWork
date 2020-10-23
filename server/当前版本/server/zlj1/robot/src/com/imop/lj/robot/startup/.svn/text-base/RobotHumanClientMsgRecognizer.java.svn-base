package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.human.msg.GCHumanCdQueueUpdate;
import com.imop.lj.gameserver.human.msg.GCPropertyChangedNumber;
import com.imop.lj.gameserver.human.msg.GCPropertyChangedString;
import com.imop.lj.gameserver.human.msg.GCFuncList;
import com.imop.lj.gameserver.human.msg.GCFuncUpdate;
import com.imop.lj.gameserver.human.msg.GCOfflinerewardInfo;
import com.imop.lj.gameserver.human.msg.GCBuyPowerTips;
import com.imop.lj.gameserver.human.msg.GCChannelExchange;
import com.imop.lj.gameserver.human.msg.GCVipInfo;
import com.imop.lj.gameserver.human.msg.GCBehaviorInfo;
import com.imop.lj.gameserver.human.msg.GCDay7TaskUpdate;
import com.imop.lj.gameserver.human.msg.GCDay7TaskList;
import com.imop.lj.gameserver.human.msg.GCLoginDays;
import com.imop.lj.gameserver.human.msg.GCCreateTime;

public class RobotHumanClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_HUMAN_CD_QUEUE_UPDATE, GCHumanCdQueueUpdate.class);
		msgs.put(MessageType.GC_PROPERTY_CHANGED_NUMBER, GCPropertyChangedNumber.class);
		msgs.put(MessageType.GC_PROPERTY_CHANGED_STRING, GCPropertyChangedString.class);
		msgs.put(MessageType.GC_FUNC_LIST, GCFuncList.class);
		msgs.put(MessageType.GC_FUNC_UPDATE, GCFuncUpdate.class);
		msgs.put(MessageType.GC_OFFLINEREWARD_INFO, GCOfflinerewardInfo.class);
		msgs.put(MessageType.GC_BUY_POWER_TIPS, GCBuyPowerTips.class);
		msgs.put(MessageType.GC_CHANNEL_EXCHANGE, GCChannelExchange.class);
		msgs.put(MessageType.GC_VIP_INFO, GCVipInfo.class);
		msgs.put(MessageType.GC_BEHAVIOR_INFO, GCBehaviorInfo.class);
		msgs.put(MessageType.GC_DAY7_TASK_UPDATE, GCDay7TaskUpdate.class);
		msgs.put(MessageType.GC_DAY7_TASK_LIST, GCDay7TaskList.class);
		msgs.put(MessageType.GC_LOGIN_DAYS, GCLoginDays.class);
		msgs.put(MessageType.GC_CREATE_TIME, GCCreateTime.class);
		return msgs;
	}
}
