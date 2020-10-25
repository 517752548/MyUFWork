package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.lifeskill.msg.GCUseLifeSkill;
import com.imop.lj.gameserver.lifeskill.msg.GCLifeSkillUpgrade;
import com.imop.lj.gameserver.lifeskill.msg.GCLifeSkillInfo;

public class RobotLifeskillClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_USE_LIFE_SKILL, GCUseLifeSkill.class);
		msgs.put(MessageType.GC_LIFE_SKILL_UPGRADE, GCLifeSkillUpgrade.class);
		msgs.put(MessageType.GC_LIFE_SKILL_INFO, GCLifeSkillInfo.class);
		return msgs;
	}
}
