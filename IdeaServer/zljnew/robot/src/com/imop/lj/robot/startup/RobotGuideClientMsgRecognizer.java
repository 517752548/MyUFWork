package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.guide.msg.GCShowGuideInfo;
import com.imop.lj.gameserver.guide.msg.GCFuncHasGuide;
import com.imop.lj.gameserver.guide.msg.GCFuncHasGuideList;
import com.imop.lj.gameserver.guide.msg.GCFinishedGuideListByFunc;
import com.imop.lj.gameserver.guide.msg.GCFinishedGuideByFunc;

public class RobotGuideClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_SHOW_GUIDE_INFO, GCShowGuideInfo.class);
		msgs.put(MessageType.GC_FUNC_HAS_GUIDE, GCFuncHasGuide.class);
		msgs.put(MessageType.GC_FUNC_HAS_GUIDE_LIST, GCFuncHasGuideList.class);
		msgs.put(MessageType.GC_FINISHED_GUIDE_LIST_BY_FUNC, GCFinishedGuideListByFunc.class);
		msgs.put(MessageType.GC_FINISHED_GUIDE_BY_FUNC, GCFinishedGuideByFunc.class);
		return msgs;
	}
}
