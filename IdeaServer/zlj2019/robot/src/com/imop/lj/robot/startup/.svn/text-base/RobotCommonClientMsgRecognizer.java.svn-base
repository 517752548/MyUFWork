package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.common.msg.GCSystemMessage;
import com.imop.lj.gameserver.common.msg.GCSystemNotice;
import com.imop.lj.gameserver.common.msg.GCShowOptionDlg;
import com.imop.lj.gameserver.common.msg.GCPing;
import com.imop.lj.gameserver.common.msg.GCShowCurrency;
import com.imop.lj.gameserver.common.msg.GCConstantList;
import com.imop.lj.gameserver.common.msg.GCMusicConfigList;
import com.imop.lj.gameserver.common.msg.GCSystemMessageList;
import com.imop.lj.gameserver.common.msg.GCNoticeTipsInfoList;
import com.imop.lj.gameserver.common.msg.GCNoticeTipsInfoAdd;
import com.imop.lj.gameserver.common.msg.GCPopFlag;
import com.imop.lj.gameserver.common.msg.GCOfflineUserBaseInfo;
import com.imop.lj.gameserver.common.msg.GCOfflineUserLeaderInfo;
import com.imop.lj.gameserver.common.msg.GCOfflineUserPetInfo;

public class RobotCommonClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_SYSTEM_MESSAGE, GCSystemMessage.class);
		msgs.put(MessageType.GC_SYSTEM_NOTICE, GCSystemNotice.class);
		msgs.put(MessageType.GC_SHOW_OPTION_DLG, GCShowOptionDlg.class);
		msgs.put(MessageType.GC_PING, GCPing.class);
		msgs.put(MessageType.GC_SHOW_CURRENCY, GCShowCurrency.class);
		msgs.put(MessageType.GC_CONSTANT_LIST, GCConstantList.class);
		msgs.put(MessageType.GC_MUSIC_CONFIG_LIST, GCMusicConfigList.class);
		msgs.put(MessageType.GC_SYSTEM_MESSAGE_LIST, GCSystemMessageList.class);
		msgs.put(MessageType.GC_NOTICE_TIPS_INFO_LIST, GCNoticeTipsInfoList.class);
		msgs.put(MessageType.GC_NOTICE_TIPS_INFO_ADD, GCNoticeTipsInfoAdd.class);
		msgs.put(MessageType.GC_POP_FLAG, GCPopFlag.class);
		msgs.put(MessageType.GC_OFFLINE_USER_BASE_INFO, GCOfflineUserBaseInfo.class);
		msgs.put(MessageType.GC_OFFLINE_USER_LEADER_INFO, GCOfflineUserLeaderInfo.class);
		msgs.put(MessageType.GC_OFFLINE_USER_PET_INFO, GCOfflineUserPetInfo.class);
		return msgs;
	}
}
