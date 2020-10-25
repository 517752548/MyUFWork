package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.equip.msg.GCEqpCraft;
import com.imop.lj.gameserver.equip.msg.GCEqpCraftInfo;
import com.imop.lj.gameserver.equip.msg.GCEqpUpstar;
import com.imop.lj.gameserver.equip.msg.GCEqpGemTakedown;
import com.imop.lj.gameserver.equip.msg.GCEqpGemSet;
import com.imop.lj.gameserver.equip.msg.GCEqpGemSynthesis;
import com.imop.lj.gameserver.equip.msg.GCEqpRecast;
import com.imop.lj.gameserver.equip.msg.GCEqpDecompose;
import com.imop.lj.gameserver.equip.msg.GCEqpHole;

public class RobotEquipClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_EQP_CRAFT, GCEqpCraft.class);
		msgs.put(MessageType.GC_EQP_CRAFT_INFO, GCEqpCraftInfo.class);
		msgs.put(MessageType.GC_EQP_UPSTAR, GCEqpUpstar.class);
		msgs.put(MessageType.GC_EQP_GEM_TAKEDOWN, GCEqpGemTakedown.class);
		msgs.put(MessageType.GC_EQP_GEM_SET, GCEqpGemSet.class);
		msgs.put(MessageType.GC_EQP_GEM_SYNTHESIS, GCEqpGemSynthesis.class);
		msgs.put(MessageType.GC_EQP_RECAST, GCEqpRecast.class);
		msgs.put(MessageType.GC_EQP_DECOMPOSE, GCEqpDecompose.class);
		msgs.put(MessageType.GC_EQP_HOLE, GCEqpHole.class);
		return msgs;
	}
}
