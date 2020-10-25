package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.wizardraid.msg.GCWizardraidLeftTimes;
import com.imop.lj.gameserver.wizardraid.msg.GCWizardraidEnterSingle;
import com.imop.lj.gameserver.wizardraid.msg.GCWizardraidAskEnterTeam;
import com.imop.lj.gameserver.wizardraid.msg.GCWizardraidEnterTeam;
import com.imop.lj.gameserver.wizardraid.msg.GCWizardraidInfo;

public class RobotWizardraidClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_WIZARDRAID_LEFT_TIMES, GCWizardraidLeftTimes.class);
		msgs.put(MessageType.GC_WIZARDRAID_ENTER_SINGLE, GCWizardraidEnterSingle.class);
		msgs.put(MessageType.GC_WIZARDRAID_ASK_ENTER_TEAM, GCWizardraidAskEnterTeam.class);
		msgs.put(MessageType.GC_WIZARDRAID_ENTER_TEAM, GCWizardraidEnterTeam.class);
		msgs.put(MessageType.GC_WIZARDRAID_INFO, GCWizardraidInfo.class);
		return msgs;
	}
}
