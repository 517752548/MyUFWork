package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.tower.msg.GCTowerInfo;
import com.imop.lj.gameserver.tower.msg.GCOpenDoubleStatus;
import com.imop.lj.gameserver.tower.msg.GCWatchFirstKillerReplay;
import com.imop.lj.gameserver.tower.msg.GCWatchBestKillerReplay;
import com.imop.lj.gameserver.tower.msg.GCTowerReward;
import com.imop.lj.gameserver.tower.msg.GCGuaji;
import com.imop.lj.gameserver.tower.msg.GCStopGuaji;

public class RobotTowerClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_TOWER_INFO, GCTowerInfo.class);
		msgs.put(MessageType.GC_OPEN_DOUBLE_STATUS, GCOpenDoubleStatus.class);
		msgs.put(MessageType.GC_WATCH_FIRST_KILLER_REPLAY, GCWatchFirstKillerReplay.class);
		msgs.put(MessageType.GC_WATCH_BEST_KILLER_REPLAY, GCWatchBestKillerReplay.class);
		msgs.put(MessageType.GC_TOWER_REWARD, GCTowerReward.class);
		msgs.put(MessageType.GC_GUAJI, GCGuaji.class);
		msgs.put(MessageType.GC_STOP_GUAJI, GCStopGuaji.class);
		return msgs;
	}
}
