package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.siegedemon.msg.GCOpenSiegedemontaskPanel;
import com.imop.lj.gameserver.siegedemon.msg.GCSiegedemontaskDone;
import com.imop.lj.gameserver.siegedemon.msg.GCSiegedemontaskUpdate;
import com.imop.lj.gameserver.siegedemon.msg.GCSiegedemonAskEnterTeam;
import com.imop.lj.gameserver.siegedemon.msg.GCSiegedemonEnterTeam;

public class RobotSiegedemonClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_OPEN_SIEGEDEMONTASK_PANEL, GCOpenSiegedemontaskPanel.class);
		msgs.put(MessageType.GC_SIEGEDEMONTASK_DONE, GCSiegedemontaskDone.class);
		msgs.put(MessageType.GC_SIEGEDEMONTASK_UPDATE, GCSiegedemontaskUpdate.class);
		msgs.put(MessageType.GC_SIEGEDEMON_ASK_ENTER_TEAM, GCSiegedemonAskEnterTeam.class);
		msgs.put(MessageType.GC_SIEGEDEMON_ENTER_TEAM, GCSiegedemonEnterTeam.class);
		return msgs;
	}
}
