package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.corps.msg.GCCorpsListPanel;
import com.imop.lj.gameserver.corps.msg.GCUpdateSingleCorps;
import com.imop.lj.gameserver.corps.msg.GCOpenCorpsPanel;
import com.imop.lj.gameserver.corps.msg.GCOpenCorpsMemberList;
import com.imop.lj.gameserver.corps.msg.GCCorpsStorage;
import com.imop.lj.gameserver.corps.msg.GCStorageItemList;
import com.imop.lj.gameserver.corps.msg.GCCorpsEventNotice;
import com.imop.lj.gameserver.corps.msg.GCCorpsMemberInfo;
import com.imop.lj.gameserver.corps.msg.GCCorpsChangedMemberInfo;
import com.imop.lj.gameserver.corps.msg.GCCorpswarInfo;
import com.imop.lj.gameserver.corps.msg.GCCorpswarRankList;
import com.imop.lj.gameserver.corps.msg.GCOpenCorpsBuildingPanel;
import com.imop.lj.gameserver.corps.msg.GCUpgradeCorps;
import com.imop.lj.gameserver.corps.msg.GCDegradeCorps;
import com.imop.lj.gameserver.corps.msg.GCOpenCorpsBenifitPanel;
import com.imop.lj.gameserver.corps.msg.GCGetBenifit;
import com.imop.lj.gameserver.corps.msg.GCOpenCorpsCultivatePanel;
import com.imop.lj.gameserver.corps.msg.GCCultivateSkill;
import com.imop.lj.gameserver.corps.msg.GCOpenCorpsAssistPanel;
import com.imop.lj.gameserver.corps.msg.GCLearnAssistSkill;
import com.imop.lj.gameserver.corps.msg.GCMakeItem;
import com.imop.lj.gameserver.corps.msg.GCOpenCorpsRedEnvelopePanel;
import com.imop.lj.gameserver.corps.msg.GCCreateCorpsRedEnvelope;
import com.imop.lj.gameserver.corps.msg.GCGotCorpsRedEnvelope;
import com.imop.lj.gameserver.corps.msg.GCOpenAllocatePanel;

public class RobotCorpsClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_CORPS_LIST_PANEL, GCCorpsListPanel.class);
		msgs.put(MessageType.GC_UPDATE_SINGLE_CORPS, GCUpdateSingleCorps.class);
		msgs.put(MessageType.GC_OPEN_CORPS_PANEL, GCOpenCorpsPanel.class);
		msgs.put(MessageType.GC_OPEN_CORPS_MEMBER_LIST, GCOpenCorpsMemberList.class);
		msgs.put(MessageType.GC_CORPS_STORAGE, GCCorpsStorage.class);
		msgs.put(MessageType.GC_STORAGE_ITEM_LIST, GCStorageItemList.class);
		msgs.put(MessageType.GC_CORPS_EVENT_NOTICE, GCCorpsEventNotice.class);
		msgs.put(MessageType.GC_CORPS_MEMBER_INFO, GCCorpsMemberInfo.class);
		msgs.put(MessageType.GC_CORPS_CHANGED_MEMBER_INFO, GCCorpsChangedMemberInfo.class);
		msgs.put(MessageType.GC_CORPSWAR_INFO, GCCorpswarInfo.class);
		msgs.put(MessageType.GC_CORPSWAR_RANK_LIST, GCCorpswarRankList.class);
		msgs.put(MessageType.GC_OPEN_CORPS_BUILDING_PANEL, GCOpenCorpsBuildingPanel.class);
		msgs.put(MessageType.GC_UPGRADE_CORPS, GCUpgradeCorps.class);
		msgs.put(MessageType.GC_DEGRADE_CORPS, GCDegradeCorps.class);
		msgs.put(MessageType.GC_OPEN_CORPS_BENIFIT_PANEL, GCOpenCorpsBenifitPanel.class);
		msgs.put(MessageType.GC_GET_BENIFIT, GCGetBenifit.class);
		msgs.put(MessageType.GC_OPEN_CORPS_CULTIVATE_PANEL, GCOpenCorpsCultivatePanel.class);
		msgs.put(MessageType.GC_CULTIVATE_SKILL, GCCultivateSkill.class);
		msgs.put(MessageType.GC_OPEN_CORPS_ASSIST_PANEL, GCOpenCorpsAssistPanel.class);
		msgs.put(MessageType.GC_LEARN_ASSIST_SKILL, GCLearnAssistSkill.class);
		msgs.put(MessageType.GC_MAKE_ITEM, GCMakeItem.class);
		msgs.put(MessageType.GC_OPEN_CORPS_RED_ENVELOPE_PANEL, GCOpenCorpsRedEnvelopePanel.class);
		msgs.put(MessageType.GC_CREATE_CORPS_RED_ENVELOPE, GCCreateCorpsRedEnvelope.class);
		msgs.put(MessageType.GC_GOT_CORPS_RED_ENVELOPE, GCGotCorpsRedEnvelope.class);
		msgs.put(MessageType.GC_OPEN_ALLOCATE_PANEL, GCOpenAllocatePanel.class);
		return msgs;
	}
}
