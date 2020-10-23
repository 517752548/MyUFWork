package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.plotdungeon.msg.GCPlotDungeonInfo;
import com.imop.lj.gameserver.plotdungeon.msg.GCDailyPlotDungeonInfo;

public class RobotPlotdungeonClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_PLOT_DUNGEON_INFO, GCPlotDungeonInfo.class);
		msgs.put(MessageType.GC_DAILY_PLOT_DUNGEON_INFO, GCDailyPlotDungeonInfo.class);
		return msgs;
	}
}
