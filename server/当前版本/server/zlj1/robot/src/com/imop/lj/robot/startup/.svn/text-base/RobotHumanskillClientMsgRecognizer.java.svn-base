package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.humanskill.msg.GCHsMainChange;
import com.imop.lj.gameserver.humanskill.msg.GCHsMainSkillUpgrade;
import com.imop.lj.gameserver.humanskill.msg.GCHsSubSkillUpgrade;
import com.imop.lj.gameserver.humanskill.msg.GCHsOpenPanel;

public class RobotHumanskillClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_HS_MAIN_CHANGE, GCHsMainChange.class);
		msgs.put(MessageType.GC_HS_MAIN_SKILL_UPGRADE, GCHsMainSkillUpgrade.class);
		msgs.put(MessageType.GC_HS_SUB_SKILL_UPGRADE, GCHsSubSkillUpgrade.class);
		msgs.put(MessageType.GC_HS_OPEN_PANEL, GCHsOpenPanel.class);
		return msgs;
	}
}
