package com.imop.lj.gameserver.humanskill.msg;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;

/**
 *  Generated by MessageCodeGenerator,don't modify please.
 *  Need to register in<code>GameMessageRecognizer#init</code>
 */
public class HumanskillMsgMappingProvider implements MessageMappingProvider {

	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> map = new HashMap<Short, Class<?>>();
		map.put(MessageType.CG_HS_MAIN_SKILL_UPGRADE, CGHsMainSkillUpgrade.class);
		map.put(MessageType.CG_HS_SUB_SKILL_UPGRADE, CGHsSubSkillUpgrade.class);
		map.put(MessageType.CG_HS_SUB_SKILL_ADD_PROFICIENCY, CGHsSubSkillAddProficiency.class);
		map.put(MessageType.CG_HS_OPEN_PANEL, CGHsOpenPanel.class);
		return map;
	}

}